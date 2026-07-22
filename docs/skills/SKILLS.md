# SKILLS.md

## Zweck

Diese Datei ist die Lookup-Datei fuer atomare, wiederverwendbare Agenten-Skills.

## Verwendung

[MUST_IF] Der Agent muss mehrere passende Skill-Dateien lesen und befolgen, wenn mehrere beschriebene Situationen eintreten und kein passender Workflow den zusammenhaengenden Ablauf festlegt.

[MUST] Der Agent muss `github_type-setzen` unmittelbar nach `github_issue-erstellen` verwenden, weil jedes neu erstellte GitHub-Issue einen nativen Issue-Type erhalten muss.

## Skills

| Skill | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|
| Anforderungsklaerung | Anforderungen, Ziele, Nicht-Ziele oder Scope-Grenzen unklar sind. | [anforderungsklaerung.md](https://heljens-it-services.github.io/agent-files/skills/anforderungsklaerung.md) | Anforderungen und Scope klaeren. |
| Brainstorming | Denk- oder Loesungsrichtungen interaktiv entwickelt und abgewogen werden sollen. | [brainstorming.md](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Loesungsrichtungen entwickeln. |
| Code Analyse | Code, Branches, Legacy-Bereiche oder Fehlverhalten bewertet werden sollen. | [code_analyse.md](https://heljens-it-services.github.io/agent-files/skills/code_analyse.md) | Technischen Bestand einordnen. |
| Code Diff Review | Ein Aenderungssatz auf Scope, Risiken oder Nebeneffekte geprueft werden soll. | [code_diff-review.md](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Aenderungen reviewen. |
| Code Implementieren | Eine geklaerte Verhaltens-, Logik-, Feature- oder API-Aenderung umgesetzt werden soll. | [code_implementieren.md](https://heljens-it-services.github.io/agent-files/skills/code_implementieren.md) | Codeaenderungen umsetzen. |
| Code Implementierungsplanung | Vorhandener Kontext in einen konkreten technischen Umsetzungsplan ueberfuehrt werden soll. | [code_implementierungsplanung.md](https://heljens-it-services.github.io/agent-files/skills/code_implementierungsplanung.md) | Umsetzung planen. |
| Code Lesen | Bestehender Code gezielt in den Agenten-Kontext geladen werden muss. | [code_lesen.md](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Codekontext erfassen. |
| Code Refactoring | Struktur ohne beabsichtigte Verhaltensaenderung verbessert werden soll. | [code_refactoring.md](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Code strukturieren. |
| Code Testen | Eine Aenderung mit Build-, Test- oder manuellen Pruefschritten verifiziert werden soll. | [code_testen.md](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Aenderungen verifizieren. |
| Dokumentation | Dokumentation erstellt, aktualisiert oder umstrukturiert werden soll. | [dokumentation.md](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Dokumentation pflegen. |
| GitHub Branch Checkout From Default | Ein Arbeitsbranch von der aktuellen Standardbasis erstellt oder bestaetigt werden soll. | [github_branch-checkout-from-default.md](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Arbeitsbranch vorbereiten. |
| GitHub Commit Push | Aenderungen logisch geschnitten, committet und gepusht werden sollen. | [github_commit-push.md](https://heljens-it-services.github.io/agent-files/skills/github_commit-push.md) | Aenderungen veroeffentlichen. |
| GitHub Issue Erstellen | Ein strukturiertes GitHub-Issue aus vorhandenem Kontext erstellt werden soll. | [github_issue-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | Issue erstellen. |
| GitHub Issue Lesen | Ein GitHub-Issue und seine Kommentare gelesen werden muessen. | [github_issue-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | Issue-Kontext erfassen. |
| GitHub PR Erstellen | Ein Pull Request mit Titel, Body, Base und Head erstellt werden soll. | [github_pr-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Pull Request erstellen. |
| GitHub Relationship Setzen | Native GitHub-Relationships wie Blocked-by oder Parent/Child gesetzt werden sollen. | [github_relationship-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setzen.md) | Issue-Beziehungen pflegen. |
| GitHub Type Setzen | Der native GitHub-Issue-Type eines bestehenden oder neu erstellten Issues gesetzt werden soll. | [github_type-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_type-setzen.md) | Issue-Type pflegen. |
| Research | Web-, Repository-, Issue- oder PR-Kontext recherchiert und zusammengefasst werden soll. | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Kontext recherchieren. |
