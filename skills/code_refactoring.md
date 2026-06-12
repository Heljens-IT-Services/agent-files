# Skill: Code Refactoring

## Zweck

Code strukturieren, ohne beabsichtigtes Verhalten zu aendern.

## Verwenden

- Wenn Lesbarkeit, Wartbarkeit oder Verantwortungsgrenzen verbessert werden sollen.
- Wenn das zu erhaltende Verhalten durch vorhandenen Kontext oder `code_lesen` ausreichend verstanden ist.
- Nicht verwenden, wenn fachliches Verhalten geaendert werden soll. Dann Implementierung planen.

## Vorgehen

1. Verhalten benennen, das erhalten bleiben muss.
2. Kleinsten sinnvollen Strukturumbau waehlen.
3. Refactoring am Sprachtyp ausrichten.
4. Unmittelbar zu aendernde Dateien lesen, soweit es fuer das Refactoring noetig ist.
5. Produktivcode, bei Bedarf Testdateien und code-nahe Dokumentation schrittweise ohne beabsichtigte Verhaltensaenderung aendern.
6. Strukturgewinn und erforderliche nachgelagerte Verifikation benennen.

## Grenzen

- Kein fachliches Verhalten, keine Logik, keine Features und keine API absichtlich aendern. Dann `code_implementieren` nutzen.
- Wenn eine Verhaltensaenderung noetig wird, stoppen und `code_implementieren` als passenden Skill benennen.
- Nicht refaktorieren, wenn das zu erhaltende Verhalten unklar ist. Dann vorher `code_lesen` oder `code_analyse` nutzen.
- Keine breite Kontextsuche durchfuehren. Wenn Kontext fehlt, vorher `code_lesen` nutzen.
- Nur unmittelbar betroffene Dateien lesen.
- Keine Tests, Builds oder Anwendungen ausfuehren. Das gehoert zu `code_testen`.
- Testdateien duerfen geaendert werden, wenn sie an neue Struktur, Namen oder Verantwortungsgrenzen angepasst werden und dasselbe Verhalten absichern.
- Code-nahe Dokumentation darf angepasst werden, wenn sie direkt zu geaenderten Namen, Struktur oder Verantwortungsgrenzen gehoert.
- README, Architektur-Doku, Nutzer-Doku, Changelog oder externe Dokumentation nicht automatisch aktualisieren. Dann `dokumentation` nutzen.
- Pro Ausfuehrung ein zusammenhaengendes Refactoring-Arbeitspaket umsetzen.
- Mehrere Refactoring-Arbeitspakete nur umsetzen, wenn sie im Plan explizit als ein Umsetzungsschritt zusammengehoeren.
- Keine breite Analyse, Recherche oder Implementierungsplanung ersetzen.
- Backend: Verantwortlichkeiten duerfen staerker getrennt werden, wenn Logik testbarer und Abhaengigkeiten klarer werden.
- HTML/CSS: Struktur eher reduzieren als abstrahieren; Verschachtelung, Container und komplexe Selektoren abbauen.

## Output

- refaktorierter Code
- erhaltendes Verhalten
- Strukturgewinn
- Hinweis auf erforderliche nachgelagerte Verifikation
- Restrisiken, falls sichtbar

## Qualitaetskriterien

- Jede Verhaltensaenderung explizit markieren.
- Kein Refactoring als verdeckte Feature-Arbeit.
- Vorher-Nachher-Unterschied strukturell erklaeren.
- Nicht behaupten, etwas sei getestet.
- Strukturgewinn immer konkret benennen.
- Restrisiken nur benennen, wenn sie sichtbar sind; nicht als eigene Analyse ausweiten.
