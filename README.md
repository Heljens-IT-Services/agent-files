# engineering-blueprint

`engineering-blueprint` enthaelt wiederverwendbare Arbeitsregeln, Strukturvorgaben und Entwicklerleitlinien fuer Softwareprojekte bei Heljens IT Services.

Das Repository dient als Vorlage und Referenz fuer Menschen und AI-/Code-Agents. Es beschreibt, welche Dokumente in Projekten vorhanden sein sollen, wie diese Dokumente gepflegt werden und welche technologieuebergreifenden bzw. technologiespezifischen Entwicklungsregeln gelten.

## Zweck

Dieses Repository soll Projektstarts, Refactorings und Agent-Arbeit vereinheitlichen. Es definiert einen kompakten Dokumentationsrahmen fuer Architektur, Projektwissen, Struktur, Coding-Regeln und technologiespezifische Patterns.

Typische Nutzung:

- neue Repositories mit konsistenten Agent- und Developer-Regeln aufsetzen
- bestehende Repositories auf klare Struktur- und Architekturvorgaben ausrichten
- AI-/Code-Agents mit eindeutiger Pflichtlektuere und Prioritaeten steuern
- wiederverwendbare Regeln fuer Angular, .NET Console und .NET Web API bereitstellen

## Wichtige Dateien

| Pfad | Zweck |
|---|---|
| `agent-files/AGENTS.md` | Vorlage fuer `AGENTS.md` in Ziel-Repositories. |
| `agent-files/agents/PROJECT.md` | Vorlage fuer projektspezifische Regeln, Fakten und Domaenenwissen. |
| `agent-files/agents/DEVELOPER.md` | Vorlage fuer technologieuebergreifende Architektur-, Clean-Code-, Security- und Testregeln. |
| `agent-files/agents/DEVELOPER.Angular.md` | Vorlage fuer Angular-spezifische Entwicklungsregeln. |
| `agent-files/agents/DEVELOPER.NetConsole.md` | Vorlage fuer .NET-Konsolenanwendungen. |
| `agent-files/agents/DEVELOPER.NetWebApi.md` | Vorlage fuer .NET-Web-APIs. |

## Dokumentenmodell

Die Vorlagen liegen in diesem Repository unter `agent-files/`. Beim Uebernehmen in ein Ziel-Repository werden sie in das Repository-Root kopiert: `agent-files/AGENTS.md` wird zu `AGENTS.md`, und `agent-files/agents/` wird zu `agents/`.

Die Zieldokumente sind bewusst getrennt:

- `AGENTS.md` beschreibt, welche Regeln Agents lesen muessen, welche Prioritaet sie haben und welche deontischen Regelmarker verwendet werden.
- `agents/PROJECT.md` enthaelt projektspezifisches Wissen, keine allgemeinen Technikregeln.
- `agents/DEVELOPER.md` enthaelt allgemeine Entwicklungsregeln.
- `agents/DEVELOPER.*.md` enthaelt spezifische Regeln fuer einen Technologie- oder Anwendungskontext.

Bei widerspruechlichen Vorgaben gilt die Prioritaet aus `AGENTS.md`.

Die Agent-Dateien verwenden ein kompaktes Marker-System wie `[MUST]`, `[MUST_NOT]`, `[ALLOW_IF]`, `[SHOULD]`, `[OPTIONAL]` und `[PRIORITY]`, damit Pflichten, Verbote, Erlaubnisse, Defaults und Vorrangregeln eindeutig unterscheidbar sind.

## Verwendung in Projekten

Beim Aufsetzen eines neuen Projekts werden die relevanten Dateien aus diesem Repository uebernommen und an den Projektkontext angepasst.

Minimal empfohlen im Ziel-Repository:

```text
README.md
AGENTS.md
agents/
  PROJECT.md
  DEVELOPER.md
```

Je nach Technologie kommt mindestens eine passende spezifische Datei hinzu, z. B.:

```text
agents/DEVELOPER.Angular.md
agents/DEVELOPER.NetConsole.md
agents/DEVELOPER.NetWebApi.md
```

## Pflege

Dieses Repository ist eine lebende Vorlage. Aenderungen an Architektur-, Struktur- oder Coding-Regeln sollen direkt in den passenden Dateien dokumentiert werden.

Pflegegrundsatz:

- Allgemeine Regeln gehoeren in der Vorlage nach `agent-files/agents/DEVELOPER.md` und im Ziel-Repository nach `agents/DEVELOPER.md`.
- Technologiespezifische Regeln gehoeren in der Vorlage nach `agent-files/agents/DEVELOPER.*.md` und im Ziel-Repository nach `agents/DEVELOPER.*.md`.
- Projektspezifisches Wissen gehoert in der Vorlage nach `agent-files/agents/PROJECT.md` und im Ziel-Repository nach `agents/PROJECT.md`.
- Agent-Prioritaeten und Pflichtlektuere gehoeren in der Vorlage nach `agent-files/AGENTS.md` und im Ziel-Repository nach `AGENTS.md`.

## Status

Stand: Mai 2026. Die aktuellen spezifischen Developer-Vorlagen decken Angular, .NET-Konsolenanwendungen und .NET-Web-APIs ab. Die Vorlagen liegen unter `agent-files/` und sind fuer die Zielstruktur `AGENTS.md` plus `agents/` formuliert.
