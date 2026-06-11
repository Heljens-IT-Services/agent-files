# Skill: GitHub Commit Vorbereiten

## Zweck

Formuliere einen sauberen Commit aus einem abgeschlossenen Aenderungssatz.

## Wann verwenden

- Wenn die Aenderung lokal abgeschlossen und geprueft ist.
- Vor Push oder PR-Erstellung.

## Input

- Diff oder Zusammenfassung der Aenderung
- optional: Ticketnummer, Commit-Konvention, Teststatus

## Vorgehen

1. Inhalt des Aenderungssatzes in eine Commit-Einheit verdichten.
2. Passende Commit-Botschaft formulieren.
3. Teststatus und verbleibende Risiken erfassen.
4. Pruefen, ob der Diff fuer einen einzelnen Commit sauber geschnitten ist.

## Output

- vorgeschlagene Commit-Message
- Kurzbeschreibung des Commit-Inhalts
- Teststatus
- Hinweise auf unsauberen Scope, falls vorhanden

## Qualitätskriterien

- Commit soll logisch zusammenhaengen.
- Commit-Message soll das Warum und Was knapp transportieren.
- Unpassend gebuendelte Aenderungen offen benennen.
