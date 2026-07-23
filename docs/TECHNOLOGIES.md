# TECHNOLOGIES.md

## Zweck

Diese Datei ordnet stabile Technologie-IDs den zugehoerigen Developer-Regeln zu. Die Command-Semantik steht in [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md).

## Verwendung

[MUST] `/technologies show <technology-id>` muss die verknuepfte Regeldatei laden, ohne dadurch ihre bedingte Relevanz oder ihren Scope zu erweitern.

[MUST_NOT] Der Technologiekatalog darf allgemeine Developer-Regeln aus [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) nicht duplizieren.

## Technologien

| ID | Technologie | URL | Zweck |
|---|---|---|---|
| `angular` | Angular | [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) | Angular-spezifische Entwicklungsregeln. |
| `csharp-net` | C# und .NET | [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) | Allgemeine C#- und .NET-Regeln. |
| `css` | CSS | [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Css.md) | CSS-, Styling- und UI-nahe Praesentationsregeln. |
| `html` | HTML | [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Html.md) | HTML- und Markup-Regeln. |
| `net-application` | .NET Application | [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) | Gemeinsame Regeln fuer geschichtete .NET-Anwendungen. |
| `net-console` | .NET Console | [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) | Regeln fuer .NET-Konsolenanwendungen. |
| `net-web-api` | .NET Web API | [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) | Regeln fuer .NET-Web-APIs. |
| `typescript` | TypeScript | [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.TypeScript.md) | TypeScript-spezifische Entwicklungsregeln. |
