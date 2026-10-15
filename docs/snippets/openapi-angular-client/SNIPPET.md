# Snippet: OpenAPI Angular Client

Stand: 2026-10-15

## Zweck

Contract-first-Pipeline zwischen .NET-Web-API und Angular: Der Backend-Build erzeugt einen deterministischen, committeten Vertrag `contracts/api.json`, orval erzeugt daraus den typisierten Angular-Client, und zwei CI-Prüfungen verhindern Abweichungen zwischen Code, Vertrag und Client.

## Verwenden

- Wenn ein Angular-Frontend eine .NET-Web-API desselben Repositorys konsumiert.
- Wenn Endpunkte, Request- oder Response-Verträge geändert werden; dann sind Vertrag und Client im selben Commit neu zu erzeugen.
- Nicht verwenden für externe APIs, deren Vertrag nicht im Repository entsteht.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [WebApi.csproj.xml](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/WebApi/WebApi.csproj.xml) | `WebApi` | Ausschnitt: Vertrag beim Build nach `contracts/api.json` erzeugen. |
| [OpenApiConfiguration.cs](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/WebApi/Configuration/OpenApiConfiguration.cs) | `WebApi` | Nur `application/json`, sortierte Pfade und Tags. |
| [orval.config.ts](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/frontend/orval.config.ts) | Angular | Generatorkonfiguration. |
| [http-client.mutator.ts](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/frontend/src/app/core/data-access/api/http-client.mutator.ts) | Angular | Durchreichende Naht zum `HttpClient`. |
| [index.ts](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/frontend/src/app/core/data-access/api/index.ts) | Angular | Fassade über dem erzeugten Code. |
| [package.scripts.json](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/frontend/package.scripts.json) | Angular | Ausschnitt: npm-Skripte für Erzeugung und Drift-Prüfung. |
| [api-contract.yml](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/ci/api-contract.yml) | CI | Ausschnitt: GitHub-Actions-Job mit beiden Drift-Prüfungen. |

Der Namespace-Präfix `Example` und Projektpfade sind an das Zielprojekt anzupassen. Benötigte Einträge in `GlobalUsings.cs` von `WebApi`: `Microsoft.AspNetCore.Mvc`, `Microsoft.OpenApi`.

`AddWebApi(...)` ruft `services.AddControllersWithStableContract()` statt `AddControllers()` auf; `Program.cs` mappt `app.MapOpenApi()` nur in der Entwicklungsumgebung.

## Regeln

### Vertrag

[MUST] Der OpenAPI-Vertrag muss beim Build über `Microsoft.Extensions.ApiDescription.Server` erzeugt und unter `contracts/api.json` committet werden.

[MUST] Der Vertrag muss bei unverändertem Code byteidentisch erzeugt werden; dazu müssen Pfade und Tags ordinal sortiert und Request- sowie Response-Inhalte auf `application/json` beschränkt sein.

[MUST_NOT] `contracts/api.json` darf nicht von Hand bearbeitet werden.

[MUST] `Microsoft.OpenApi` muss in Version 2.11.0 oder neuer zentral gepinnt sein, weil ältere 2.x-Versionen eine bekannte Sicherheitslücke ([GHSA-v5pm-xwqc-g5wc](https://github.com/advisories/GHSA-v5pm-xwqc-g5wc)) enthalten, die mit NuGet-Audit den Build bricht.

[MUST] Endpunkte müssen alle Statuscodes über `ProducesResponseType` und einen stabilen `EndpointName` deklarieren, damit der erzeugte Client vollständige Typen und stabile Methodennamen erhält.

### Client

[MUST] Der Angular-Client muss mit orval im Modus `tags-split`, `client: 'angular'`, `retrievalClient: 'httpClient'` und `headers: true` erzeugt werden.

[MUST] `target` und `schemas` müssen innerhalb von `core/data-access/api/generated/` liegen; handgeschriebene Dateien müssen außerhalb dieses Verzeichnisses liegen.

[MUST] Der erzeugte Code muss committet und von Lint, Formatierung und Abhängigkeitsprüfung ausgenommen werden.

[MUST_NOT] Erzeugter Code darf nicht von Hand bearbeitet werden.

[MUST] Feature-Code darf den erzeugten Client nur über die Fassade `core/data-access/api/index.ts` und nur in Data-Access-Services verwenden. Die Abhängigkeitsprüfung muss direkte Importe aus `generated/` und direkte `HttpClient`-Nutzung außerhalb der Data-Access-Schicht verbieten.

[MUST] Der Mutator muss `params`, `headers`, `body` und `responseType` unverändert weiterreichen. Authentifizierung, XSRF und Fehlerbehandlung gehören in HTTP-Interceptors.

[MUST_IF] Wenn ein Zahlenfeld im Vertrag als `integer | string` typisiert ist, muss die Data-Access-Schicht es mit `Number(...)` normalisieren, bevor es an Feature-Code geht.

### Drift-Prüfung

[MUST] Die CI muss bei Pull Requests und Pushes nach `develop` und `main` sowohl `api:contract:check` (Backend gegen `contracts/api.json`) als auch `api:client:check` (Vertrag gegen erzeugten Client) ausführen.

[MUST] Änderungen an Endpunkten müssen Code, `contracts/api.json` und erzeugten Client im selben Commit enthalten.

## Grenzen

- Die Pfadsortierung ersetzt eine fachliche Reihenfolge; Clients dürfen sich nicht auf die Reihenfolge im Vertrag verlassen.
- .NET 10 typisiert Zahlen standardmäßig als `integer | string`; eine abweichende `JsonNumberHandling`-Konfiguration ändert den Vertrag für alle Clients.
- Für Header-Parameter wie `Page` und `Page-Size` aus [C# Pagination](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/SNIPPET.md) ist `headers: true` zwingend.
