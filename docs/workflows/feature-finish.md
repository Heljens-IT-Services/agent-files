# Workflow: Feature Finish

## Ziel

Einen bereits umgesetzten und vom User freigegebenen Arbeitsbranch mit `/finish` sicher committen, veröffentlichen, prüfen und nach `develop` mergen.

## Verwenden

- Wenn der User `/finish` oder gleichbedeutend den vollständigen Branch-Abschluss beauftragt.
- Für den Abschluss eines Feature- oder Task-Branches nach `develop`.
- Nicht für die Freigabe von `develop` nach `main`; dafür `/release` beziehungsweise den Workflow `release` verwenden.
- Wenn Implementierung und taskbezogene lokale Verifikation bereits abgeschlossen sind oder im Workflow abgeschlossen werden können.
- Nicht verwenden, um Implementierung, Fehlerbehebung oder fachliche Freigabe zu ersetzen.

## Reifekriterien

- Ein aufgabenbezogener Arbeitsbranch ist aktiv und ist weder `develop` noch `main`.
- Der Remote-Branch `develop` ist als Zielbranch vorhanden und auflösbar.
- Task-Scope und taskbezogene Änderungen sind eindeutig.
- Der User hat den vollständigen Abschluss einschließlich Commit, Push, Pull Request, Check-Beobachtung und Merge ausdrücklich beauftragt.
- Repository, Remote und Branch-Zustände sind auflösbar.

## Verwendete Skills

- `code_testen`
- `code_diff-review`
- `github_pr-erstellen`
- `github_pr-checks-beobachten`
- `github_pr-merge`
- `github_integrationsbranch-aktualisieren`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. `PROJECT.md`, Repository-Kontext, aktuellen Branch, Working Tree, Remote, den Zielbranch `develop` und taskbezogenen Scope bestimmen.
2. Stoppen, wenn `develop` oder `main` aktiv ist, `develop` remote nicht existiert, der Task-Scope unklar ist oder fremde Änderungen nicht sicher vom Task getrennt werden können.
3. Mit `code_testen` die für die Änderung relevanten lokalen Prüfungen ausführen oder einen bereits belastbaren Teststatus bestätigen.
4. Mit `code_diff-review` den gesamten taskbezogenen Änderungssatz prüfen und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
5. Mit dem Workflow `commit-push.md` ausschließlich taskbezogene Änderungen committen und zum konfigurierten Remote pushen.
6. Mit `github_pr-erstellen` einen vorhandenen Pull Request für den Branch gegen `develop` wiederverwenden oder mit `develop` als expliziter Basis erstellen. `/finish` gilt für diesen Workflow als ausdrückliche Anweisung, den Pull Request als Ready for Review bereitzustellen.
7. Mit `github_pr-checks-beobachten` die erforderlichen Checks für den unveränderten Pull-Request-Head bis zu einem terminalen Zustand beobachten.
8. Bei vollständig erfolgreichen erforderlichen Checks und erfüllten Repository-Regeln mit `github_pr-merge` und der aufgelösten Merge-Methode mergen. Bei `spending-limit-blocked` nur nach der dort vorgeschriebenen zusätzlichen Bestätigung fortfahren; eine erforderliche Merge Queue bis zum terminalen Ergebnis beobachten.
9. Nach verifiziertem Merge mit `github_integrationsbranch-aktualisieren` auf `develop` wechseln und ihn per Fast-Forward aktualisieren.
10. Commit, Pull Request, Check-Ergebnis, Merge und lokalen Abschlusszustand zusammenfassen.

## Rücksprungregeln

- Bei fehlgeschlagenen lokalen Prüfungen zur passenden Implementierung oder Fehlerbehebung zurückkehren; keine beliebigen Fehler außerhalb des Task-Scopes beheben.
- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zur passenden Umsetzung zurückkehren.
- Bei `spending-limit-blocked` zur ausdrücklichen Rückfrage in `github_pr-merge` wechseln.
- Bei anderen fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und den Arbeitsbranch aktiv lassen.
- Wenn der Merge nicht verifiziert werden kann, nicht auf `develop` wechseln.

## Endergebnis

- taskbezogene Änderungen sind bewusst committed und gepusht
- ein vorhandener Pull Request wurde wiederverwendet oder ein passender Pull Request erstellt
- erforderliche Checks sind für den gemergten Head-Commit erfolgreich oder der nachgewiesene Spending-Limit-Fall wurde für diesen Head-Commit ausdrücklich bestätigt
- der Pull Request ist regelkonform gemergt
- der lokale Checkout steht auf dem per Fast-Forward aktualisierten Branch `develop`
