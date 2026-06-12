# Workflow: Feature Umsetzung

## Ziel

Ein neues Feature strukturiert von Idee oder Ticket bis zur verifizierten Implementierung bearbeiten.

## Verwenden

- Wenn ein neues Feature fachlich und technisch umgesetzt werden soll.
- Wenn Anforderung, Richtung, Implementierung, Verifikation und Pull Request zusammenhaengend bearbeitet werden sollen.
- Nicht verwenden, wenn nur Optionen abgewogen werden sollen. Dann `brainstorming` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `brainstorming`
- `code_lesen`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Feature-Anforderung mit `github_issue-lesen` oder vorhandener Beschreibung verdichten.
3. Falls die Richtung noch offen ist, mit `brainstorming` Optionen vergleichen.
4. Bestehende Architektur mit `code_lesen` einordnen.
5. Mit `code_implementierungsplanung` Zielzustand, Schritte und Tests festlegen.
6. Mit `code_implementieren` das Feature umsetzen.
7. Mit `code_testen` die Funktion und angrenzende Risiken pruefen.
8. Mit `code_diff-review` den Scope und Nebeneffekte kontrollieren.
9. Mit `github_pr-erstellen` den Pull Request mit Review-Kontext erstellen.

## Ruecksprungregeln

- Bei Architekturkonflikten zurueck zu `brainstorming` oder `code_implementierungsplanung`.
- Bei unklaren Anforderungen zurueck zu `github_issue-lesen`.

## Endergebnis

- verifizierte Feature-Aenderung
- dokumentierter Teststatus
- erstellter Pull Request
