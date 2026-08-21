# TECHNOLOGIES.md

## Zweck

Diese Datei ist die einzige Lookup-Quelle für technologiespezifische Regeldateien. Die Command-Semantik steht in [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md).

## Verwendung

[MUST] `/technologies show <technology-id>` muss alle rollenbezogenen Regeldatei-Mappings der Technologie-ID beschreiben, ohne dadurch eine Rolle oder Regeldatei außerhalb ihres Verwendungskriteriums zu aktivieren.

[MUST] Eine Technologie-ID darf mehrere rollenbezogene Regeldatei-Mappings besitzen. Ein Mapping darf nur angewendet werden, wenn die zugehörige Rolle im aktuellen Task bereits relevant ist.

[MUST_NOT] Der Technologiekatalog darf allgemeine Rollenregeln aus [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md), [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) oder [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) nicht duplizieren.

## Technologien

| ID | Technologie | Rolle | Regeldatei | Lesen und verwenden, wenn | Zweck |
|---|---|---|---|---|---|
| `angular` | Angular | Developer | [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) | Developer-Verantwortung sowie Angular relevant sind. | Angular-spezifische Entwicklungsregeln. |
| `angular` | Angular | Tester | [TESTER.Angular.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.Angular.md) | Tester-Verantwortung sowie Angular relevant sind. | Angular-spezifische Testregeln. |
| `csharp-net` | C# und .NET | Developer | [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) | Developer-Verantwortung sowie C# oder .NET relevant sind. | Allgemeine C#- und .NET-Regeln. |
| `css` | CSS | Developer | [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Css.md) | Developer-Verantwortung sowie CSS, Styling oder UI-nahe Präsentation relevant sind. | CSS-, Styling- und UI-nahe Präsentationsregeln. |
| `html` | HTML | Developer | [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Html.md) | Developer-Verantwortung sowie HTML oder Markup relevant sind. | HTML- und Markup-Regeln. |
| `net-application` | .NET Application | Developer | [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) | Developer-Verantwortung sowie eine geschichtete .NET-Anwendung relevant ist. | Gemeinsame Regeln für geschichtete .NET-Anwendungen. |
| `net-console` | .NET Console | Developer | [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) | Developer-Verantwortung sowie eine .NET-Konsolenanwendung relevant ist. | Regeln für .NET-Konsolenanwendungen. |
| `net-web-api` | .NET Web API | Developer | [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) | Developer-Verantwortung sowie eine .NET-Web-API relevant ist. | Regeln für .NET-Web-APIs. |
| `playwright` | Playwright | Tester | [TESTER.Angular.Playwright.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.Angular.Playwright.md) | Tester-Verantwortung sowie Angular und Playwright für funktionale oder visuelle Tests relevant sind. | Playwright-Regeln für Angular. |
| `typescript` | TypeScript | Developer | [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.TypeScript.md) | Developer-Verantwortung sowie TypeScript relevant sind. | TypeScript-spezifische Entwicklungsregeln. |
