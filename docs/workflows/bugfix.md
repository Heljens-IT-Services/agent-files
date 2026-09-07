# Workflow: Bugfix

## Ziel

Einen Fehler zielgerichtet auf dem aktuell ausgecheckten Branch analysieren, beheben und absichern, ohne den umgebenden Branch- oder Pull-Request-Lifecycle eigenständig zu verändern.

Für einen bewusst isolierten Bugfix mit neuem Branch von der Standardbasis und anschließendem Pull Request ist `bugfix-from-default.md` beziehungsweise `/bugfix from-default` zu verwenden.

## Verwenden

- Wenn ein konkretes Fehlverhalten auf dem aktuell ausgecheckten Arbeitsbranch behoben werden soll.
- Wenn Ursache, Fix, Verifikation und Commit/Push zusammenhängend bearbeitet werden sollen.
- Wenn der Bugfix Bestandteil eines bereits laufenden Feature-, Agent- oder Remediation-Branches ist.
- Nicht verwenden, wenn ausdrücklich ein neuer Bugfix-Branch von der Standardbasis mit anschließendem Pull Request gewünscht ist. Dann `bugfix-from-default.md` beziehungsweise `/bugfix from-default` nutzen.
- Nicht verwenden, wenn nur eine Ursache analysiert werden soll. Dann `code-analysis` nutzen.

## Direkter Alias

- `/bugfix`

Der kanonische Aufruf lautet `/workflows run bugfix`.

## Verwendete Skills

- `issue-reading`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-testing`
- `code-diff-review`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Bug-Input aufnehmen: vorhandenen Kontext verwenden oder mit `issue-reading` das Issue lesen.
2. Den aktuell ausgecheckten Branch und den Working Tree feststellen. Den Branch nicht automatisch wechseln, neu erstellen oder auf eine andere Basis zurücksetzen.
3. Prüfen, dass der vorhandene Arbeitsstand für den Bugfix eindeutig weiterverwendet werden kann. Bei nicht zuordenbaren oder fachfremden lokalen Änderungen stoppen und den konkreten Zustand melden.
4. Einen vorhandenen terminalen Issue- oder Task-Plan gegen Repository-Zustand und geltende Regeln prüfen. Nur bei ungeklärter Ursache oder Planbruch mit `code-analysis` Ursache, Scope und Risiken klären.
5. Mit `code-testing` den Bug reproduzieren.
6. Den vorhandenen Issue- oder Task-Plan übernehmen. Nur ohne vollständigen Plan oder bei Planbruch mit `code-implementation-planning` gezielt planen.
7. Mit `code-implementation` den Bugfix umsetzen.
8. Mit `code-testing` prüfen, dass die ursprüngliche Reproduktion nicht mehr fehlschlägt und relevante Regressionen abgedeckt sind.
9. Mit `code-diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
10. Mit dem Workflow `commit-push.md` Commit und Push auf dem aktuell verwendeten Branch ausführen.

## Rücksprungregeln

## Codex-Orchestrierung

- Anforderungs- oder Ursachenklärung: `planner` beziehungsweise `developer` bei technischer Analyse.
- Umsetzung: `developer`.
- Regression und Fehlerpfadprüfung: `tester`.
- Commit und Push: `main/orchestrator`.
- Planbruch geht an `planner`, ein lokaler Test- oder Implementierungsfehler gezielt zurück an `developer`.

- Wenn Ursache, Scope oder Risiken unklar sind, zurück zu `code-analysis`.
- Wenn der Bug nicht reproduziert werden kann, zurück zu `code-analysis`, um Repro-Bedingungen, Ursache oder Scope weiter zu klären.
- Wenn der Fix größer als erwartet wird, zurück zu `code-implementation-planning`.
- Bei einem lokalen Implementierungsfehler Ursache im geplanten Scope korrigieren und die relevante Prüfung wiederholen.
- Bei einem grundlegenden Widerspruch zwischen Reproduktion, Plan und Repository-Zustand zurück zu `code-analysis` oder `code-implementation-planning`.

## Endergebnis

- behobener Fehler auf dem bereits aktiven Branch
- nachvollziehbarer Bugfix-Kontext
- nachvollziehbarer Test- und Review-Kontext
- Commit und Push auf dem aktuellen Branch
- keine implizite Branch-Erstellung
- keine implizite Pull-Request-Erstellung

## Grenzen

- Den aktuell ausgecheckten Branch nicht automatisch wechseln oder ersetzen.
- Keinen neuen Branch erzeugen.
- Keinen Pull Request erzeugen.
- Bugfix-Planung und Implementierung dürfen erst beginnen, wenn der Bug reproduziert wurde.
- Nach der Implementierung muss die ursprüngliche Reproduktion erfolgreich sein.
- Relevante Regressionen müssen geprüft werden.
