# Skill: GitHub Worktree Creation

## Zweck

Einen Linked Worktree für einen Arbeitsbranch kontrolliert unter dem Managed Worktree Root erstellen oder einen vorhandenen Linked Worktree in einem eigenen VS-Code-Fenster öffnen.

## Verwenden

- Wenn der User ausdrücklich einen zusätzlichen Worktree verlangt oder `/worktree create <issue-number>` auslöst.
- Wenn ein vorhandener Linked Worktree mit `/worktree open <worktree-ref>` in VS Code geöffnet werden soll.
- Nicht verwenden, wenn im aktuellen Arbeitsverzeichnis gearbeitet werden kann. Dann `github-branch-checkout-from-default` nutzen.
- Nicht verwenden, um Worktrees zu entfernen oder zu bereinigen. Dann `worktree-removal` oder `worktree-orphan-cleanup` nutzen.

## Argumente

- `<issue-number>`: positive Ganzzahl mit optionalem `#`; bestimmt Branch- und Verzeichnisnamen.
- `--base <branch>`: ausdrücklich gewünschter Basisbranch; überschreibt die Basisauflösung.
- `<worktree-ref>`: wie in [worktree-inventory](https://heljens-it-services.github.io/agent-files/skills/github_worktree-inventory.md) definiert.

## Vorgehen

1. Autorisierung prüfen: ausdrückliche User-Anweisung oder ausgelöster Worktree-Command.
2. Kontext gemäß `worktree-inventory`, Abschnitt `Kontext bestimmen`, ermitteln. Ohne festgelegten Managed Worktree Root stoppen und nachfragen.
3. Primary Remote fetchen.
4. Basisbranch bestimmen: `--base` oder ausdrückliche User-Vorgabe, sonst die Basisreihenfolge aus [github-branch-checkout-from-default](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md). Als Basis den Remote-Tracking-Branch `<primary-remote>/<basis-branch>` verwenden; einen lokalen Branch nur, wenn kein Remote-Pendant existiert und er nicht hinter diesem zurückliegt.
5. Branch-Namen nach der Konvention aus `github-branch-checkout-from-default` bilden und lokal sowie auf dem Primary Remote auf Existenz prüfen.
6. Zielpfad `<managed-worktree-root>/<verzeichnisname>` bilden, z. B. `issue-688` oder `<typ>-<issue-number>-<kurzer-scope>`, kanonisch auflösen und prüfen, dass er innerhalb des Managed Worktree Root liegt und noch nicht existiert.
7. Vor der Mutation absoluten Zielpfad, Arbeitsbranch, Basisbranch mit Basis-Commit und Verwendungszweck nennen.
8. Worktree erstellen:
   - neuer Branch: atomar über `git worktree add` mit `-b` und `--no-track` auf den Basis-Commit;
   - vorhandener lokaler Branch: ohne neue Branch-Erstellung auschecken;
   - nur remote vorhandener Branch: lokalen Tracking-Branch auf dem Remote-Stand anlegen.
9. Tatsächlichen Branch, HEAD-Commit, Pfad und Registrierung mit `git worktree list --porcelain` verifizieren.
10. Projektabhängigkeiten nur installieren, wenn der Task es erfordert und `PROJECT.md` oder der User das Vorgehen vorgibt.
11. Worktree mit `code -n <pfad>` in einem separaten VS-Code-Fenster öffnen, wenn eine VS-Code-Umgebung genutzt wird; vorher absoluten Pfad und Branch nennen.

Für `/worktree open <worktree-ref>` gelten nur die Schritte 2, 9 und 11 für den aufgelösten, bereits registrierten Linked Worktree.

## Kommandos

```powershell
git fetch <primary-remote>
git rev-parse --verify "<primary-remote>/<basis-branch>"
git rev-list --left-right --count "<basis-branch>...<primary-remote>/<basis-branch>"
git show-ref --verify "refs/heads/<branch>"
git ls-remote --heads <primary-remote> <branch>
git worktree add --no-track -b <branch> <pfad> "<primary-remote>/<basis-branch>"
git worktree add <pfad> <branch>
git worktree add --track -b <branch> <pfad> "<primary-remote>/<branch>"
git -C <pfad> status --short --branch
git -C <pfad> rev-parse HEAD
git worktree list --porcelain
code -n <pfad>
```

`--no-track` verhindert, dass der Basisbranch als Upstream gesetzt wird; der Upstream entsteht beim ersten Push über `github-push`.

## Grenzen

- Zustandsverändernd arbeiten: Es werden ausschließlich ein Linked Worktree und gegebenenfalls ein lokaler Branch erstellt.
- Keinen Worktree außerhalb des Managed Worktree Root erstellen.
- Einen vorhandenen Branch nicht neu erstellen, zurücksetzen, rebasen oder auf eine andere Basis verschieben.
- Keinen Branch-Namen oder Zielpfad wiederverwenden, der bereits existiert.
- Basisbranch nicht raten; bei unklarer Basis stoppen und nachfragen.
- `code -r` nur verwenden, wenn der User ausdrücklich das aktuelle Fenster ersetzen will.
- Keine anderen VS-Code-Fenster oder Projekte schließen.
- Nicht committen, pushen oder Pull Requests erstellen.

## Output

- absoluter Worktree-Pfad
- Arbeitsbranch, Basisbranch und Basis-Commit
- Hinweis, ob ein vorhandener Branch ausgecheckt wurde
- Status des VS-Code-Fensters
- verbleibende Worktrees gemäß `git worktree list --porcelain`

## Qualitätskriterien

- Pfad, Branch, Basis und Basis-Commit werden vor und nach der Mutation genannt.
- Der Worktree liegt kanonisch innerhalb des Managed Worktree Root.
- Der neue Branch startet auf dem geprüften aktuellen Remote-Stand der Basis.
- Der Erfolg wird aus dem verifizierten Git-Zustand abgeleitet, nicht allein aus einem Exitcode.
