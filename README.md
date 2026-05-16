# agent-files

`agent-files` enthaelt wiederverwendbare Vorlagen fuer `AGENTS.md` sowie projekt- und technologiespezifische Developer-Dateien bei Heljens IT Services.

Das Repository dient als Vorlage fuer Ziel-Repositories, in denen AI-/Code-Agents klare Pflichtlektuere, Prioritaeten und Entwicklungsregeln erhalten sollen.

## Zweck

Dieses Repository vereinheitlicht die Grundstruktur fuer Agent-Regeln und Developer-Leitplanken in Projekten.

Typische Nutzung:

- neue Repositories mit konsistenten Agent- und Developer-Dateien aufsetzen
- bestehende Repositories auf klare Regeldateien und Verantwortlichkeiten ausrichten
- AI-/Code-Agents mit eindeutiger Pflichtlektuere und Konfliktlogik steuern
- wiederverwendbare allgemeine, projektbezogene und technologiespezifische Regeln bereitstellen

## Struktur

Die Vorlagen liegen in diesem Repository unter `files/`.

Beim Uebernehmen in ein Ziel-Repository werden sie in die Zielstruktur kopiert:

- `files/AGENTS.md` wird zu `AGENTS.md`
- `files/agents/` wird zu `agents/`

## Wichtige Dateien

| Pfad | Zweck |
|---|---|
| `files/AGENTS.md` | Vorlage fuer `AGENTS.md` in Ziel-Repositories. |
| `files/agents/PROJECT.md` | Vorlage fuer projektspezifischen Arbeitskontext und fachliche Leitplanken. |
| `files/agents/DEVELOPER.md` | Vorlage fuer allgemeine Architektur-, Qualitaets-, Security- und Testregeln. |
| `files/agents/DEVELOPER.Project.md` | Vorlage fuer projektspezifische technische Entscheidungen. |
| `files/agents/DEVELOPER.Angular.md` | Vorlage fuer Angular-spezifische Entwicklungsregeln. |
| `files/agents/DEVELOPER.NetConsole.md` | Vorlage fuer .NET-Konsolenanwendungen. |
| `files/agents/DEVELOPER.NetWebApi.md` | Vorlage fuer .NET-Web-APIs. |

## Dokumentenmodell

Die Zieldokumente sind bewusst getrennt:

- `AGENTS.md` definiert Pflichtlektuere, Prioritaeten und die verwendeten Regelmarker.
- `agents/PROJECT.md` enthaelt projektspezifisches Wissen und fachliche Leitplanken.
- `agents/DEVELOPER.md` enthaelt technologieuebergreifende Entwicklungsregeln.
- `agents/DEVELOPER.Project.md` enthaelt projektspezifische technische Entscheidungen.
- `agents/DEVELOPER.*.md` enthaelt technologiespezifische Regeln fuer passende Kontexte.

Die Agent-Dateien verwenden ein kompaktes Marker-System wie `[MUST]`, `[MUST_IF]`, `[MUST_NOT]`, `[ALLOW]`, `[ALLOW_IF]`, `[SHOULD]`, `[OPTIONAL]` und `[PRIORITY]`.

Bei widerspruechlichen Vorgaben gilt die Prioritaetslogik aus `AGENTS.md`.

## Verwendung in Projekten

Minimal empfohlen im Ziel-Repository:

```text
README.md
AGENTS.md
agents/
  PROJECT.md
  DEVELOPER.md
```

Je nach Projekt kommen weitere Dateien hinzu, zum Beispiel:

```text
agents/DEVELOPER.Project.md
agents/DEVELOPER.Angular.md
agents/DEVELOPER.NetConsole.md
agents/DEVELOPER.NetWebApi.md
```

## Pflege

Dieses Repository ist eine lebende Vorlage. Regel- und Strukturaenderungen sollen direkt in der jeweils passenden Datei gepflegt werden.

Pflegegrundsatz:

- allgemeine Regeln in `files/agents/DEVELOPER.md`
- projektspezifisches Fachwissen in `files/agents/PROJECT.md`
- projektspezifische technische Entscheidungen in `files/agents/DEVELOPER.Project.md`
- technologiespezifische Regeln in `files/agents/DEVELOPER.*.md`
- Agent-Prioritaeten und Pflichtlektuere in `files/AGENTS.md`

## Status

Stand: Mai 2026.

Aktuell enthaelt das Repository Vorlagen fuer:

- allgemeine Agent- und Developer-Regeln
- projektspezifische Developer-Regeln
- Angular
- .NET-Konsolenanwendungen
- .NET-Web-APIs
