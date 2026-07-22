# Skill: Code Implementieren

## Zweck

Eine geklaerte Aenderung mit minimalem Scope im Code umsetzen.

## Verwenden

- Wenn Ziel, Scope und Richtung ausreichend klar sind.
- Wenn eine kleine, offensichtliche Aenderung direkt umgesetzt werden kann.
- Wenn fuer nicht-triviale Aenderungen bereits ein belastbarer Plan vorliegt.
- Nicht verwenden, wenn erst Anforderung, Ursache, Optionen oder Plan geklaert werden muessen.
- Bei nicht-trivialen Aenderungen vorher `code_implementierungsplanung` nutzen.

## Vorgehen

1. Ziel, Scope und betroffene Dateien pruefen.
2. Unmittelbar zu aendernde Dateien lesen, soweit es fuer die Umsetzung noetig ist.
3. Produktivcode, relevante Testdateien und code-nahe Dokumentation entlang bestehender Patterns umsetzen.
4. Struktur an den Sprachtyp anpassen.
5. Ergebnis gegen Ziel, Scope und bekannte Risiken pruefen.
6. Nachgelagerte Verifikation durch `code_testen` benennen.

## Grenzen

- Keine ungeplanten Nebenaenderungen vornehmen.
- Keine Anforderungen stillschweigend erweitern.
- Nicht implementieren, wenn Ziel oder Scope unklar ist. Dann `anforderungsklaerung` oder `code_implementierungsplanung` nutzen.
- Keine breite Analyse, Recherche oder Alternativenabwaegung durchfuehren.
- Keine breite Kontextsuche durchfuehren. Wenn Kontext fehlt, vorher `code_lesen` nutzen.
- Nur unmittelbar betroffene Dateien lesen.
- Keine Tests, Builds oder Anwendungen ausfuehren. Das gehoert zu `code_testen`.
- Verhalten, Logik, Feature oder API gezielt veraendern; das ist der Zweck dieses Skills.
- Kein reines Refactoring durchfuehren. Verhaltenserhaltende Strukturverbesserung mit Zweck Lesbarkeit, Wartbarkeit oder Redundanzabbau gehoert zu `code_refactoring`.
- Minimale strukturelle Anpassungen sind erlaubt, wenn sie unmittelbar noetig sind, um die Verhaltensaenderung sauber einzubauen.
- Testdateien duerfen angepasst oder ergaenzt werden, wenn sie zur umgesetzten Aenderung gehoeren.
- Code-nahe Dokumentation darf aktualisiert werden, wenn sie direkt zur geaenderten Stelle gehoert, z. B. Kommentare, XML-docs, JSDoc oder API-Beschreibungen im selben Aenderungsbereich.
- README, Architektur-Doku, Nutzer-Doku, Changelog oder externe Dokumentation nicht automatisch aktualisieren.
- Kleine lokale Abweichungen vom Plan sind erlaubt, wenn Ziel und Scope gleich bleiben.
- Stoppen und passenden vorgelagerten Skill benennen, wenn Architektur, Scope, Risiko oder Annahmen kippen.
- Pro Ausfuehrung ein zusammenhaengendes Arbeitspaket umsetzen.
- Mehrere Arbeitspakete nur umsetzen, wenn sie im Plan explizit als ein Umsetzungsschritt zusammengehoeren.
- Backend: Logik, Orchestrierung, Datenzugriff und Hilfen trennen, wenn Verantwortungen sonst vermischt werden.
- HTML/CSS: DOM und Styling direkt halten; unnoetige Wrapper, Helferklassen und tiefe Verschachtelung vermeiden.

## Output

- umgesetzte Aenderung
- kurze Zusammenfassung
- Hinweis auf erforderliche nachgelagerte Verifikation
- offene Punkte, falls nach der Implementierung sichtbar

## Qualitaetskriterien

- Bestehende Architektur und Konventionen respektieren.
- Nicht behaupten, etwas sei getestet.
- Offene Punkte nur benennen, wenn sie sichtbar sind; nicht als eigene Analyse ausweiten.
