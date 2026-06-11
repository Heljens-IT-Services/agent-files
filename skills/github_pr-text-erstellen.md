# Skill: GitHub PR Text Erstellen

## Zweck

Erzeuge einen klaren Pull-Request-Text fuer Review und Merge.

## Wann verwenden

- Vor dem Erstellen eines Pull Requests.
- Wenn Reviewer schnell verstehen sollen, warum und wie sich etwas geaendert hat.

## Input

- Ticket, Ziel oder Problem
- Aenderungszusammenfassung
- Teststatus
- optional: Risiken, offene Punkte, Screenshots

## Vorgehen

1. Motivation und Ziel der Aenderung beschreiben.
2. Wesentliche Codeaenderungen knapp zusammenfassen.
3. Test- und Verifikationsstatus angeben.
4. Risiken, offene Punkte oder Review-Fokus ergaenzen.

## Empfohlene Kommandos

```powershell
git status --short --branch
git diff --stat
git log --oneline --decorate -5
gh pr status
gh pr list --head <branch-name>
```

Wenn ein Pull Request erstellt werden soll:

```powershell
gh pr create --draft --title "<pr-titel>" --body "<pr-body>" --base <basis-branch> --head <branch-name>
gh pr view --json title,body,state,url,baseRefName,headRefName
```

Wenn ein Issue als Kontext dient:

```powershell
gh issue view <issue-nummer> --comments
```

`<branch-name>`, `<basis-branch>`, `<pr-titel>`, `<pr-body>` und `<issue-nummer>` muessen aus dem aktuellen Repository-Kontext abgeleitet werden.

## Output

- PR-Titel
- PR-Beschreibung
- Teststatus
- offene Punkte oder Review-Hinweise

## Qualitätskriterien

- Reviewer sollen ohne Diff-Einstieg den Kontext verstehen.
- Kein Changelog-Stil, sondern fokussierte Zusammenfassung.
- Risiken und Luecken nicht verstecken.
