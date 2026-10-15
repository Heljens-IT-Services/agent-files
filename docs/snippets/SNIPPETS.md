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
| `openapi-contract-first` | OpenAPI Contract First | Developer | `net-web-api`, `angular` | Eine HTTP-API entsteht oder ihre Endpunkte, Parameter oder Modelle geändert werden. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/SNIPPET.md) | Handgepflegter Vertrag, mit OpenAPI Generator erzeugte Controller-Basen, DTOs und Angular-Client. |
| `csharp-unit-of-work` | C# Unit of Work | Developer | `csharp-net`, `net-application` | Ein Use Case in einer C#-/.NET-Anwendung auf datenbankgestützte Persistenz zugreift. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/SNIPPET.md) | Eine Transaktion je fachlicher Operation über einen Core-Port. |
| `csharp-integration-tests` | C# Integration Tests | Developer, Tester | `net-web-api` | WebApi-Endpunkte, Persistenz, Mandantentrennung oder DI-Verkabelung integrativ getestet werden. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/csharp-integration-tests/SNIPPET.md) | WebApplicationFactory gegen PostgreSQL aus Testcontainers mit Testauthentifizierung. |
| `csharp-architecture-tests` | C# Architecture Tests | Developer, Tester | `csharp-net`, `net-application` | Eine geschichtete .NET-Anwendung angelegt wird oder Schichten, Verträge oder Persistenzgrenzen geändert werden. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/csharp-architecture-tests/SNIPPET.md) | Ausführbare Regeln für Schichten, Verträge, Persistenz und Mandanten. |
| `dotnet-build-hygiene` | .NET Build Hygiene | Developer | `csharp-net` | Ein .NET-Repository angelegt wird, seine Build-Konfiguration geändert wird oder Pakete geändert werden. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/SNIPPET.md) | Gemeinsame Build-, Analyse- und Paketbasis. |
| `angular-data-access` | Angular Data Access | Developer | `angular`, `typescript` | Ein Angular-Feature API-Daten lädt oder ändert oder Feature-State, Sitzung, Guards oder Interceptors entstehen. | [SNIPPET.md](https://heljens-it-services.github.io/agent-files/snippets/angular-data-access/SNIPPET.md) | Data-Access-Services, Signal-Stores, Guard und Interceptor. |
