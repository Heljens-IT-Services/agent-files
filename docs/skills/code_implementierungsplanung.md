# Skill: Code Implementierungsplanung

## Zweck

Belastbaren vorhandenen Kontext in einen konkreten, testbaren technischen Umsetzungsplan überführen.

## Verwenden

- Vor nicht-trivialen Codeänderungen.
- Wenn mehrere Dateien, Schichten oder Risiken betroffen sind.
- Wenn ein Plan als Agenten-Kontext für die Umsetzung oder als technische Vorarbeit für ein GitHub-Issue gebraucht wird.
- Nicht verwenden, wenn Ziel, Scope, Nicht-Ziele oder Akzeptanzkriterien noch unklar sind. Dann `requirements-clarification` nutzen.
- Nicht verwenden, wenn der nächste Schritt offensichtlich und klein ist.

## Vorgehen

1. Prüfen, ob Ziel, Scope, Nicht-Ziele, Akzeptanzkriterien und relevanter Kontext ausreichend vorliegen.
2. Fehlenden Kontext explizit benennen und passenden vorgelagerten Skill fordern.
3. Zielzustand und Definition of Done fixieren.
4. Betroffene Bereiche und Schnittstellen benennen.
5. Strukturentscheidung an den Sprachtyp anpassen.
6. Umsetzungsschritte arbeitspaketgenau in Ausführungsreihenfolge formulieren.
7. Test- oder Verifikationsplan und Risiken festlegen.
8. Betriebsart beachten: Agenten-Kontext, Chat-Output, Artefakt oder GitHub-Issue-Vorarbeit.
9. Bei GitHub-Issue-Vorarbeit alle Inhalte für den [kanonischen Task-Issue-Vertrag](../github/ISSUE_TEMPLATES.md#task-issue-vertrag) liefern. Wesentliche offene Entscheidungen verhindern einen terminalen Task und müssen als Klärungsbedarf sichtbar bleiben.
10. Im Default nur kurz bestätigen, den Plan als Arbeitsgrundlage nutzen und direkt mit der nächsten angefragten Arbeit fortfahren.

## Grenzen

- Keine Codeänderungen vornehmen.
- Keinen Code, keine Issues und keine externe Dokumentation selbst lesen.
- Wenn Kontext fehlt, vorgelagert `code-reading`, `code-analysis`, `research`, `brainstorming` oder `requirements-clarification` nutzen.
- Nicht blind planen, wenn belastbarer Kontext fehlt.
- Design- oder Architekturentscheidungen nur aufnehmen, wenn sie die Umsetzung direkt steuern.
- Keine breite Alternativenabwägung ausführen. Dann `brainstorming` nutzen.
- Umsetzungsschritte nicht zu grob und nicht mikrogranular formulieren.
- Dateien oder Symbole nur nennen, wenn sie bekannt und für die Umsetzung hilfreich sind.
- Offene Punkte und Risiken klar benennen, wenn sie sichtbar sind.
- Keine Scheingenauigkeit erzeugen: unbekannte Dateien, Symbole oder Entscheidungen nicht erfinden.
- Bei offenen Punkten fragen, ob zuerst geklärt oder bewusst mit Annahmen weitergeplant werden soll.
- Kritische Risiken, die die Umsetzbarkeit gefährden, nicht überspringen.
- Betriebsart muss explizit vom User genannt werden; Default ist ein Plan im Agenten-Kontext.
- Keine Anforderungen stillschweigend erweitern.
- Keine Planung vortäuschen, wenn wesentliche Ziel- oder Scope-Fragen offen sind.
- Backend: Verantwortlichkeiten, Abhängigkeiten und testbare Grenzen bewusst trennen. Mehr Struktur ist akzeptabel, wenn sie Kopplung reduziert.
- HTML/CSS: Markup und Styling flach halten. Wrapper, Selektorketten und Abstraktion nur einführen, wenn sie konkret vereinfachen.

## Artefakt

- Nur erstellen, wenn der User es explizit verlangt.
- Dateiname: `docs/plan-<scope>.md`.
- Inhalt entspricht dem Output dieses Skills.
- Als Artefakt Checkbox-Listen für Arbeitspakete und Verifikation bevorzugen.

## Output

- Zielzustand
- Scope und Nicht-Ziele
- Akzeptanzkriterien
- Definition of Done
- betroffene Bereiche
- Umsetzungsschritte
- umsetzungsrelevante Design- oder Architekturentscheidungen
- Testplan
- Risiken oder offene Punkte
- Hinweise, falls der Plan als GitHub-Issue-Vorarbeit gedacht ist
- keine Issue-Form; bei GitHub-Issue-Vorarbeit aber eine eindeutige Zuordnung zum kanonischen Task-Issue-Vertrag
- Bei Betriebsart Agenten-Kontext nur kurze Bestätigung, keine ausführliche Planausgabe

## Qualitätskriterien

- Plan muss direkt umsetzbar sein.
- Scope klein halten.
- Tests oder Verifikation immer benennen.
- Test- oder Verifikationsplan gehört zu jeder Betriebsart, auch Agenten-Kontext.
- Reihenfolge muss die Umsetzung logisch tragen.
- Annahmen und offene Punkte klar markieren.
- Schritte sollen konkrete Arbeitspakete mit betroffenem Bereich beschreiben.
- Der Plan soll auf eine ausführbare Grundlage zielen, nicht auf Scheinsicherheit.
