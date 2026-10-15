# Snippet: C# Tenant Isolation

Stand: 2026-10-15

## Zweck

Doppelte Mandantentrennung für C#-/.NET-Backends mit EF Core und PostgreSQL: ein globaler EF-Query-Filter als erste Sperre und Row-Level-Security in der Datenbank als zweite Sperre. Der Mandant stammt ausschließlich aus dem Zugriffstoken oder einer ausdrücklich erlaubten Zuweisung; nach außen trägt er seine Business-Id, intern den Integer-Schlüssel `tenants.id`.

## Verwenden

- Wenn eine Anwendung Daten mehrerer Mandanten in einer gemeinsamen Datenbank hält.
- Wenn eine mandantenbezogene Entität, Tabelle, Migration oder ein Hintergrundjob über Mandantendaten entsteht.
- Nicht verwenden bei einer Datenbank je Mandant oder bei Anwendungen ohne Mandantenbezug.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [ITenantContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Core/Tenants/ITenantContext.cs) | `Core` | Business-Id und interner Schlüssel des aktuellen Mandanten. |
| [ITenantAssignment.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Core/Tenants/ITenantAssignment.cs) | `Core` | Ausdrückliche Zuweisung für Interceptor, Jobs und Mandantenanlage. |
| [ITenantScoped.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Tenants/ITenantScoped.cs) | `Infrastructure` | Marker für mandantenbezogene Entitäten. |
| [TenantContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Tenants/TenantContext.cs) | `Infrastructure` | Liest den Claim `tenant_id`; Zuweisung hat Vorrang. |
| [AppDbContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/AppDbContext.cs) | `Infrastructure` | Globaler Query-Filter und automatisches Setzen des Mandanten beim Anlegen. |
| [TenantTransactionInterceptor.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/TenantTransactionInterceptor.cs) | `Infrastructure` | Setzt `app.tenant_id` und `app.tenant_key` je Transaktion für RLS. |
| [MigrationBuilderTenantExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/MigrationBuilderTenantExtensions.cs) | `Infrastructure` | Aktiviert und entfernt RLS-Policies in Migrationen. |
| [WorkerTenantScope.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Worker/Tenancy/WorkerTenantScope.cs) | `Worker` | Mandanten-Scope für Hintergrundjobs. |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Infrastructure`: `System.Data.Common`, `System.Globalization`, `System.Linq.Expressions`, `Microsoft.AspNetCore.Http`, `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Diagnostics`, `Microsoft.EntityFrameworkCore.Migrations`, `<Name>.Core.Tenants`, `<Name>.Infrastructure.Tenants`
- `Worker`: `Microsoft.Extensions.DependencyInjection`, `<Name>.Core.Tenants`

Registrierung in `AddInfrastructure(...)`:

```csharp
services.AddHttpContextAccessor();
services.AddScoped<TenantContext>();
services.AddScoped<ITenantContext>(serviceProvider => serviceProvider.GetRequiredService<TenantContext>());
services.AddScoped<ITenantAssignment>(serviceProvider => serviceProvider.GetRequiredService<TenantContext>());

// Scoped, damit Context und Interceptor den TenantContext des aktuellen Scopes erhalten.
services.AddDbContextFactory<AppDbContext>(
    (serviceProvider, options) => options
        .UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(new TenantTransactionInterceptor(
            serviceProvider.GetRequiredService<ITenantContext>(),
            serviceProvider.GetRequiredService<ITenantAssignment>())),
    ServiceLifetime.Scoped);
