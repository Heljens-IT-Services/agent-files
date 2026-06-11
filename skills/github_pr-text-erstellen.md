# Skill: GitHub PR Text Erstellen

## Zweck

Pull-Request-Titel und Beschreibung fuer Review und Merge erstellen.

## Verwenden

- Vor dem Erstellen oder Aktualisieren eines Pull Requests.
- Wenn Reviewer Kontext, Aenderung, Tests und Risiken schnell verstehen muessen.

## Vorgehen

1. Ziel und Ausgangsproblem bestimmen.
2. Diff, Commits und verknuepfte Issues pruefen.
3. Wesentliche Aenderungen zusammenfassen.
4. Teststatus und Risiken nennen.
5. PR-Titel und Body formulieren.

## Empfohlene Kommandos

```powershell
git status --short --branch
git diff --stat
git log --oneline --decorate -5
gh issue view <issue-nummer> --comments
gh pr create --draft --title "<pr-titel>" --body "<pr-body>" --base <basis-branch> --head <branch-name>
gh pr view --json title,body,state,url,baseRefName,headRefName
```

## Output

- PR-Titel
- PR-Beschreibung
- Teststatus
- Risiken oder Review-Hinweise

## Qualitaetskriterien

- Kein Changelog-Ersatz.
- Motivation, Aenderung und Verifikation muessen erkennbar sein.
- Risiken und Testluecken nicht verstecken.
