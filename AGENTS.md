# AGENTS.md
Stand: April 2026

## Zweck

Diese Datei ist der verbindliche Einstiegspunkt für AI-/Code-Agents in diesem Repository. Sie legt fest, welche Dokumente vor Änderungen zu berücksichtigen sind, wie Regeln priorisiert werden und welche Qualitätskriterien für Code-Änderungen gelten.

Projektspezifische Informationen stehen in `agents/Repository.md`. Technologieübergreifende Architekturregeln stehen in `agents/Architecture.md`. Technologiespezifische Regeln stehen in den passenden `agents/Architecture.*.md`-Dateien.

Der Ordner `agents/` enthält bewusst gepflegte Agent- und Engineering-Regeln. Der Ordner `docs/` ist für ergänzende Langform-Dokumentation wie ADRs, API-Spezifikationen, Domänenbeschreibungen, Betriebsdokumentation oder Diagramme gedacht.

| Pfad | Zweck |
|---|---|
| `README.md` | Liefert den kompakten Einstieg in das Repository. |
| `agents/STRUCTURE.md` | Beschreibt die aktuelle Repository-Struktur. |
| `agents/PROJECT.md` | Enthält projektspezifische Regeln, Fakten, sowie Domänwissen. |
| `agents/DEVELOPER.md` | Definiert allgemeine Entwicklungsregeln für dieses Repository. |
| `agents/DEVELOPER.*.md` | Ergänzt technologie- oder kontextspezifische Entwicklerregeln. |

## Priorität von Anweisungen

1. `agents/Repository.md` lesen, um Projektziel, Fachregeln, wichtige Pfade, Build-/Test-Kommandos und lokale Besonderheiten zu verstehen.
2. `agents/Architecture.md` lesen, um die allgemeinen Architektur-, Clean-Code- und Qualitätsregeln zu kennen.
3. Die passende Technologie-Datei lesen, zum Beispiel `agents/Architecture.Angular.md` für Angular oder `agents/Architecture.NETConsole.md` für .NET-Konsolenanwendungen.
4. Weitere lokale Dokumente wie `README.md`, `STRUCTURE.md`, ADRs, API-Spezifikationen oder Schema-Dateien lesen, wenn die Änderung deren Bereich berührt.

Wenn eine passende `agents/Architecture.*.md` fehlt, wird nach den vorhandenen Patterns des Repositories gearbeitet. Eine neue Technologie-Regeldatei wird nur ergänzt, wenn die Regel dauerhaft für mehrere Änderungen relevant ist.

## Regelpriorität

Bei widersprüchlichen Vorgaben gilt diese Reihenfolge:

1. Direkte User-Anweisung im aktuellen Task.
2. Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung.
3. `AGENTS.md`.
4. `agents/Repository.md`.
5. `agents/Architecture.md`.
6. Passende `agents/Architecture.*.md`.
7. Bestehender Code-Stil und lokale Patterns.

Repository-spezifische Regeln dürfen allgemeine Architekturregeln einschränken, müssen aber in `agents/Repository.md` oder einer lokalen ADR begründet sein.

Abweichungen sind erlaubt, wenn sie für das konkrete Repository sinnvoller sind.

## STRUCTURE.md

Index wichtiger Dateien und Einstiegspunkte.

Beispiel:

| Pfad | Typ | Zweck |
|---|---|---|
| `Program.cs` | Program | Startet die Anwendung und verdrahtet zentrale Abhängigkeiten. |

## PROJECT.md

Hier befinden sich fachlicher Kontext und Domänenwissen. Keine Technikdetails, keine Strukturregeln, keine Implementierungsvorgaben.

- `agents/Repository.md` wird aktualisiert, wenn sich Projektziel, wichtige Pfade, Build-/Test-Kommandos, Fachregeln oder externe Verträge ändern.
- `agents/Architecture.md` und `agents/Architecture.*.md` werden angepasst, wenn eine Regel allgemein gelten soll.
- Struktur- oder Typenübersichten werden aktualisiert, wenn das Repository solche Dokumente verwendet.
- Entscheidungen mit langfristiger Wirkung werden als ADR oder in der naheliegendsten Dokumentation festgehalten.

`agents/DEVELOPER.md` enthält technologieübergreifende Architektur-, Clean-Code-, Qualitäts-, Security- und Testregeln. Diese Regeln gelten für alle Implementierungen, sofern keine passendere `agents/DEVELOPER.*.md` eine spezifischere Vorgabe macht.

Technologie- und kontextspezifische Ergänzungen liegen in eigenen Dateien.

Agents lesen zuerst `agents/DEVELOPER.md` und anschließend die passende spezifische Datei. Bei mehreren passenden Dateien gilt die Datei, die dem zu ändernden Projekt oder Technologie-Stack am nächsten liegt.
