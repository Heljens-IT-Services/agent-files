# ROLES.md

## Zweck

Diese Datei definiert das Rollenmodell und ist die Lookup-Datei für kontextabhängige Rollendateien.

## Verwendung

[MUST] Rollen sind unabhängige, kombinierbare Verantwortungs- und Qualitätsregelwerke; sie sind weder exklusive Personas noch Prozessschritte.

[MUST] Alle für den aktuellen Task relevanten Rollen müssen gelesen und angewendet werden.

[MUST_NOT] Rollen dürfen nicht allein wegen ihrer Existenz, einer Persona oder einer festen Workflow- oder Skill-Zuordnung geladen werden.

[MUST_IF] Wird ein weiterer Verantwortungsbereich im Task relevant, muss die zugehörige Rolle nachgeladen werden.

[MUST_IF] Wenn eine spezialisierte Regeldatei relevant ist, muss der Agent zusätzlich die in der Tabelle als `Allgemein` gekennzeichnete Regeldatei derselben Rolle lesen.

## Rollenagnostische Leitplanken

[MUST] Regeln für das Rollensystem oder alle Rollen gehören in diese Datei; rollenspezifische Regeln gehören in die passende Rollendatei.

[MUST] Allgemeine Agent-Governance ohne Rollenbezug gehört in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).

[MUST_IF] Rollen eingeführt oder entkoppelt werden, müssen bestehende Regeln auf ihren fachlich allgemeinsten Scope klassifiziert werden.

[MUST_NOT] Regeln dürfen nicht allein wegen ihrer historischen Ablage in einer Rollendatei verbleiben.

## Rollen

| Rolle | Typ | Regeldatei | Lesen und verwenden, wenn | Zweck |
|---|---|---|---|---|
| Developer | Allgemein | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Architektur, Implementierung, Refactoring, Code-Review oder technische Planung relevant sind. | Technologieübergreifende Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) | Developer-Verantwortung sowie C# oder .NET relevant sind. | Allgemeine C#- und .NET-Regeln. |
| Developer | Spezialisiert | [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) | Developer-Verantwortung sowie Angular relevant sind. | Angular-spezifische Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Html.md) | Developer-Verantwortung sowie HTML oder Markup relevant sind. | HTML- und Markup-Regeln. |
| Developer | Spezialisiert | [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Css.md) | Developer-Verantwortung sowie CSS, Styling oder UI-nahe Präsentation relevant sind. | CSS-, Styling- und UI-nahe Regeln. |
| Developer | Spezialisiert | [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.TypeScript.md) | Developer-Verantwortung sowie TypeScript relevant sind. | TypeScript-spezifische Entwicklungsregeln. |
| Developer | Spezialisiert | [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) | Developer-Verantwortung sowie eine geschichtete .NET-Anwendung, .NET-Konsole oder .NET-Web-API relevant sind. | Gemeinsame Regeln für Entry-, Infrastructure- und Core-Projekte. |
| Developer | Spezialisiert | [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) | Developer-Verantwortung sowie eine .NET-Konsolenanwendung relevant sind. | Regeln für .NET-Konsolenanwendungen. |
| Developer | Spezialisiert | [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) | Developer-Verantwortung sowie eine .NET-Web-API relevant ist. | Regeln für .NET-Web-APIs. |
