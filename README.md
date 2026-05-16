# agent-files

`agent-files` enthaelt die verbindlich veroeffentlichten Agent- und Developer-Anweisungen von Heljens IT Services.

Das Repository ist bewusst einfach aufgebaut: Die relevanten Markdown-Dateien liegen direkt unter `docs/` und werden von GitHub Pages unmittelbar veroeffentlicht. Es gibt keine separate HTML-, CSS- oder Build-Schicht.

## GitHub Pages

Die veroeffentlichte Referenz liegt unter:

`https://heljens-it-services.github.io/agent-files/`

Dieses Repository ist ein GitHub-Pages-Projekt. Die Pages-Ausgabe wird aus dem Branch `main` und dem Ordner `docs/` bereitgestellt.

Die Dateien sind direkt unter festen Markdown-URLs erreichbar, zum Beispiel:

- `https://heljens-it-services.github.io/agent-files/AGENTS.md`
- `https://heljens-it-services.github.io/agent-files/PROJECT.md`
- `https://heljens-it-services.github.io/agent-files/DEVELOPER.md`
- `https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md`

Andere Repositories und Projekte sollen auf diese URLs verweisen, wenn sie die aktuell gueltigen Arbeitsanweisungen fuer KI-Agenten, Codex oder vergleichbare Entwicklungsassistenten referenzieren wollen.

## Zweck

Das Repository dient als zentrale, online referenzierbare Single Source of Truth fuer Agent- und Developer-Anweisungen.

Die Markdown-Dateien sind von deontischer Logik inspiriert. Sie arbeiten mit expliziten Regelmarkern, um Verpflichtungen, Verbote, Erlaubnisse, Prioritaeten und bedingte Geltungsbereiche fuer Agents und Entwicklungsassistenten klar und maschinenlesbar zu formulieren.

Typische Nutzung:

- `AGENTS.md` als verbindliche Pflichtlektuere fuer Agents referenzieren
- projektbezogene und technologiespezifische Developer-Regeln zentral bereitstellen
- andere Repositories auf stabile, direkt aufrufbare Markdown-Dateien verweisen lassen

## Struktur

Die veroeffentlichten Dokumente liegen direkt unter `docs/` in flacher Hierarchie.

Aktuell relevante Dateien sind:

| Pfad | Url | Zweck |
|---|---|---|
| `docs/AGENTS.md` | `https://heljens-it-services.github.io/agent-files/AGENTS.md` | Pflichtlektuere, Prioritaeten und Konfliktlogik fuer Agents. |
| `docs/PROJECT.md` | `https://heljens-it-services.github.io/agent-files/PROJECT.md` | Projektspezifischer Arbeitskontext, Begriffe und fachliche Leitplanken. |
| `docs/DEVELOPER.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` | Allgemeine technologieuebergreifende Entwicklungsregeln. |
| `docs/DEVELOPER.Project.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.Project.md` | Projektspezifische technische Leitplanken und Entwicklungsregeln. |
| `docs/DEVELOPER.CSharpNet.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.CSharpNet.md` | Allgemeine C#- und .NET-Regeln. |
| `docs/DEVELOPER.Angular.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md` | Angular-spezifische Entwicklungsregeln. |
| `docs/DEVELOPER.Html.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md` | HTML- und Markup-Regeln. |
| `docs/DEVELOPER.Css.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md` | CSS-, Styling- und UI-nahe Regeln. |
| `docs/DEVELOPER.TypeScript.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md` | TypeScript-spezifische Entwicklungsregeln. |
| `docs/DEVELOPER.NetConsole.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetConsole.md` | Regeln fuer .NET-Konsolenanwendungen. |
| `docs/DEVELOPER.NetWebApi.md` | `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetWebApi.md` | Regeln fuer .NET-Web-APIs. |

## Pflege

Die Dateien unter `docs/` sind die veroeffentlichten Quelldateien.

Aenderungen an den Agent- und Developer-Anweisungen erfolgen direkt in diesen Markdown-Dateien. Es gibt bewusst keine separate Generierung und keinen zusaetzlichen Sync-Schritt.

Die Regeln verwenden dazu Marker wie `MUST`, `MUST_IF`, `MUST_NOT`, `ALLOW`, `ALLOW_IF`, `SHOULD`, `OPTIONAL` und `PRIORITY`, damit die normative Bedeutung jeder Anweisung moeglichst eindeutig bleibt.

## Verwendung in Projekten

Andere Repositories koennen direkt auf die benoetigten Dokumente unter GitHub Pages verweisen, zum Beispiel:

```text
https://heljens-it-services.github.io/agent-files/AGENTS.md
https://heljens-it-services.github.io/agent-files/DEVELOPER.md
https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md
```

Damit ist klar, welche Fassung jeweils veroeffentlicht und referenziert wird.
