# Skill: Code Analyse

## Zweck

Code, Branches, Legacy-Bereiche oder konkrete Fehlverhalten bewerten und einordnen.

## Verwenden

- Bei Analysefragen zu Bugs, Fehlverhalten, Seiteneffekten, Legacy-Code, Branches, Architektur, Wartbarkeit oder konkreten Code-Stellen.
- Verwenden, wenn eine Bewertung oder Einordnung erwartet wird.
- Default-Modus: mit Artefakt.
- Context-only-Modus: ohne Artefakt, wenn ein Workflow oder User dies explizit verlangt.
- Nicht automatisch bei "Fix bug X" verwenden. Das gehoert in einen Bugfix-Workflow, der Analyse explizit als Schritt benennt.
- Nicht verwenden, wenn Code nur gelesen oder als Kontext erklaert werden soll. Dann `code_lesen` nutzen.

## Vorgehen

1. Auftrag, Ausgangsfrage und naheliegende Annahmen knapp festhalten.
2. Betroffenen Scope bestimmen: Dateien, Symbole, Branches, Module, Datenfluesse, Schnittstellen oder Laufzeitkontext.
3. Read-only Evidenz aus Code, Diffs, Historie und vorhandenen Logs sammeln.
4. Bei Docker-Projekten Container-Logs und Datenbankinhalte nur lesend pruefen, wenn sie fuer die Analyse relevant sind.
5. Befunde mit Evidenz abgleichen und Unsicherheiten markieren.
6. Bewertung nach Ursache/Verhalten, Auswirkungen, Risiken, Wartbarkeit/Komplexitaet, Architekturgrenzen, Testbarkeit und Abhaengigkeiten/Schnittstellen strukturieren.
7. Im Default-Modus Analyseartefakt unter `docs/analysis-<scope>.md` erstellen.
8. Im Context-only-Modus Analyse nur in den Agenten-Kontext laden und knapp zusammenfassen.

## Grenzen

- Hauptsaechlich read-only arbeiten.
- Keine Produktivcode-Aenderungen vornehmen.
- Keine Debug-Logs, Repro-Skripte oder Tests anlegen, ausser der User fordert es explizit.
- Keine Tests oder Builds ausfuehren und keine externe Recherche durchfuehren; benoetigte Ergebnisse vorgelagert mit `code_testen` bzw. `research` laden.
- Schreibend ist nur das Analyseartefakt unter `docs/` vorgesehen, falls der Modus ein Artefakt verlangt.
- Bei unklarem Auftrag selbststaendig mit naheliegenden Annahmen starten und diese im Artefakt oder im Context-only-Ergebnis markieren.

## Artefakt

- Default: Markdown-Artefakt direkt unter `docs/` erstellen.
- Im Context-only-Modus kein Artefakt erstellen.
- Dateiname: `analysis-<scope>.md`, ohne Timestamp und ohne Unterordner.
- Minimalistisch und scharf formulieren.
- Bulletpoint-Listen und Tabellen bevorzugen.
- Code-Schnipsel vermeiden, ausser sie sind gewuenscht oder fuer Evidenz zwingend noetig.

Standardabschnitte:

- Ausgangsfrage
- Annahmen
- Untersuchter Scope
- Relevante Dateien/Symbole
- Befunde mit Evidenz
- Bewertung
- Risiken/Auswirkungen
- Offene Fragen

## Output

- Analyseartefakt unter `docs/analysis-<scope>.md`, ausser im Context-only-Modus
- kurze Chat-Zusammenfassung der zentralen Befunde, Bewertung, Risiken und offenen Fragen

## Qualitaetskriterien

- Keine Loesung verkaufen, bevor die Ursache belastbar ist.
- Unsicherheit explizit markieren.
- Dateipfade, Symbole oder Logs nennen, wenn sie die Aussage stuetzen.
- Beobachtung, Bewertung und Annahme klar trennen.
- Keine naechsten Schritte als eigenen Abschnitt im Artefakt ausgeben.
