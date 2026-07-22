# WORKFLOWS.md

## Zweck

Diese Datei ist die Lookup-Datei fuer Workflows, die mehrere atomare Skills zu einem zusammenhaengenden Ablauf kombinieren.

## Verwendung

[MUST_IF] Der Agent muss alle referenzierten Skill-Dateien lesen und befolgen, wenn er einen Workflow verwendet.

## Workflows

| ID | Workflow | Direkter Alias | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `bugfix` | Bugfix | - | Ein Fehler analysiert, behoben und abgesichert werden soll. | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler beheben. |
| `feature-umsetzung` | Feature Umsetzung | - | Ein Feature von der Anforderung bis zur verifizierten Implementierung bearbeitet werden soll. | [feature-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/feature-umsetzung.md) | Feature umsetzen. |
| `finish` | Finish | `/finish` | Ein freigegebener Arbeitsbranch sicher committed, geprueft, gemergt und abgeschlossen werden soll. | [finish.md](https://heljens-it-services.github.io/agent-files/workflows/finish.md) | Arbeitsbranch abschliessen. |
| `instruction-improvement-issue` | Instruction Improvement Issue | - | Ein Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows als Issue erfasst werden soll. | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Instruction-Verbesserung erfassen. |
| `insight-to-issue` | Insight To Issue | - | Eine Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue ueberfuehrt werden soll. | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis als Issue erfassen. |
| `issue-to-sub-issues` | Issue To Sub Issues | - | Ein grosses GitHub-Issue in mehrere Sub-Issues geschnitten und als Child-Issues angelegt werden soll. | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Issue aufteilen. |
| `issue-to-pr` | Issue To PR | - | Ein Ticket bis zur Pull-Request-Erstellung ueberfuehrt werden soll. | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ticket als Pull Request umsetzen. |
| `issue-umsetzung` | Issue Umsetzung | - | Ein einzelnes Issue oder Arbeitspaket umgesetzt, verifiziert, committet und gepusht werden soll. | [issue-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Issue umsetzen. |
| `refactoring-secure` | Refactoring Secure | - | Code bei nachweisbarem Verhaltenserhalt strukturiert und abgesichert werden soll. | [refactoring-secure.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Refactoring absichern. |
