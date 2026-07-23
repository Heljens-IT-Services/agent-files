# Skill: GitHub Push

## Zweck

Bereits vorhandene lokale Commits eines Branches auf dessen konfigurierten Remote-Upstream pushen.

## Verwenden

- Wenn lokale Commits vorhanden sind, die noch nicht auf dem konfigurierten Upstream liegen.
- Wenn der User nur einen Push ohne neuen Commit beauftragt.
- Nicht verwenden, wenn lokale Aenderungen zuerst committet werden sollen. Dann `github_commit` nutzen.
- Nicht verwenden, wenn Commit und Push zusammenhaengend ausgefuehrt werden sollen. Dann den Workflow `commit-push.md` nutzen.

## Vorgehen

1. Aktuellen Branch, Arbeitsstatus und konfigurierten Upstream bestimmen.
2. Remote-Status fetchen.
3. Ahead-/Behind-Status zwischen lokalem Branch und Upstream bestimmen.
4. Stoppen, wenn kein Upstream existiert oder der Upstream voraus bzw. mit dem lokalen Branch divergiert ist.
5. Ohne Push abschliessen, wenn kein lokaler Commit voraus ist.
6. Vorhandene vorausliegende Commits auf den konfigurierten Upstream pushen.
7. Remote-Status erneut lesen und den synchronen Stand verifizieren.

## Kommandos

```powershell
git status --short --branch
git branch --show-current
git rev-parse --abbrev-ref --symbolic-full-name "@{upstream}"
git fetch <remote>
git rev-list --left-right --count "HEAD...@{upstream}"
git log --oneline "@{upstream}..HEAD"
git push
git rev-list --left-right --count "HEAD...@{upstream}"
```

Remote und Upstream aus der bestehenden Branch-Konfiguration ableiten.

## Grenzen

- Extern wirksam arbeiten: Bereits vorhandene lokale Commits werden gepusht.
- Keine Dateien stagen und keine Commits erstellen, amendieren oder umschreiben.
- Kein Pull, Merge oder Rebase ausfuehren.
- Keinen Upstream automatisch setzen oder aendern.
- Kein Force-Push und keine Umgehung von Branch-Regeln verwenden.
- Keine Tags pushen, ausser der User verlangt das ausdruecklich.
- Uncommittete Aenderungen duerfen nicht als Teil des Pushes dargestellt werden und muessen im Abschluss genannt werden.
- Bei fehlendem Upstream, Remote-Vorsprung, Divergenz, Berechtigungsfehlern oder abgelehntem Push stoppen und den lokalen Zustand unveraendert lassen.

## Output

- gepushte Commit-Hashes oder Hinweis, dass nichts zu pushen war
- Remote, Upstream und Branch
- verifizierter Ahead-/Behind-Status
- nicht gepushte uncommittete Aenderungen
- Blocker, falls der Push nicht ausgefuehrt wurde

## Qualitaetskriterien

- Nur bereits vorhandene lokale Commits duerfen veroeffentlicht werden.
- Erfolg muss durch einen synchronen lokalen und entfernten Branch verifiziert werden.
- Ein erfolgreicher Push darf nicht als Commit-Erstellung dargestellt werden.
