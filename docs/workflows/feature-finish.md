# Workflow: Feature Finish

## Ziel

Einen bereits umgesetzten und vom User freigegebenen Arbeitsbranch mit `/finish` sicher committen, veroeffentlichen, pruefen und nach `develop` mergen.

## Verwenden

- Wenn der User `/finish` oder gleichbedeutend den vollstaendigen Branch-Abschluss beauftragt.
- Fuer den Abschluss eines Feature- oder Task-Branches nach `develop`.
- Nicht fuer die Freigabe von `develop` nach `main`; dafuer `/release` beziehungsweise den Workflow `release` verwenden.
- Wenn Implementierung und taskbezogene lokale Verifikation bereits abgeschlossen sind oder im Workflow abgeschlossen werden koennen.
- Nicht verwenden, um Implementierung, Fehlerbehebung oder fachliche Freigabe zu ersetzen.

## Reifekriterien

- Ein aufgabenbezogener Arbeitsbranch ist aktiv und ist weder `develop` noch `main`.
- Der Remote-Branch `develop` ist als Zielbranch vorhanden und aufloesbar.
- Task-Scope und taskbezogene Aenderungen sind eindeutig.
- Der User hat den vollstaendigen Abschluss einschliesslich Commit, Push, Pull Request, Check-Beobachtung und Merge ausdruecklich beauftragt.
- Repository, Remote und Branch-Zustaende sind aufloesbar.

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
2. Stoppen, wenn `develop` oder `main` aktiv ist, `develop` remote nicht existiert, der Task-Scope unklar ist oder fremde Aenderungen nicht sicher vom Task getrennt werden koennen.
3. Mit `code_testen` die fuer die Aenderung relevanten lokalen Pruefungen ausfuehren oder einen bereits belastbaren Teststatus bestaetigen.
4. Mit `code_diff-review` den gesamten taskbezogenen Aenderungssatz pruefen und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
5. Mit dem Workflow `commit-push.md` ausschliesslich taskbezogene Aenderungen committen und zum konfigurierten Remote pushen.
6. Mit `github_pr-erstellen` einen vorhandenen Pull Request fuer den Branch gegen `develop` wiederverwenden oder mit `develop` als expliziter Basis erstellen. `/finish` gilt fuer diesen Workflow als ausdrueckliche Anweisung, den Pull Request als Ready for Review bereitzustellen.
7. Mit `github_pr-checks-beobachten` die erforderlichen Checks fuer den unveraenderten Pull-Request-Head bis zu einem terminalen Zustand beobachten.
8. Nur bei vollstaendig erfolgreichen erforderlichen Checks und erfuellten Repository-Regeln mit `github_pr-merge` und der aufgeloesten Merge-Methode mergen; eine erforderliche Merge Queue bis zum terminalen Ergebnis beobachten.
9. Nach verifiziertem Merge mit `github_integrationsbranch-aktualisieren` auf `develop` wechseln und ihn per Fast-Forward aktualisieren.
10. Commit, Pull Request, Check-Ergebnis, Merge und lokalen Abschlusszustand zusammenfassen.

## Ruecksprungregeln

- Bei fehlgeschlagenen lokalen Pruefungen zur passenden Implementierung oder Fehlerbehebung zurueckkehren; keine beliebigen Fehler ausserhalb des Task-Scopes beheben.
- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zur passenden Umsetzung zurueckkehren.
- Bei fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und den Arbeitsbranch aktiv lassen.
- Wenn der Merge nicht verifiziert werden kann, nicht auf `develop` wechseln.

## Endergebnis

- taskbezogene Aenderungen sind bewusst committed und gepusht
- ein vorhandener Pull Request wurde wiederverwendet oder ein passender Pull Request erstellt
- erforderliche Checks sind fuer den gemergten Head-Commit erfolgreich
- der Pull Request ist regelkonform gemergt
- der lokale Checkout steht auf dem per Fast-Forward aktualisierten Branch `develop`
