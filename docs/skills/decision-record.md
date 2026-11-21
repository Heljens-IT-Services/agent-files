# Skill: Decision Record

## Zweck

Eine getroffene, nicht-triviale Architektur- oder Technologieentscheidung als Architecture Decision Record (ADR) nachvollziehbar und dauerhaft im Repository festhalten.

## Verwenden

- Wenn eine Architektur-, Technologie-, Schnittstellen-, Datenhaltungs- oder Infrastrukturentscheidung getroffen wurde, die schwer umkehrbar ist oder mehrere Bereiche, Teams oder Folgeaufgaben bindet.
- Wenn zwischen mehreren ernsthaft geprüften Alternativen entschieden wurde und die Begründung später nicht mehr aus Code oder Historie ableitbar wäre.
- Wenn eine bestehende ADR durch eine neue Entscheidung abgelöst werden soll.
- Wenn der User ausdrücklich eine ADR verlangt.
- Nicht verwenden für triviale, lokal begrenzte oder ohne nennenswerten Aufwand umkehrbare Entscheidungen.
- Nicht verwenden, wenn die Entscheidung noch offen ist. Dann `brainstorming` oder `requirements-clarification` nutzen.
- Nicht verwenden für dauerhaft verbindliche Projektregeln. Diese gehören als Leitplanke in `PROJECT.md`; eine ADR darf die Herleitung einer solchen Leitplanke dokumentieren.
- Nicht verwenden für Entscheidungen, die nur ein einzelnes Issue oder einen einzelnen Pull Request betreffen. Diese gehören in den Issue- oder PR-Kontext.

## Entscheidungskriterien

Eine ADR ist angemessen, wenn mindestens zwei dieser Kriterien zutreffen:

- Die Rückabwicklung erfordert Migration, Datenumbau, Vertragsänderung oder koordinierte Änderungen mehrerer Komponenten.
- Die Entscheidung legt Abhängigkeiten, Frameworks, Plattformen, Protokolle oder öffentliche Verträge fest.
- Es gab mindestens eine ernsthaft geprüfte Alternative mit relevanten Trade-offs.
- Folgeaufgaben oder andere Beteiligte müssen die Begründung kennen, um konsistent weiterzuarbeiten.

## Vorgehen

1. Entscheidung, Entscheidungsstand und Entscheidungsträger aus dem vorhandenen Kontext übernehmen.
2. Anhand der Entscheidungskriterien prüfen, ob eine ADR angemessen ist; andernfalls den passenden Ablageort nennen und stoppen.
3. Fehlenden Kontext zu Alternativen, Constraints oder Konsequenzen explizit benennen und den passenden vorgelagerten Skill fordern.
4. Zielverzeichnis gemäß `Artefakt` bestimmen und vorhandene ADRs auf Überschneidung oder abzulösende Einträge prüfen.
5. Nächste freie Nummer ermitteln und die ADR nach der vorgegebenen Struktur erstellen.
6. Bei einer Ablösung die neue ADR mit Verweis auf die abgelöste erstellen und in der abgelösten ADR ausschließlich Status und Verweis auf die Nachfolgerin anpassen.
7. Ergebnis gegen Struktur, Status und Konsistenz mit `PROJECT.md` sowie bestehenden ADRs prüfen.

## Artefakt

[MUST] Der Agent muss das Zielverzeichnis in dieser Reihenfolge bestimmen: ausdrückliche Vorgabe in `PROJECT.md`, bereits vorhandenes ADR-Verzeichnis im Repository, `docs/adr/`.

[MUST_IF] Wenn `PROJECT.md` den Ordner `docs/` für einen Sonderzweck wie veröffentlichte Inhalte reserviert und kein ADR-Verzeichnis vorgibt, muss stattdessen `adr/` im Repository-Root verwendet werden.

- Dateiname: `NNNN-<kurzer-titel>.md` mit vierstelliger, fortlaufender Nummer und ASCII-Kurztitel aus Kleinbuchstaben, Ziffern und Bindestrichen, z. B. `0007-use-postgresql-for-reporting.md`.
- Nummern werden nicht wiederverwendet, auch nicht nach Ablösung.
- Inhalt auf Deutsch, knapp und entscheidungsbezogen; Bulletpoint-Listen bevorzugen.

Struktur:

```md
# NNNN: <Titel der Entscheidung>

Status: <vorgeschlagen | akzeptiert | abgelöst durch NNNN-<kurzer-titel>.md>
Datum: <JJJJ-MM-TT>
Löst ab: <NNNN-<kurzer-titel>.md | ->

## Kontext
## Entscheidung
## Alternativen
## Konsequenzen
```

- `Kontext`: Problem, Treiber und relevante Constraints.
- `Entscheidung`: die getroffene Entscheidung in eindeutiger Formulierung.
- `Alternativen`: ernsthaft geprüfte Optionen mit Grund der Verwerfung.
- `Konsequenzen`: positive und negative Folgen, Risiken und entstehende Folgearbeit.
- Verweise zwischen ADRs als relative Markdown-Links auf den Dateinamen setzen.

[MUST_NOT] Eine ADR mit Status `akzeptiert` darf inhaltlich nicht mehr bearbeitet werden. Eine geänderte Entscheidung muss als neue ADR erfasst werden, die die bisherige ablöst.

[ALLOW_IF] An einer akzeptierten ADR dürfen nur Status und Nachfolgerverweis bei einer Ablösung sowie offensichtliche Tipp- oder Linkfehler ohne Bedeutungsänderung korrigiert werden.

[MUST_NOT] Der Status `akzeptiert` darf nicht ohne erkennbare Entscheidung des Users oder des im Kontext benannten Entscheidungsträgers gesetzt werden; sonst bleibt der Status `vorgeschlagen`.

## Grenzen

- Nur ADR-Dateien im bestimmten Zielverzeichnis erstellen oder gemäß Ablösungsregel anpassen.
- Keine Codeänderungen vornehmen.
- Keine Entscheidung selbst treffen, erfinden oder nachträglich umdeuten.
- Keine Alternativenabwägung ersetzen. Dafür `brainstorming` nutzen.
- Keine Leitplanken in `PROJECT.md` pflegen; ein dafür nötiger Folgeschritt wird benannt.
- Keinen Code, keine Issues und keine externen Quellen selbst lesen. Wenn Kontext fehlt, vorgelagert `code-reading`, `code-analysis`, `issue-reading` oder `research` nutzen.
- Nicht committen. Dafür `github-commit` nutzen.

## Output

- Pfad der erstellten oder abgelösten ADR
- Status der ADR
- Hinweis auf abgelöste ADRs
- Folgeschritte, z. B. Leitplanke in `PROJECT.md`, Issue oder Commit
- offene Kontextlücken

## Qualitätskriterien

- Kontext, Entscheidung, Alternativen und Konsequenzen sind klar getrennt.
- Die Entscheidung ist eindeutig und ohne Kenntnis der Unterhaltung verständlich.
- Jede genannte Alternative hat einen konkreten Verwerfungsgrund.
- Negative Konsequenzen und Risiken werden nicht ausgelassen.
- Akzeptierte ADRs bleiben unverändert; Änderungen erfolgen ausschließlich per Ablösung.
- Keine Spekulation als Fakt darstellen; Annahmen werden markiert.
