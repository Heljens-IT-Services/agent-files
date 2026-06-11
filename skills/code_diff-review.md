# Skill: Code Diff Review

## Zweck

Einen Aenderungssatz auf Scope, Korrektheit und Risiken pruefen.

## Verwenden

- Vor Commit oder Pull Request.
- Nach riskanten oder groesseren Aenderungen.
- Wenn unbeabsichtigte Neben- oder Formatierungsaenderungen moeglich sind.

## Vorgehen

1. Diff gegen Ziel und Scope abgleichen.
2. Unerwartete Dateien, Hunks und Nebeneffekte suchen.
3. Regressionen, fehlende Tests und riskante Annahmen markieren.
4. Versandbereitschaft knapp bewerten.

## Empfohlene Kommandos

```powershell
git status --short --branch
git diff --stat
git diff
git diff --cached --stat
git diff --cached
git diff -- <pfad>
rg "<symbol-oder-begriff>"
```

Platzhalter aus dem Review-Scope ableiten.

## Output

- Bewertung: versandbereit oder nicht
- relevante Befunde
- Risiken
- notwendige Nacharbeit

## Qualitaetskriterien

- Echte Risiken vor Stilfragen.
- Scope-Abweichungen klar benennen.
- Nicht nur zusammenfassen, sondern bewerten.
