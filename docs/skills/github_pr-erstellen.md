# Skill: GitHub PR Erstellen

## Zweck

Einen vorhandenen Pull Request wiederverwenden oder einen neuen Pull Request mit passendem Titel, Body, Base und Head in GitHub erstellen.

## Verwenden

- Wenn ein gepushter Branch als Pull Request bereitgestellt werden soll.
- Wenn Reviewer Kontext, Aenderung, Tests und Risiken schnell verstehen muessen.
- Nicht verwenden, wenn noch kein Commit/Push erfolgt ist. Dann `github_commit-push` nutzen.

## Vorgehen

1. Aktuellen Branch, Remote, Base-Branch und Push-Status pruefen.
2. Base-Branch nach Prioritaet bestimmen: User-Vorgabe, Workflow-/Issue-Vorgabe, eindeutiger Upstream-/Tracking-Kontext, Remote-Default, `develop`, `main`, `master`.
3. Ziel, Ausgangsproblem und verknuepfte Issues aus vorhandenem Kontext bestimmen.
4. Commits und relevanten Diff-Kontext lesen.
5. Bestehende offene Pull Requests fuer den aktuellen Branch suchen.
6. Wenn ein offener PR fuer den Branch existiert, bei zusaetzlichem Kontext einen Kommentar ergaenzen, einen vorhandenen Draft bei ausdruecklicher Anweisung als Ready markieren, die PR-URL melden und die Erstellung beenden.
7. Wenn kein offener PR existiert, PR-Titel und Body mit Issue-Verknuepfungen formulieren.
8. Teststatus, Risiken und Review-Hinweise nennen.
9. Pull Request standardmaessig als Draft, bei ausdruecklicher Ready-for-Review-Anweisung direkt als Ready erstellen.
10. Pull Request mit URL, Base, Head und Draft-/Ready-Status ausgeben.

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

Platzhalter aus aktuellem Branch, Remote-Default, verknuepften Issues und PR-Kontext ableiten.

## Grenzen

- Extern wirksam arbeiten: Pull Request wird tatsaechlich erstellt.
- Keine Commits erstellen und nicht pushen. Das gehoert zu `github_commit-push`.
- Keine Codeaenderungen vornehmen.
- Keine Tests oder Diff-Reviews ersetzen.
- Kein Changelog-Ersatz schreiben.
- PR nur erstellen, wenn Branch gepusht ist und Base/Head eindeutig sind.
- Wenn Base-Branch nach Prioritaetenliste unklar bleibt, nachfragen.
- Bestehenden PR-Titel oder PR-Body nicht aktualisieren.
- Bei zusaetzlichem Kontext zum bestehenden PR einen Kommentar ergaenzen.
- Vorhandene Issue-Kontexte immer im PR-Body verlinken.
- Primaeres Issue mit `Closes #<nummer>` oder `Refs #<nummer>` verknuepfen, passend dazu, ob der PR das Issue abschliesst.
- Parent-, Sub-, Blocked- oder Related-Issues nur verlinken, wenn sie fuer Scope, Review oder Merge relevant sind.
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

## Qualitaetskriterien

- Motivation, Aenderung und Verifikation muessen erkennbar sein.
- Risiken und Testluecken nicht verstecken.
- PR-Titel muss Review-Scope knapp beschreiben.
- PR-Body muss keine Commit-Liste duplizieren.
