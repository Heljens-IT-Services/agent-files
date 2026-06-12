# Skill: GitHub Commit Push

## Zweck

Einen abgeschlossenen lokalen Aenderungssatz logisch schneiden, committen und pushen.

## Verwenden

- Wenn Aenderungen lokal fertig und geprueft sind.
- Wenn ein abgeschlossener Aenderungssatz auf den Remote-Branch veroeffentlicht werden soll.
- Nicht verwenden, wenn der Aenderungssatz noch nicht getestet oder reviewed ist.
- Nicht verwenden, um einen Pull Request zu erstellen.

## Vorgehen

1. Arbeitsstatus und Diff pruefen.
2. Remote-Status holen und aktuellen Branch per Fast-forward aktualisieren, falls Remote voraus ist.
3. Aenderungssaetze logisch schneiden.
4. Wenn mehrere klar trennbare Aenderungssaetze vorhanden sind, mehrere Commits vorbereiten.
5. Nur passende Dateien je Commit stagen.
6. Gestagten Diff je Commit pruefen.
7. Praezise Commit-Message je Commit aus Diff und vorhandenem Kontext selbst formulieren.
8. Commit oder Commits erstellen.
9. Nach allen Commits auf den aktuellen Remote-Branch pushen.
10. Falls der User explizit nur committen will, Push ueberspringen und Grund nennen.

## Kommandos

```powershell
git status --short --branch
git fetch origin
git pull --ff-only
git diff --stat
git diff
git add <pfade>
git diff --cached --stat
git diff --cached
git commit -m "<type>: <kurze konkrete aenderung>"
git push
```

Platzhalter aus aktuellem Branch und Commit-Scope ableiten.

## Grenzen

- Extern wirksam arbeiten: Commit und Push werden tatsaechlich ausgefuehrt.
- Keine unzusammenhaengenden Aenderungen in einen Sammelcommit aufnehmen.
- Vor Commit und Push pruefen, ob der aktuelle Branch hinter dem Remote ist.
- Wenn Remote voraus ist, nur per Fast-forward aktualisieren.
- Kein Rebase und kein Merge-Commit.
- Wenn Fast-forward nicht moeglich ist, stoppen und Blocker melden.
- Bei gemischtem Worktree logisch getrennte Commits erstellen, wenn die Trennung fachlich eindeutig ist.
- Nachfragen, wenn die Trennung unsicher ist oder einzelne Dateien nicht eindeutig zuordenbar sind.
- Kein Hunk-Staging verwenden; nur ganze Dateien stagen.
- Wenn eine Datei Aenderungen fuer mehrere Aenderungssaetze enthaelt, dem naheliegenderen Commit zuordnen.
- Kein `git add -A`, wenn der Scope nicht eindeutig den gesamten Worktree umfasst.
- Keine Tests, Builds oder Diff-Reviews ersetzen. Diese muessen vorher durch `code_testen` und `code_diff-review` erfolgt sein oder als fehlend genannt werden.
- Commit-Message im Format `<type>: <kurze konkrete aenderung>` formulieren.
- Erlaubte Types: `feat`, `fix`, `refactor`, `test`, `docs`, `chore`, `ci`, `build`.
- Commit-Message knapp, konkret und ohne Punkt am Ende formulieren.
- Nicht pushen, wenn kein Commit erstellt wurde.
- Keinen Upstream automatisch setzen. Wenn kein Upstream existiert, stoppen und Blocker melden oder User-Entscheidung einholen.
- Nicht pushen, wenn der User explizit nur committen will.
- Keinen Pull Request erstellen.

## Output

- Commit-Message
- Commit-Hash oder Commit-Hashes
- Push-Ziel
- Teststatus
- Scope-Hinweise, falls der Diff nicht sauber geschnitten ist
- Hinweis, falls Push uebersprungen oder blockiert wurde

## Qualitaetskriterien

- Kein Sammelcommit fuer unzusammenhaengende Aenderungen.
- Commit-Message beschreibt konkrete Aenderung, nicht Aktivitaet.
- Ungetestete oder offene Risiken nennen.
- Gestagter Diff muss vor Commit geprueft werden.
- Push nur nach erfolgreichem Commit.
- Keine zusaetzliche Arbeitsbaum-Statusausgabe nach erfolgreichem Push erforderlich.
