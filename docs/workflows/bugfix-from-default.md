# Workflow: Bugfix From Default

## Ziel

Einen Fehler zielgerichtet analysieren, beheben und absichern und dafür bewusst einen neuen Arbeitsbranch von der Standardbasis bis zu einem Pull Request organisieren.

Dieser Workflow erhält den bisherigen vollständigen Bugfix-Ablauf inklusive Branch-Erstellung und Pull-Request-Erstellung. Für einen Bugfix auf dem bereits aktiven Branch ist stattdessen `bugfix.md` beziehungsweise `/bugfix` zu verwenden.

## Verwenden

- Wenn ein konkretes Fehlverhalten behoben werden soll und ausdrücklich ein eigener Bugfix-Branch von der Standardbasis gewünscht ist.
- Wenn Ursache, Fix, Verifikation, Commit/Push und Pull Request zusammenhängend bearbeitet werden sollen.
- Wenn der Bugfix nicht auf dem aktuell aktiven Arbeitsbranch verbleiben soll.
- Nicht verwenden, wenn der aktuelle Branch bewusst weiterverwendet werden soll. Dann `bugfix.md` beziehungsweise `/bugfix` nutzen.
- Nicht verwenden, wenn nur eine Ursache analysiert werden soll. Dann `code-analysis` nutzen.

## Direkter Alias

- `/bugfix from-default`

Der kanonische Aufruf lautet `/workflows run bugfix-from-default`.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-minimization`
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
8. Erst nach erfolgreicher Reproduktion und lokaler Stabilisierung mit `code-minimization` den Bugfix-Änderungssatz auf unbegründete Bestandteile prüfen und minimieren.
9. Nach jeder akzeptierten Reduktion die ursprüngliche Reproduktion und die durch die Reduktion betroffene Regression fokussiert erneut grün prüfen. Eine fehlgeschlagene Reduktion zurücknehmen; echte Unklarheit über Invariante oder Constraint als Planbruch routen.
10. Mit `code-testing` die unabhängige Verifikation des minimierten Bugfixes ausführen; Developer-Retests ersetzen diese nicht.
11. Mit `code-diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
12. Mit dem Workflow `commit-push.md` Commit und Push ausführen.
13. Mit `pr-creation` den Pull Request mit Ursache, Fix und Absicherung zur Standardbasis erstellen.

## Rücksprungregeln

## Codex-Orchestrierung

- Anforderungs- oder Ursachenklärung: `planner` beziehungsweise `developer` bei technischer Analyse.
- Umsetzung: `developer`.
- Regression und Fehlerpfadprüfung: `tester`.
- Branch-Erstellung, Commit, Push und abschließende GitHub-Mutation: `main/orchestrator`.
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
- eigener Bugfix-Arbeitsbranch von der Standardbasis
- Commit und Push
- erstellter Pull Request zur Standardbasis

## Grenzen

- Dieser Workflow darf nur bei ausdrücklich gewünschter Branch-/PR-Orchestrierung verwendet werden.
- Bugfix-Planung und Implementierung dürfen erst beginnen, wenn der Bug reproduziert wurde.
- Nach der Implementierung muss die ursprüngliche Reproduktion erfolgreich sein.
- Relevante Regressionen müssen geprüft werden.
