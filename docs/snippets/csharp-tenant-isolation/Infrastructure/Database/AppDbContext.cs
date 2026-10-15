namespace Example.Infrastructure.Database;

/// <summary>
/// Ausschnitt des Anwendungs-Contexts mit der ersten Mandantensperre: jede Entität, die
/// <see cref="ITenantScoped"/> implementiert, erhält automatisch einen globalen Query-Filter und
/// beim Anlegen den Mandanten des aktuellen Scopes.
/// </summary>
public sealed class AppDbContext(DbContextOptions<AppDbContext> options, ITenantContext tenantContext) : DbContext(options)
{
    /// <summary>
    /// Der vom Query-Filter gelesene interne Mandantenschlüssel. Der Filter verweist auf diese
    /// Eigenschaft des Contexts statt auf <see cref="ITenantContext"/> direkt: EF Core cacht das
    /// Modell je Context-Typ, wertet Mitglieder des Contexts aber je Abfrage gegen die ausführende
    /// Instanz aus. Ohne aufgelösten Schlüssel liefert der Filter <c>0</c> und damit keine Zeilen.
    /// </summary>
    internal int CurrentTenantKey => tenantContext.TryGetTenantKey(out var tenantKey) ? tenantKey : 0;

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        StampTenantOnNewEntities();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        StampTenantOnNewEntities();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        ApplyTenantQueryFilters(modelBuilder);
    }

    /// <summary>
    /// Setzt <see cref="ITenantScoped.TenantId"/> neuer Entitäten auf den aktuellen Mandanten und
    /// verhindert, dass bestehende Entitäten den Mandanten wechseln. Damit hängt der Mandant einer
    /// Zeile nie von Repository- oder Aufrufercode ab.
    /// </summary>
    private void StampTenantOnNewEntities()
    {
        foreach (var entry in ChangeTracker.Entries<ITenantScoped>())
        {
            var tenantIdProperty = entry.Property(nameof(ITenantScoped.TenantId));
            if (entry.State == EntityState.Added)
            {
                tenantIdProperty.CurrentValue = tenantContext.TenantKey;
            }
            else if (entry.State == EntityState.Modified && tenantIdProperty.IsModified)
            {
                throw new InvalidOperationException($"The tenant of an existing {entry.Metadata.DisplayName()} must not change.");
            }
        }
    }

    private void ApplyTenantQueryFilters(ModelBuilder modelBuilder)
    {
        var tenantScopedTypes = modelBuilder.Model.GetEntityTypes()
            .Where(entityType => entityType.BaseType is null)
            .Select(entityType => entityType.ClrType)
            .Where(clrType => typeof(ITenantScoped).IsAssignableFrom(clrType));

        foreach (var clrType in tenantScopedTypes)
        {
            // Entspricht entity => entity.TenantId == this.CurrentTenantKey, generisch über Expression-Bäume.
            var context = Expression.Constant(this, typeof(AppDbContext));
            var currentTenantKey = Expression.Property(context, nameof(CurrentTenantKey));
            var entity = Expression.Parameter(clrType, "entity");
            var entityTenantId = Expression.Property(entity, nameof(ITenantScoped.TenantId));

            modelBuilder.Entity(clrType).HasQueryFilter(
                Expression.Lambda(Expression.Equal(entityTenantId, currentTenantKey), entity));
        }
    }
}
