# Workflow: Bugfix

## Ziel

Einen Fehler zielgerichtet analysieren, beheben und absichern.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_analyse`
- `code_lesen`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Fehlerbild mit `github_issue-lesen` oder vorhandener Beschreibung schaerfen.
3. Mit `code_analyse` die wahrscheinlichste Ursache eingrenzen.
4. Mit `code_lesen` den relevanten Ausfuehrungspfad erklaeren.
5. Mit `code_implementierungsplanung` eine minimal-invasive Korrektur definieren.
6. Mit `code_implementieren` den Fix umsetzen.
7. Mit `code_testen` Reproduktion und Regression pruefen.
8. Mit `code_diff-review` Nebeneffekte und Scope-Ausweitung kontrollieren.
9. Mit `github_pr-erstellen` den Pull Request mit Ursache, Fix und Absicherung erstellen.

## Ruecksprungregeln

- Wenn die Ursache nicht belastbar ist, zurueck zu `code_analyse`.
- Wenn der Fix groesser als erwartet wird, zurueck zu `code_implementierungsplanung`.

## Endergebnis

- behobener Fehler
- dokumentierte Ursache
- nachvollziehbarer Test- und Review-Kontext
