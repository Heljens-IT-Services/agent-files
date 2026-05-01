# AGENTS.md
Stand: April 2026

## Zweck

Diese Datei definiert verbindliche Arbeitsregeln für AI-/Code-Agents in diesem Repository. 

## Pflichtlektüre

| Pfad | Zweck |
|---|---|
| `README.md` | Liefert den kompakten Einstieg in das Repository. |
| `agents/STRUCTURE.md` | Beschreibt die aktuelle Repository-Struktur. |
| `agents/PROJECT.md` | Enthält projektspezifische Regeln, Fakten, sowie Domänwissen. |
| `agents/DEVELOPER.md` | Definiert allgemeine Entwicklungsregeln für dieses Repository. |
| `agents/DEVELOPER.*.md` | Ergänzt technologie- oder kontextspezifische Entwicklerregeln. |

## Priorität von Anweisungen

Bei widersprüchlichen Vorgaben gilt die Reihenfolge:

1. Direkte User-Anweisung im aktuellen Task.
2. Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung.
3. Passende `agents/DEVELOPER.*.md`.
4. `agents/DEVELOPER.md`.
5. `AGENTS.md`.
6. `agents/PROJECT.md`.
7. Bestehender Code-Stil und lokale Patterns.

## Dokumentenpflege

| Pfad | Pflege-Regel |
|---|---|
| `README.md` | Bei Änderungen am Einstieg oder an den ersten Schritten. |
| `agents/STRUCTURE.md` | Bei Änderungen an Struktur, Ordnern oder Ablagelogik. |
| `agents/PROJECT.md` | Bei Änderungen an projektspezifischen Regeln, Fakten oder Pfaden. |
| `agents/DEVELOPER.md` | Bei Änderungen an allgemeinen Entwicklungsregeln. |
| `agents/DEVELOPER.*.md` | Bei Änderungen an technologie- oder kontextspezifischen Regeln. |

## README.md

Eine gute `README.md` ist kurz, klar und auf schnellen Einstieg ausgelegt. Typische Struktur:

- Titel und Kurzbeschreibung
- Zweck oder Nutzen des Projekts
- Voraussetzungen
- Installation oder Setup
- Start, Build und Tests
- Wichtige Links oder Verweise

Abweichungen sind erlaubt, wenn sie für das konkrete Repository sinnvoller sind.

## STRUCTURE.md

Index wichtiger Dateien und Einstiegspunkte.

Beispiel:

| Pfad | Typ | Zweck |
|---|---|---|
| `Program.cs` | Program | Startet die Anwendung und verdrahtet zentrale Abhängigkeiten. |

## PROJECT.md

Hier befinden sich fachlicher Kontext und Domänenwissen. Keine Technikdetails, keine Strukturregeln, keine Implementierungsvorgaben.

## DEVELOPER.md

`agents/DEVELOPER.md` enthält technologieübergreifende Architektur-, Clean-Code-, Qualitäts-, Security- und Testregeln. Diese Regeln gelten für alle Implementierungen, sofern keine passendere `agents/DEVELOPER.*.md` eine spezifischere Vorgabe macht.

Technologie- und kontextspezifische Ergänzungen liegen in eigenen Dateien:

| Pfad | Gilt für |
|---|---|
| `agents/DEVELOPER.Angular.md` | Angular-Anwendungen und Angular-nahe Frontend-Teile. |
| `agents/DEVELOPER.NetConsole.md` | .NET-Konsolenanwendungen mit `Console -> Infrastructure -> Core`-Struktur. |
| `agents/DEVELOPER.NetWebApi.md` | .NET-Web-APIs mit `WebApi -> Infrastructure -> Core`-Struktur. |

Agents lesen zuerst `agents/DEVELOPER.md` und anschließend die passende spezifische Datei. Bei mehreren passenden Dateien gilt die Datei, die dem zu ändernden Projekt oder Technologie-Stack am nächsten liegt.
