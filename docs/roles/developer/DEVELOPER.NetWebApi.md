# DEVELOPER.NetWebApi.md

Stand: 2026-08-05

## Zweck

Diese Datei gilt für .NET-Web-APIs. Zugehörige allgemeine und anwendungsbezogene Regeldateien werden über [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgelöst.

## Zielbild

[MUST] Eine .NET-Web-API muss die produktiven Hauptprojekte `<Name>.WebApi`, `<Name>.Infrastructure` und `<Name>.Core` enthalten.

[MUST] `WebApi` muss Composition Root für Host, Konfiguration, Dependency Injection, Middleware, Routing und HTTP-Verträge sein.

## Module und Bootstrap

[MUST] Die DI-Erweiterungsmethoden müssen `AddWebApi(...)`, `AddInfrastructure(...)` und `AddCore(...)` heißen.

[MUST] `Program.cs` muss Host, Konfiguration, Logging, Dependency Injection, Middleware-Pipeline und Routing aufbauen.

[ALLOW_IF] Middleware und Filter dürfen HTTP-nahe Querschnittsthemen wie Fehlerabbildung, Authentifizierung, Correlation IDs, Request Logging und CORS behandeln, wenn sie keinen fachlichen Use Case ersetzen.

## HTTP-Verträge

[MUST] Controller oder Minimal-API-Endpoints müssen Requests validieren, Use Cases aufrufen und Ergebnisse in HTTP-Antworten mappen.

[MUST] Endpoints müssen ressourcen- oder use-case-orientiert benannt werden und passende HTTP-Methoden, Statuscodes und Routen verwenden.

[MUST] Request- und Response-DTOs müssen in `WebApi/Contracts/` liegen.

[MUST_NOT] Domain- oder Core-Modelle dürfen nicht direkt als HTTP-Verträge veröffentlicht werden.

[SHOULD] Fehlerantworten sollen eine Problem-Details-nahe Struktur verwenden. Abweichungen sind erlaubt, wenn ein bestehender stabiler API-Vertrag ein anderes Format vorgibt.

[MUST] API-Fehler müssen zentral in HTTP-Antworten gemappt werden.

[MUST_IF] Fällt eine notwendige Infrastruktur- oder Upstream-Abhängigkeit ohne fachlich definierten Fallback aus, muss die API den stabilen Fehlervertrag mit einem passenden Nicht-2xx-Statuscode zurückgeben.

[MUST] Der Cancellation-Token eines HTTP-Requests muss an aufgerufene Use Cases und Infrastrukturports weitergereicht werden.

## Auth, Security und Observability

[MUST] Authentifizierung, Autorisierung und CORS müssen explizit konfiguriert werden.

[MUST_NOT] Unsichere Defaults dürfen nicht verwendet werden.

[MUST_IF] Correlation IDs, strukturierte Logs und Health Checks müssen vorhanden sein, wenn die Web API produktionsnah betrieben wird.

## OpenAPI und API-Versionierung

[MUST] Öffentliche oder teamübergreifend genutzte APIs müssen Routen, Statuscodes sowie Request- und Response-Verträge über OpenAPI dokumentieren.

[MUST_NOT] Breaking Changes dürfen nicht stillschweigend eingeführt werden.

[MUST] Breaking Changes müssen eine API-Versionierung oder dokumentierte Migration erhalten.

[MUST_IF] Beispiele, Fehlerantworten und Auth-Anforderungen müssen dokumentiert sein, wenn Clients sie für die Integration benötigen.

## Tests

[MUST] WebApi-Tests müssen Routing, Statuscodes, Authentifizierung, Validierung, Fehlerantworten, HTTP-Verträge und DI-Verkabelung deterministisch prüfen.

[MUST_IF] Tests geänderter oder neuer WebApi-Fehlerpfade müssen nachweisen, dass Ausfälle notwendiger Abhängigkeiten nicht als erfolgreiche `2xx`-Antwort erscheinen.
