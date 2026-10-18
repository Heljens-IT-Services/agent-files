# Skill: GitHub Worktree Inventory

## Zweck

Haupt- und Linked Worktrees eines Repositorys lesend inventarisieren und für einen einzelnen Linked Worktree das Sicherheits-Audit vor einer Entfernung erstellen.

## Verwenden

- Wenn vorhandene Worktrees, ihr Zustand oder verwaiste Worktree-Reste erfasst werden sollen, z. B. mit `/worktrees`.
- Wenn für einen benannten Linked Worktree geprüft werden soll, ob er sicher entfernt werden kann, z. B. mit `/worktree status <worktree-ref>`.
- Als Kontextschritt vor `worktree-creation`, `worktree-removal` und `worktree-orphan-cleanup`, die die Abschnitte `Kontext bestimmen` und `Sicherheits-Audit` dieses Skills verwenden.
- Nicht verwenden, um Worktrees zu erstellen, zu entfernen oder zu bereinigen.

## Argumente

- `<worktree-ref>`: Issue-Nummer als positive Ganzzahl mit optionalem `#`, z. B. `688` oder `#688`, oder der Verzeichnisname eines Linked Worktrees unter dem Managed Worktree Root.
- Eine Issue-Nummer wird über Branches nach dem Muster `<typ>/<issue-number>-<kurzer-scope>` und Verzeichnisnamen mit dieser Nummer aufgelöst. Ist das Ergebnis nicht genau ein Worktree, wird gestoppt und die Kandidatenliste genannt.

## Kontext bestimmen

1. Repository-Root, Git-Verzeichnis und Common Git Directory über Git ermitteln, nicht über Ordnernamen.
2. Hauptworktree bestimmen: der in `PROJECT.md` benannte Pfad, sonst der erste Eintrag aus `git worktree list --porcelain`, dessen `.git` ein Verzeichnis ist. Abweichungen zwischen beiden Quellen als Blocker melden.
3. Primary Remote bestimmen: Vorgabe in `PROJECT.md`, ausdrückliche User-Vorgabe oder genau ein vorhandener Remote. Bei mehreren Remotes ohne Vorgabe stoppen und nachfragen; `origin` nicht pauschal annehmen.
4. Default-Branch des Primary Remote ermitteln.
5. Managed Worktree Root bestimmen: Vorgabe in `PROJECT.md` oder ausdrückliche User-Vorgabe. Ohne Vorgabe als `nicht festgelegt` ausweisen; der Root wird nicht geraten.
6. Pfade kanonisch auflösen, einschließlich Symlinks und Junctions, und einheitlich mit abschließendem Trennzeichen vergleichen, damit z. B. `<root>-alt` nicht als Unterpfad von `<root>` gilt.

## Inventur

Für jeden Eintrag aus `git worktree list --porcelain` erfassen:

- Typ: Hauptworktree oder Linked Worktree
- absoluter kanonischer Pfad und Lage innerhalb oder außerhalb des Managed Worktree Root
- Branch oder Detached HEAD
- HEAD-Commit und Commit-Datum
- Arbeitsstatus: sauber oder verändert, einschließlich untracked Dateien
- Upstream sowie Ahead/Behind
- Commits, die auf keinem Remote-Tracking-Branch des Primary Remote liegen
- Git-Zustand: registriert, `locked`, `prunable` oder Verzeichnis fehlt

Zusätzlich Verzeichnisse unter dem Managed Worktree Root erfassen, die nicht als Worktree registriert sind, und als mögliche Reste kennzeichnen.

## Sicherheits-Audit

Das Audit gilt für genau einen Linked Worktree und ist nur gültig, wenn es unmittelbar vor der Entscheidung oder Mutation erstellt wurde. Jeder Prüfpunkt wird mit `bestanden`, `nicht bestanden` oder `nicht prüfbar` bewertet.

