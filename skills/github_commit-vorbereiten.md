# Skill: GitHub Commit Vorbereiten

## Zweck

Einen abgeschlossenen Aenderungssatz logisch schneiden und committen.

## Verwenden

- Wenn Aenderungen lokal fertig und geprueft sind.
- Vor Push oder Pull Request.

## Vorgehen

1. Arbeitsstatus und Diff pruefen.
2. Scope des Commits bestimmen.
3. Nur passende Dateien stagen.
4. Gestagten Diff pruefen.
5. Praezise Commit-Message formulieren.
6. Commit erstellen.

## Empfohlene Kommandos

```powershell
git status --short --branch
git diff --stat
git diff
git add <pfade>
git diff --cached --stat
git commit -m "<commit-message>"
```

## Output

- Commit-Message
- Commit-Hash, falls erstellt
- Teststatus
- Scope-Hinweise, falls der Diff nicht sauber geschnitten ist

## Qualitaetskriterien

- Kein Sammelcommit fuer unzusammenhaengende Aenderungen.
- Commit-Message beschreibt konkrete Aenderung, nicht Aktivitaet.
- Ungetestete oder offene Risiken nennen.
