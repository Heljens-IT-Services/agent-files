# Snippet: C# Tenant Isolation

Stand: 2026-10-15

## Zweck

Doppelte Mandantentrennung für C#-/.NET-Backends mit EF Core und PostgreSQL: ein globaler EF-Query-Filter als erste Sperre und Row-Level-Security in der Datenbank als zweite Sperre. Der Mandant stammt ausschließlich aus dem Zugriffstoken oder einer ausdrücklich erlaubten Zuweisung.

## Verwenden

- Wenn eine Anwendung Daten mehrerer Mandanten in einer gemeinsamen Datenbank hält.
- Wenn eine mandantenbezogene Entität, Tabelle, Migration oder ein Hintergrundjob über Mandantendaten entsteht.
- Nicht verwenden bei einer Datenbank je Mandant oder bei Anwendungen ohne Mandantenbezug.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [ITenantContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Core/Tenants/ITenantContext.cs) | `Core` | Lesender Zugriff auf den aktuellen Mandanten. |
| [ITenantAssignment.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Core/Tenants/ITenantAssignment.cs) | `Core` | Benannte Ausnahme zur ausdrücklichen Zuweisung. |
| [ITenantScoped.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Tenants/ITenantScoped.cs) | `Infrastructure` | Marker für mandantenbezogene Entitäten. |
| [TenantContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Tenants/TenantContext.cs) | `Infrastructure` | Liest den Claim `tenant_id`; Zuweisung hat Vorrang. |
| [AppDbContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/AppDbContext.cs) | `Infrastructure` | Generischer globaler Query-Filter für alle `ITenantScoped`-Entitäten. |
| [TenantTransactionInterceptor.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/TenantTransactionInterceptor.cs) | `Infrastructure` | Setzt `app.tenant_id` je Transaktion für RLS. |
| [MigrationBuilderTenantExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Infrastructure/Database/MigrationBuilderTenantExtensions.cs) | `Infrastructure` | Aktiviert und entfernt RLS-Policies in Migrationen. |
| [WorkerTenantScope.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/Worker/Tenancy/WorkerTenantScope.cs) | `Worker` | Mandanten-Scope für Hintergrundjobs. |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Infrastructure`: `System.Data.Common`, `System.Linq.Expressions`, `Microsoft.AspNetCore.Http`, `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Diagnostics`, `Microsoft.EntityFrameworkCore.Migrations`, `<Name>.Core.Tenants`, `<Name>.Infrastructure.Tenants`
- `Worker`: `Microsoft.Extensions.DependencyInjection`, `<Name>.Core.Tenants`

Registrierung in `AddInfrastructure(...)`:

```csharp
services.AddHttpContextAccessor();
services.AddScoped<TenantContext>();
services.AddScoped<ITenantContext>(serviceProvider => serviceProvider.GetRequiredService<TenantContext>());
services.AddScoped<ITenantAssignment>(serviceProvider => serviceProvider.GetRequiredService<TenantContext>());

// Scoped, damit Context und Interceptor den ITenantContext des aktuellen Scopes erhalten.
services.AddDbContextFactory<AppDbContext>(
    (serviceProvider, options) => options
        .UseNpgsql(connectionString)
        .AddInterceptors(new TenantTransactionInterceptor(serviceProvider.GetRequiredService<ITenantContext>())),
    ServiceLifetime.Scoped);
```

## Regeln

### Mandantenquelle

[MUST] Der Mandant muss ausschließlich aus dem Claim `tenant_id` des validierten Zugriffstokens stammen.

[MUST_NOT] Der Mandant darf nicht aus Route, Query, Header oder Body übernommen werden.

[MUST] `ITenantAssignment` darf nur von Hintergrundjobs über `WorkerTenantScope` und von der Anlage eines neuen Mandanten verwendet werden. Jede Verwendung muss in einer Architekturtest-Allowlist stehen.

[MUST] `TenantContext` muss scoped registriert sein. `AddDbContextFactory` muss mit `ServiceLifetime.Scoped` registriert sein, damit Query-Filter und Interceptor den Mandanten des aktuellen Scopes sehen.

### Datenmodell

[MUST] Jede mandantenbezogene Entität muss `ITenantScoped` implementieren und eine nicht nullbare Spalte `tenant_id` besitzen.

[MUST] `tenant_id` muss in jedem zusammengesetzten Index und Unique-Constraint der Tabelle an erster Stelle stehen.

[MUST] Jede Migration, die eine mandantenbezogene Tabelle anlegt, muss `EnableTenantRowLevelSecurity` aufrufen; das `Down` muss `DisableTenantRowLevelSecurity` aufrufen.

[MUST] Repositories müssen beim Anlegen `TenantId` aus `ITenantContext` setzen, nie aus einem Parameter oder DTO des Aufrufers.

[MUST] Die Anwendung muss sich mit einer Datenbankrolle ohne `BYPASSRLS` verbinden, die nicht Superuser ist. Migrationen dürfen eine eigene Rolle verwenden.

### Zugriff

[MUST] Mandantenbezogene Zugriffe müssen innerhalb einer asynchron begonnenen expliziten Transaktion laufen, damit der Interceptor `app.tenant_id` setzt.

[MUST_NOT] `IgnoreQueryFilters()` und rohes SQL auf mandantenbezogenen Tabellen dürfen außerhalb von `Infrastructure` und ohne Eintrag in einer Architekturtest-Allowlist nicht verwendet werden.

[MUST] Hintergrundjobs müssen je Mandant einen `WorkerTenantScope` öffnen und alle Dienste über dessen `ServiceProvider` auflösen. Ein Fehler eines Mandanten darf die Verarbeitung der übrigen Mandanten nicht abbrechen.

## Tests

[MUST] Ein Integrationstest gegen echtes PostgreSQL muss nachweisen, dass Mandant A Zeilen von Mandant B weder lesen noch ändern kann, sowohl über EF Core als auch über `IgnoreQueryFilters()` (RLS als zweite Sperre).

[MUST] Ein Integrationstest muss nachweisen, dass ein Zugriff ohne Mandant keine Zeilen liefert und kein Schreiben erlaubt.

[MUST] Ein Architekturtest muss prüfen, dass alle Entitäten mit Spalte `TenantId` `ITenantScoped` implementieren und `ITenantAssignment` nur in der Allowlist verwendet wird.

## Grenzen

- Die RLS-Sperre ist PostgreSQL-spezifisch; der Query-Filter funktioniert providerunabhängig.
- Synchrone EF-Core-Transaktionen werden vom Interceptor abgelehnt.
- Mandantenübergreifende Administrationsfunktionen benötigen eine eigene, ausdrücklich freigegebene Lösung.
