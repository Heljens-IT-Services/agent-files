# WORKFLOWS.md

## Zweck

Diese Datei ist die Lookup-Datei für Workflows, die mehrere atomare Skills zu einem zusammenhängenden Ablauf kombinieren.

## Workflows

| ID | Workflow | Direkte Aliase | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `bugfix` | Bugfix | - | Ein Fehler analysiert, behoben und abgesichert werden soll. | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler beheben. |
| `commit-history-summary` | Commit History Summary | `/summary` | Commits und gemergte Pull Requests für einen Zeitraum fachlich, technisch oder detailliert zusammengefasst werden sollen. | [commit-history-summary.md](https://heljens-it-services.github.io/agent-files/workflows/commit-history-summary.md) | Änderungshistorie zusammenfassen. |
| `commit-push` | Commit Push | `/cp` | Fertige lokale Änderungen zusammenhängend committet und gepusht werden sollen. | [commit-push.md](https://heljens-it-services.github.io/agent-files/workflows/commit-push.md) | Änderungen committen und pushen. |
| `feature-finish` | Feature Finish | `/finish` | Ein freigegebener Arbeitsbranch sicher committed, geprüft, gemergt und abgeschlossen werden soll. | [feature-finish.md](https://heljens-it-services.github.io/agent-files/workflows/feature-finish.md) | Arbeitsbranch abschließen. |
| `issue-graph-umsetzung` | Issue Graph Umsetzung | `/umsetzen <issue-nummer>`<br>`/umsetzung <issue-nummer>` | Ein Issue mit seinen relevanten Issue-Beziehungen bis zur verifizierten Implementierung und zum Pull Request bearbeitet werden soll. | [issue-graph-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-graph-umsetzung.md) | Issue-Graph umsetzen. |
| `insight-to-issue` | Insight To Issue | - | Eine Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue überführt werden soll. | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis als Issue erfassen. |
| `instruction-improvement-issue` | Instruction Improvement Issue | - | Ein Verbesserungsvorschlag für Agent Instructions, Skills oder Workflows als Issue erfasst werden soll. | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Instruction-Verbesserung erfassen. |
| `issue-to-pr` | Issue To PR | - | Ein Ticket bis zur Pull-Request-Erstellung überführt werden soll. | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ticket als Pull Request umsetzen. |
| `issue-to-sub-issues` | Issue To Sub Issues | `/sub-issues <issue-nummer>`<br>`/sub-issues <issue-nummer> flat` | Ein Issue rekursiv oder flach in Child-Issues zerlegt werden soll. | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Issue-Baum erzeugen. |
| `issue-to-sub-issues-flat` | Issue To Sub Issues Flat | - | Genau eine Child-Ebene erzeugt werden soll. | [issue-to-sub-issues-flat.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues-flat.md) | Eine Child-Ebene erzeugen. |
| `issue-umsetzung` | Issue Umsetzung | - | Ein einzelnes Issue oder Arbeitspaket umgesetzt, verifiziert, committet und gepusht werden soll. | [issue-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Issue umsetzen. |
| `refactoring-secure` | Refactoring Secure | - | Code bei nachweisbarem Verhaltenserhalt strukturiert und abgesichert werden soll. | [refactoring-secure.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Refactoring absichern. |
| `release` | Release | `/release` | Der freigegebene Stand von `develop` nach `main` veröffentlicht werden soll. | [release.md](https://heljens-it-services.github.io/agent-files/workflows/release.md) | Develop-Stand nach Main freigeben. |
