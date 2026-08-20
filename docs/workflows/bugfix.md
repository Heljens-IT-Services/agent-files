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
3. Mit `code-analysis` im Context-only-Modus Ursache, betroffenen Scope und relevante Risiken klären.
4. Mit `code-testing` den Bug reproduzieren.
5. Mit `code-implementation-planning` den Bugfix planen.
6. Mit `code-implementation` den Bugfix umsetzen.
7. Mit `code-testing` prüfen, dass die ursprüngliche Reproduktion nicht mehr fehlschlägt und relevante Regressionen abgedeckt sind.
8. Mit `code-diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
9. Mit dem Workflow `commit-push.md` Commit und Push ausführen.
10. Mit `pr-creation` den Pull Request mit Ursache, Fix und Absicherung erstellen.

## Rücksprungregeln

- Wenn Ursache, Scope oder Risiken unklar sind, zurück zu `code-analysis`.
- Wenn der Bug nicht reproduziert werden kann, zurück zu `code-analysis`, um Repro-Bedingungen, Ursache oder Scope weiter zu klären.
- Wenn der Fix größer als erwartet wird, zurück zu `code-implementation-planning`.
- Bei fehlgeschlagenen Tests zurück zu `code-implementation-planning`.

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
