# Skill: Code Refactoring

## Zweck

Code strukturieren, ohne beabsichtigtes Verhalten zu ändern.

## Verwenden

- Wenn Lesbarkeit, Wartbarkeit oder Verantwortungsgrenzen verbessert werden sollen.
- Wenn das zu erhaltende Verhalten durch vorhandenen Kontext oder `code-reading` ausreichend verstanden ist.
- Wenn ein Task oder Plan Zielstruktur, Scope, Verhaltensgrenzen und Verifikation belastbar vorgibt.
- Nicht verwenden, wenn fachliches Verhalten geändert werden soll. Dann Implementierung planen.

## Direkter Alias

- `/refactor`

`/refactor` verwendet den aktuellen Task- und Änderungskontext als Refactoring-Scope. Wenn der Alias unmittelbar nach `/implement <issue-number>` aufgerufen wird, bilden die durch diesen Workflow geänderten produktiven Dateien und zugehörigen Tests den Default-Scope; spätere oder nicht taskbezogene Änderungen gehören nicht automatisch dazu. Wenn das zu erhaltende Verhalten oder die Zuordnung zum vorausgegangenen Änderungssatz nicht eindeutig ist, muss der fehlende Kontext vor dem Refactoring geklärt werden.

## Vorgehen

1. Aus Task oder Plan zu erhaltendes Verhalten, Zielstruktur, Scope und Verifikation übernehmen.
2. Das nächste geplante Refactoring-Arbeitspaket und den kleinsten überprüfbaren Strukturumbau bestimmen.
3. Unmittelbar zu ändernde Dateien und angegebene Referenzen lesen.
4. Refactoring am Sprachtyp ausrichten.
5. Produktivcode, bei Bedarf Testdateien und code-nahe Dokumentation schrittweise ohne beabsichtigte Verhaltensänderung ändern.
6. Nach jedem Arbeitspaket Strukturgewinn, Verhaltenserhalt und erforderliche Verifikation benennen.

## Grenzen

- Kein fachliches Verhalten, keine Logik, keine Features und keine API absichtlich ändern. Dann `code-implementation` nutzen.
- Wenn eine Verhaltensänderung nötig wird, stoppen und `code-implementation` als passenden Skill benennen.
- Nicht refaktorieren, wenn das zu erhaltende Verhalten unklar ist. Dann vorher `code-reading` oder `code-analysis` nutzen.
- Keine breite Kontextsuche durchführen. Wenn Kontext fehlt, vorher `code-reading` nutzen.
- Nur unmittelbar betroffene Dateien lesen.
- Keine Tests, Builds oder Anwendungen ausführen. Das gehört zu `code-testing`.
- Testdateien dürfen geändert werden, wenn sie an neue Struktur, Namen oder Verantwortungsgrenzen angepasst werden und dasselbe Verhalten absichern.
- Code-nahe Dokumentation darf angepasst werden, wenn sie direkt zu geänderten Namen, Struktur oder Verantwortungsgrenzen gehört.
- README, Architektur-Doku, Nutzer-Doku, Changelog oder externe Dokumentation nicht automatisch aktualisieren. Dann `documentation` nutzen.
- Pro Ausführung ein zusammenhängendes Refactoring-Arbeitspaket umsetzen.
- Mehrere Refactoring-Arbeitspakete nur umsetzen, wenn sie im Plan explizit als ein Umsetzungsschritt zusammengehören.
- Keine breite Analyse, Recherche oder Implementierungsplanung ersetzen.
- Keine Zielstruktur oder Alternativen während der Ausführung grundlegend neu ableiten; bei Planbruch stoppen.
- Backend: Verantwortlichkeiten dürfen stärker getrennt werden, wenn Logik testbarer und Abhängigkeiten klarer werden.
- HTML/CSS: Struktur eher reduzieren als abstrahieren; Verschachtelung, Container und komplexe Selektoren abbauen.

## Output

- refaktorierter Code
- erhaltendes Verhalten
- Strukturgewinn
- Hinweis auf erforderliche nachgelagerte Verifikation
- Restrisiken, falls sichtbar

## Qualitätskriterien

- Jede Verhaltensänderung explizit markieren.
- Kein Refactoring als verdeckte Feature-Arbeit.
- Vorher-Nachher-Unterschied strukturell erklären.
- Nicht behaupten, etwas sei getestet.
- Strukturgewinn immer konkret benennen.
- Restrisiken nur benennen, wenn sie sichtbar sind; nicht als eigene Analyse ausweiten.
