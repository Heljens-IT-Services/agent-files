# Snippet: C# Architecture Tests

Stand: 2026-10-15

## Zweck

Ausführbare Architekturregeln für geschichtete .NET-Anwendungen mit ArchUnitNET und Quellprüfungen: Schichtrichtung, Controller-Bauform, Business-Ids in HTTP-Verträgen, Persistenzgrenze und Mandantentrennung brechen den Test statt nur im Review aufzufallen.

## Verwenden

- Wenn eine geschichtete .NET-Anwendung nach [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) neu angelegt wird.
- Wenn Projekte, Schichten, Verträge oder Persistenzgrenzen geändert werden.
- Nicht verwenden als Ersatz für fachliche Tests.

## Dateien

| Datei | Zweck |
|---|---|
| [ArchitectureModel.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/Architecture.Tests/ArchitectureModel.cs) | Geladene Assemblies und Quellverzeichnis. |
| [LayerRules.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/Architecture.Tests/LayerRules.cs) | Namensräume und Referenzrichtung `WebApi -> Infrastructure -> Core`. |
| [ContractRules.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/Architecture.Tests/ContractRules.cs) | Controller-Bauform, Vertragsabdeckung durch erzeugte Basisklassen und keine Integer-Ids in Verträgen. |
| [PersistenceRules.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/Architecture.Tests/PersistenceRules.cs) | Nur die Unit of Work konsumiert `IDbContextFactory`; kein EF Core in WebApi außerhalb der Komposition. |
| [TenantScopeRules.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/Architecture.Tests/TenantScopeRules.cs) | Mandantenbezug aller Entitäten, Filterumgehung und Zuweisungs-Allowlist. |

Die Vertragsregeln in `ContractRules` setzen [OpenAPI Contract First](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/SNIPPET.md) voraus. `PersistenceRules` setzt [C# Unit of Work](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/SNIPPET.md) voraus, `TenantScopeRules` [C# Tenant Isolation](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/SNIPPET.md). Ohne das jeweilige Muster entfällt die Datei.

Der Namespace-Präfix `Example` ist in Code und Regex-Mustern durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`: `System.Runtime.CompilerServices`, `ArchUnitNET.Domain`, `ArchUnitNET.Domain.Extensions`, `ArchUnitNET.Fluent`, `ArchUnitNET.Loader`, `ArchUnitNET.xUnitV3`, `AwesomeAssertions`, `Microsoft.AspNetCore.Mvc`, `Microsoft.EntityFrameworkCore`, `Xunit`, `<Name>.Core.Tenants`, `<Name>.Infrastructure.Database`, `<Name>.Infrastructure.Tenants` sowie `global using static ArchUnitNET.Fluent.ArchRuleDefinition;`.

Pakete: `TngTech.ArchUnitNET`, `TngTech.ArchUnitNET.xUnitV3`, `AwesomeAssertions`, `xunit.v3.mtp-v2`. Das Testprojekt referenziert alle produktiven Projekte.

## Regeln

[MUST] Jede geschichtete .NET-Anwendung muss ein Projekt `Architecture.Tests` mit mindestens `LayerRules` und `ContractRules` besitzen.

[MUST] Architekturtests müssen in derselben CI-Stufe wie Unit-Tests laufen und dürfen nicht als optional markiert werden.

[MUST] Ausnahmen müssen als benannte Einträge in einer Liste der jeweiligen Regel mit Begründungskommentar stehen.

[MUST_NOT] Regeln dürfen nicht durch breitere Muster, zusätzliche Bedingungen oder Löschen abgeschwächt werden, um einen Verstoß zu beseitigen.

[MUST] Die Id-Regel muss jeden Namensraum `<Name>.WebApi…Contracts` erfassen, auch die erzeugten Modelle unter `Contracts.Generated.Models`.

[MUST] Jede neue Regel muss einmal nachweislich rot gelaufen sein, etwa mit einem vorübergehend eingefügten Verstoß, bevor sie übernommen wird.

[MUST] Regelnamen und Assertion-Texte müssen das geprüfte Verhalten fachlich beschreiben; Plan- oder Ticketnummern gehören nicht hinein.

## Grenzen

- Quellprüfungen über Textmuster erkennen keine indirekten Aufrufe, etwa über Hilfsmethoden; sie ergänzen Reviews, ersetzen sie nicht.
- `Every_entity_is_tenant_scoped_unless_exempt` baut das EF-Modell ohne Datenbankverbindung; Provider-Erweiterungen wie `UseVector()` müssen in der Testkonfiguration ergänzt werden.
