# Workflow: Commit Push

## Ziel

Einen abgeschlossenen lokalen Aenderungssatz logisch committen und die neu erstellten Commits anschliessend auf den konfigurierten Upstream pushen.

## Verwenden

- Wenn der User `/cp` oder gleichbedeutend Commit und Push als zusammenhaengenden Ablauf beauftragt.
- Wenn Aenderungen fertig, getestet und reviewed sind.
- Nicht verwenden, wenn nur ein lokaler Commit gewuenscht ist. Dann `/commit` beziehungsweise `github_commit` nutzen.
- Nicht verwenden, wenn nur vorhandene Commits gepusht werden sollen. Dann `/push` beziehungsweise `github_push` nutzen.

## Verwendete Skills

- `github_commit`
- `github_push`

## Ablauf

1. Task-Scope, Teststatus, Review-Status, Branch und Arbeitsstatus bestimmen.
2. Vor dem Commit das Push-Ziel und den Remote-Status nach den Regeln von `github_push` pruefen.
3. Stoppen, wenn Scope, Teststatus, Review-Status oder Push-Status keinen sicheren Commit mit anschliessendem Push erlauben.
4. Mit `github_commit` ausschliesslich den taskbezogenen Aenderungssatz committen.
5. Mit `github_push` die neu erstellten Commits auf den konfigurierten Upstream pushen oder den Branch bei eindeutigem Ziel erstmals veroeffentlichen.
6. Commit-Hashes, Messages, Push-Ziel und synchronen Abschlusszustand ausgeben.

## Ruecksprungregeln

- Bei unklarem oder gemischtem Commit-Scope zu `github_commit` zurueckkehren und die Trennung klaeren.
- Bei fehlender Verifikation oder nicht versandbereitem Review zur passenden vorgelagerten Umsetzung oder Pruefung zurueckkehren.
- Wenn der Commit fehlschlaegt, keinen Push ausfuehren.
- Wenn der Push fehlschlaegt, den lokalen Commit erhalten und den Push-Blocker melden.

## Endergebnis

- taskbezogene Aenderungen sind logisch committed
- erstellte Commits sind auf den konfigurierten Upstream gepusht
- lokaler Branch und Upstream sind synchron
- nicht zum Scope gehoerende Aenderungen bleiben unveraendert

## Grenzen

- Bei bekanntem Remote-Vorsprung, Divergenz oder mehrdeutigem Push-Ziel keinen lokalen Commit beginnen.
- Ein fehlender Upstream ist kein Blocker, wenn `github_push` Remote und gleichnamigen Zielbranch eindeutig und sicher bestimmen kann.
- Keinen Pull Request erstellen.
- Keine fehlgeschlagene Commit- oder Push-Phase als vollstaendigen Erfolg darstellen.
