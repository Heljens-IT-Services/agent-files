# agent-files

`agent-files` enthaelt wiederverwendbare Vorlagen fuer `AGENTS.md` sowie projekt-, technologie- und kontextspezifische Dateien unter `agents/` bei Heljens IT Services.

Das Repository dient als Vorlage fuer Ziel-Repositories, in denen AI-/Code-Agents klare Pflichtlektuere, Prioritaeten, Projektkontext und Entwicklungsregeln erhalten sollen.

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
| `files/agents/PROJECT.md` | Vorlage fuer projektspezifischen Arbeitskontext, Begriffe, Abgrenzungen und fachliche Leitplanken. |
| `files/agents/DEVELOPER.md` | Vorlage fuer allgemeine Architektur-, Qualitaets-, Security- und Testregeln. |
| `files/agents/DEVELOPER.Project.md` | Vorlage fuer projektspezifische technische Leitplanken und Entwicklungsregeln. |
| `files/agents/DEVELOPER.CSharpNet.md` | Vorlage fuer allgemeine C#- und .NET-Regeln unabhaengig vom Einstiegstyp. |
| `files/agents/DEVELOPER.Angular.md` | Vorlage fuer Angular-spezifische Entwicklungsregeln. |
| `files/agents/DEVELOPER.NetConsole.md` | Vorlage fuer .NET-Konsolenanwendungen auf Basis von `net10.0`. |
| `files/agents/DEVELOPER.NetWebApi.md` | Vorlage fuer .NET-Web-APIs auf Basis von `net10.0`. |

## Dokumentenmodell

Die Zieldokumente sind bewusst getrennt:

- `AGENTS.md` definiert Pflichtlektuere, Prioritaeten und die verwendeten Regelmarker.
- `agents/PROJECT.md` enthaelt projektspezifischen Arbeitskontext, stabile Begriffe, Abgrenzungen und fachliche Leitplanken.
- `agents/DEVELOPER.md` enthaelt technologieuebergreifende Entwicklungsregeln.
- `agents/DEVELOPER.Project.md` enthaelt projektspezifische technische Leitplanken und Entwicklungsregeln.
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
agents/DEVELOPER.CSharpNet.md
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

Stand: 2026-05-16.

Aktuell enthaelt das Repository Vorlagen fuer:

- allgemeine Agent-Regeln
- allgemeine technologieuebergreifende Developer-Regeln
- projektspezifischen Projektkontext
- projektspezifische technische Leitplanken
- allgemeine C#- und .NET-Regeln
- Angular
- .NET-Konsolenanwendungen
- .NET-Web-APIs
