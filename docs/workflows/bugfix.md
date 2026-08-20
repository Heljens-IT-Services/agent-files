# Workflow: Bugfix

## Ziel

Einen Fehler zielgerichtet analysieren, beheben und absichern.

## Verwenden

- Wenn ein konkretes Fehlverhalten behoben werden soll.
- Wenn Ursache, Fix, Verifikation und Pull Request zusammenhängend bearbeitet werden sollen.
- Nicht verwenden, wenn nur eine Ursache analysiert werden soll. Dann `code-analysis` nutzen.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-testing`
- `code-diff-review`
- `pr-creation`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Bug-Input aufnehmen: vorhandenen Kontext verwenden oder mit `issue-reading` das Issue lesen.
2. Mit `github-branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
3. Einen vorhandenen terminalen Issue- oder Task-Plan gegen Repository-Zustand und geltende Regeln prüfen. Nur bei ungeklärter Ursache oder Planbruch mit `code-analysis` Ursache, Scope und Risiken klären.
4. Mit `code-testing` den Bug reproduzieren.
5. Den vorhandenen Issue- oder Task-Plan übernehmen. Nur ohne vollständigen Plan oder bei Planbruch mit `code-implementation-planning` gezielt planen.
6. Mit `code-implementation` den Bugfix umsetzen.
7. Mit `code-testing` prüfen, dass die ursprüngliche Reproduktion nicht mehr fehlschlägt und relevante Regressionen abgedeckt sind.
8. Mit `code-diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
9. Mit dem Workflow `commit-push.md` Commit und Push ausführen.
10. Mit `pr-creation` den Pull Request mit Ursache, Fix und Absicherung erstellen.

## Rücksprungregeln

## Codex-Orchestrierung

- Anforderungs- oder Ursachenklärung: `planner` beziehungsweise `developer` bei technischer Analyse.
- Umsetzung: `developer`.
- Regression und Fehlerpfadprüfung: `tester`.
- Commit, Push und abschließende GitHub-Mutation: `main/orchestrator`.
- Planbruch geht an `planner`, ein lokaler Test- oder Implementierungsfehler gezielt zurück an `developer`.

- Wenn Ursache, Scope oder Risiken unklar sind, zurück zu `code-analysis`.
- Wenn der Bug nicht reproduziert werden kann, zurück zu `code-analysis`, um Repro-Bedingungen, Ursache oder Scope weiter zu klären.
- Wenn der Fix größer als erwartet wird, zurück zu `code-implementation-planning`.
- Bei einem lokalen Implementierungsfehler Ursache im geplanten Scope korrigieren und die relevante Prüfung wiederholen.
- Bei einem grundlegenden Widerspruch zwischen Reproduktion, Plan und Repository-Zustand zurück zu `code-analysis` oder `code-implementation-planning`.

## Endergebnis

- behobener Fehler
- nachvollziehbarer Bugfix-Kontext
- nachvollziehbarer Test- und Review-Kontext
- Commit und Push
- erstellter Pull Request

## Grenzen

- Bugfix-Planung und Implementierung dürfen erst beginnen, wenn der Bug reproduziert wurde.
- Nach der Implementierung muss die ursprüngliche Reproduktion erfolgreich sein.
- Relevante Regressionen müssen geprüft werden.
