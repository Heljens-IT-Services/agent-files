# CHANGELOG.md

## Zweck

Diese Datei verzeichnet Regeländerungen an den veröffentlichten Agent Files unter `docs/`. Sie ermöglicht konsumierenden Agents, ohne vollständigen Neuabruf zu erkennen, welche Regeldateien sich seit ihrer Kontextfassung geändert haben.

## Format

- Je Änderungsdatum ein Abschnitt `### YYYY-MM-DD`, neueste Einträge oben.
- Je Eintrag die betroffene Datei als Pfad relativ zu `docs/` und die Wirkung der Änderung in einem Satz.
- Änderungen vor dem 2026-10-18 sind nicht verzeichnet; maßgeblich ist dort die `Stand:`-Zeile der jeweiligen Datei.

## Einträge

### 2026-10-18

- `CHANGELOG.md`: Changelog als datierter Nachweis der Regeländerungen eingeführt.
- `AGENTS.md`: Aktualitätsprüfung bereits gelesener Regeldateien über den Changelog ergänzt.
- Alle Markdown-Dateien unter `docs/`: fehlende `Stand:`-Zeilen mit dem Datum der letzten Änderung nachgetragen; keine inhaltliche Regeländerung.
