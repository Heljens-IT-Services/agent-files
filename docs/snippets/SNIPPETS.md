# SNIPPETS.md

Stand: 2026-10-15

## Zweck

Diese Datei ist die Lookup-Datei für verbindliche Code-Snippets. Ein Snippet legt fest, wie ein wiederkehrendes technisches Muster in Heljens-Projekten einheitlich umgesetzt wird.

## Verwendung

[MUST_IF] Wenn ein Task ein in der Tabelle beschriebenes Muster neu einführt, ändert oder erweitert, muss der Agent die verlinkte `SNIPPET.md` vollständig lesen und das Muster gemäß ihren Regeln übernehmen.

[MUST_IF] Wenn ein Projekt das Muster bereits in abweichender Form umsetzt, muss der Agent die Abweichung benennen und darf sie nur mit ausdrücklicher User-Freigabe oder abweichender Regel in `PROJECT.md` beibehalten oder erweitern.

[MUST] Snippet-Code muss beim Übernehmen an die Projektkonventionen angepasst werden, insbesondere Namespace-Präfix, `GlobalUsings.cs` und Projektstruktur. Fachliche Semantik, Verträge und Regeln des Snippets dürfen dabei nicht verändert werden.

[MUST_NOT] Snippets dürfen Rollen- oder Technologieregeln nicht duplizieren oder abschwächen; bei Widerspruch gilt die Prioritätsreihenfolge aus [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).

## Snippets

| ID | Snippet | Rolle | Technologie | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|---|
| `csharp-pagination` | C# Pagination | Developer | `csharp-net`, `net-web-api` | Listen-Endpunkte, Listen-Use-Cases oder Repository-Abfragen in einem C#-/.NET-Backend paginiert werden sollen. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/SNIPPET.md) | Einheitliche Seitenverträge, Header-Bindung und stabile Sortierung. |
| `api-error-codes` | API Error Codes | Developer | `csharp-net`, `net-web-api`, `angular` | Eine API fachliche Fehler an Clients meldet oder ein Frontend auf fachliche API-Fehler reagiert. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/SNIPPET.md) | Einheitliche Fehlercodes über ProblemDetails von Core bis Frontend. |
| `csharp-tenant-isolation` | C# Tenant Isolation | Developer | `csharp-net`, `net-application` | Eine C#-/.NET-Anwendung Daten mehrerer Mandanten in einer gemeinsamen PostgreSQL-Datenbank hält. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/SNIPPET.md) | Mandantentrennung über EF-Query-Filter und Row-Level-Security. |
| `openapi-angular-client` | OpenAPI Angular Client | Developer | `net-web-api`, `angular` | Ein Angular-Frontend eine .NET-Web-API desselben Repositorys konsumiert oder deren Verträge geändert werden. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/openapi-angular-client/SNIPPET.md) | Deterministischer OpenAPI-Vertrag, erzeugter Angular-Client und Drift-Prüfung. |
