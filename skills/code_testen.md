# Skill: Code Testen

## Zweck

Eine Aenderung mit passenden Build-, Test- oder manuellen Pruefschritten verifizieren.

## Verwenden

- Nach Implementierung, Refactoring oder Bugfix.
- Vor Commit oder Pull Request.

## Vorgehen

1. Relevante Pruefebene waehlen: Build, Unit, Integration, UI oder manuell.
2. Kommandos aus Projektdateien, README oder CI ableiten.
3. Pruefungen ausfuehren und Ergebnis bewerten.
4. Nicht ausgefuehrte, aber relevante Pruefungen benennen.

## Empfohlene Kommandos

```powershell
dotnet test
npm test
npm run test
npm run build
```

Nur ausfuehren, wenn sie zum Projekt passen.

## Output

- ausgefuehrte Pruefungen
- Ergebnis
- Fehler oder Auffaelligkeiten
- verbleibende Testluecken

## Qualitaetskriterien

- Keine pauschale Aussage wie "getestet".
- Testluecken offenlegen.
- Fehler nicht relativieren.
