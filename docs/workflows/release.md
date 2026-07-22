# Workflow: Release

## Ziel

Den freigegebenen Stand von `develop` mit `/finish release` kontrolliert ueber einen Pull Request nach `main` veroeffentlichen und den lokalen Default-Branch aktualisieren.

## Verwenden

- Wenn der User `/finish release` oder kanonisch `/workflows run release` beauftragt.
- Ausschliesslich fuer die Freigabe von `develop` nach `main`.
- Nicht fuer den Abschluss eines Feature- oder Task-Branches; dafuer `/finish` beziehungsweise den Workflow `finish` verwenden.

## Reifekriterien

- Der Branch `develop` ist aktiv, der Arbeitsbaum ist sauber und der lokale Branch ist mit dem Remote synchronisiert.
- Die Remote-Branches `develop` und `main` sind vorhanden und `main` ist der aufgeloeste Default-Branch.
- `develop` enthaelt gegenueber `main` zu veroeffentlichende Aenderungen.
- Der User hat mit `/finish release` Pull Request, Check-Beobachtung und Merge von `develop` nach `main` ausdruecklich beauftragt.

## Verwendete Skills

- `code_diff-review`
- `github_pr-erstellen`
- `github_pr-checks-beobachten`
- `github_pr-merge`
- `github_default-branch-aktualisieren`

## Ablauf

1. `PROJECT.md`, Repository-Kontext, Working Tree, Remote, Default-Branch sowie die Branch-Zustaende von `develop` und `main` bestimmen.
2. Stoppen, wenn nicht `develop` aktiv ist, der Arbeitsbaum Aenderungen enthaelt, `develop` nicht mit dem Remote synchronisiert ist, einer der beiden Remote-Branches fehlt oder `main` nicht der Default-Branch ist.
3. Commits und Gesamtdiff von `<remote>/main` bis `<remote>/develop` bestimmen. Wenn kein Unterschied besteht, ohne Mutation mit dem Hinweis beenden, dass nichts zu veroeffentlichen ist.
4. Mit `code_diff-review` den vollstaendigen Release-Diff pruefen und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
5. Die seit `main` in `develop` enthaltenen Pull Requests und deren noch offene, durch den Release tatsaechlich erledigte Issues bestimmen. Diese Issues im Release-PR mit `Closes #<nummer>` verknuepfen, damit sie erst durch die Veroeffentlichung nach `main` geschlossen werden.
6. Mit `github_pr-erstellen` einen vorhandenen Pull Request von `develop` nach `main` wiederverwenden oder mit `main` als expliziter Basis und `develop` als explizitem Head erstellen. `/finish release` gilt als ausdrueckliche Anweisung, den Pull Request als Ready for Review bereitzustellen.
7. Mit `github_pr-checks-beobachten` die erforderlichen Checks fuer den unveraenderten Pull-Request-Head bis zu einem terminalen Zustand beobachten.
8. Nur bei vollstaendig erfolgreichen erforderlichen Checks und erfuellten Repository-Regeln mit `github_pr-merge` und der aufgeloesten Merge-Methode mergen; eine erforderliche Merge Queue bis zum terminalen Ergebnis beobachten.
9. Nach verifiziertem Merge mit `github_default-branch-aktualisieren` auf `main` wechseln und ihn per Fast-Forward aktualisieren.
10. Pull Request, enthaltene Issues, Check-Ergebnis, Merge und lokalen Abschlusszustand zusammenfassen.

## Ruecksprungregeln

- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zur betroffenen Umsetzung auf einem separaten Arbeitsbranch zurueckkehren; `develop` im Release-Workflow nicht direkt veraendern.
- Bei einem nach der Check-Beobachtung veraenderten Pull-Request-Head die Checks erneut beobachten.
- Bei fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und `develop` aktiv lassen.
- Wenn der Merge nicht verifiziert werden kann, nicht auf `main` wechseln.

## Endergebnis

- ein vorhandener Release-Pull-Request von `develop` nach `main` wurde wiederverwendet oder passend erstellt
- enthaltene offene Issues sind im Release-Pull-Request korrekt verknuepft
- erforderliche Checks sind fuer den gemergten Head-Commit erfolgreich
- der Release-Pull-Request ist regelkonform gemergt
- der lokale Checkout steht auf dem per Fast-Forward aktualisierten Branch `main`

## Grenzen

- Auf `develop` oder `main` keine Release-Aenderungen committen.
- Kein Force-Push, kein `--admin` und keine Umgehung erforderlicher Checks oder Reviews.
- `develop` und Arbeitsbranches weder lokal noch remote automatisch loeschen.
