# Snippet: OpenAPI Contract First

Stand: 2026-10-15

## Zweck

Vertrag zuerst für HTTP-APIs zwischen .NET-Backend und Angular-Frontend: `contracts/api.yaml` wird von Hand gepflegt und reviewt. [OpenAPI Generator](https://openapi-generator.tech) erzeugt daraus im Backend abstrakte Controller-Basisklassen und DTOs und im Frontend den Angular-Client. Die CI weist nach, dass der erzeugte Code zum Vertrag passt und das Backend ihn vollständig implementiert.

## Verwenden

- Wenn eine HTTP-API eines Heljens-Projekts neu entsteht oder Endpunkte, Parameter, Request- oder Response-Modelle geändert werden.
- Wenn ein Angular-Frontend eine API desselben Repositorys konsumiert.
- Nicht verwenden für externe APIs, deren Vertrag nicht im Repository gepflegt wird; deren Client wird aus dem Fremdvertrag mit demselben Werkzeug erzeugt.

## Dateien

| Datei | Ablage im Projekt | Zweck |
|---|---|---|
| [api.yaml](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/contracts/api.yaml) | `contracts/api.yaml` | Beispielvertrag mit Pagination-Headern und Problem-Schema. |
| [controller.mustache](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/contracts/templates/aspnetcore/controller.mustache) | `contracts/templates/aspnetcore/` | Vorlage: abstrakte Controller-Basis mit `CancellationToken`. |
| [openapitools.json](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/openapitools.json) | Repository-Root | Generatorversion und Optionen für Backend und Frontend. |
| [generate-api.mjs](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/scripts/generate-api.mjs) | `scripts/` | Erzeugt beide Seiten, räumt auf und prüft mit `--check` auf Abweichungen. |
| [package.scripts.json](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/frontend/package.scripts.json) | Ausschnitt für `app/frontend/package.json` | `api:generate`, `api:check` und die CLI als Dev-Abhängigkeit. |
| [index.ts](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/frontend/src/app/core/data-access/api/index.ts) | `app/frontend/src/app/core/data-access/api/` | Fassade über dem erzeugten Client. |
| [api-contract.yml](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/ci/api-contract.yml) | `.github/workflows/` | CI-Job für Abweichungsprüfung und Build. |

Erzeugte Ziele, die ausschließlich dem Generator gehören:

- Backend: `backend/src/WebApi/Contracts/Generated/` mit `Controllers/`, `Models/` und `Converters/`
- Frontend: `app/frontend/src/app/core/data-access/api/generated/`

Pfade, Paketname und Namespace-Präfix `Example` sind in `openapitools.json` und `generate-api.mjs` an das Projekt anzupassen. Benötigt werden Node und Java 11 oder neuer; die Generatorversion lädt die CLI selbst.

## Ablauf einer API-Änderung

1. `contracts/api.yaml` ändern und im Pull Request zuerst reviewen lassen.
2. `npm run api:generate` in `app/frontend` ausführen.
3. Den Build-Fehler der neuen oder geänderten abstrakten Methode im Backend durch die Implementierung im Controller beheben.
4. Data-Access-Services im Frontend an den erzeugten Client anpassen.
5. Vertrag, erzeugten Code und Implementierung im selben Commit einchecken.

## Regeln

### Vertrag

[MUST] `contracts/api.yaml` muss die einzige Quelle der Wahrheit für Routen, Parameter, Request- und Response-Modelle und Statuscodes der API sein.

[MUST] Jede Operation muss `operationId` in `camelCase`, genau einen `tag` je Ressource, `summary` und alle fachlichen Statuscodes besitzen.

[MUST] Fachliche Fehlerantworten müssen auf das gemeinsame Schema `Problem` mit dem Pflichtfeld `errorCode` über `components/responses` verweisen; siehe [API Error Codes](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/SNIPPET.md).

[MUST] Wiederkehrende Parameter wie `Page` und `Page-Size` müssen einmal unter `components/parameters` definiert und per `$ref` eingebunden werden.

[MUST] Numerische Parameter mit Untergrenze müssen auch `maximum` angeben, weil der Generator `[Range]` nur bei beiden Grenzen erzeugt.

[MUST] Externe Identifikatoren müssen als `type: string, format: uuid` modelliert werden; technische Integer-Ids dürfen im Vertrag nicht vorkommen.

[MUST_NOT] Breaking Changes am Vertrag dürfen ohne API-Versionierung oder dokumentierte Migration nicht eingeführt werden.

### Generierung

[MUST] Backend und Frontend müssen mit OpenAPI Generator in der in `openapitools.json` gepinnten Version erzeugt werden: `aspnetcore` mit der Vorlage aus `contracts/templates/aspnetcore` und `typescript-angular`.

[MUST] Die Generierung muss ausschließlich über `scripts/generate-api.mjs` laufen, das die Ziele vor jedem Lauf vollständig ersetzt.

[MUST] Der erzeugte Code muss committet werden.

[MUST_NOT] Erzeugter Code darf nicht von Hand bearbeitet werden; Anpassungen erfolgen über Vertrag, Generatoroptionen oder Vorlage.

[MUST] Erzeugter Backend-Code muss über `.editorconfig` als `generated_code` markiert und von Analyzern ausgenommen sein; erzeugter Frontend-Code muss von Lint, Formatierung und Knip ausgenommen sein.

### Backend

[MUST] Jeder Controller muss von genau einer erzeugten `<Tag>ControllerBase` erben, `[ApiController]` tragen und alle abstrakten Methoden überschreiben. Endpunkte ohne Vertragsbasis sind nicht zulässig.

[MUST] Controller müssen den `CancellationToken` der erzeugten Methode an Use Cases weiterreichen.

[MUST] Controller müssen Core-Ergebnisse explizit in die erzeugten Modelle mappen; erzeugte Modelle dürfen `WebApi` nicht verlassen.

[MUST] Architekturtests müssen nachweisen, dass jeder Controller eine Vertragsbasis implementiert und jede Vertragsbasis genau einen Controller hat; siehe [C# Architecture Tests](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/SNIPPET.md).

### Frontend

[MUST] Der erzeugte Client darf nur über die Fassade `core/data-access/api/index.ts` und nur in Data-Access-Services unter `core/data-access/` verwendet werden; siehe [Angular Data Access](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/SNIPPET.md). Die Abhängigkeitsprüfung muss direkte Importe aus `generated/` verbieten.

[MUST] Die Anwendung muss den Client mit `provideApi(...)` konfigurieren; ohne Basispfad ruft er `http://localhost` auf.

### CI

[MUST] Die CI muss bei Pull Requests und Pushes nach `develop` und `main` `npm run api:check` und anschließend den Backend-Build ausführen.

## Beispiel

```csharp
// backend/src/WebApi/Teams/TeamsController.cs
[ApiController]
[Authorize]
public sealed class TeamsController(ITeamService teamService) : TeamsControllerBase
{
    public override async Task<IActionResult> ListTeams(int page, int pageSize, CancellationToken cancellationToken)
    {
        var result = await teamService.ListAsync(new PageRequest(page, pageSize), cancellationToken).ConfigureAwait(false);
        return Ok(new TeamPage { Count = result.Count, Items = result.Items.Select(ToResponse).ToList() });
    }

    public override async Task<IActionResult> CreateTeam(CreateTeamRequest createTeamRequest, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(createTeamRequest);
        var result = await teamService.CreateAsync(createTeamRequest.Name, cancellationToken).ConfigureAwait(false);
        return result.Succeeded
            ? Created($"/api/teams/{result.Value.BusinessId}", ToResponse(result.Value))
            : ErrorProblem.ToResult(result.Error);
    }

    private static TeamResponse ToResponse(TeamDto dto) => new() { BusinessId = dto.BusinessId, Name = dto.Name };
}
```

## Grenzen

- Die eigene Controller-Vorlage muss bei einem Wechsel der Generator-Hauptversion gegen die Originalvorlage geprüft werden.
- Erzeugte Backend-Modelle sind veränderliche Klassen ohne Nullable-Annotationen; sie bleiben deshalb auf `WebApi` beschränkt.
- Laufzeitvalidierung entsteht nur für Regeln, die der Generator als Attribute abbildet (`required`, `minLength`/`maxLength`, `minimum` mit `maximum`, `pattern`); weitere fachliche Regeln prüft der Use Case.
- Die CLI lädt die Generatorversion beim ersten Lauf aus dem Netz; in abgeschotteten Umgebungen muss die JAR-Datei vorab bereitgestellt werden.