```

## Regeln

### Mandantenquelle

[MUST] Die Business-Id des Mandanten muss ausschließlich aus dem Claim `tenant_id` des validierten Zugriffstokens stammen.

[MUST_NOT] Der Mandant darf nicht aus Route, Query, Header oder Body übernommen werden.

[MUST] `ITenantAssignment` darf außer vom `TenantTransactionInterceptor` nur von Hintergrundjobs über `WorkerTenantScope` und von der Anlage eines neuen Mandanten verwendet werden. Jede Verwendung muss in einer Architekturtest-Allowlist stehen.

[MUST] `TenantContext` muss scoped registriert sein. `AddDbContextFactory` muss mit `ServiceLifetime.Scoped` registriert sein, damit Query-Filter und Interceptor den Mandanten des aktuellen Scopes sehen.

### Datenmodell

[MUST] Die Tabelle `tenants` muss einen Integer-Schlüssel `id` und eine eindeutige Guid-Spalte `business_id` besitzen; der Claim `tenant_id` trägt die `business_id`.

[MUST] Jede mandantenbezogene Entität muss `ITenantScoped` implementieren und eine nicht nullbare Integer-Spalte `tenant_id` mit Fremdschlüssel auf `tenants.id` besitzen.

[MUST] `tenant_id` muss in jedem zusammengesetzten Index und Unique-Constraint der Tabelle an erster Stelle stehen.

[MUST] Die Migration der Tabelle `tenants` muss `EnableTenantTableRowLevelSecurity` aufrufen. Jede Migration, die eine mandantenbezogene Tabelle anlegt, muss `EnableTenantRowLevelSecurity` aufrufen; das `Down` muss `DisableTenantRowLevelSecurity` aufrufen.

[MUST] `TenantId` neuer Entitäten setzt ausschließlich `AppDbContext` beim Speichern aus `ITenantContext.TenantKey`. Repositories und Aufrufer dürfen ihn nicht setzen; ein Wechsel des Mandanten bestehender Entitäten wird abgelehnt.

[MUST] Der Context muss `UseSnakeCaseNamingConvention()` aus `EFCore.NamingConventions` verwenden, weil Interceptor und Policies die Spalten `tenant_id` und `business_id` adressieren.

[MUST] Die Anwendung muss sich mit einer Datenbankrolle ohne `BYPASSRLS` verbinden, die nicht Superuser und nicht Eigentümer der Tabellen ist. Migrationen müssen eine eigene Rolle verwenden.

### Zugriff

[MUST] Mandantenbezogene Zugriffe müssen innerhalb einer asynchron begonnenen expliziten Transaktion laufen, damit der Interceptor die Sitzungsvariablen setzt und den internen Schlüssel auflöst. Mit [C# Unit of Work](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/SNIPPET.md) ist das sichergestellt.

[MUST_NOT] `IgnoreQueryFilters()`, `FromSqlRaw`, `ExecuteSqlRaw` und `ExecuteSqlInterpolated` dürfen außerhalb von `Infrastructure` nicht verwendet werden.

[MUST] Hintergrundjobs müssen je Mandant einen `WorkerTenantScope` öffnen und alle Dienste über dessen `ServiceProvider` auflösen. Ein Fehler eines Mandanten darf die Verarbeitung der übrigen Mandanten nicht abbrechen.

## Tests

[MUST] Ein Integrationstest gegen echtes PostgreSQL mit der Anwendungsrolle muss nachweisen, dass Mandant A Zeilen von Mandant B weder lesen noch ändern kann, sowohl über EF Core als auch über `IgnoreQueryFilters()` (RLS als zweite Sperre).

[MUST] Ein Integrationstest muss nachweisen, dass ein Zugriff ohne Mandant keine Zeilen liefert und kein Schreiben erlaubt.

[MUST] Ein Architekturtest muss prüfen, dass alle Entitäten außer einer benannten Ausnahmeliste `ITenantScoped` implementieren und `ITenantAssignment` nur in der Allowlist verwendet wird; siehe [C# Architecture Tests](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/SNIPPET.md).

## Grenzen

- Die RLS-Sperre ist PostgreSQL-spezifisch; der Query-Filter funktioniert providerunabhängig.
- Synchrone EF-Core-Transaktionen werden vom Interceptor abgelehnt.
- Die erste Transaktion eines Scopes führt eine zusätzliche Abfrage auf `tenants` aus, um den internen Schlüssel aufzulösen.
- Mandantenübergreifende Administrationsfunktionen benötigen eine eigene, ausdrücklich freigegebene Lösung.
