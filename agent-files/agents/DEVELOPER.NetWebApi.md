# DEVELOPER.NetWebApi.md

Stand: 2026-05-13

## Zweck

Diese Datei definiert .NET-spezifische Entwicklungsregeln fuer Web APIs dieses Repositories. Allgemeine Regeln stehen in `DEVELOPER.md`. Sie gilt fuer fachlich relevante HTTP-APIs mit Routing, Authentifizierung, Validierung, externer Integration, Workflows, Persistenz, Berechnungen und strukturierten API-Antworten.

[PRIORITY] Diese Regeln gelten in ihrem Scope vorrangig vor allgemeineren Regeln aus `DEVELOPER.md`.

## Versionsbasis

[MUST] .NET-Web-API-Anwendungen muessen auf `net10.0` zielen.

[MUST] Die Versionen in `global.json`, `.csproj`, `Directory.Build.props` und CI-Konfiguration sind verbindlich.

[MUST] `Nullable` muss aktiviert sein.

[MUST] `ImplicitUsings` muss deaktiviert sein.

[MUST] File-scoped namespaces muessen verwendet werden.

[MUST] Projektweite Namespaces muessen ausschliesslich ueber `GlobalUsings.cs` verwaltet werden.

## Zielbild

[MUST] .NET-Web-API-Anwendungen muessen aus genau drei produktiven Projekten innerhalb einer Solution bestehen: `<Name>.WebApi`, `<Name>.Infrastructure` und `<Name>.Core`.

[ALLOW] Testprojekte duerfen zusaetzlich angelegt werden.

[MUST] Die Referenzrichtung muss `WebApi -> Infrastructure -> Core` sein.

[MUST] `Core` muss die fachliche Mitte mit Domain, Use Cases, Ports, Services, Ergebnisobjekten und fachlichen Fehlern sein.

[MUST] `Infrastructure` muss technische Details und Ports aus `Core` implementieren.

[MUST] `WebApi` muss Composition Root fuer Host, Konfiguration, DI, Middleware, Routing, HTTP-Endpoints und API-Vertraege sein.

## Standardstruktur

[SHOULD] Die Projektstruktur soll Domain-Driven Design auf Solution-Ebene folgen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aufgabe keine Strukturmigration ist.

[MUST] Die drei Hauptprojekte muessen direkt auf oberster Ebene der Solution liegen.

[MUST_NOT] Die drei Hauptprojekte duerfen nicht unterhalb eines `src/`-Ordners liegen.

[MUST] `<Name>.WebApi/Program.cs` muss Composition Root fuer Host, Konfiguration, Logging, DI, Middleware und Routing sein.

[MUST_NOT] `<Name>.WebApi/Program.cs` darf keine Fachlogik enthalten.

[ALLOW] `<Name>.WebApi/appsettings.json` darf Runtime-Konfiguration fuer Auth, CORS, Provider, Timeouts, Retry, Persistenz und fachliche Settings enthalten.

[MUST_NOT] `<Name>.WebApi/appsettings.json` darf keine Secrets enthalten.

[ALLOW] `<Name>.WebApi/Controllers/` und `<Name>.WebApi/Endpoints/` duerfen HTTP-Einstiege enthalten.

[MUST_NOT] Controller und Endpoints duerfen keine Fachlogik enthalten.

[MUST] `<Name>.WebApi/Contracts/` muss HTTP-Request-/Response-Contracts enthalten.

[MUST_NOT] Domainmodelle duerfen nicht als direkte API-Vertraege verwendet werden.

[MUST] `<Name>.Infrastructure/` muss technische Implementierungen enthalten, `Core` referenzieren und von `WebApi` referenziert werden.

[MUST] `<Name>.Core/` muss fachliche Modelle, Ports, Use Cases, Workflows und fachliche Regeln enthalten.

[MUST_NOT] `<Name>.Core/` darf `WebApi` oder `Infrastructure` nicht referenzieren.

## Module.cs und DI

[MUST] Jedes der drei Hauptprojekte muss eine `Module.cs` als zentralen Einstiegspunkt fuer die DI-Registrierung enthalten.

[MUST] Die Methodennamen muessen `AddWebApi(...)`, `AddInfrastructure(...)` und `AddCore(...)` lauten.

[ALLOW] `Program.cs` darf wegen transitiver Referenzierung alle drei Module explizit registrieren.

[MUST] Die direkte Projektreferenz muss `WebApi -> Infrastructure -> Core` bleiben.

## Projekt- und Referenzregeln

[MUST] `WebApi` muss `Infrastructure` referenzieren.

[MUST] `Infrastructure` muss `Core` referenzieren.

[MUST_NOT] `Core` darf kein produktives Projekt referenzieren.

[MUST] `WebApi` muss technische Implementierungen ueber DI kennen.

[MUST] Ports muessen in `Core` liegen.

[MUST] Adapter muessen in `Infrastructure` liegen.

[MUST_NOT] `Core` darf keine HTTP-Schicht, keinen Host, keinen `HttpClient`, keine Options-Bindings und keinen DI-Container als Laufzeitdetail kennen.

## Domain-Driven-Design-Regeln

[MUST] Fachliche Begriffe, Value Objects, Domain Services, Regeln und fachliche Fehler muessen in `Core` liegen.

[MUST] Workflows in `Core` muessen Use Cases ueber Ports orchestrieren.

[MUST_NOT] Workflows duerfen fachliche Regeln nicht in langen Ablaufbloecken verstecken.

[MUST] Mapping zwischen API und Core muss explizit sein.

[MUST_NOT] HTTP-Contracts duerfen nicht automatisch als Domainmodelle verwendet werden.

## WebApi und Bootstrap

[MUST] `Program.cs` muss Host, Konfiguration, Logging, DI, Middleware-Pipeline und Routing aufbauen.

