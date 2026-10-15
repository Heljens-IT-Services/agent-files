namespace Example.Infrastructure.Database;

/// <summary>
/// Aktiviert Row-Level-Security für mandantenbezogene Tabellen in Migrationen. Die Policy vergleicht
/// <c>tenant_id</c> mit der vom <see cref="TenantTransactionInterceptor"/> gesetzten
/// Sitzungsvariable; ist sie leer, sind keine Zeilen sichtbar oder schreibbar.
/// </summary>
public static class MigrationBuilderTenantExtensions
{
    public static void EnableTenantRowLevelSecurity(this MigrationBuilder migrationBuilder, string table)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        ArgumentException.ThrowIfNullOrWhiteSpace(table);

        migrationBuilder.Sql($"ALTER TABLE {table} ENABLE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"ALTER TABLE {table} FORCE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"""
            CREATE POLICY rls_{table}_tenant ON {table}
                USING (tenant_id = NULLIF(current_setting('app.tenant_id', true), '')::uuid)
                WITH CHECK (tenant_id = NULLIF(current_setting('app.tenant_id', true), '')::uuid);
            """);
    }

    public static void DisableTenantRowLevelSecurity(this MigrationBuilder migrationBuilder, string table)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        ArgumentException.ThrowIfNullOrWhiteSpace(table);

        migrationBuilder.Sql($"DROP POLICY IF EXISTS rls_{table}_tenant ON {table};");
        migrationBuilder.Sql($"ALTER TABLE {table} NO FORCE ROW LEVEL SECURITY;");
        migrationBuilder.Sql($"ALTER TABLE {table} DISABLE ROW LEVEL SECURITY;");
    }
}
