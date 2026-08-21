# Workflow: Issue To PR

## Ziel

Eine bereits umgesetzte Änderung mit Issue-Kontext committen, pushen und als Pull Request erstellen.

## Verwenden

- Wenn eine Änderung bereits umgesetzt ist und aus dem Issue-Kontext ein Pull Request entstehen soll.
- Wenn relevante Issue-Relationships für PR-Kontext oder Verlinkung einbezogen werden sollen.
- Nicht verwenden, wenn die Änderung erst geplant oder implementiert werden muss. Dann `issue-implementation.md`, `issue-graph-implementation.md` oder `bugfix.md` nutzen.

## Verwendete Skills

- `issue-reading`
- `code-testing`
- `code-diff-review`
- `pr-creation`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Mit `issue-reading` das Haupt-Issue und explizit relevante Relationships als PR-Kontext lesen.
2. Mit `code-testing` die im Issue oder Task vorgesehene Verifikation ausführen oder Testlücken benennen.
3. Mit `code-diff-review` den Änderungssatz gegen Scope, Nicht-Scope, Akzeptanzkriterien, Nebeneffekte und Versandbereitschaft prüfen.
4. Mit dem Workflow `commit-push.md` den Änderungssatz sauber committen und pushen.
5. Mit `pr-creation` den Pull Request erstellen und Issue-Kontext verlinken.

## Rücksprungregeln

## Codex-Orchestrierung

- Issue-Kontext und technische Vorbereitung: `planner`; technische Analyse und Umsetzung: `developer`.
- Task-Verifikation und Review-Prüfungen: `tester` beziehungsweise `developer` für den technischen Diff-Review.
- Commit, Push und Pull-Request-Erstellung: `main/orchestrator`.
- Ein Planbruch geht an `planner`; ein lokaler Fehler nach der Verifikation gezielt an `developer`.

- Bei unklarem Issue-Kontext zurück zu `issue-reading`.
- Bei fehlender oder gescheiterter Verifikation zurück zu `code-testing`.
- Bei nicht versandbereitem Diff zurück zu passendem Umsetzungs- oder Refactoring-Workflow.

## Endergebnis

- gelesener Issue- und Relationship-Kontext
- geprüfte Änderung
- Commit und Push
- erstellter Pull Request

## Grenzen

- Fehlende oder gescheiterte Verifikation blockiert Commit, Push und Pull-Request-Erstellung.
