# Skill: Code Implementieren

## Zweck

Eine geklärte Änderung mit minimalem Scope im Code umsetzen.

## Verwenden

- Wenn Ziel, Scope und Richtung ausreichend klar sind.
- Wenn eine kleine, offensichtliche Änderung direkt umgesetzt werden kann.
- Wenn für nicht-triviale Änderungen bereits ein belastbarer Plan vorliegt.
- Nicht verwenden, wenn erst Anforderung, Ursache, Optionen oder Plan geklärt werden müssen.
- Bei nicht-trivialen Änderungen vorher `code-implementation-planning` nutzen.

## Vorgehen

1. Ziel, Scope und betroffene Dateien prüfen.
2. Unmittelbar zu ändernde Dateien lesen, soweit es für die Umsetzung nötig ist.
3. Produktivcode, relevante Testdateien und code-nahe Dokumentation entlang bestehender Patterns umsetzen.
4. Struktur an den Sprachtyp anpassen.
5. Ergebnis gegen Ziel, Scope und bekannte Risiken prüfen.
6. Nachgelagerte Verifikation durch `code-testing` benennen.

## Grenzen

- Keine ungeplanten Nebenänderungen vornehmen.
- Keine Anforderungen stillschweigend erweitern.
- Nicht implementieren, wenn Ziel oder Scope unklar ist. Dann `requirements-clarification` oder `code-implementation-planning` nutzen.
- Keine breite Analyse, Recherche oder Alternativenabwägung durchführen.
- Keine breite Kontextsuche durchführen. Wenn Kontext fehlt, vorher `code-reading` nutzen.
- Nur unmittelbar betroffene Dateien lesen.
- Keine Tests, Builds oder Anwendungen ausführen. Das gehört zu `code-testing`.
- Verhalten, Logik, Feature oder API gezielt verändern; das ist der Zweck dieses Skills.
- Kein reines Refactoring durchführen. Verhaltenserhaltende Strukturverbesserung mit Zweck Lesbarkeit, Wartbarkeit oder Redundanzabbau gehört zu `code-refactoring`.
- Minimale strukturelle Anpassungen sind erlaubt, wenn sie unmittelbar nötig sind, um die Verhaltensänderung sauber einzubauen.
- Testdateien dürfen angepasst oder ergänzt werden, wenn sie zur umgesetzten Änderung gehören.
- Code-nahe Dokumentation darf aktualisiert werden, wenn sie direkt zur geänderten Stelle gehört, z. B. Kommentare, XML-docs, JSDoc oder API-Beschreibungen im selben Änderungsbereich.
- README, Architektur-Doku, Nutzer-Doku, Changelog oder externe Dokumentation nicht automatisch aktualisieren.
- Kleine lokale Abweichungen vom Plan sind erlaubt, wenn Ziel und Scope gleich bleiben.
- Stoppen und passenden vorgelagerten Skill benennen, wenn Architektur, Scope, Risiko oder Annahmen kippen.
- Pro Ausführung ein zusammenhängendes Arbeitspaket umsetzen.
- Mehrere Arbeitspakete nur umsetzen, wenn sie im Plan explizit als ein Umsetzungsschritt zusammengehören.
- Backend: Logik, Orchestrierung, Datenzugriff und Hilfen trennen, wenn Verantwortungen sonst vermischt werden.
- HTML/CSS: DOM und Styling direkt halten; unnötige Wrapper, Helferklassen und tiefe Verschachtelung vermeiden.

## Output

- umgesetzte Änderung
- kurze Zusammenfassung
- Hinweis auf erforderliche nachgelagerte Verifikation
- offene Punkte, falls nach der Implementierung sichtbar

## Qualitätskriterien

- Bestehende Architektur und Konventionen respektieren.
- Nicht behaupten, etwas sei getestet.
- Offene Punkte nur benennen, wenn sie sichtbar sind; nicht als eigene Analyse ausweiten.