1. Der Pfad ist technisch ein registrierter Linked Worktree desselben Common Git Directory.
2. Der Pfad ist weder Hauptworktree noch Repository-Root des Hauptworktrees und liegt kanonisch innerhalb des Managed Worktree Root.
3. `git status --short` ist leer; untracked und ignorierte, aber fachlich relevante Dateien sind benannt.
4. Ein Upstream ist vorhanden oder die Remote-Sicherung aller Commits ist anderweitig eindeutig nachgewiesen.
5. Ahead/Behind gegenüber dem Upstream ist bestimmt; es gibt keine Commits, die nicht auf dem Primary Remote liegen.
6. PR- oder Merge-Status ist geprüft, wenn `PROJECT.md` oder der User eine Retention Policy vorgibt.
7. Symlinks, Junctions und andere Reparse Points innerhalb des Pfads sind inventarisiert, ohne ihnen zu folgen.
8. Prozesse mit Bezug zum Pfad sind identifiziert, z. B. VS-Code-Fenster, integrierte Terminals, Devserver, Test-Watcher und Buildprozesse. Ist das nicht zuverlässig möglich, ist der Prüfpunkt `nicht prüfbar` und erfordert eine Bestätigung des Users.

[MUST] Das Audit ist nur `sicher entfernbar`, wenn alle Prüfpunkte `bestanden` sind oder ein `nicht prüfbar` ausdrücklich vom User bestätigt wurde.

## Kommandos

```powershell
git rev-parse --show-toplevel
git rev-parse --path-format=absolute --git-dir
git rev-parse --path-format=absolute --git-common-dir
git remote
git symbolic-ref --short "refs/remotes/<primary-remote>/HEAD"
git worktree list --porcelain
git -C <pfad> status --short --branch
git -C <pfad> rev-parse --abbrev-ref --symbolic-full-name "@{upstream}"
git -C <pfad> rev-list --left-right --count "HEAD...@{upstream}"
git -C <pfad> log --oneline HEAD --not "--remotes=<primary-remote>"
git -C <pfad> log -1 --format="%H %cI"
gh pr list --repo <org>/<repo> --head <branch> --state all --json number,state,url
Get-ChildItem -LiteralPath <pfad> -Recurse -Force -Attributes ReparsePoint
Get-CimInstance Win32_Process | Where-Object { $_.CommandLine -like "*<pfad>*" }
```

Unter Linux oder macOS sind `realpath`, `find <pfad> -type l` und `lsof +D <pfad>` gleichwertige Alternativen. `Get-ChildItem -Recurse` folgt in PowerShell 7 Verknüpfungen nicht; in älteren PowerShell-Versionen Reparse Points nur ebenenweise ohne Rekursion in Links inventarisieren.

## Grenzen

- Ausschließlich lesend arbeiten.
- Keine Worktrees, Branches, Verzeichnisse, Prozesse oder Git-Metadaten verändern; kein `git worktree prune`.
- `git fetch` nur ausführen, wenn der User oder der aufrufende Skill aktuelle Remote-Daten verlangt; sonst den Stand der Remote-Tracking-Branches mit Zeitbezug benennen.
- Symlinks und Junctions nicht traversieren.
- Keine Prozesse beenden.

## Output

- Repository, Hauptworktree, Primary Remote, Default-Branch und Managed Worktree Root
- kompakte Inventurtabelle aller Worktrees und möglichen Reste
- bei einem Audit: Prüfpunkte mit Bewertung und Gesamtergebnis `sicher entfernbar` oder `nicht entfernbar` mit konkreten Blockern

## Qualitätskriterien

- Hauptworktree und Linked Worktrees sind über Git-Metadaten unterschieden.
- Jeder Pfad ist absolut und kanonisch angegeben.
- Nicht prüfbare Punkte werden nicht als bestanden dargestellt.
- Ungepushte Commits und uncommittete Änderungen sind je Worktree sichtbar.
