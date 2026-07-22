# Skill: Code Testen

## Zweck

Eine Aenderung mit passenden Build-, Test- oder manuellen Pruefschritten verifizieren.

## Verwenden

- Nach Implementierung, Refactoring oder Bugfix.
- Vor Commit oder Pull Request.

## Vorgehen

1. Relevante Pruefebenen breit waehlen: Build, Unit, Integration, UI oder manuell.
2. Kommandos aus Projektdateien, README oder CI ableiten.
3. Passende Kommandos oder manuelle Pruefschritte ausfuehren, z. B. `dotnet test`, `npm test`, `npm run test`, `npm run build` oder UI-Pruefung mit verfuegbaren Tools, wenn sie zum Projekt passen.
4. Fehlende nicht-invasive Setup-Schritte aus Projektdateien oder README ableiten und ausfuehren, wenn sie fuer die Pruefung noetig sind.
5. Ergebnis bewerten.
6. Nicht ausgefuehrte, aber relevante Pruefungen benennen.

## Grenzen

- Keine Codeaenderungen vornehmen.
- Keine Testdateien anpassen oder ergaenzen. Das gehoert zu `code_implementieren` oder `code_refactoring`.
- Keine Fehler beheben. Dafuer passenden vorgelagerten Skill nutzen.
- Keine Projektkonfiguration aendern, Dependencies upgraden, Tests umschreiben oder Build-System fixen.
- Wenn Setup-Reparatur Code- oder Konfigaenderungen braucht, stoppen und passenden Skill benennen.
- Keine breite Analyse ersetzen. Fehler nur soweit einordnen, wie es fuer den Teststatus noetig ist.
- Laufzeitkontext wie Docker, Test-Logs oder Test-Datenbanken nur verwenden, wenn er Teil eines definierten Build-, Test- oder Integrationspruefschritts ist.
- Anwendungen, Dev-Server oder Docker-Services duerfen gestartet werden, wenn sie Teil eines definierten Pruefschritts sind.
- Manuelle Pruefschritte duerfen selbst durchgefuehrt werden, wenn geeignete Tools verfuegbar sind.
- Keine freie Fehlersuche in Logs, Containern oder Datenbanken durchfuehren. Das gehoert zu `code_analyse`.
- Keine produktiven Daten oder produktionsnahen Systeme pruefen, ausser der User fordert es explizit und read-only.

## Output

- ausgefuehrte Pruefungen
- Ergebnis
- Fehler oder Auffaelligkeiten knapp
- verbleibende Testluecken

## Qualitaetskriterien

- Keine pauschale Aussage wie "getestet".
- Testluecken offenlegen.
- Fehler nicht relativieren.
- Fehlgeschlagene Pruefungen knapp melden und nicht in Analyse ausweiten.
