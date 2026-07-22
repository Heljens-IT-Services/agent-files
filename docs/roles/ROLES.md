# ROLES.md

## Zweck

Diese Datei ist die Lookup-Datei fuer Rollen und deren kontextabhaengige Regeldateien.

## Verwendung

[MUST_IF] Der Agent muss die in der Tabelle als `Allgemein` gekennzeichnete Regeldatei derselben Rolle zusaetzlich lesen und ihre rollenbasierte Prioritaetsreihenfolge anwenden, wenn eine spezialisierte Regeldatei dieser Rolle relevant ist.

## Rollen

| Rolle | Typ | Regeldatei | Lesen und verwenden, wenn | Zweck |
|---|---|---|---|---|
| Developer | Allgemein | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Implementierung, Refactoring, Code-Review, technische Planung oder Teststrategie relevant sind. | Technologieuebergreifende Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) | C# oder .NET relevant sind. | Allgemeine C#- und .NET-Regeln. |
| Developer | Spezialisiert | [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) | Angular relevant ist. | Angular-spezifische Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Html.md) | HTML oder Markup relevant sind. | HTML- und Markup-Regeln. |
| Developer | Spezialisiert | [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Css.md) | CSS, Styling oder UI-nahe Praesentationsregeln relevant sind. | CSS-, Styling- und UI-nahe Regeln. |
| Developer | Spezialisiert | [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.TypeScript.md) | TypeScript relevant ist. | TypeScript-spezifische Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) | Eine geschichtete .NET-Anwendung oder eine .NET-Konsole bzw. .NET-Web-API relevant ist. | Gemeinsame Regeln fuer Entry-, Infrastructure- und Core-Projekte. |
| Developer | Spezialisiert | [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) | Eine .NET-Konsolenanwendung relevant ist. | Regeln fuer .NET-Konsolenanwendungen. |
| Developer | Spezialisiert | [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) | Eine .NET-Web-API relevant ist. | Regeln fuer .NET-Web-APIs. |
