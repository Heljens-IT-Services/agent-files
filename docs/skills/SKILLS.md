# SKILLS.md

## Zweck

Diese Datei ist die Lookup-Datei für atomare, wiederverwendbare Agenten-Skills.

## Verwendung

[MUST_IF] Der Agent muss mehrere passende Skill-Dateien lesen und befolgen, wenn mehrere beschriebene Situationen eintreten und kein passender Workflow den zusammenhängenden Ablauf festlegt.

## Skills

| ID | Skill | Direkter Alias | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `requirements-clarification` | Requirements Clarification | - | Anforderungen, Ziele, Nicht-Ziele oder Scope-Grenzen unklar sind. | [anforderungsklaerung.md](https://heljens-it-services.github.io/agent-files/skills/anforderungsklaerung.md) | Anforderungen und Scope klären. |
| `brainstorming` | Brainstorming | - | Denk- oder Lösungsrichtungen interaktiv entwickelt und abgewogen werden sollen. | [brainstorming.md](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Lösungsrichtungen entwickeln. |
| `code-analysis` | Code Analysis | - | Code, Branches, Legacy-Bereiche oder Fehlverhalten bewertet werden sollen. | [code_analyse.md](https://heljens-it-services.github.io/agent-files/skills/code_analyse.md) | Technischen Bestand einordnen. |
| `code-diff-review` | Code Diff Review | - | Ein Änderungssatz auf Scope, Risiken oder Nebeneffekte geprüft werden soll. | [code_diff-review.md](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Änderungen reviewen. |
| `code-implementation` | Code Implementation | - | Eine geklärte Verhaltens-, Logik-, Feature- oder API-Änderung umgesetzt werden soll. | [code_implementieren.md](https://heljens-it-services.github.io/agent-files/skills/code_implementieren.md) | Codeänderungen implementieren. |
| `code-implementation-planning` | Code Implementation Planning | - | Vorhandener Kontext in einen konkreten technischen Umsetzungsplan überführt werden soll. | [code_implementierungsplanung.md](https://heljens-it-services.github.io/agent-files/skills/code_implementierungsplanung.md) | Implementierung planen. |
| `code-reading` | Code Reading | - | Bestehender Code gezielt in den Agenten-Kontext geladen werden muss. | [code_lesen.md](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Codekontext erfassen. |
| `code-refactoring` | Code Refactoring | `/refactor` | Struktur ohne beabsichtigte Verhaltensänderung verbessert werden soll. | [code_refactoring.md](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Code strukturieren. |
| `code-testing` | Code Testing | `/testing`<br>`/testing <test-mode>` | Eine Änderung mit Build-, Test-, E2E- oder manuellen Prüfschritten verifiziert werden soll. | [code_testen.md](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Änderungen gezielt oder kontextbezogen verifizieren. |
| `documentation` | Documentation | - | Dokumentation erstellt, aktualisiert oder umstrukturiert werden soll. | [dokumentation.md](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Dokumentation pflegen. |
| `github-branch-checkout-from-default` | GitHub Branch Checkout From Default | - | Ein Arbeitsbranch von der aktuellen Standardbasis erstellt oder bestätigt werden soll. | [github_branch-checkout-from-default.md](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Arbeitsbranch vorbereiten. |
| `github-commit` | GitHub Commit | `/commit` | Fertige lokale Änderungen logisch geschnitten und ohne Push committet werden sollen. | [github_commit.md](https://heljens-it-services.github.io/agent-files/skills/github_commit.md) | Lokale Commits erstellen. |
| `commit-history-reading` | Commit History Reading | - | Commits und gemergte Pull Requests eines Repositorys für einen Zeitraum vollständig gelesen werden sollen. | [github_commit-history-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_commit-history-lesen.md) | Änderungshistorie erfassen. |
| `default-branch-update` | Default Branch Update | - | Nach einem verifizierten Merge sicher auf den aktualisierten Default-Branch gewechselt werden soll. | [github_default-branch-aktualisieren.md](https://heljens-it-services.github.io/agent-files/skills/github_default-branch-aktualisieren.md) | Default-Branch aktualisieren. |
| `integration-branch-update` | Integration Branch Update | - | Nach einem verifizierten Feature-Merge sicher auf `develop` gewechselt und der Branch aktualisiert werden soll. | [github_integrationsbranch-aktualisieren.md](https://heljens-it-services.github.io/agent-files/skills/github_integrationsbranch-aktualisieren.md) | Integrationsbranch aktualisieren. |
| `issue-creation` | Issue Creation | - | Ein strukturiertes GitHub-Issue aus vorhandenem Kontext erstellt werden soll. | [github_issue-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | Issue erstellen. |
| `issue-reading` | Issue Reading | - | Ein GitHub-Issue und seine Kommentare gelesen werden müssen. | [github_issue-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | Issue-Kontext erfassen. |
| `pr-checks-observation` | PR Checks Observation | - | Erforderliche Pull-Request-Checks bis zu einem terminalen Zustand beobachtet werden sollen. | [github_pr-checks-beobachten.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-checks-beobachten.md) | Pull-Request-Checks beobachten. |
| `pr-creation` | PR Creation | - | Ein Pull Request mit Titel, Body, Base und Head erstellt oder wiederverwendet werden soll. | [github_pr-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Pull Request bereitstellen. |
| `github-pr-merge` | GitHub PR Merge | - | Ein freigegebener Pull Request regelkonform gemergt werden soll. | [github_pr-merge.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-merge.md) | Pull Request mergen. |
| `github-push` | GitHub Push | `/push` | Vorhandene lokale Commits ohne neuen Commit auf den konfigurierten Upstream gepusht werden sollen. | [github_push.md](https://heljens-it-services.github.io/agent-files/skills/github_push.md) | Lokale Commits pushen. |
| `repository-baseline-configuration` | Repository Baseline Configuration | - | Die standardisierte GitHub-Basiskonfiguration eines Repositorys geprüft oder ergänzt werden soll. | [github_repository-basiskonfiguration.md](https://heljens-it-services.github.io/agent-files/skills/github_repository-basiskonfiguration.md) | GitHub-Repository-Basis pflegen. |
| `relationship-setting` | Relationship Setting | - | Native GitHub-Relationships wie Blocked-by oder Parent/Child gesetzt werden sollen. | [github_relationship-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setzen.md) | Issue-Beziehungen pflegen. |
| `type-setting` | Type Setting | - | Der native GitHub-Issue-Type eines bestehenden oder neu erstellten Issues gesetzt werden soll. | [github_type-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_type-setzen.md) | Issue-Type pflegen. |
| `research` | Research | - | Web-, Repository-, Issue- oder PR-Kontext recherchiert und zusammengefasst werden soll. | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Kontext recherchieren. |
