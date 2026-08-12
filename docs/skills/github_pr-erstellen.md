# Skill: GitHub PR Erstellen

## Zweck

Einen vorhandenen Pull Request wiederverwenden oder einen neuen Pull Request mit passendem Titel, Body, Base und Head in GitHub erstellen.

## Verwenden

- Wenn ein gepushter Branch als Pull Request bereitgestellt werden soll.
- Wenn Reviewer Kontext, Änderung, Tests und Risiken schnell verstehen müssen.
- Nicht verwenden, wenn Commit und Push noch fehlen. Dann den Workflow `commit-push.md` nutzen.

## Vorgehen

1. Aktuellen Branch, Remote, Base-Branch und Push-Status prüfen.
2. Base-Branch nach Priorität bestimmen: User-Vorgabe, Workflow-/Issue-Vorgabe, eindeutiger Upstream-/Tracking-Kontext, Remote-Default, `develop`, `main`, `master`.
3. Ziel, Ausgangsproblem und verknüpfte Issues aus vorhandenem Kontext bestimmen.
4. Commits und relevanten Diff-Kontext lesen.
5. Bestehende offene Pull Requests für den aktuellen Branch suchen.
6. Wenn ein offener PR für den Branch existiert, bei zusätzlichem Kontext einen Kommentar ergänzen, einen vorhandenen Draft bei ausdrücklicher Anweisung als Ready markieren, die PR-URL melden und die Erstellung beenden.
7. Wenn kein offener PR existiert, PR-Titel und Body mit Issue-Verknüpfungen formulieren.
8. Teststatus, Risiken und Review-Hinweise nennen.
9. Pull Request standardmäßig als Draft, bei ausdrücklicher Ready-for-Review-Anweisung direkt als Ready erstellen.
10. Pull Request mit URL, Base, Head und Draft-/Ready-Status ausgeben.

## Issue-Verknüpfungen

- Ein einzelnes primäres Issue mit `Closes #<nummer>` verknüpfen, wenn der Pull Request dieses Issue vollständig abschließt; andernfalls `Refs #<nummer>` verwenden.
- Wenn ein vorgelagerter Workflow mehrere Issues als durch denselben Pull Request vollständig abgeschlossen bestätigt, darf und soll für jedes dieser Issues eine eigene `Closes #<nummer>`-Verknüpfung gesetzt werden.
- Nicht vollständig abgeschlossene, nur kontextuelle, extern blockierte oder lediglich verwandte Issues mit `Refs #<nummer>` oder normalem Kontext verlinken, sofern sie für Review oder Merge relevant sind.
- Bei `issue-graph-umsetzung.md` ausschließlich den final bestätigten Scope aus dessen Abschlussphase verwenden. Den gelesenen Rohgraphen nicht automatisch als Closure-Liste übernehmen.

## Kommandos

```powershell
git status --short --branch
git branch --show-current
git log --oneline --decorate origin/<base-branch>..HEAD
git diff --stat origin/<base-branch>...HEAD
gh issue view <issue-nummer> --comments
gh pr list --head <branch-name> --state open
gh pr comment <pr-nummer> --body "<kommentar>"
gh pr create --draft --title "<pr-titel>" --body "<pr-body>" --base <basis-branch> --head <branch-name>
gh pr create --title "<pr-titel>" --body "<pr-body>" --base <basis-branch> --head <branch-name>
gh pr ready <pr-nummer>
gh pr view --json title,body,state,isDraft,url,baseRefName,headRefName
```

Platzhalter aus aktuellem Branch, Remote-Default, verknüpften Issues und PR-Kontext ableiten.

## Grenzen

- Extern wirksam arbeiten: Pull Request wird tatsächlich erstellt.
- Keine lokalen Git-Mutationen ausführen. Das gehört zum Workflow `commit-push.md`.
- Keine Codeänderungen vornehmen.
- Keine Tests oder Diff-Reviews ersetzen.
- Kein Changelog-Ersatz schreiben.
- PR nur erstellen, wenn Branch gepusht ist und Base/Head eindeutig sind.
- Wenn Base-Branch nach Prioritätenliste unklar bleibt, nachfragen.
- Bestehenden PR-Titel oder PR-Body nicht aktualisieren.
- Bei zusätzlichem Kontext zum bestehenden PR einen Kommentar ergänzen.
- Vorhandene Issue-Kontexte immer im PR-Body verlinken.
- `Closes` nur für Issues verwenden, deren vollständiger Abschluss durch den aktuellen PR aus dem vorhandenen Workflow-Kontext eindeutig bestätigt ist.
- Parent-, Sub-, Blocked- oder Related-Issues nur verlinken, wenn sie für Scope, Review oder Merge relevant sind.
- Keinen irrelevanten Issue-Graph in den PR-Body aufnehmen.
- Reviewer, Assignees oder Labels nur setzen, wenn der User es explizit verlangt.

## Output

- PR-Titel
- PR-Beschreibung
- PR-URL
- Draft-/Ready-Status
- Base-Branch und Head-Branch
- Teststatus
- Risiken oder Review-Hinweise
- gesetzte Reviewer, Assignees oder Labels, falls explizit verlangt

## Qualitätskriterien

- Motivation, Änderung und Verifikation müssen erkennbar sein.
- Risiken und Testlücken nicht verstecken.
- PR-Titel muss Review-Scope knapp beschreiben.
- PR-Body muss keine Commit-Liste duplizieren.
- Closure-Verknüpfungen müssen den tatsächlich abgeschlossenen Scope widerspiegeln.
