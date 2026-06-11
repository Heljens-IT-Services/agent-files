# Skill: Code Diff Review

## Zweck

Pruefe einen Aenderungssatz auf Korrektheit, Scope-Treue und unerwuenschte Nebeneffekte.

## Wann verwenden

- Vor Commit oder Pull Request.
- Nach groesseren oder riskanten Aenderungen.
- Wenn unbeabsichtigte Formatierungs- oder Nebenaenderungen moeglich sind.

## Input

- aktueller Diff oder Change-Set
- optional: Ziel des Tickets oder Implementierungsplans

## Vorgehen

1. Diff gegen Ziel und Scope abgleichen.
2. Unerwartete Dateiaenderungen oder Scope-Ausweitung suchen.
3. Risiken, Regressionen und fehlende Absicherungen markieren.
4. Falls sinnvoll konkrete Nachbesserungen empfehlen.

## Output

- Kurzbewertung
- auffaellige Dateien oder Hunks
- Risiken oder Inkonsistenzen
- empfohlene Nacharbeiten

## Qualitätskriterien

- Fokus auf echte Risiken statt Stilkleinigkeiten.
- Scope-Abweichungen klar benennen.
- Review soll die Frage beantworten, ob der Aenderungssatz versandbereit ist.
