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
- `github_pr-erstellen`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Mit `github_issue-lesen` das Haupt-Issue und explizit relevante Relationships als PR-Kontext lesen.
2. Mit `code_testen` vorhandene Verifikation ausfuehren oder Testluecken benennen.
3. Mit `code_diff-review` den Aenderungssatz auf Scope, Nebeneffekte und Versandbereitschaft pruefen.
4. Mit dem Workflow `commit-push.md` den Aenderungssatz sauber committen und pushen.
5. Mit `github_pr-erstellen` den Pull Request erstellen und Issue-Kontext verlinken.

## Ruecksprungregeln

- Bei unklarem Issue-Kontext zurueck zu `github_issue-lesen`.
- Bei fehlender oder gescheiterter Verifikation zurueck zu `code_testen`.
- Bei nicht versandbereitem Diff zurueck zu passendem Umsetzungs- oder Refactoring-Workflow.

## Endergebnis

- gelesener Issue- und Relationship-Kontext
- gepruefte Aenderung
- Commit und Push
- erstellter Pull Request

## Grenzen

- Fehlende oder gescheiterte Verifikation blockiert Commit, Push und Pull-Request-Erstellung.
