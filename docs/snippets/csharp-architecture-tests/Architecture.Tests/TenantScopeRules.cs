namespace Example.Architecture.Tests;

/// <summary>
/// Prüft die Mandantentrennung: jede Entität ist mandantenbezogen oder benannt ausgenommen, der
/// Query-Filter wird nur in <c>Infrastructure</c> umgangen, und die ausdrückliche Mandantenzuweisung
/// bleibt auf eine Allowlist beschränkt. Ausnahmen werden sichtbar in den Listen ergänzt, nie durch
/// Aufweichen der Regel.
/// </summary>
[Trait("Category", "Architecture")]
public sealed class TenantScopeRules
{
    private static readonly string[] EntitiesExemptFromTenantScoping =
    [
        "Tenant", // Die Mandantentabelle selbst; geschützt über ihre eigene Policy.
    ];

    private static readonly string[] TenantFilterBypassPatterns =
        ["IgnoreQueryFilters", "FromSqlRaw", "ExecuteSqlRaw", "ExecuteSqlInterpolated"];

    private static readonly string[] FilesAllowedToUseTenantAssignment =
    [
        "ITenantAssignment.cs",
        "TenantContext.cs",
        "TenantTransactionInterceptor.cs",
        "WorkerTenantScope.cs",
        "Module.cs",
    ];

    [Fact]
    public void Every_entity_is_tenant_scoped_unless_exempt()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql("Host=localhost;Database=archtest").Options;
        using var context = new AppDbContext(options, new NoTenantContext());

        var violations = context.Model.GetEntityTypes()
            .Select(entityType => entityType.ClrType)
            .Where(clrType => !EntitiesExemptFromTenantScoping.Contains(clrType.Name, StringComparer.Ordinal))
            .Where(clrType => !typeof(ITenantScoped).IsAssignableFrom(clrType))
            .Select(clrType => clrType.Name);

        violations.Should().BeEmpty("jede Entität außerhalb der Ausnahmeliste muss ITenantScoped implementieren");
    }

    [Fact]
    public void Only_infrastructure_bypasses_the_tenant_query_filter()
    {
        var infrastructureDirectory = Path.Combine(ArchitectureModel.SourceDirectory, "Infrastructure") + Path.DirectorySeparatorChar;

        var violations = SourceFiles()
            .Where(file => !file.StartsWith(infrastructureDirectory, StringComparison.Ordinal))
            .SelectMany(file => TenantFilterBypassPatterns
                .Where(pattern => File.ReadAllText(file).Contains(pattern, StringComparison.Ordinal))
                .Select(pattern => $"{file}: {pattern}"));

        violations.Should().BeEmpty("nur Infrastructure darf den Mandantenfilter umgehen");
    }

    [Fact]
    public void Only_allowlisted_files_use_tenant_assignment()
    {
        var referencingFiles = SourceFiles()
            .Where(file => File.ReadAllText(file).Contains("ITenantAssignment", StringComparison.Ordinal))
            .Select(Path.GetFileName)
            .Where(fileName => !FilesAllowedToUseTenantAssignment.Contains(fileName, StringComparer.Ordinal));

        referencingFiles.Should().BeEmpty("jede Verwendung von ITenantAssignment muss sichtbar in der Allowlist stehen");
    }

    private static List<string> SourceFiles()
    {
        var files = Directory.GetFiles(ArchitectureModel.SourceDirectory, "*.cs", SearchOption.AllDirectories)
            .Where(file => !file.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}", StringComparison.Ordinal))
            .Where(file => !file.Contains($"{Path.DirectorySeparatorChar}Migrations{Path.DirectorySeparatorChar}", StringComparison.Ordinal))
            .ToList();

        files.Should().NotBeEmpty("die Regel braucht Quelldateien, gegen die sie prüft");
        return files;
    }

    private sealed class NoTenantContext : ITenantContext
    {
        public Guid TenantId => Guid.Empty;

        public int TenantKey => 0;

        public bool TryGetTenantId(out Guid tenantId)
        {
            tenantId = Guid.Empty;
            return false;
        }

        public bool TryGetTenantKey(out int tenantKey)
        {
            tenantKey = 0;
            return false;
        }
    }
}
