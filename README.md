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
| `agent-files/AGENTS.md` | Einstiegspunkt fuer AI-/Code-Agents mit Pflichtlektuere, Prioritaeten und Pflege-Regeln. |
| `agent-files/agents/PROJECT.md` | Platz fuer projektspezifische Regeln, Fakten und Domaenenwissen. |
| `agent-files/agents/DEVELOPER.md` | Technologieuebergreifende Architektur-, Clean-Code-, Security- und Testregeln. |
| `agent-files/agents/DEVELOPER.Angular.md` | Angular-spezifische Entwicklungsregeln. |
| `agent-files/agents/DEVELOPER.NetConsole.md` | Entwicklungsregeln fuer .NET-Konsolenanwendungen. |
| `agent-files/agents/DEVELOPER.NetWebApi.md` | Entwicklungsregeln fuer .NET-Web-APIs. |

## Dokumentenmodell

Die Dokumente sind bewusst getrennt:

- `agent-files/AGENTS.md` beschreibt, welche Regeln Agents lesen muessen und welche Prioritaet sie haben.
- `agent-files/agents/PROJECT.md` enthaelt projektspezifisches Wissen, keine allgemeinen Technikregeln.
- `agent-files/agents/DEVELOPER.md` enthaelt allgemeine Entwicklungsregeln.
- `agent-files/agents/DEVELOPER.*.md` enthaelt spezifische Regeln fuer einen Technologie- oder Anwendungskontext.

Bei widerspruechlichen Vorgaben gilt die Prioritaet aus `agent-files/AGENTS.md`.

## Verwendung in Projekten

Beim Aufsetzen eines neuen Projekts werden die relevanten Dateien aus diesem Repository uebernommen und an den Projektkontext angepasst.

Minimal empfohlen:

```text
README.md
agent-files/
  AGENTS.md
  agents/
    PROJECT.md
    DEVELOPER.md
```

Je nach Technologie kommt mindestens eine passende spezifische Datei hinzu, z. B.:

```text
agent-files/agents/DEVELOPER.Angular.md
agent-files/agents/DEVELOPER.NetConsole.md
agent-files/agents/DEVELOPER.NetWebApi.md
```

## Pflege

Dieses Repository ist eine lebende Vorlage. Aenderungen an Architektur-, Struktur- oder Coding-Regeln sollen direkt in den passenden Dateien dokumentiert werden.

Pflegegrundsatz:

- Allgemeine Regeln gehoeren in `agent-files/agents/DEVELOPER.md`.
- Technologiespezifische Regeln gehoeren in `agent-files/agents/DEVELOPER.*.md`.
- Projektspezifisches Wissen gehoert in `agent-files/agents/PROJECT.md`.
- Agent-Prioritaeten und Pflichtlektuere gehoeren in `agent-files/AGENTS.md`.

## Status

Stand: Mai 2026. Die aktuellen spezifischen Developer-Dateien decken Angular, .NET-Konsolenanwendungen und .NET-Web-APIs ab.
