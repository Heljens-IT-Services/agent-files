# SKILLS.md

## Zweck

Diese Datei ist die Lookup-Datei für atomare, wiederverwendbare Agenten-Skills.

## Verwendung

[MUST_IF] Der Agent muss mehrere passende Skill-Dateien lesen und befolgen, wenn mehrere beschriebene Situationen eintreten und kein passender Workflow den zusammenhängenden Ablauf festlegt.

## Skills

| ID | Skill | Direkter Alias | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `requirements-clarification` | Requirements Clarification | - | Anforderungen, Ziele, Nicht-Ziele oder Scope-Grenzen unklar sind. | [requirements-clarification.md](https://heljens-it-services.github.io/agent-files/skills/requirements-clarification.md) | Anforderungen und Scope klären. |
| `brainstorming` | Brainstorming | - | Denk- oder Lösungsrichtungen interaktiv entwickelt und abgewogen werden sollen. | [brainstorming.md](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Lösungsrichtungen entwickeln. |
| `code-analysis` | Code Analysis | - | Code, Branches, Legacy-Bereiche oder Fehlverhalten bewertet werden sollen. | [code-analysis.md](https://heljens-it-services.github.io/agent-files/skills/code-analysis.md) | Technischen Bestand einordnen. |
| `code-diff-review` | Code Diff Review | - | Ein Änderungssatz auf Scope, Risiken oder Nebeneffekte geprüft werden soll. | [code_diff-review.md](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Änderungen reviewen. |
| `code-implementation` | Code Implementation | - | Eine geklärte Verhaltens-, Logik-, Feature- oder API-Änderung umgesetzt werden soll. | [code-implementation.md](https://heljens-it-services.github.io/agent-files/skills/code-implementation.md) | Codeänderungen implementieren. |
| `code-implementation-planning` | Code Implementation Planning | - | Vorhandener Kontext in einen konkreten technischen Umsetzungsplan überführt werden soll. | [code-implementation-planning.md](https://heljens-it-services.github.io/agent-files/skills/code-implementation-planning.md) | Implementierung planen. |
| `code-reading` | Code Reading | - | Bestehender Code gezielt in den Agenten-Kontext geladen werden muss. | [code-reading.md](https://heljens-it-services.github.io/agent-files/skills/code-reading.md) | Codekontext erfassen. |
| `code-refactoring` | Code Refactoring | `/refactor` | Struktur ohne beabsichtigte Verhaltensänderung verbessert werden soll. | [code_refactoring.md](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Code strukturieren. |
| `code-testing` | Code Testing | `/testing`<br>`/testing <test-mode>` | Eine Änderung mit Build-, Test-, E2E- oder manuellen Prüfschritten verifiziert werden soll. | [code-testing.md](https://heljens-it-services.github.io/agent-files/skills/code-testing.md) | Änderungen gezielt oder kontextbezogen verifizieren. |
| `design-prototyping` | Design Prototyping | `/design-prototype` | Eine Designrichtung als leichtes renderbares Artefakt visualisiert werden soll. | [design-prototyping.md](https://heljens-it-services.github.io/agent-files/skills/design-prototyping.md) | Designideen schnell visualisieren. |
| `design-review` | Design Review | `/design-review` | Ein tatsächliches visuelles oder interaktives Ergebnis betrachtet, bewertet oder mit Varianten verglichen werden soll. | [design-review.md](https://heljens-it-services.github.io/agent-files/skills/design-review.md) | Designs visuell prüfen und Iterationen ableiten. |
| `documentation` | Documentation | - | Dokumentation erstellt, aktualisiert oder umstrukturiert werden soll. | [documentation.md](https://heljens-it-services.github.io/agent-files/skills/documentation.md) | Dokumentation pflegen. |
| `github-branch-checkout-from-default` | GitHub Branch Checkout From Default | - | Ein Arbeitsbranch von der aktuellen Standardbasis erstellt oder bestätigt werden soll. | [github_branch-checkout-from-default.md](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Arbeitsbranch vorbereiten. |
| `github-commit` | GitHub Commit | `/commit` | Fertige lokale Änderungen logisch geschnitten und ohne Push committet werden sollen. | [github_commit.md](https://heljens-it-services.github.io/agent-files/skills/github_commit.md) | Lokale Commits erstellen. |
| `commit-history-reading` | Commit History Reading | - | Commits und gemergte Pull Requests eines Repositorys für einen Zeitraum vollständig gelesen werden sollen. | [github_commit-history-reading.md](https://heljens-it-services.github.io/agent-files/skills/github_commit-history-reading.md) | Änderungshistorie erfassen. |
| `default-branch-update` | Default Branch Update | - | Nach einem verifizierten Merge sicher auf den aktualisierten Default-Branch gewechselt werden soll. | [github_default-branch-update.md](https://heljens-it-services.github.io/agent-files/skills/github_default-branch-update.md) | Default-Branch aktualisieren. |
| `integration-branch-update` | Integration Branch Update | - | Nach einem verifizierten Feature-Merge sicher auf `develop` gewechselt und der Branch aktualisiert werden soll. | [github_integration-branch-update.md](https://heljens-it-services.github.io/agent-files/skills/github_integration-branch-update.md) | Integrationsbranch aktualisieren. |
| `issue-creation` | Issue Creation | - | Ein strukturiertes GitHub-Issue aus vorhandenem Kontext erstellt werden soll. | [github_issue-creation.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-creation.md) | Issue erstellen. |
| `issue-reading` | Issue Reading | - | Ein GitHub-Issue und seine Kommentare gelesen werden müssen. | [github_issue-reading.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-reading.md) | Issue-Kontext erfassen. |
| `pr-checks-observation` | PR Checks Observation | - | Erforderliche Pull-Request-Checks bis zu einem terminalen Zustand beobachtet werden sollen. | [github_pr-checks-observation.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-checks-observation.md) | Pull-Request-Checks beobachten. |
| `pr-creation` | PR Creation | - | Ein Pull Request mit Titel, Body, Base und Head erstellt oder wiederverwendet werden soll. | [github_pr-creation.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-creation.md) | Pull Request bereitstellen. |
| `github-pr-merge` | GitHub PR Merge | - | Ein freigegebener Pull Request regelkonform gemergt werden soll. | [github_pr-merge.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-merge.md) | Pull Request mergen. |
| `github-push` | GitHub Push | `/push` | Vorhandene lokale Commits ohne neuen Commit auf den konfigurierten Upstream gepusht werden sollen. | [github_push.md](https://heljens-it-services.github.io/agent-files/skills/github_push.md) | Lokale Commits pushen. |
| `repository-baseline-configuration` | Repository Baseline Configuration | - | Die standardisierte GitHub-Basiskonfiguration eines Repositorys geprüft oder ergänzt werden soll. | [github_repository-baseline-configuration.md](https://heljens-it-services.github.io/agent-files/skills/github_repository-baseline-configuration.md) | GitHub-Repository-Basis pflegen. |
| `relationship-setting` | Relationship Setting | - | Native GitHub-Relationships wie Blocked-by oder Parent/Child gesetzt werden sollen. | [github_relationship-setting.md](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setting.md) | Issue-Beziehungen pflegen. |
| `type-setting` | Type Setting | - | Der native GitHub-Issue-Type eines bestehenden oder neu erstellten Issues gesetzt werden soll. | [github_type-setting.md](https://heljens-it-services.github.io/agent-files/skills/github_type-setting.md) | Issue-Type pflegen. |
| `research` | Research | - | Web-, Repository-, Issue- oder PR-Kontext recherchiert und zusammengefasst werden soll. | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Kontext recherchieren. |

## Codex-Default-Zuordnung

Die Zuordnung beschreibt die fachliche Standardverantwortung unter Codex. Ein Workflow darf sie für einen konkreten Schritt bewusst überschreiben, ohne die fachlichen Regeln des Skills zu umgehen.

| Skill-ID | Standard unter Codex | Ausführungshinweis |
|---|---|---|
| `requirements-clarification` | `planner` | Ziel, Scope und offene Anforderungen klären. |
| `brainstorming` | `planner` | Optionen strukturieren und Entscheidungen vorbereiten. |
| `code-analysis` | `developer` | Technische Ursachen, Risiken und Abhängigkeiten bewerten. |
| `code-diff-review` | `developer` | Technischen Änderungssatz prüfen; fachliche Testbewertung bleibt beim Tester. |
| `code-implementation` | `developer` | Geplante Codeänderungen umsetzen. |
| `code-implementation-planning` | `planner` | Technische Arbeitspakete aus geklärtem Kontext planen. |
| `code-reading` | `developer` | Codekontext für technische Folgearbeit erfassen. |
| `code-refactoring` | `developer` | Verhaltenserhaltende Strukturänderungen umsetzen. |
| `code-testing` | `tester` | Build-, Test-, E2E- und manuelle Verifikation ausführen. |
| `design-prototyping` | `designer` | Leichte visuelle Designartefakte für Exploration und Vergleich erzeugen. |
| `design-review` | `designer` | Gerenderte Designs visuell bewerten, vergleichen und Iterationen ableiten. |
| `documentation` | `main/orchestrator` | Dokumentationsscope und veröffentlichte Regelwirkung koordinieren; workflowbezogen delegierbar. |
| `github-branch-checkout-from-default` | `main/orchestrator` | Branchwechsel und Basiswahl koordinieren; nicht parallel delegieren. |
| `github-commit` | `main/orchestrator` | Commit-Scope und lokale Git-Mutation koordinieren. |
| `commit-history-reading` | `main/orchestrator` | Repositoryhistorie als Workflow-Kontext lesen. |
| `default-branch-update` | `main/orchestrator` | Integrationsbranch nach verifiziertem Merge aktualisieren. |
| `integration-branch-update` | `main/orchestrator` | `develop` nach verifiziertem Merge aktualisieren. |
| `issue-creation` | `planner` | Issues fachlich strukturieren; Mutation durch den Orchestrator kontrollieren. |
| `issue-reading` | `planner` | Issue-Ziel, Scope, Typen und Beziehungen erfassen. |
| `pr-checks-observation` | `tester` | Erforderliche Checks und deren terminalen Zustand bewerten. |
| `pr-creation` | `main/orchestrator` | PR-Schnitt, Closure-Semantik und externe Mutation koordinieren. |
| `github-pr-merge` | `main/orchestrator` | Freigabe, Merge-Gates und Merge-Mutation koordinieren. |
| `github-push` | `main/orchestrator` | Upstream und externe Push-Mutation kontrollieren. |
| `repository-baseline-configuration` | `main/orchestrator` | Repositoryweite Sollbestände und externe Wirkung koordinieren. |
| `relationship-setting` | `planner` | Beziehung fachlich ableiten; Mutation nur kontrolliert durch den Workflow. |
| `type-setting` | `planner` | Issue-Type fachlich ableiten; Mutation nur kontrolliert durch den Workflow. |
| `research` | `main/orchestrator` | Je nach Gegenstand an Planner, Developer, Tester oder Designer delegierbar. |

## Delegation und Fallback

[MUST] Der Hauptagent bleibt Orchestrator für zusammengesetzte Abläufe, rollenübergreifende Entscheidungen und mutierende administrative Schritte.

[MUST_IF] Wenn ein mutierender Skill von einem SubAgent ausgeführt wird, muss der aufrufende Workflow Scope, Berechtigung, Reihenfolge und anschließende Verifikation eindeutig festlegen.

[MUST_NOT] Die Default-Zuordnung darf keine unkoordinierten parallelen Schreibzugriffe verschiedener SubAgents auf denselben Worktree erlauben.

[MUST] Der Orchestrator übergibt Ziel, Scope, relevanten Kontext, Constraints, Entscheidungen und erwartetes Ergebnis und erwartet Ergebnis, Verifikation, Abweichungen, Blocker und nächste Rolle zurück.

[ALLOW_IF] Ohne Codex-Custom-Agents führt der aktuelle Agent die Skills selbst nach denselben fachlichen Regeln aus.
