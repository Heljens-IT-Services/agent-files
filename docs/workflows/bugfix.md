# Workflow: Bugfix

## Ziel

Einen Fehler zielgerichtet analysieren, beheben und absichern.

## Verwenden

- Wenn ein konkretes Fehlverhalten behoben werden soll.
- Wenn Ursache, Fix, Verifikation und Pull Request zusammenhängend bearbeitet werden sollen.
- Nicht verwenden, wenn nur eine Ursache analysiert werden soll. Dann `code_analyse` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_pr-erstellen`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Bug-Input aufnehmen: vorhandenen Kontext verwenden oder mit `github_issue-lesen` das Issue lesen.
2. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
3. Mit `code_analyse` im Context-only-Modus Ursache, betroffenen Scope und relevante Risiken klären.
4. Mit `code_testen` den Bug reproduzieren.
5. Mit `code_implementierungsplanung` den Bugfix planen.
6. Mit `code_implementieren` den Bugfix umsetzen.
7. Mit `code_testen` prüfen, dass die ursprüngliche Reproduktion nicht mehr fehlschlägt und relevante Regressionen abgedeckt sind.
8. Mit `code_diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
9. Mit dem Workflow `commit-push.md` Commit und Push ausführen.
10. Mit `github_pr-erstellen` den Pull Request mit Ursache, Fix und Absicherung erstellen.

## Rücksprungregeln

- Wenn Ursache, Scope oder Risiken unklar sind, zurück zu `code_analyse`.
- Wenn der Bug nicht reproduziert werden kann, zurück zu `code_analyse`, um Repro-Bedingungen, Ursache oder Scope weiter zu klären.
- Wenn der Fix größer als erwartet wird, zurück zu `code_implementierungsplanung`.
- Bei fehlgeschlagenen Tests zurück zu `code_implementierungsplanung`.

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
