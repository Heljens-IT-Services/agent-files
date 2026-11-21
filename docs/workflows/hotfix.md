# Workflow: Hotfix

## Ziel

Einen dringenden Fehler auf dem veröffentlichten Stand `main` mit `/hotfix` auf einem eigenen Bugfix-Branch von `main` beheben, per Pull Request nach `main` bringen und anschließend kontrolliert nach `develop` zurückführen.

## Verwenden

- Wenn der User `/hotfix`, kanonisch `/workflows run hotfix`, oder gleichbedeutend einen dringenden Fix des veröffentlichten Stands beauftragt.
- Wenn der Fehler auf `main` reproduzierbar ist und nicht bis zum nächsten regulären Release warten kann.
- Nicht verwenden, wenn der Fehler nur auf `develop` oder einem Arbeitsbranch auftritt oder bis zum nächsten Release warten kann. Dann `bugfix-from-default` beziehungsweise `/bugfix from-default` mit der regulären Basis nutzen.
- Nicht verwenden, um den Stand von `develop` nach `main` zu veröffentlichen. Dafür `release` beziehungsweise `/release` nutzen.
- Nicht verwenden, wenn auf dem aktuellen Branch weitergearbeitet werden soll. Dann `bugfix` beziehungsweise `/bugfix` nutzen.

## Direkter Alias

- `/hotfix`

Der kanonische Aufruf lautet `/workflows run hotfix`.

## Reifekriterien

- Die Remote-Branches `main` und `develop` sind vorhanden und `main` ist der aufgelöste Default-Branch.
- Der Arbeitsbaum ist sauber oder enthält keine fachlichen Änderungen, die mitgenommen werden müssten.
- Fehlerbild, betroffener veröffentlichter Stand und Dringlichkeit sind benannt.
- `/hotfix` beauftragt Branch, Fix, Verifikation, Commit, Push und Pull Requests. Jeder Merge erfordert zusätzlich eine ausdrückliche Freigabe des Users für den konkreten Pull Request.

## Verwendete Skills

- `issue-reading`
- `github-branch-checkout-from-default`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-minimization`
- `code-testing`
- `code-diff-review`
- `pr-creation`
- `pr-checks-observation`
- `github-pr-merge`
- `github-push`
- `default-branch-update`
- `integration-branch-update`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

### Phase 1: Fix nach `main`

1. `PROJECT.md`, Repository-Kontext, Working Tree, Remote, Default-Branch sowie die Branch-Zustände von `main` und `develop` bestimmen. Stoppen, wenn ein Reifekriterium nicht erfüllt ist.
2. Bug-Input aufnehmen: vorhandenen Kontext verwenden oder mit `issue-reading` das Issue lesen.
3. Mit `github-branch-checkout-from-default` und der expliziten Basis `main` einen Branch `bugfix/<kurzer-scope>` beziehungsweise `bugfix/<issue-number>-<kurzer-scope>` erstellen.
4. Nur bei ungeklärter Ursache mit `code-analysis` Ursache, Scope und Risiken klären.
5. Mit `code-testing` den Fehler auf dem von `main` abgeleiteten Stand reproduzieren. Ist er dort nicht reproduzierbar, gemäß Rücksprungregeln stoppen.
6. Den vorhandenen Issue- oder Task-Plan übernehmen. Nur ohne vollständigen Plan oder bei Planbruch mit `code-implementation-planning` gezielt planen.
7. Mit `code-implementation` den kleinstmöglichen Fix umsetzen.
8. Mit `code-testing` prüfen, dass die ursprüngliche Reproduktion nicht mehr fehlschlägt und relevante Regressionen abgedeckt sind.
9. Mit `code-minimization` den Änderungssatz auf unbegründete Bestandteile prüfen; nach jeder akzeptierten Reduktion Reproduktion und betroffene Regression erneut grün prüfen.
10. Mit `code-diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
11. Mit dem Workflow `commit-push.md` Commit und Push auf dem Hotfix-Branch ausführen.
12. Mit `pr-creation` einen Pull Request mit Base `main` und dem Hotfix-Branch als Head erstellen oder wiederverwenden. `/hotfix` gilt als ausdrückliche Anweisung, ihn als Ready for Review bereitzustellen. Der Body nennt Ursache, Fix, Absicherung und die anstehende Rückführung nach `develop`.
13. Mit `pr-checks-observation` die erforderlichen Checks für den unveränderten Head beobachten.
14. Check-Ergebnis und Merge-Bereitschaft melden und die ausdrückliche Merge-Freigabe des Users einholen. Erst danach mit `github-pr-merge` mergen.
15. Nach verifiziertem Merge mit `default-branch-update` auf `main` wechseln und ihn per Fast-Forward aktualisieren.

### Phase 2: Rückführung nach `develop`

