# Skill: Code Testen

## Zweck

Eine Aenderung mit passenden Build-, Test- oder manuellen Pruefschritten verifizieren.

## Verwenden

- Nach Implementierung, Refactoring oder Bugfix.
- Vor Commit oder Pull Request.

## Direkter Alias

- `/testing`
- `/testing <modus>`

Zulaessige Modi:

| Modus | Verhalten |
|---|---|
| `auto` | Relevante Pruefungen aus Task-, Aenderungs- und Projektkontext bestimmen. Das ist der Default ohne Modus. |
| `build` | Build-, Compile- und statische Projektpruefungen ausfuehren. |
| `unit` | Projektdefinierte Unit-Tests und ihre erforderlichen Build-Schritte ausfuehren. |
| `integration` | Projektdefinierte Integrations- und Adaptertests samt erforderlichem Setup ausfuehren. |
| `e2e` | Projektdefinierte End-to-End-Tests fuer sichtbare Nutzerflows und systemweite Ablaeufe samt erforderlichem Setup ausfuehren. |
| `all` | Alle im Projekt definierten und in der aktuellen Umgebung sicher ausfuehrbaren Pruefebenen ausfuehren. |

`/testing` entspricht `/testing auto`. Wenn der Alias unmittelbar nach `/refactor` aufgerufen wird, muss er den refaktorierten Aenderungssatz und das dabei zu erhaltende Verhalten verifizieren.

## Vorgehen

1. Den angeforderten Modus validieren oder ohne Modus den Modus `auto` verwenden.
2. Im Modus `auto` relevante Pruefebenen breit waehlen: Build, Unit, Integration, E2E, UI oder manuell.
3. In einem expliziten Modus die bezeichnete Pruefebene und nur ihre technisch erforderlichen Build- oder Setup-Schritte auswaehlen.
4. Kommandos aus Projektdateien, README oder CI ableiten.
5. Passende Kommandos oder manuelle Pruefschritte ausfuehren, z. B. `dotnet test`, `npm test`, `npm run test`, `npm run build`, ein projektspezifisches E2E-Script oder UI-Pruefung mit verfuegbaren Tools.
6. Fehlende nicht-invasive Setup-Schritte aus Projektdateien oder README ableiten und ausfuehren, wenn sie fuer die Pruefung noetig sind.
7. Ergebnis bewerten.
8. Nicht ausgefuehrte, aber relevante Pruefungen benennen.

## Grenzen

- Keine Codeaenderungen vornehmen.
- Keine Testdateien anpassen oder ergaenzen. Das gehoert zu `code_implementieren` oder `code_refactoring`.
- Keine Fehler beheben. Dafuer passenden vorgelagerten Skill nutzen.
- Keine Projektkonfiguration aendern, Dependencies upgraden, Tests umschreiben oder Build-System fixen.
- Wenn Setup-Reparatur Code- oder Konfigaenderungen braucht, stoppen und passenden Skill benennen.
- Keine breite Analyse ersetzen. Fehler nur soweit einordnen, wie es fuer den Teststatus noetig ist.
- Keine nicht zum explizit gewaehlten Modus gehoerende Pruefebene ausfuehren, ausser sie ist eine technische Voraussetzung. Solche Voraussetzungen im Ergebnis getrennt ausweisen.
- Wenn das Projekt fuer den explizit gewaehlten Modus keine Pruefung definiert, keine andere Pruefebene als Ersatz ausgeben, sondern die Testluecke melden.
- Laufzeitkontext wie Docker, Test-Logs oder Test-Datenbanken nur verwenden, wenn er Teil eines definierten Build-, Test- oder Integrationspruefschritts ist.
- Anwendungen, Dev-Server oder Docker-Services duerfen gestartet werden, wenn sie Teil eines definierten Pruefschritts sind.
- Manuelle Pruefschritte duerfen selbst durchgefuehrt werden, wenn geeignete Tools verfuegbar sind.
- Keine freie Fehlersuche in Logs, Containern oder Datenbanken durchfuehren. Das gehoert zu `code_analyse`.
- Keine produktiven Daten oder produktionsnahen Systeme pruefen, ausser der User fordert es explizit und read-only.

## Output

- ausgefuehrte Pruefungen
- verwendeter Modus
- Ergebnis
- Fehler oder Auffaelligkeiten knapp
- verbleibende Testluecken

## Qualitaetskriterien

- Keine pauschale Aussage wie "getestet".
- Testluecken offenlegen.
- Fehler nicht relativieren.
- Fehlgeschlagene Pruefungen knapp melden und nicht in Analyse ausweiten.