[MUST_NOT] Fachlogik darf nicht in `Program.cs` liegen.

[MUST] Controller oder Minimal-API-Endpoints muessen Requests validieren, Use Cases aufrufen und Ergebnisse in HTTP-Antworten mappen.

[ALLOW_IF] Middleware und Filter duerfen HTTP-nahe Cross-Cutting Concerns wie Fehler, Auth, Correlation IDs, Request Logging und CORS behandeln, wenn die Logik keinen fachlichen Use Case ersetzt.

## HTTP-API-Regeln

[MUST] Endpoints muessen ressourcen- oder use-case-orientiert benannt werden und passende HTTP-Methoden, Statuscodes und Routen verwenden.

[MUST] Request- und Response-DTOs muessen in `WebApi/Contracts/` liegen.

[MUST_NOT] Domain- und Core-Modelle duerfen nicht direkt als HTTP-Vertrag veroeffentlicht werden.

[MUST] Fehlerantworten muessen konsistent, maschinenlesbar und fuer Clients stabil sein.

[SHOULD] Fehlerantworten sollen eine Problem-Details-nahe Struktur verwenden. Abweichungen sind erlaubt, wenn ein bestehender stabiler API-Vertrag ein anderes Format vorgibt.

## Core-Regeln

[MUST] Use Cases und Workflows muessen klare fachliche Namen haben.

[MUST] Use Cases und Workflows muessen explizite Ergebnis- und Statusobjekte liefern.

[MUST] Lang laufende Operationen muessen `CancellationToken` akzeptieren und aus HTTP-Requests weitergereicht bekommen.

[MUST_NOT] DTOs duerfen keine rohen Transportobjekte externer APIs und keine HTTP-spezifischen Typen enthalten.

## Infrastructure, Provider und externe Dienste

[MUST] Externe Dienste, Datenbanken, Caches und Dateisysteme muessen ueber Ports aus `Core` angesprochen und in `Infrastructure` implementiert werden.

[MUST] Retry, Timeout, Backoff, Fallback, Persistenz und Konfigurationsbindung muessen in `Infrastructure` liegen.

[MUST] Parser und Adapter muessen Rohdaten an der Grenze in interne Modelle wandeln und relevante Quelleninformationen erhalten.

## Auth, Security und CORS

[MUST] Authentifizierung, Autorisierung und CORS muessen explizit konfiguriert werden.

[MUST_NOT] Unsichere Defaults duerfen nicht verwendet werden.

[MUST_NOT] Secrets duerfen nicht versioniert, geloggt oder in Fehlerantworten ausgegeben werden.

[MUST] Eingaben muessen validiert werden.

[MUST_NOT] Ausgaben duerfen keine unbeabsichtigten internen Diagnose- oder Infrastrukturdetails enthalten.

## Konfiguration

[MUST] Konfiguration muss in `WebApi` geladen und in `Infrastructure` typisiert gebunden und validiert werden.

[MUST] Pflichtkonfiguration muss beim Start mit klarer Fehlermeldung scheitern.

[MUST_NOT] `Core` darf keine Konfiguration direkt lesen.

[MUST] Fachlich relevante Parameter muessen explizit uebergeben werden.

## Fehler, Logging und Observability

[MUST] Fachliche Fehler und Statusmodelle muessen in `Core` liegen.

[MUST] Technische Fehler muessen in `Infrastructure` entstehen und dort mit Kontext angereichert werden.

[MUST] API-Fehler muessen zentral in HTTP-Antworten gemappt werden.

[MUST_NOT] Logs duerfen stabile Client-Fehlervertraege nicht ersetzen.

[MUST] Correlation IDs, strukturierte Logs und Health Checks muessen fuer produktionsnahe Web APIs vorhanden sein.

## OpenAPI und API-Versionierung

[MUST] Oeffentliche oder teamuebergreifend genutzte APIs muessen Routen, Statuscodes, Request- und Response-Contracts ueber OpenAPI dokumentieren.

[MUST_NOT] Breaking Changes duerfen nicht stillschweigend eingefuehrt werden.

[MUST] Breaking Changes muessen API-Versionierung oder eine klare Migration erhalten.

[MUST] Beispiele, Fehlerantworten und Auth-Anforderungen muessen Teil der API-Dokumentation sein, wenn Clients darauf angewiesen sind.

## Code-Regeln

[MUST] File-scoped namespaces und `Nullable` muessen verwendet werden.

[MUST] `ImplicitUsings` muss deaktiviert sein.

[MUST] Namespaces muessen ueber `GlobalUsings.cs` verwaltet werden.

[MUST] Jeder oeffentliche Typ muss in einer eigenen Datei liegen.

[SHOULD] Records sollen fuer immutable DTOs, Value Objects und Ergebnisobjekte verwendet werden. Abweichungen sind erlaubt, wenn Framework-Binding, Serialisierung oder bestehende API-Vertraege Klassen erfordern.

[MUST_NOT] Rohe API-DTOs duerfen nicht in `Core` verwendet werden.

[MUST_NOT] Domainmodelle duerfen nicht als direkte HTTP-Response-Contracts verwendet werden.

## Unit Tests, Integrationstests und API-Tests

[MUST] Fachliche Regeln und Workflows muessen in `Core.Tests` mit Fake-Ports und kontrollierten Testdaten abgesichert werden.

[MUST] Infrastrukturtests muessen Adapter, Provider, Parser, Retry, Persistenz, Serialisierung und Konfigurationsbindung ohne instabile Live-Dienste pruefen.

[MUST] WebApi-Tests muessen Routing, Statuscodes, Auth, Validierung, Fehlerantworten, OpenAPI-relevante Contracts und DI-Verkabelung deterministisch pruefen.
