# Workflow: Refactoring Mit Absicherung

## Ziel

Bestehenden Code strukturell verbessern, ohne unbeabsichtigte Verhaltensaenderungen einzufuehren.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `code_lesen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_refactoring`
- `code_testen`
- `code_diff-review`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Mit `code_lesen` den bestehenden Codepfad und seine Verantwortung erfassen.
3. Mit `code_analyse` Problemstellen und Refactoring-Ziel schaerfen.
4. Mit `code_implementierungsplanung` den kleinsten sicheren Umbau planen.
5. Mit `code_refactoring` die Strukturverbesserung umsetzen.
6. Mit `code_testen` Verhalten und Regressionen pruefen.
7. Mit `code_diff-review` sicherstellen, dass keine verdeckte Fachlogik veraendert wurde.
8. Mit `github_pr-erstellen` den Pull Request mit Strukturgewinn, Risiken und Teststatus erstellen.

## Ruecksprungregeln

- Wenn Verhalten unklar ist, zurueck zu `code_lesen`.
- Wenn das Refactoring fachliche Aenderungen erzwingt, zurueck zu `code_implementierungsplanung`.

## Endergebnis

- strukturell verbesserter Code
- belegter Teststatus
- klarer Review-Kontext zum Verhaltenserhalt
