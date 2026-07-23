# Skill: Code Implementierungsplanung

## Zweck

Belastbaren vorhandenen Kontext in einen konkreten, testbaren technischen Umsetzungsplan ueberfuehren.

## Verwenden

- Vor nicht-trivialen Codeaenderungen.
- Wenn mehrere Dateien, Schichten oder Risiken betroffen sind.
- Wenn ein Plan als Agenten-Kontext fuer die Umsetzung oder als technische Vorarbeit fuer ein GitHub-Issue gebraucht wird.
- Nicht verwenden, wenn Ziel, Scope, Nicht-Ziele oder Akzeptanzkriterien noch unklar sind. Dann `anforderungsklaerung` nutzen.
- Nicht verwenden, wenn der naechste Schritt offensichtlich und klein ist.

## Vorgehen

1. Pruefen, ob Ziel, Scope, Nicht-Ziele, Akzeptanzkriterien und relevanter Kontext ausreichend vorliegen.
2. Fehlenden Kontext explizit benennen und passenden vorgelagerten Skill fordern.
3. Zielzustand und Definition of Done fixieren.
4. Betroffene Bereiche und Schnittstellen benennen.
5. Strukturentscheidung an den Sprachtyp anpassen.
6. Umsetzungsschritte arbeitspaketgenau in Ausfuehrungsreihenfolge formulieren.
7. Test- oder Verifikationsplan und Risiken festlegen.
8. Betriebsart beachten: Agenten-Kontext, Chat-Output, Artefakt oder GitHub-Issue-Vorarbeit.
9. Im Default nur kurz bestaetigen, den Plan als Arbeitsgrundlage nutzen und direkt mit der naechsten angefragten Arbeit fortfahren.

## Grenzen

- Keine Codeaenderungen vornehmen.
- Keinen Code, keine Issues und keine externe Dokumentation selbst lesen.
- Wenn Kontext fehlt, vorgelagert `code_lesen`, `code_analyse`, `research`, `brainstorming` oder `anforderungsklaerung` nutzen.
- Nicht blind planen, wenn belastbarer Kontext fehlt.
- Design- oder Architekturentscheidungen nur aufnehmen, wenn sie die Umsetzung direkt steuern.
- Keine breite Alternativenabwaegung ausfuehren. Dann `brainstorming` nutzen.
- Umsetzungsschritte nicht zu grob und nicht mikrogranular formulieren.
- Dateien oder Symbole nur nennen, wenn sie bekannt und fuer die Umsetzung hilfreich sind.
- Offene Punkte und Risiken klar benennen, wenn sie sichtbar sind.
- Bei offenen Punkten fragen, ob zuerst geklaert oder bewusst mit Annahmen weitergeplant werden soll.
- Kritische Risiken, die die Umsetzbarkeit gefaehrden, nicht ueberspringen.
- Betriebsart muss explizit vom User genannt werden; Default ist ein Plan im Agenten-Kontext.
- Keine Anforderungen stillschweigend erweitern.
- Keine Planung vortaeuschen, wenn wesentliche Ziel- oder Scope-Fragen offen sind.
- Backend: Verantwortlichkeiten, Abhaengigkeiten und testbare Grenzen bewusst trennen. Mehr Struktur ist akzeptabel, wenn sie Kopplung reduziert.
- HTML/CSS: Markup und Styling flach halten. Wrapper, Selektorketten und Abstraktion nur einfuehren, wenn sie konkret vereinfachen.

## Artefakt

- Nur erstellen, wenn der User es explizit verlangt.
- Dateiname: `docs/plan-<scope>.md`.
- Inhalt entspricht dem Output dieses Skills.
- Als Artefakt Checkbox-Listen fuer Arbeitspakete und Verifikation bevorzugen.

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
- keine Issue-Form, auch bei GitHub-Issue-Vorarbeit
- Bei Betriebsart Agenten-Kontext nur kurze Bestaetigung, keine ausfuehrliche Planausgabe

## Qualitaetskriterien

- Plan muss direkt umsetzbar sein.
- Scope klein halten.
- Tests oder Verifikation immer benennen.
- Test- oder Verifikationsplan gehoert zu jeder Betriebsart, auch Agenten-Kontext.
- Reihenfolge muss die Umsetzung logisch tragen.
- Annahmen und offene Punkte klar markieren.
- Schritte sollen konkrete Arbeitspakete mit betroffenem Bereich beschreiben.
- Der Plan soll auf eine ausfuehrbare Grundlage zielen, nicht auf Scheinsicherheit.
