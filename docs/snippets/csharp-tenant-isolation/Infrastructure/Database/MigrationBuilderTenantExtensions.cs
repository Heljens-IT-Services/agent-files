namespace Example.Infrastructure.Database;

/// <summary>
/// Aktiviert Row-Level-Security in Migrationen. Mandantenbezogene Tabellen vergleichen
/// <c>tenant_id</c> mit <c>app.tenant_key</c>; die Tabelle <c>tenants</c> selbst gibt nur die Zeile
/// frei, deren <c>business_id</c> <c>app.tenant_id</c> entspricht. Ist eine Variable leer, sind keine
/// Zeilen sichtbar oder schreibbar.
/// </summary>
public static class MigrationBuilderTenantExtensions
{
    public static void EnableTenantRowLevelSecurity(this MigrationBuilder migrationBuilder, string table) =>
        EnablePolicy(migrationBuilder, table, "tenant_id = NULLIF(current_setting('app.tenant_key', true), '')::int");

    public static void EnableTenantTableRowLevelSecurity(this MigrationBuilder migrationBuilder) =>
        EnablePolicy(migrationBuilder, "tenants", "business_id = NULLIF(current_setting('app.tenant_id', true), '')::uuid");

    public static void DisableTenantRowLevelSecurity(this MigrationBuilder migrationBuilder, string table)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        ArgumentException.ThrowIfNullOrWhiteSpace(table);

        migrationBuilder.Sql($"DROP POLICY IF EXISTS rls_{table}_tenant ON {table};");
        migrationBuilder.Sql($"ALTER TABLE {table} NO FORCE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"ALTER TABLE {table} DISABLE ROW LEVEL SECURITY;");
    }

    private static void EnablePolicy(MigrationBuilder migrationBuilder, string table, string condition)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        ArgumentException.ThrowIfNullOrWhiteSpace(table);

        migrationBuilder.Sql($"ALTER TABLE {table} ENABLE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"ALTER TABLE {table} FORCE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"CREATE POLICY rls_{table}_tenant ON {table} USING ({condition}) WITH CHECK ({condition});");
    }
}
