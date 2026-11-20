# Skill: GitHub Worktree Removal

## Zweck

Genau einen registrierten Linked Worktree nach bestandenem Sicherheits-Audit Git-nativ entfernen, ohne Arbeit zu verlieren.

## Verwenden

- Wenn ein benannter Linked Worktree nach Abschluss seiner Arbeit entfernt werden soll, z. B. mit `/worktree remove <worktree-ref>`.
- Nicht verwenden für nicht mehr registrierte Verzeichnisreste oder veraltete Metadaten ohne zugehörigen Worktree. Dann `worktree-orphan-cleanup` nutzen.
- Nicht verwenden für den Hauptworktree.

## Argumente

- `<worktree-ref>`: wie in [worktree-inventory](https://heljens-it-services.github.io/agent-files/skills/github_worktree-inventory.md) definiert.

## Vorgehen

1. `<worktree-ref>` auf genau einen registrierten Linked Worktree auflösen und dessen absoluten Pfad und Branch nennen.
2. Das Sicherheits-Audit gemäß `worktree-inventory` unmittelbar vor der Mutation für diesen Pfad erstellen.
3. Bei Ergebnis `nicht entfernbar` stoppen und die konkreten Blocker melden.
4. Den User auffordern, VS-Code-Fenster, Terminals, Devserver, Watcher und Buildprozesse dieses Worktrees zu schließen, oder nur eindeutig diesem Pfad zugeordnete, vom Agent selbst gestartete Prozesse kontrolliert beenden.
5. Den Worktree mit `git worktree remove <pfad>` entfernen.
6. `git worktree list --porcelain` erneut prüfen und das Verzeichnis auf Reste kontrollieren.
7. Bleiben Verzeichnisreste, etwa durch Windows-Dateisperren, diese als Rest melden und an `worktree-orphan-cleanup` verweisen.
8. Den lokalen Branch nur löschen, wenn der User es verlangt oder `PROJECT.md` eine Retention Policy dafür vorgibt, und dann nur mit `git branch -d`.
9. Ergebnis, Wiederherstellbarkeit über den gesicherten Remote-Branch und verbleibende Worktrees melden.

## Kommandos

```powershell
git worktree list --porcelain
git worktree remove <pfad>
git worktree list --porcelain
Test-Path -LiteralPath <pfad>
git branch -d <branch>
```

## Grenzen

- Zustandsverändernd arbeiten: Es wird ausschließlich genau ein registrierter Linked Worktree entfernt.
- Den Hauptworktree nie entfernen, verschieben oder als Ziel akzeptieren.
- Ohne bestandenes, unmittelbar vorher erstelltes Sicherheits-Audit nicht entfernen.
- `git worktree remove --force` und `git branch -D` sind kein Standardpfad und nur mit ausdrücklicher, auf den konkreten Pfad bezogener User-Autorisierung zulässig.
- Registrierte Worktrees nicht mit rekursiven Dateisystemoperationen wie `Remove-Item -Recurse` oder `rm -r` entfernen.
- Keine Remote-Branches löschen.
- Keine pauschalen Prozessbeendigungen, z. B. aller VS-Code-, Node- oder Shell-Prozesse.
- Verzeichnisreste nicht in diesem Skill rekursiv löschen.

## Output

- entfernter absoluter Pfad und Branch
- Audit-Ergebnis
- Status des lokalen Branches
- verbleibende Verzeichnisreste
- verbleibende Worktrees gemäß `git worktree list --porcelain`

## Qualitätskriterien

- Kein Worktree mit uncommitteten Änderungen oder nicht remote-gesicherten Commits wird entfernt.
- Der Erfolg wird aus dem erneut gelesenen Git- und Dateisystemzustand abgeleitet, nicht allein aus einem Exitcode.
- Die Wiederherstellbarkeit der Arbeit ist im Ergebnis benannt.
