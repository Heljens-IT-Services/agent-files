# DEVELOPER.NetWebApi.md

Stand: 2026-08-05

## Zweck

Diese Datei gilt fuer .NET-Web-APIs. Zugehoerige allgemeine und anwendungsbezogene Regeldateien werden ueber [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgeloest.

## Zielbild

[MUST] Eine .NET-Web-API muss die produktiven Hauptprojekte `<Name>.WebApi`, `<Name>.Infrastructure` und `<Name>.Core` enthalten.

[MUST] `WebApi` muss Composition Root fuer Host, Konfiguration, Dependency Injection, Middleware, Routing und HTTP-Vertraege sein.

## Module und Bootstrap

[MUST] Die DI-Erweiterungsmethoden muessen `AddWebApi(...)`, `AddInfrastructure(...)` und `AddCore(...)` heissen.

[MUST] `Program.cs` muss Host, Konfiguration, Logging, Dependency Injection, Middleware-Pipeline und Routing aufbauen.

[ALLOW_IF] Middleware und Filter duerfen HTTP-nahe Querschnittsthemen wie Fehlerabbildung, Authentifizierung, Correlation IDs, Request Logging und CORS behandeln, wenn sie keinen fachlichen Use Case ersetzen.

## HTTP-Vertraege

[MUST] Controller oder Minimal-API-Endpoints muessen Requests validieren, Use Cases aufrufen und Ergebnisse in HTTP-Antworten mappen.

[MUST] Endpoints muessen ressourcen- oder use-case-orientiert benannt werden und passende HTTP-Methoden, Statuscodes und Routen verwenden.

[MUST] Request- und Response-DTOs muessen in `WebApi/Contracts/` liegen.

[MUST_NOT] Domain- oder Core-Modelle duerfen nicht direkt als HTTP-Vertraege veroeffentlicht werden.

[SHOULD] Fehlerantworten sollen eine Problem-Details-nahe Struktur verwenden. Abweichungen sind erlaubt, wenn ein bestehender stabiler API-Vertrag ein anderes Format vorgibt.

[MUST] API-Fehler muessen zentral in HTTP-Antworten gemappt werden.

[MUST_IF] Faellt eine notwendige Infrastruktur- oder Upstream-Abhaengigkeit ohne fachlich definierten Fallback aus, muss die API den stabilen Fehlervertrag mit einem passenden Nicht-2xx-Statuscode zurueckgeben.

[MUST] Der Cancellation-Token eines HTTP-Requests muss an aufgerufene Use Cases und Infrastrukturports weitergereicht werden.

## Auth, Security und Observability

[MUST] Authentifizierung, Autorisierung und CORS muessen explizit konfiguriert werden.

[MUST_NOT] Unsichere Defaults duerfen nicht verwendet werden.

[MUST_IF] Correlation IDs, strukturierte Logs und Health Checks muessen vorhanden sein, wenn die Web API produktionsnah betrieben wird.

## OpenAPI und API-Versionierung

[MUST] Oeffentliche oder teamuebergreifend genutzte APIs muessen Routen, Statuscodes sowie Request- und Response-Vertraege ueber OpenAPI dokumentieren.

[MUST_NOT] Breaking Changes duerfen nicht stillschweigend eingefuehrt werden.

[MUST] Breaking Changes muessen eine API-Versionierung oder dokumentierte Migration erhalten.

[MUST_IF] Beispiele, Fehlerantworten und Auth-Anforderungen muessen dokumentiert sein, wenn Clients sie fuer die Integration benoetigen.

## Tests

[MUST] WebApi-Tests muessen Routing, Statuscodes, Authentifizierung, Validierung, Fehlerantworten, HTTP-Vertraege und DI-Verkabelung deterministisch pruefen.

[MUST_IF] Tests geaenderter oder neuer WebApi-Fehlerpfade muessen nachweisen, dass Ausfaelle notwendiger Abhaengigkeiten nicht als erfolgreiche `2xx`-Antwort erscheinen.
