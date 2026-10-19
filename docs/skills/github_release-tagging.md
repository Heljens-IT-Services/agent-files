# Skill: GitHub Release Taggen

## Zweck

Einen verifiziert nach `main` gemergten Release-Stand mit einem unveränderlichen Tag und einem GitHub Release versehen, damit konsumierende Repositories diesen Regelstand pinnen können.

## Verwenden

- Nach einem verifizierten Release-Merge nach `main`, wenn der Release-Workflow das Taggen vorsieht.
- Nicht für Feature-, Hotfix- oder Arbeitsbranches und nicht für Commits, die noch nicht auf `main` gemergt sind.

## Vorgehen

1. Repository, Remote und den verifizierten Merge-Commit des Release-Pull-Requests auf `<remote>/main` bestimmen.
2. Vorhandene Tags vom Remote holen und prüfen, ob der Merge-Commit bereits ein Release-Tag trägt. In diesem Fall ohne Mutation mit dem vorhandenen Tag abschließen.
3. Den Tag-Namen aus dem UTC-Datum des Merges im Schema `vJJJJ.MM.TT` bilden. Existiert dieser Tag bereits für einen anderen Commit, `vJJJJ.MM.TT.<n>` mit der kleinsten freien Zahl ab `2` verwenden.
4. Ein annotiertes Tag auf genau den Merge-Commit setzen und ausschließlich dieses Tag zum Remote pushen.
5. Zum Tag ein GitHub Release mit automatisch erzeugten Release Notes erstellen und den Release-Pull-Request in den Notes nennen.
6. Tag, Ziel-Commit und Release über Remote und GitHub API zurücklesen.

## Kommandos

```powershell
git fetch <remote> --tags
git rev-parse <remote>/main
git tag --points-at <merge-sha>
git tag -a <tag> <merge-sha> -m "Release <tag>"
git push <remote> refs/tags/<tag>
gh release create <tag> --verify-tag --title "<tag>" --generate-notes --notes "Release-PR: #<nummer>"
git ls-remote --tags <remote> <tag>
gh release view <tag> --json tagName,targetCommitish,url
```

## Grenzen

- Extern wirksam: Ein Tag und ein GitHub Release werden veröffentlicht.
- Nur auf einen verifiziert nach `main` gemergten Commit taggen.
- Veröffentlichte Tags nicht verschieben, überschreiben oder löschen; kein `--force` beim Taggen oder Pushen.
- Keine Branches pushen und keine weiteren Tags mitpushen, insbesondere kein `git push --tags`.
- Bei fehlenden Rechten, einem Namenskonflikt ohne freie Folgenummer oder einem abweichenden Ziel-Commit stoppen und den Befund melden.

## Output

- Tag-Name und Ziel-Commit
- URL des GitHub Release
- Hinweis, falls ein vorhandenes Tag wiederverwendet wurde
- Blocker, falls kein Tag oder Release erstellt werden konnte

## Qualitätskriterien

- Das Remote-Tag zeigt nachweislich auf den Merge-Commit des Release-Pull-Requests.
- Jeder Release-Commit trägt höchstens ein Release-Tag.
- Das GitHub Release ist dem Tag zugeordnet und zurückgelesen.