16. Die Rückführungsvariante gemäß [Entscheidungskriterien](#entscheidungskriterien) bestimmen und dem User mit Begründung nennen.
17. Back-Merge: Mit `pr-creation` einen Pull Request mit Base `develop` und Head `main` erstellen oder wiederverwenden.
18. Cherry-Pick: Mit `github-branch-checkout-from-default` und der expliziten Basis `develop` einen Branch `bugfix/<kurzer-scope>-develop` erstellen, die nach `main` gelandeten Hotfix-Commits mit `git cherry-pick -x` übernehmen, mit `code-testing` die Reproduktion und relevante Regressionen auf diesem Stand prüfen, mit `code-diff-review` kontrollieren, mit `github-push` veröffentlichen und mit `pr-creation` einen Pull Request mit Base `develop` erstellen.
19. Mit `pr-checks-observation` die erforderlichen Checks des Rückführungs-Pull-Requests beobachten.
20. Die ausdrückliche Merge-Freigabe des Users einholen und erst danach mit `github-pr-merge` mergen.
21. Nach verifiziertem Merge mit `integration-branch-update` auf `develop` wechseln und ihn per Fast-Forward aktualisieren.
22. Beide Pull Requests, Check-Ergebnisse, Merges, gewählte Rückführungsvariante und lokalen Abschlusszustand zusammenfassen.

Für den Cherry-Pick in Schritt 18 gibt es keinen eigenen Skill. Der Schritt ist auf die unveränderte Übernahme der bereits nach `main` gemergten Hotfix-Commits begrenzt; Merge-Commits werden nicht übernommen.

## Entscheidungskriterien

- Back-Merge ist der Default, wenn `git diff <remote>/develop...<remote>/main` ausschließlich die Hotfix-Änderungen zeigt und die für den Rückführungs-Pull-Request aufgelöste Merge-Methode einen Merge-Commit erzeugt.
- Cherry-Pick ist zu verwenden, wenn `main` gegenüber `develop` weitere, nicht für `develop` bestimmte Änderungen enthält oder für den Rückführungs-Pull-Request nur Squash oder Rebase zulässig ist.
- Lässt sich die Variante nicht eindeutig bestimmen, vor Phase 2 rückfragen.

## Rücksprungregeln

Ein Pull Request darf bei `no-checks-required` fortgesetzt werden, wenn keine erforderlichen Checks konfiguriert sind und keine Checks für den unveränderten Head berichtet werden. Das Fehlen eines tatsächlich konfigurierten erforderlichen Checks bleibt ein Blocker.

- Wenn der Fehler auf `main` nicht reproduzierbar ist, stoppen und auf `bugfix-from-default` mit der regulären Basis verweisen.
- Wenn Ursache, Scope oder Risiken unklar sind, zurück zu `code-analysis`.
- Wenn der Fix größer als erwartet wird, zurück zu `code-implementation-planning` und rückfragen, ob er noch als Hotfix gelten soll.
- Bei `code-diff-review` mit Bewertung `nicht versandbereit` zur passenden Umsetzung zurückkehren.
- Bei `spending-limit-blocked` zur ausdrücklichen Rückfrage in `github-pr-merge` wechseln.
- Bei anderen fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und den aktuellen Branch aktiv lassen.
- Bei Konflikten im Back-Merge-Pull-Request zur Cherry-Pick-Variante wechseln und dies begründen.
- Bei Konflikten im Cherry-Pick `git cherry-pick --abort` ausführen, stoppen und den Konflikt melden; eine Konfliktauflösung erfolgt nur nach Rückfrage mit `code-implementation` im Hotfix-Scope.
- Wenn ein Merge nicht verifiziert werden kann, nicht auf `main` beziehungsweise `develop` wechseln und Phase 2 nicht beginnen.

## Codex-Orchestrierung

- Ursachenklärung und Umsetzung: `developer`.
- Reproduktion, Regression und Checks: `tester`.
- Branch-Erstellung, Cherry-Pick, Commit, Push, Pull Requests und Merges: `main/orchestrator` sequenziell.

## Endergebnis

- behobener Fehler auf `main` über einen gemergten Hotfix-Pull-Request
- in `develop` zurückgeführter Hotfix über einen gemergten Back-Merge- oder Cherry-Pick-Pull-Request
- nachvollziehbarer Bugfix-, Test- und Review-Kontext
- dokumentierte Rückführungsvariante mit Begründung
- lokaler Checkout auf dem per Fast-Forward aktualisierten Branch `develop`

## Grenzen

- Nicht direkt auf `main` oder `develop` committen und nicht auf diese Branches pushen.
- Keine Änderungen aus `develop` in den Hotfix-Branch übernehmen; der Hotfix-Pull-Request enthält ausschließlich den Fix.
- Den Workflow `release` nicht ersetzen: Den Stand von `develop` nicht über den Hotfix nach `main` bringen.
- Keinen Merge ohne ausdrückliche Freigabe des Users für den konkreten Pull Request ausführen.
- Kein Force-Push, kein Rebase und keine administrative Umgehung von Checks oder Branch-Regeln.
- Phase 2 nicht auslassen; bleibt sie blockiert, den fehlenden Rückführungsstand als offenen Punkt melden.
