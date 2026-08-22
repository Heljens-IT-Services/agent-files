# WORKFLOWS.md

## Zweck

Diese Datei ist die Lookup-Datei für Workflows, die mehrere atomare Skills zu einem zusammenhängenden Ablauf kombinieren.

## Workflows

| ID | Workflow | Direkte Aliase | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `bugfix` | Bugfix | - | Ein Fehler analysiert, behoben und abgesichert werden soll. | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler beheben. |
| `commit-history-summary` | Commit History Summary | `/summary` | Commits und gemergte Pull Requests für einen Zeitraum fachlich, technisch oder detailliert zusammengefasst werden sollen. | [commit-history-summary.md](https://heljens-it-services.github.io/agent-files/workflows/commit-history-summary.md) | Änderungshistorie zusammenfassen. |
| `commit-push` | Commit Push | `/cp` | Fertige lokale Änderungen zusammenhängend committet und gepusht werden sollen. | [commit-push.md](https://heljens-it-services.github.io/agent-files/workflows/commit-push.md) | Änderungen committen und pushen. |
| `design-exploration` | Design Exploration | `/design-explore` | Eine visuelle oder interaktive Lösung explorativ entwickelt, gerendert, verglichen und iteriert werden soll. | [design-exploration.md](https://heljens-it-services.github.io/agent-files/workflows/design-exploration.md) | Designrichtungen explorieren, visualisieren und reviewen. |
| `feature-finish` | Feature Finish | `/finish` | Ein freigegebener Arbeitsbranch sicher committed, geprüft, gemergt und abgeschlossen werden soll. | [feature-finish.md](https://heljens-it-services.github.io/agent-files/workflows/feature-finish.md) | Arbeitsbranch abschließen. |
| `issue-graph-implementation` | Issue Graph Implementation | `/implement <issue-number>` | Ein Issue mit seinen relevanten Issue-Beziehungen bis zur verifizierten Implementierung und zum Pull Request bearbeitet werden soll. | [issue-graph-implementation.md](https://heljens-it-services.github.io/agent-files/workflows/issue-graph-implementation.md) | Issue-Graph implementieren. |
| `issue-sanitize` | Issue Graph Sanitization | `/sanitize <issue-number>` | Einen relevanten Issue-Graphen auf native GitHub Issue-Types und Relationships prüfen und eindeutig ableitbare Korrekturen verifizieren soll. | [issue-sanitize.md](https://heljens-it-services.github.io/agent-files/workflows/issue-sanitize.md) | Issue-Graph sanitizen. |
| `insight-to-issue` | Insight To Issue | - | Eine Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue überführt werden soll. | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis als Issue erfassen. |
| `instruction-improvement-issue` | Instruction Improvement Issue | - | Ein Verbesserungsvorschlag für Agent Instructions, Skills oder Workflows als Issue erfasst werden soll. | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Instruction-Verbesserung erfassen. |
| `issue-to-pr` | Issue To PR | - | Ein Ticket bis zur Pull-Request-Erstellung überführt werden soll. | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ticket als Pull Request umsetzen. |
| `issue-to-sub-issues` | Issue To Sub Issues | `/sub-issues <issue-number>`<br>`/sub-issues <issue-number> flat` | Ein Issue rekursiv oder flach in Child-Issues zerlegt werden soll. | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Issue-Baum erzeugen. |
| `issue-to-sub-issues-flat` | Issue To Sub Issues Flat | - | Genau eine Child-Ebene erzeugt werden soll. | [issue-to-sub-issues-flat.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues-flat.md) | Eine Child-Ebene erzeugen. |
| `issue-implementation` | Issue Implementation | - | Ein einzelnes Issue oder Arbeitspaket implementiert, verifiziert, committet und gepusht werden soll. | [issue-implementation.md](https://heljens-it-services.github.io/agent-files/workflows/issue-implementation.md) | Issue implementieren. |
| `refactoring-secure` | Refactoring Secure | - | Code bei nachweisbarem Verhaltenserhalt strukturiert und abgesichert werden soll. | [refactoring-secure.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Refactoring absichern. |
| `release` | Release | `/release` | Der freigegebene Stand von `develop` nach `main` veröffentlicht werden soll. | [release.md](https://heljens-it-services.github.io/agent-files/workflows/release.md) | Develop-Stand nach Main freigeben. |

## Codex-Orchestrierung

[MUST] Der Hauptagent bleibt für Workflow-Auswahl, Phasenkoordination, rollenübergreifende Entscheidungen und externe GitHub-/Git-Mutationen verantwortlich.

[SHOULD] Planungs- und Issue-Strukturphasen werden an `planner`, technische Analyse, Implementierung und Refactoring an `developer`, Verifikation und Check-Beobachtung an `tester` sowie gestalterische Exploration, Prototyping und visuelle Design-Reviews an `designer` delegiert, wenn die SubAgents verfügbar sind.

[ALLOW_IF] Ein Workflow darf diese Default-Zuordnung für einen konkreten Schritt überschreiben, wenn Verantwortung, Übergabe, Rückgabe und Verifikation im Workflow eindeutig bleiben.

[MUST] Übergaben enthalten Ziel, aktuellen Workflow-Schritt, Issue-/Task-Kontext, Scope, Nicht-Scope, Entscheidungen, Constraints, relevante Dateien oder Artefakte sowie das erwartete Ergebnis.

[MUST] Rückgaben enthalten Ergebnis, ausgeführte oder ausgelassene Verifikation, Abweichungen, Blocker und die Empfehlung für den nächsten Schritt oder die nächste Rolle.

[MUST_NOT] Schreibende SubAgents dürfen nicht unkoordiniert parallel auf demselben Worktree arbeiten. Parallele Delegation ist auf konfliktfreie Lese-, Analyse- oder Review-Schritte zu begrenzen.

[MUST_IF] Ein Developer einen echten Planbruch erkennt, muss der Orchestrator an `planner` zurückgeben. Findet `tester` einen lokalen Implementierungsfehler, muss die Korrektur an `developer` zurückgegeben werden; widersprüchliche Akzeptanzkriterien gehen an `planner` oder den Orchestrator.

[ALLOW_IF] Ohne Codex-Custom-Agents führt der Hauptagent dieselben Workflow-Phasen nach den fachlichen Regeln selbst aus.
