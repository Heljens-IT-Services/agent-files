# Workflow: Issue To PR

## Ziel

Ein Ticket in einen durchgaengigen Lieferablauf bis zur Pull-Request-Erstellung ueberfuehren.

## Verwenden

- Wenn ein einzelnes, ausreichend klares Issue umgesetzt und als Pull Request bereitgestellt werden soll.
- Wenn keine komplexen Issue-Beziehungen oder mehrere Arbeitseinheiten im Scope liegen.
- Nicht verwenden, wenn ein Issue-Graph oder mehrere verwandte Issues koordiniert werden muessen. Dann `issue-umsetzung.md` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `github_commit-push`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Mit `github_issue-lesen` das Ticket in klare Arbeitsanforderungen uebersetzen.
3. Mit `code_implementierungsplanung` Schritte und Verifikation festlegen.
4. Mit `code_implementieren` die Aenderung umsetzen.
5. Mit `code_testen` die Aenderung pruefen.
6. Mit `github_commit-push` den Commit sauber schneiden, benennen und pushen.
7. Mit `github_pr-erstellen` den Pull Request erstellen.

## Ruecksprungregeln

- Bei unklaren Anforderungen zurueck zu `github_issue-lesen`.
- Bei unerwarteten Umsetzungsproblemen zurueck zu `code_implementierungsplanung`.

## Endergebnis

- umgesetzte Aenderung
- Commit und Push
- erstellter Pull Request
