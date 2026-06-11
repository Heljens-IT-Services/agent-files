# Skill: Code Testen

## Zweck

Pruefe, ob eine Aenderung technisch und funktional wie erwartet wirkt.

## Wann verwenden

- Nach Implementierung oder Refactoring.
- Vor Commit oder Pull Request.
- Wenn Unsicherheit ueber Nebeneffekte besteht.

## Input

- geaenderter Scope
- vorhandene Test- und Build-Kommandos
- optional: manuelle Pruefschritte

## Vorgehen

1. Passende Testebene waehlen: Unit, Integration, Build, manuelle Verifikation.
2. Nur die relevanten Kommandos und Pruefschritte auswaehlen.
3. Ergebnisse auf Fehler, Warnungen oder Luecken bewerten.
4. Nicht ausgefuehrte Pruefungen transparent benennen.

## Output

- ausgefuehrte Pruefungen
- Ergebnis je Pruefung
- Fehlschlaege oder Auffaelligkeiten
- verbleibende Testluecken

## Qualitätskriterien

- Keine pauschale Aussage wie "getestet", ohne konkrete Pruefung.
- Testluecken offenlegen.
- Ergebnisse knapp, aber nachvollziehbar dokumentieren.
