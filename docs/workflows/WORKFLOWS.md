# WORKFLOWS.md

## Zweck

Diese Datei ist die Lookup-Datei fuer Workflows, die mehrere atomare Skills zu einem zusammenhaengenden Ablauf kombinieren.

## Verwendung

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass diese Datei im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, damit passende Workflows vor der eigenstaendigen Ausfuehrung erkannt werden koennen.

[ALLOW_IF] Wenn diese Datei in der laufenden Unterhaltung bereits gelesen wurde und kein Hinweis auf eine zwischenzeitliche Aenderung besteht, darf der Agent die vorhandene Kontextfassung wiederverwenden, statt sie erneut vollstaendig abzurufen.

[MUST_IF] Der Agent muss diese Datei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST] Der Agent muss die Situationstabelle in dieser Datei verwenden, um passende Workflows zu bestimmen.

[MUST_IF] Der Agent muss die verlinkte Workflow-Datei vor der Ausfuehrung lesen und befolgen, wenn die beschriebene Situation fuer den aktuellen Task eintritt.

[MUST_IF] Der Agent muss die in einem verwendeten Workflow referenzierten Skill-Dateien lesen und befolgen.

[SHOULD] Der Agent soll einen Workflow fuer zusammenhaengende End-to-End-Aufgaben und einen Skill fuer einzelne Arbeitsschritte verwenden.

[MUST_IF] Der Agent muss Abweichungen von einem passenden Workflow kurz begruenden, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund dafuer liefert.

## Workflows

| Workflow | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|
| Bugfix | Ein Fehler analysiert, behoben und abgesichert werden soll. | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler beheben. |
| Feature Umsetzung | Ein Feature von der Anforderung bis zur verifizierten Implementierung bearbeitet werden soll. | [feature-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/feature-umsetzung.md) | Feature umsetzen. |
| Instruction Improvement Issue | Ein Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows als Issue erfasst werden soll. | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Instruction-Verbesserung erfassen. |
| Insight To Issue | Eine Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue ueberfuehrt werden soll. | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis als Issue erfassen. |
| Issue To Sub Issues | Ein grosses GitHub-Issue in mehrere Sub-Issues geschnitten und als Child-Issues angelegt werden soll. | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Issue aufteilen. |
| Issue To PR | Ein Ticket bis zur Pull-Request-Erstellung ueberfuehrt werden soll. | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ticket als Pull Request umsetzen. |
| Issue Umsetzung | Ein einzelnes Issue oder Arbeitspaket umgesetzt, verifiziert, committet und gepusht werden soll. | [issue-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Issue umsetzen. |
| Refactoring Secure | Code bei nachweisbarem Verhaltenserhalt strukturiert und abgesichert werden soll. | [refactoring-secure.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Refactoring absichern. |
