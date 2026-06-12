# Workflow: Issue To PR

## Ziel

Eine bereits umgesetzte Aenderung mit Issue-Kontext committen, pushen und als Pull Request erstellen.

## Verwenden

- Wenn eine Aenderung bereits umgesetzt ist und aus dem Issue-Kontext ein Pull Request entstehen soll.
- Wenn relevante Issue-Relationships fuer PR-Kontext oder Verlinkung einbezogen werden sollen.
- Nicht verwenden, wenn die Aenderung erst geplant oder implementiert werden muss. Dann `issue-umsetzung.md`, `feature-umsetzung.md` oder `bugfix.md` nutzen.

## Verwendete Skills

- `github_issue-lesen`
- `code_testen`
- `code_diff-review`
- `github_commit-push`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_issue-lesen` das Haupt-Issue und explizit relevante Relationships als PR-Kontext lesen.
2. Mit `code_testen` vorhandene Verifikation ausfuehren oder Testluecken benennen.
3. Mit `code_diff-review` den Aenderungssatz auf Scope, Nebeneffekte und Versandbereitschaft pruefen.
4. Mit `github_commit-push` den Commit sauber schneiden, benennen und pushen.
5. Mit `github_pr-erstellen` den Pull Request erstellen und Issue-Kontext verlinken.

## Ruecksprungregeln

- Bei unklarem Issue-Kontext zurueck zu `github_issue-lesen`.
- Bei fehlender oder gescheiterter Verifikation zurueck zu `code_testen`.
- Bei nicht versandbereitem Diff zurueck zu passendem Umsetzungs- oder Refactoring-Workflow.

## Grenzen

- Fehlende oder gescheiterte Verifikation blockiert Commit, Push und Pull-Request-Erstellung.
- Keine Pull-Request-Erstellung auf Basis ungetesteter Aenderungen.
- `code_diff-review` mit Bewertung `versandbereit mit Hinweisen` darf fortfahren.
- `code_diff-review` mit Bewertung `nicht versandbereit` blockiert Commit, Push und Pull-Request-Erstellung.

## Endergebnis

- gelesener Issue- und Relationship-Kontext
- gepruefte Aenderung
- Commit und Push
- erstellter Pull Request
