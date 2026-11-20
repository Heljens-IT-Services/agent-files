# Skill: GitHub Worktree Orphan Cleanup

## Zweck

Veraltete Worktree-Metadaten und nicht mehr registrierte Verzeichnisreste unter dem Managed Worktree Root standardmäßig als Dry Run klassifizieren und nur nach ausdrücklicher Freigabe sicher bereinigen.

## Verwenden

- Wenn nach einer Worktree-Entfernung Verzeichnisreste verbleiben oder Worktrees als `prunable` gelten, z. B. mit `/worktree cleanup`.
- Wenn zuvor im Dry Run als sicher bewertete Reste bereinigt werden sollen, z. B. mit `/worktree cleanup --apply`.
- Nicht verwenden für registrierte Linked Worktrees mit vorhandenem Verzeichnis. Dann `worktree-removal` nutzen.

## Argumente

- ohne Option: Dry Run ohne Mutation.
- `--apply`: Bereinigung ausschließlich der Einträge, die im unmittelbar vorangegangenen Dry Run als `sicher bereinigbar` bewertet wurden.

## Vorgehen

1. Kontext und Inventur gemäß [worktree-inventory](https://heljens-it-services.github.io/agent-files/skills/github_worktree-inventory.md) erstellen. Ohne festgelegten Managed Worktree Root stoppen.
2. Kandidaten klassifizieren:
   - `prunable`: registrierte Metadaten ohne vorhandenes Verzeichnis;
   - `Rest`: Verzeichnis unter dem Managed Worktree Root ohne Registrierung;
   - `ausgeschlossen`: Hauptworktree, Pfade außerhalb des Managed Worktree Root, Verzeichnisse mit eigenem `.git`-Verzeichnis, `.git`-Dateien, die auf ein anderes Repository verweisen, oder Inhalte mit unklarer Herkunft.
3. Für jeden `Rest` prüfen: kanonischer Pfad innerhalb des Managed Worktree Root, enthaltene Symlinks, Junctions und Reparse Points ohne Traversierung, Read-only-Dateien, Dateisperren und Prozesse mit Bezug zum Pfad sowie verbliebene, nicht anderweitig gesicherte Dateien.
4. Jeden Kandidaten als `sicher bereinigbar` oder `blockiert` mit Grund bewerten und den Dry Run mit absoluten Pfaden präsentieren.
5. Ohne `--apply` oder ausdrückliche User-Freigabe nach dem Dry Run enden.
6. Mit `--apply` unmittelbar vor jeder Mutation Pfad, Klassifikation und Prüfpunkte erneut prüfen; geänderte Einträge auslassen und melden.
7. `prunable`-Metadaten mit `git worktree prune` bereinigen.
8. In einem `Rest` zuerst Symlinks und Junctions ausschließlich als Link entfernen, ohne ihr Ziel zu verändern; danach den Pfad erneut prüfen und erst dann das Restverzeichnis löschen.
9. Gesperrte oder leere, aber blockierte Ordner als harmlosen Rest melden und erst nach Freigabe der Sperre erneut versuchen.
10. Nach jeder Teilmutation den tatsächlichen Zustand mit `git worktree list --porcelain` und Dateisystemprüfung verifizieren.

## Kommandos

```powershell
git worktree list --porcelain
git worktree prune --dry-run --verbose
git worktree prune --verbose
Get-ChildItem -LiteralPath <pfad> -Force -Attributes ReparsePoint
cmd /c rmdir "<junction-pfad>"
Remove-Item -LiteralPath <pfad> -Recurse -Force
Test-Path -LiteralPath <pfad>
```

`cmd /c rmdir` ohne `/s` entfernt eine Junction als Link, ohne ihr Ziel zu löschen. Unter Linux oder macOS entfernt `rm <link>` ohne abschließenden Schrägstrich nur den Symlink; das Restverzeichnis wird erst nach erneuter Prüfung mit `rm -r <pfad>` gelöscht.

## Grenzen

- Standardmäßig als Dry Run ohne jede Mutation arbeiten.
- Rekursive Dateisystemlöschung ist ausschließlich für `Rest`-Einträge zulässig, die im Dry Run als `sicher bereinigbar` bewertet und unmittelbar vorher erneut geprüft wurden.
- Nie außerhalb des Managed Worktree Root löschen.
- Hauptworktree, registrierte Worktrees mit vorhandenem Verzeichnis und ausgeschlossene Einträge nie bereinigen.
- Ziele von Symlinks und Junctions weder traversieren noch löschen.
- Keine pauschalen Prozessbeendigungen.
- Keine Branches oder Remote-Branches löschen.
- Hintergrundhelfer zum verzögerten Löschen nur mit ausdrücklicher Freigabe, eng auf den Pfad begrenzt, zeitlich befristet und mit Meldung an den User einsetzen.

## Output

- Dry-Run-Tabelle mit absolutem Pfad, Klassifikation, Bewertung und Grund
- bei `--apply`: bereinigte, ausgelassene und verbliebene Einträge
- verbleibende Worktrees gemäß `git worktree list --porcelain`

## Qualitätskriterien

- Ohne `--apply` oder ausdrückliche Freigabe wird nichts verändert.
- Jeder bereinigte Pfad lag nachweislich kanonisch innerhalb des Managed Worktree Root.
- Kein Link-Ziel wurde verändert.
- Der Erfolg wird aus dem erneut geprüften Zustand abgeleitet, nicht allein aus einem Exitcode.
