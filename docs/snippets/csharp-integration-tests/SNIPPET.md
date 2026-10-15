# Snippet: C# Integration Tests

Stand: 2026-10-15

## Zweck

Realitätsnahe HTTP-Integrationstests für .NET-Web-APIs: Die WebApi läuft in-process über `WebApplicationFactory` gegen ein echtes PostgreSQL aus Testcontainers mit eingeschränkter Anwendungsrolle. Die Authentifizierung wird über Testheader ersetzt, und ein Abfragezähler macht N+1-Abfragen messbar.

## Verwenden

- Wenn Routing, Statuscodes, Authentifizierung, Validierung, Fehlerantworten, HTTP-Verträge oder DI-Verkabelung einer WebApi getestet werden.
- Wenn Mandantentrennung, Row-Level-Security oder Datenbank-Constraints nachgewiesen werden müssen.
- Nicht verwenden für reine Fachlogik; diese wird in `Core.Tests` ohne Datenbank getestet.

## Dateien

| Datei | Zweck |
|---|---|
| [PostgresFixture.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/PostgresFixture.cs) | Container, Migration und Anwendungsrolle ohne `BYPASSRLS`. |
| [PostgresCollectionDefinition.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/PostgresCollectionDefinition.cs) | Ein Container für alle Testklassen der Collection. |
| [ApiFactory.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/ApiFactory.cs) | `WebApplicationFactory` mit Testauthentifizierung und Abfragezähler. |
| [TestAuthHandler.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/TestAuthHandler.cs) | Claims aus `X-Test-Subject`, `X-Test-Tenant-Id` und `X-Test-Roles`. |
| [HttpClientTestExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/HttpClientTestExtensions.cs) | `AsUser(...)` setzt die Testheader. |
| [TestQueryCounter.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/TestQueryCounter.cs) | Threadsicherer Zähler abgesetzter Befehle. |
| [CountingDbCommandInterceptor.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/CountingDbCommandInterceptor.cs) | EF-Interceptor für den Zähler. |
| [FakeTenantContext.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/WebApi.Tests/Support/FakeTenantContext.cs) | Fester Mandantenkontext für Migration und Repository-Tests. |

Die Dateien setzen [C# Tenant Isolation](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/SNIPPET.md) voraus (`AppDbContext`, `ITenantContext`). Ohne Mandantentrennung entfallen `FakeTenantContext` und der Header `X-Test-Tenant-Id`.

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs` des Testprojekts: `System.Data.Common`, `System.Security.Claims`, `System.Text.Encodings.Web`, `Microsoft.AspNetCore.Authentication`, `Microsoft.AspNetCore.Hosting`, `Microsoft.AspNetCore.Mvc.Testing`, `Microsoft.AspNetCore.TestHost`, `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Diagnostics`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Logging`, `Microsoft.Extensions.Options`, `Npgsql`, `Testcontainers.PostgreSql`, `Xunit`, `AwesomeAssertions`, `<Name>.Core.Tenants`, `<Name>.Infrastructure.Database`, `<Name>.WebApi.Tests.Support`.

Pakete: `Microsoft.AspNetCore.Mvc.Testing`, `Testcontainers.PostgreSql`, `xunit.v3.mtp-v2`, `AwesomeAssertions`. Die Versionen verwaltet [.NET Build Hygiene](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/SNIPPET.md) zentral.

`Program.cs` der WebApi muss am Ende diesen Marker enthalten, damit `WebApplicationFactory<Program>` den Einstiegspunkt erreicht; der geschützte Konstruktor erfüllt Sonar S1118:

```csharp
/// <summary>Einstiegspunkt-Marker für <c>WebApplicationFactory&lt;Program&gt;</c>.</summary>
public partial class Program
{
    protected Program()
    {
    }
}
```

## Regeln

[MUST] WebApi-Integrationstests müssen gegen PostgreSQL aus Testcontainers laufen; In-Memory-Provider und SQLite sind als Ersatz nicht zulässig.

[MUST] Tests müssen sich mit der eingeschränkten Anwendungsrolle verbinden. Die Superuser-Verbindung ist nur zum Herrichten von Testdaten erlaubt.

[MUST] Alle Testklassen eines Testprojekts, die die Datenbank verwenden, müssen über `[Collection(PostgresCollectionDefinition.Name)]` denselben Container teilen.

[MUST] Jeder Test muss seine Daten in einem eigenen, neu erzeugten Mandanten oder mit eindeutigen Business-Ids anlegen, damit Tests unabhängig von Reihenfolge und Vorbestand sind.

[MUST] `ApiFactory` darf ausschließlich Authentifizierung, Testmesspunkte und nicht verfügbare externe Dienste ersetzen. DI, Routing, Middleware und Persistenz müssen die Produktionsverkabelung bleiben.

[MUST] Externe Dienste ohne Testcontainer müssen in `ConfigureTestServices` per `RemoveAll<T>()` und neuer Registrierung durch ein Testdoppel ersetzt werden.

[MUST_NOT] Secrets und Passwörter dürfen nicht im Quelltext stehen oder über prozessweite Umgebungsvariablen an Fixtures gereicht werden; sie werden je Lauf zufällig erzeugt.

[MUST_NOT] `TestAuthHandler` darf nicht außerhalb von Testprojekten referenziert oder registriert werden.

[MUST] Testdaten müssen über kleine, fachlich benannte Builder oder Hilfsmethoden je Fachbereich angelegt werden. Eine zentrale Fixture mit Seed-Methoden aller Fachbereiche ist nicht zulässig.

[MUST] Listen-Endpunkte müssen mit `TestQueryCounter` nachweisen, dass die Zahl der Abfragen nicht mit der Zahl der Elemente wächst.

## Beispiel

```csharp
[Collection(PostgresCollectionDefinition.Name)]
public sealed class TeamsEndpointTests(PostgresFixture database)
{
    [Fact]
    public async Task Listing_teams_without_authentication_returns_401()
    {
        await using var factory = new ApiFactory(database.AppConnectionString);
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/api/teams", TestContext.Current.CancellationToken);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Listing_teams_does_not_issue_one_query_per_team()
    {
        await using var factory = new ApiFactory(database.AppConnectionString);
        var tenantId = await TeamSeed.CreateTenantWithTeamsAsync(database, teamCount: 20);
        using var client = factory.CreateClient().AsUser("user-1", tenantId);
        var counter = factory.Services.GetRequiredService<TestQueryCounter>();
        counter.Reset();

        using var request = new HttpRequestMessage(HttpMethod.Get, "/api/teams");
        request.Headers.Add("Page", "1");
        request.Headers.Add("Page-Size", "50");
        var response = await client.SendAsync(request, TestContext.Current.CancellationToken);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        counter.Count.Should().BeLessThanOrEqualTo(5);
    }
}
```

## Grenzen

- Testcontainers benötigt eine laufende Docker-kompatible Umgebung lokal und in der CI.
- Die Fixture legt die Anwendungsrolle selbst an. Wenn Migrationen die Rolle in Produktion anlegen, muss die Fixture denselben Mechanismus verwenden, statt eine abweichende Rolle zu erzeugen.
