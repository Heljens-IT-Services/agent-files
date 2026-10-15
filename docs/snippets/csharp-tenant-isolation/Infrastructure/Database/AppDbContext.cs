namespace Example.Infrastructure.Database;

/// <summary>
/// Ausschnitt des Anwendungs-Contexts mit der ersten Mandantensperre: jede Entität, die
/// <see cref="ITenantScoped"/> implementiert, erhält automatisch einen globalen Query-Filter.
/// </summary>
public sealed class AppDbContext(DbContextOptions<AppDbContext> options, ITenantContext tenantContext) : DbContext(options)
{
    /// <summary>
    /// Der vom Query-Filter gelesene Mandant. Der Filter verweist auf diese Eigenschaft des Contexts
    /// statt auf <see cref="ITenantContext"/> direkt: EF Core cacht das Modell je Context-Typ, wertet
    /// Mitglieder des Contexts aber je Abfrage gegen die ausführende Instanz aus. Ohne Mandant liefert
    /// der Filter <see cref="Guid.Empty"/> und damit keine Zeilen.
    /// </summary>
    internal Guid CurrentTenantId => tenantContext.TryGetTenantId(out var tenantId) ? tenantId : Guid.Empty;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        ApplyTenantQueryFilters(modelBuilder);
    }

    private void ApplyTenantQueryFilters(ModelBuilder modelBuilder)
    {
        var tenantScopedTypes = modelBuilder.Model.GetEntityTypes()
            .Where(entityType => entityType.BaseType is null)
            .Select(entityType => entityType.ClrType)
            .Where(clrType => typeof(ITenantScoped).IsAssignableFrom(clrType));

        foreach (var clrType in tenantScopedTypes)
        {
            // Entspricht entity => entity.TenantId == this.CurrentTenantId, generisch über Expression-Bäume.
            var context = Expression.Constant(this, typeof(AppDbContext));
            var currentTenantId = Expression.Property(context, nameof(CurrentTenantId));
            var entity = Expression.Parameter(clrType, "entity");
            var entityTenantId = Expression.Property(entity, nameof(ITenantScoped.TenantId));

            modelBuilder.Entity(clrType).HasQueryFilter(
                Expression.Lambda(Expression.Equal(entityTenantId, currentTenantId), entity));
        }
    }
}
