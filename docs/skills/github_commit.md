# Skill: GitHub Commit

## Zweck

Einen abgeschlossenen lokalen Aenderungssatz logisch schneiden und als einen oder mehrere lokale Git-Commits speichern.

## Verwenden

- Wenn lokale Aenderungen fertig, getestet und reviewed sind und bewusst committet werden sollen.
- Wenn der User nur einen lokalen Commit ohne Push beauftragt.
- Nicht verwenden, wenn bereits vorhandene lokale Commits nur gepusht werden sollen. Dann `github_push` nutzen.
- Nicht verwenden, wenn Commit und Push zusammenhaengend ausgefuehrt werden sollen. Dann den Workflow `commit-push.md` nutzen.

## Vorgehen

1. Branch, Arbeitsstatus sowie staged, unstaged und untracked Aenderungen pruefen.
2. Taskbezogenen Scope bestimmen und fremde Aenderungen ausschliessen.
3. Logisch zusammengehoerige Aenderungssaetze bilden.
4. Wenn mehrere klar trennbare Aenderungssaetze vorhanden sind, mehrere Commits vorbereiten.
5. Nur die vollstaendigen, zum jeweiligen Commit gehoerenden Dateien stagen.
6. Gestagten Diff und verbleibende unstaged bzw. untracked Aenderungen pruefen.
7. Commit-Message aus Diff und Task-Kontext formulieren.
8. Commit erstellen und Hash, Message sowie verbleibenden Arbeitsstatus pruefen.

## Kommandos

```powershell
git status --short --branch
git diff --stat
git diff
git diff --cached --stat
git diff --cached
git add <pfade>
git commit -m "<type>: <kurze konkrete aenderung>"
git rev-parse HEAD
```

Platzhalter aus dem geprueften Commit-Scope ableiten.

## Grenzen

- Zustandsveraendernd arbeiten: Es werden ausschliesslich lokale Commits erstellt.
- Keine Remote-Operationen ausfuehren; insbesondere nicht fetchen, pullen oder pushen.
- Keine unzusammenhaengenden oder fremden Aenderungen in einen Commit aufnehmen.
- Bei gemischtem Worktree logisch getrennte Commits erstellen, wenn die Trennung fachlich eindeutig ist.
- Nachfragen, wenn Dateien nicht eindeutig einem Aenderungssatz zugeordnet werden koennen.
- Kein Hunk-Staging verwenden; nur ganze Dateien stagen.
- Kein `git add -A` verwenden, wenn der Scope nicht eindeutig den gesamten Worktree umfasst.
- Keine leeren Commits erstellen, ausser der User verlangt das ausdruecklich.
- Bestehende Commits nicht amendieren, umschreiben oder zusammenfassen, ausser der User verlangt das ausdruecklich.
- Keine Tests, Builds oder Diff-Reviews ersetzen; fehlende Verifikation oder Review als Blocker bzw. Risiko benennen.
- Commit-Message im Format `<type>: <kurze konkrete aenderung>` formulieren.
- Erlaubte Types: `feat`, `fix`, `refactor`, `test`, `docs`, `chore`, `ci`, `build`.
- Commit-Message knapp, konkret und ohne Punkt am Ende formulieren.

## Output

- Commit-Message und Commit-Hash je erstelltem Commit
- nicht committete Aenderungen
- Test- und Review-Status
- Blocker oder Scope-Hinweise

## Qualitaetskriterien

- Jeder Commit muss einen fachlich zusammenhaengenden Aenderungssatz enthalten.
- Commit-Message muss die konkrete Aenderung statt der Aktivitaet beschreiben.
- Ein erfolgreicher Commit darf nicht als Push dargestellt werden.
