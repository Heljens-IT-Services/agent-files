# Skill: Code Testen

## Zweck

Eine Änderung mit passenden Build-, Test- oder manuellen Prüfschritten verifizieren.

## Verwenden

- Nach Implementierung, Refactoring oder Bugfix.
- Vor Commit oder Pull Request.

## Direkter Alias

- `/testing`
- `/testing <modus>`

Zulässige Modi:

| Modus | Verhalten |
|---|---|
| `auto` | Relevante Prüfungen aus Task-, Änderungs- und Projektkontext bestimmen. Das ist der Default ohne Modus. |
| `build` | Build-, Compile- und statische Projektprüfungen ausführen. |
| `unit` | Projektdefinierte Unit-Tests und ihre erforderlichen Build-Schritte ausführen. |
| `integration` | Projektdefinierte Integrations- und Adaptertests samt erforderlichem Setup ausführen. |
| `e2e` | Projektdefinierte End-to-End-Tests für sichtbare Nutzerflows und systemweite Abläufe samt erforderlichem Setup ausführen. |
| `all` | Alle im Projekt definierten und in der aktuellen Umgebung sicher ausführbaren Prüfebenen ausführen. |

`/testing` entspricht `/testing auto`. Wenn der Alias unmittelbar nach `/refactor` aufgerufen wird, muss er den refaktorierten Änderungssatz und das dabei zu erhaltende Verhalten verifizieren.

## Vorgehen

1. Den angeforderten Modus validieren oder ohne Modus den Modus `auto` verwenden.
2. Im Modus `auto` relevante Prüfebenen breit wählen: Build, Unit, Integration, E2E, UI oder manuell.
3. In einem expliziten Modus die bezeichnete Prüfebene und nur ihre technisch erforderlichen Build- oder Setup-Schritte auswählen.
4. Kommandos aus Projektdateien, README oder CI ableiten.
5. Passende Kommandos oder manuelle Prüfschritte ausführen, z. B. `dotnet test`, `npm test`, `npm run test`, `npm run build`, ein projektspezifisches E2E-Script oder UI-Prüfung mit verfügbaren Tools.
6. Fehlende nicht-invasive Setup-Schritte aus Projektdateien oder README ableiten und ausführen, wenn sie für die Prüfung nötig sind.
7. Ergebnis bewerten.
8. Nicht ausgeführte, aber relevante Prüfungen benennen.

## Grenzen

- Keine Codeänderungen vornehmen.
- Keine Testdateien anpassen oder ergänzen. Das gehört zu `code_implementieren` oder `code_refactoring`.
- Keine Fehler beheben. Dafür passenden vorgelagerten Skill nutzen.
- Keine Projektkonfiguration ändern, Dependencies upgraden, Tests umschreiben oder Build-System fixen.
- Wenn Setup-Reparatur Code- oder Konfigänderungen braucht, stoppen und passenden Skill benennen.
- Keine breite Analyse ersetzen. Fehler nur soweit einordnen, wie es für den Teststatus nötig ist.
- Keine nicht zum explizit gewählten Modus gehörende Prüfebene ausführen, außer sie ist eine technische Voraussetzung. Solche Voraussetzungen im Ergebnis getrennt ausweisen.
- Wenn das Projekt für den explizit gewählten Modus keine Prüfung definiert, keine andere Prüfebene als Ersatz ausgeben, sondern die Testlücke melden.
- Laufzeitkontext wie Docker, Test-Logs oder Test-Datenbanken nur verwenden, wenn er Teil eines definierten Build-, Test- oder Integrationsprüfschritts ist.
- Anwendungen, Dev-Server oder Docker-Services dürfen gestartet werden, wenn sie Teil eines definierten Prüfschritts sind.
- Manuelle Prüfschritte dürfen selbst durchgeführt werden, wenn geeignete Tools verfügbar sind.
- Keine freie Fehlersuche in Logs, Containern oder Datenbanken durchführen. Das gehört zu `code_analyse`.
- Keine produktiven Daten oder produktionsnahen Systeme prüfen, außer der User fordert es explizit und read-only.

## Output

- ausgeführte Prüfungen
- verwendeter Modus
- Ergebnis
- Fehler oder Auffälligkeiten knapp
- verbleibende Testlücken

## Qualitätskriterien

- Keine pauschale Aussage wie "getestet".
- Testlücken offenlegen.
- Fehler nicht relativieren.
- Fehlgeschlagene Prüfungen knapp melden und nicht in Analyse ausweiten.
