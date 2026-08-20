# Workflow: Release

## Ziel

Den freigegebenen Stand von `develop` mit `/release` kontrolliert über einen Pull Request nach `main` veröffentlichen und den lokalen Default-Branch aktualisieren.

## Verwenden

- Wenn der User `/release` oder kanonisch `/workflows run release` beauftragt.
- Ausschließlich für die Freigabe von `develop` nach `main`.
- Nicht für den Abschluss eines Feature- oder Task-Branches; dafür `/finish` beziehungsweise den Workflow `feature-finish` verwenden.

## Reifekriterien

- Der Branch `develop` ist aktiv, der Arbeitsbaum ist sauber und der lokale Branch ist mit dem Remote synchronisiert.
- Die Remote-Branches `develop` und `main` sind vorhanden und `main` ist der aufgelöste Default-Branch.
- `develop` enthält gegenüber `main` zu veröffentlichende Änderungen.
- Der User hat mit `/release` Pull Request, Check-Beobachtung und Merge von `develop` nach `main` ausdrücklich beauftragt.

## Verwendete Skills

- `code-diff-review`
- `pr-creation`
- `pr-checks-observation`
- `github-pr-merge`
- `default-branch-update`

## Ablauf

1. `PROJECT.md`, Repository-Kontext, Working Tree, Remote, Default-Branch sowie die Branch-Zustände von `develop` und `main` bestimmen.
2. Stoppen, wenn nicht `develop` aktiv ist, der Arbeitsbaum Änderungen enthält, `develop` nicht mit dem Remote synchronisiert ist, einer der beiden Remote-Branches fehlt oder `main` nicht der Default-Branch ist.
3. Commits und Gesamtdiff von `<remote>/main` bis `<remote>/develop` bestimmen. Wenn kein Unterschied besteht, ohne Mutation mit dem Hinweis beenden, dass nichts zu veröffentlichen ist.
4. Mit `code-diff-review` den vollständigen Release-Diff prüfen und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
5. Die seit `main` in `develop` enthaltenen Pull Requests und deren noch offene, durch den Release tatsächlich erledigte Issues bestimmen. Diese Issues im Release-PR mit `Closes #<nummer>` verknüpfen, damit sie erst durch die Veröffentlichung nach `main` geschlossen werden.
6. Mit `pr-creation` einen vorhandenen Pull Request von `develop` nach `main` wiederverwenden oder mit `main` als expliziter Basis und `develop` als explizitem Head erstellen. `/release` gilt als ausdrückliche Anweisung, den Pull Request als Ready for Review bereitzustellen.
7. Mit `pr-checks-observation` die erforderlichen Checks für den unveränderten Pull-Request-Head bis zu einem terminalen Zustand beobachten.
8. Bei vollständig erfolgreichen erforderlichen Checks und erfüllten Repository-Regeln mit `github-pr-merge` und der aufgelösten Merge-Methode mergen. Bei `spending-limit-blocked` nur nach der dort vorgeschriebenen zusätzlichen Bestätigung fortfahren; eine erforderliche Merge Queue bis zum terminalen Ergebnis beobachten.
9. Nach verifiziertem Merge mit `default-branch-update` auf `main` wechseln und ihn per Fast-Forward aktualisieren.
10. Pull Request, enthaltene Issues, Check-Ergebnis, Merge und lokalen Abschlusszustand zusammenfassen.

## Rücksprungregeln

## Codex-Orchestrierung

- Release-Scope und Reifekriterien: `planner` nur bei offenen fachlichen Entscheidungen.
- Checks und Live-/Pages-Verifikation: `tester`.
- Branchwechsel, Merge, Push und externe Veröffentlichung: `main/orchestrator`; keine parallelen Schreibmutationen.

- Bei `code-diff-review` mit Bewertung `nicht versandbereit` zur betroffenen Umsetzung auf einem separaten Arbeitsbranch zurückkehren; `develop` im Release-Workflow nicht direkt verändern.
- Bei `spending-limit-blocked` zur ausdrücklichen Rückfrage in `github-pr-merge` wechseln.
- Bei anderen fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und `develop` aktiv lassen.
- Wenn der Merge nicht verifiziert werden kann, nicht auf `main` wechseln.

## Endergebnis

- ein vorhandener Release-Pull-Request wurde wiederverwendet oder mit Base `main` und Head `develop` erstellt
- enthaltene offene Issues sind im Release-Pull-Request korrekt verknüpft
- erforderliche Checks sind für den gemergten Head-Commit erfolgreich oder der nachgewiesene Spending-Limit-Fall wurde für diesen Head-Commit ausdrücklich bestätigt
- der Release-Pull-Request ist regelkonform gemergt
- der lokale Checkout steht auf dem per Fast-Forward aktualisierten Branch `main`

## Grenzen

- Auf `develop` oder `main` keine Release-Änderungen committen.
