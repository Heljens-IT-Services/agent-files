# Workflow: Issue Umsetzung

## Ziel

Ein bestehendes Issue von der Anforderungsaufnahme bis zur versandbereiten Aenderung bearbeiten.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_verstehen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_commit-vorbereiten`
- `github_pr-text-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Issue mit `github_issue-lesen` in Ziel, Scope und offene Fragen uebersetzen.
3. Relevanten Code mit `code_verstehen` einordnen.
4. Mit `code_analyse` Risiken, Ursachen oder Auswirkungen klaeren.
5. Mit `code_implementierungsplanung` den Umsetzungsweg festlegen.
6. Mit `code_implementieren` die Aenderung umsetzen.
7. Mit `code_testen` die Aenderung verifizieren.
8. Mit `code_diff-review` den Aenderungssatz auf Scope und Risiken pruefen.
9. Mit `github_commit-vorbereiten` den Commit vorbereiten.
10. Mit `github_pr-text-erstellen` den PR-Text formulieren.

## Ruecksprungregeln

- Bei unklarem Issue zurueck zu `github_issue-lesen`.
- Bei unerwartetem Verhalten oder Seiteneffekten zurueck zu `code_analyse`.
- Bei zu grossem Scope zurueck zu `code_implementierungsplanung`.

## Endergebnis

- umgesetzte und verifizierte Aenderung
- Commit-Vorschlag
- PR-fertige Beschreibung
