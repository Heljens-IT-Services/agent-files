# Workflow: Bugfix

## Ziel

Einen Fehler zielgerichtet analysieren, beheben und absichern.

## Verwenden

- Wenn ein konkretes Fehlverhalten behoben werden soll.
- Wenn Ursache, Fix, Verifikation und Pull Request zusammenhaengend bearbeitet werden sollen.
- Nicht verwenden, wenn nur eine Ursache analysiert werden soll. Dann `code_analyse` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_commit-push`
- `github_pr-erstellen`

## Ablauf

1. Bug-Input aufnehmen: vorhandenen Kontext verwenden oder mit `github_issue-lesen` das Issue lesen.
2. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
3. Mit `code_analyse` im Context-only-Modus Ursache, betroffenen Scope und relevante Risiken klaeren.
4. Mit `code_testen` den Bug reproduzieren.
5. Mit `code_implementierungsplanung` den Bugfix planen.
6. Mit `code_implementieren` den Bugfix umsetzen.
7. Mit `code_testen` pruefen, dass die urspruengliche Reproduktion nicht mehr fehlschlaegt und relevante Regressionen abgedeckt sind.
8. Mit `code_diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
9. Mit `github_commit-push` Commit und Push ausfuehren.
10. Mit `github_pr-erstellen` den Pull Request mit Ursache, Fix und Absicherung erstellen.

## Ruecksprungregeln

- Wenn Ursache, Scope oder Risiken unklar sind, zurueck zu `code_analyse`.
- Wenn der Bug nicht reproduziert werden kann, zurueck zu `code_analyse`, um Repro-Bedingungen, Ursache oder Scope weiter zu klaeren.
- Wenn der Fix groesser als erwartet wird, zurueck zu `code_implementierungsplanung`.
- Bei fehlgeschlagenen Tests zurueck zu `code_implementierungsplanung`.

## Endergebnis

- behobener Fehler
- nachvollziehbarer Bugfix-Kontext
- nachvollziehbarer Test- und Review-Kontext
- Commit und Push
- erstellter Pull Request

## Grenzen

- `code_diff-review` mit Bewertung `versandbereit mit Hinweisen` darf fortfahren.
- `code_diff-review` mit Bewertung `nicht versandbereit` blockiert Commit, Push und Pull-Request-Erstellung.
- Bugfix-Planung und Implementierung duerfen erst beginnen, wenn der Bug reproduziert wurde.
- Nach der Implementierung muss die urspruengliche Reproduktion erfolgreich sein.
- Relevante Regressionen muessen geprueft werden.
