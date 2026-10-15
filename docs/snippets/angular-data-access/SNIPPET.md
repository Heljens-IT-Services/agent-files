# Snippet: Angular Data Access

Stand: 2026-10-15

## Zweck

Einheitlicher Datenfluss in Angular-Anwendungen: Data-Access-Services unter `core/data-access/` kapseln den erzeugten API-Client und liefern Promises mit internen Modellen, Feature-Stores halten Zustand als Signals, und Sitzungsablauf wird zentral über Guard und Interceptor behandelt.

## Verwenden

- Wenn ein Feature Daten von einer API lädt, ändert oder anzeigt.
- Wenn Feature-Zustand, app-weiter Sitzungszustand, Route-Guards oder HTTP-Interceptors entstehen oder geändert werden.
- Nicht verwenden für rein lokalen UI-Zustand einer einzelnen Komponente; dieser bleibt als Signal in der Komponente.

## Dateien

| Datei | Zweck |
|---|---|
| [team.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/data-access/teams/team.ts) | Internes Modell, entkoppelt vom API-DTO. |
| [teams-api.service.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/data-access/teams/teams-api.service.ts) | Data-Access-Service: Promise, Mapping, `ApiResult<T>`. |
| [index.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/data-access/teams/index.ts) | Öffentliche Schnittstelle des Data-Access-Bereichs. |
| [teams.store.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/features/teams/teams.store.ts) | Feature-Store mit privaten Signals und lesender Außensicht. |
| [teams.routes.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/features/teams/teams.routes.ts) | Store im Injector der Feature-Route. |
| [session-store.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/session/session-store.ts) | Globaler Sitzungszustand mit idempotentem Laden. |
| [session.guard.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/session/session.guard.ts) | Route-Guard mit unterschiedenen Ergebnissen. |
| [session-expired.interceptor.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/core/http/session-expired.interceptor.ts) | Zentrale Reaktion auf `401`. |
| [app.config.ts](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/src/app/app.config.ts) | Ausschnitt: `provideApi('')`, `provideHttpClient` mit Interceptors und XSRF. |

Die Dateien setzen `ApiResult<T>` und `toApiResult` aus [API Error Codes](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/SNIPPET.md) und den erzeugten Client aus [OpenAPI Contract First](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/SNIPPET.md) voraus. `UsersApiService` und `CurrentUser` sind nach demselben Muster wie `TeamsApiService` und `Team` anzulegen.

## Regeln

### Data Access

[MUST] Je API-Ressource muss es genau einen Data-Access-Service unter `core/data-access/<ressource>/` geben, der den erzeugten Client ausschließlich über die Fassade `@core/data-access/api` verwendet.

[MUST] Data-Access-Services müssen Promises liefern und API-DTOs in interne Modelle mappen. API-DTOs dürfen den Data-Access-Bereich nicht verlassen.

[MUST] Data-Access-Services müssen fachliche Fehler als `ApiResult<T>` liefern; technische Fehler werden geworfen.

### State

[MUST] Feature-Stores müssen Zustand in privaten `signal`s halten und ausschließlich über `asReadonly()` oder `computed` herausgeben. Änderungen erfolgen nur über Methoden des Stores.

[MUST] Feature-Stores müssen ohne `providedIn` deklariert und in `providers` der Feature-Route bereitgestellt werden.

[MUST] Globale Stores unter `core/` mit `providedIn: 'root'` sind auf app-weiten Zustand wie Sitzung oder Benutzer beschränkt.

[MUST] Sichtbare Zustände wie Laden, leer, Fehler und geladen müssen im Store als eigener Zustand modelliert sein.

[MUST] Ladevorgänge müssen parallele Aufrufe auf einen laufenden Abruf zusammenführen, statt doppelte Anfragen zu senden.

[MUST_NOT] Komponenten dürfen Data-Access-Services nicht direkt aufrufen, wenn das Feature einen Store besitzt; sie verwenden den Store.

### Sitzung und HTTP

[MUST] Der erzeugte Client muss über `provideApi(...)` mit dem Basispfad der API konfiguriert werden; bei gleicher Origin mit `provideApi('')`.

[MUST] HTTP-Interceptors müssen funktional (`HttpInterceptorFn`) sein und über `withInterceptors` registriert werden.

[MUST] Interceptors dürfen Querschnittsthemen wie Sitzungsablauf, Authentifizierung und Korrelation behandeln, müssen Fehler aber weiterreichen.

[MUST] Geschützte Routen müssen über einen Guard abgesichert sein, der zwischen nicht angemeldet und nicht erreichbar unterscheidet. Ein API-Ausfall (`0` oder `5xx`) darf nicht als abgelaufene Sitzung behandelt werden.

[MUST_IF] Wenn die Sitzung über Cookies läuft, muss `withXsrfConfiguration` mit dem vom Server gesetzten Cookie- und Headernamen konfiguriert sein.

## Tests

[MUST] Data-Access-Services müssen mit `HttpTestingController` auf Mapping, Header und `ApiResult`-Fehlerfall getestet werden.

[MUST] Stores müssen auf Zustandsübergänge inklusive Fehlerzustand und zusammengeführter paralleler Ladeaufrufe getestet werden.

[MUST] Guard und Interceptor müssen für jedes Ergebnis beziehungsweise jeden Statusfall getestet werden.

## Grenzen

- Die Unterscheidung „angemeldet, aber ohne Mandant“ ist anwendungsspezifisch und muss bei Bedarf als weiteres Guard-Ergebnis ergänzt werden.
- Ein `401` während der Anmeldung selbst wird vom Interceptor bewusst nicht umgeleitet.
