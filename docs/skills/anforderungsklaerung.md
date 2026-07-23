# Skill: Anforderungsklaerung

## Zweck

Unklare Anforderungen, Ziele, Nicht-Ziele und Scope-Grenzen in eine belastbare Arbeitsgrundlage ueberfuehren.

## Verwenden

- Wenn ein Vorhaben fachlich, technisch oder organisatorisch noch unscharf ist.
- Wenn Ziel, Scope, Nicht-Ziele, Akzeptanzkriterien oder Prioritaeten geklaert werden muessen.
- Wenn ein Issue, Feature, Bugfix oder Konzept vor Planung oder Umsetzung konkretisiert werden soll.
- Standardmaessig interaktiv verwenden.
- Stillen Modus nur verwenden, wenn der User ihn explizit verlangt oder ein Workflow nur Kontextstrukturierung braucht.
- Nicht verwenden, wenn mehrere Loesungsoptionen kreativ oder strategisch abgewogen werden sollen. Dann `brainstorming` nutzen.
- Nicht verwenden, wenn Code nur gelesen werden soll. Dann `code_lesen` nutzen.
- Nicht verwenden, wenn bereits ein umsetzbarer technischer Plan erstellt werden soll. Dann `code_implementierungsplanung` nutzen.

## Vorgehen

1. Ausgangswunsch, Zielbild und bekannten Kontext knapp zusammenfassen.
2. Scope, Nicht-Ziele, Abhaengigkeiten und Randbedingungen trennen.
3. Akzeptanzkriterien oder Erfolgskriterien ableiten.
4. Widersprueche, Luecken und implizite Annahmen markieren.
5. Plausible Annahmen vorschlagen, damit der User sie bestaetigen oder ablehnen kann.
6. Wenige gezielte Klaerungsfragen stellen.
7. User-Antworten in eine geschaerfte Arbeitsgrundlage ueberfuehren.
8. Abschliessen, wenn die Anforderungen als belastbare Arbeitsgrundlage geklaert sind.
9. Im stillen Modus keine Rueckfragen stellen, sondern vorhandene Anforderungen strukturieren und offene Punkte markieren.

## Grenzen

- Keine Dateien aendern.
- Keine technische Umsetzung planen, bevor Ziel und Scope ausreichend klar sind.
- Keine Anforderungen stillschweigend erweitern.
- Keine Issues, Research-Ergebnisse oder Code-Analysen selbst lesen. Nur vorhandenen Kontext verwenden.
- Wenn Kontext fehlt, vorgelagert `github_issue-lesen`, `research`, `code_lesen` oder `code_analyse` nutzen.
- Annahmen duerfen vorgeschlagen, aber nicht stillschweigend als bestaetigt behandelt werden.
- Im stillen Modus keine offenen Punkte klaeren, sondern nur markieren.
- Wenn entscheidende Informationen fehlen und nicht geklaert werden koennen, mit `BLOCKED` enden.
- `BLOCKED` muss die konkreten fehlenden Entscheidungen oder Informationen nennen.
- Keine nachgelagerte Planung oder Umsetzung empfehlen, solange der Klaerungsstatus blockiert ist.

## Artefakt

- Nur erstellen, wenn der User es explizit verlangt.
- Dateiname: `docs/requirements-<scope>.md`.
- Inhalt entspricht dem Output dieses Skills.

## Output

- geschaerftes Zielbild
- Scope und Nicht-Ziele
- Akzeptanz- oder Erfolgskriterien
- bekannte Randbedingungen
- offene Fragen
- im stillen Modus: strukturierte Anforderungen ohne Rueckfrage
- `BLOCKED` mit konkreten fehlenden Informationen, falls Klaerung nicht moeglich war

## Qualitaetskriterien

- Ziel, Scope und Nicht-Ziele klar trennen.
- Annahmen explizit markieren.
- Fragen muessen klaerungsrelevant und auf wenige pro Antwort begrenzt sein.
- Keine Loesung vorwegnehmen, wenn die Anforderung noch unklar ist.
- Knapp und interaktiv arbeiten.
