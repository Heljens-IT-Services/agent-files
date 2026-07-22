# SKILLS.md

## Zweck

Diese Datei ist die Lookup-Datei fuer atomare, wiederverwendbare Agenten-Skills.

## Verwendung

[MUST_IF] Der Agent muss mehrere passende Skill-Dateien lesen und befolgen, wenn mehrere beschriebene Situationen eintreten und kein passender Workflow den zusammenhaengenden Ablauf festlegt.

[MUST] Der Agent muss `github_type-setzen` unmittelbar nach `github_issue-erstellen` verwenden, weil jedes neu erstellte GitHub-Issue einen nativen Issue-Type erhalten muss.

## Slash-Commands

[MUST] Die allgemeine Syntax, Aufloesung und Fehlerbehandlung fuer Slash-Commands muss [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md) folgen.

[MUST] Jeder Skill muss in der folgenden Tabelle eine stabile ID besitzen. Der kanonische Aufruf lautet `/skills run <skill-id>`.

[ALLOW] Ein Skill darf einen global eindeutigen direkten Alias besitzen, wenn dieser in der Tabelle registriert ist.

[MUST_NOT] Slash-Commands duerfen die automatische kontextbezogene Auswahl, natuerliche User-Anfragen oder die explizite Namensnennung nicht ersetzen oder einschraenken.

## Skills

| ID | Skill | Direkter Alias | Lesen und verwenden, wenn | URL | Zweck |
|---|---|---|---|---|---|
| `anforderungsklaerung` | Anforderungsklaerung | - | Anforderungen, Ziele, Nicht-Ziele oder Scope-Grenzen unklar sind. | [anforderungsklaerung.md](https://heljens-it-services.github.io/agent-files/skills/anforderungsklaerung.md) | Anforderungen und Scope klaeren. |
| `brainstorming` | Brainstorming | - | Denk- oder Loesungsrichtungen interaktiv entwickelt und abgewogen werden sollen. | [brainstorming.md](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Loesungsrichtungen entwickeln. |
| `code-analyse` | Code Analyse | - | Code, Branches, Legacy-Bereiche oder Fehlverhalten bewertet werden sollen. | [code_analyse.md](https://heljens-it-services.github.io/agent-files/skills/code_analyse.md) | Technischen Bestand einordnen. |
| `code-diff-review` | Code Diff Review | - | Ein Aenderungssatz auf Scope, Risiken oder Nebeneffekte geprueft werden soll. | [code_diff-review.md](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Aenderungen reviewen. |
| `code-implementieren` | Code Implementieren | - | Eine geklaerte Verhaltens-, Logik-, Feature- oder API-Aenderung umgesetzt werden soll. | [code_implementieren.md](https://heljens-it-services.github.io/agent-files/skills/code_implementieren.md) | Codeaenderungen umsetzen. |
| `code-implementierungsplanung` | Code Implementierungsplanung | - | Vorhandener Kontext in einen konkreten technischen Umsetzungsplan ueberfuehrt werden soll. | [code_implementierungsplanung.md](https://heljens-it-services.github.io/agent-files/skills/code_implementierungsplanung.md) | Umsetzung planen. |
| `code-lesen` | Code Lesen | - | Bestehender Code gezielt in den Agenten-Kontext geladen werden muss. | [code_lesen.md](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Codekontext erfassen. |
| `code-refactoring` | Code Refactoring | - | Struktur ohne beabsichtigte Verhaltensaenderung verbessert werden soll. | [code_refactoring.md](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Code strukturieren. |
| `code-testen` | Code Testen | - | Eine Aenderung mit Build-, Test- oder manuellen Pruefschritten verifiziert werden soll. | [code_testen.md](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Aenderungen verifizieren. |
| `dokumentation` | Dokumentation | - | Dokumentation erstellt, aktualisiert oder umstrukturiert werden soll. | [dokumentation.md](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Dokumentation pflegen. |
| `github-branch-checkout-from-default` | GitHub Branch Checkout From Default | - | Ein Arbeitsbranch von der aktuellen Standardbasis erstellt oder bestaetigt werden soll. | [github_branch-checkout-from-default.md](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Arbeitsbranch vorbereiten. |
| `github-commit-push` | GitHub Commit Push | - | Aenderungen logisch geschnitten, committet und gepusht werden sollen. | [github_commit-push.md](https://heljens-it-services.github.io/agent-files/skills/github_commit-push.md) | Aenderungen veroeffentlichen. |
| `github-default-branch-aktualisieren` | GitHub Default Branch Aktualisieren | - | Nach einem verifizierten Merge sicher auf den aktualisierten Default-Branch gewechselt werden soll. | [github_default-branch-aktualisieren.md](https://heljens-it-services.github.io/agent-files/skills/github_default-branch-aktualisieren.md) | Default-Branch aktualisieren. |
| `github-issue-erstellen` | GitHub Issue Erstellen | - | Ein strukturiertes GitHub-Issue aus vorhandenem Kontext erstellt werden soll. | [github_issue-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | Issue erstellen. |
| `github-issue-lesen` | GitHub Issue Lesen | - | Ein GitHub-Issue und seine Kommentare gelesen werden muessen. | [github_issue-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | Issue-Kontext erfassen. |
| `github-pr-checks-beobachten` | GitHub PR Checks Beobachten | - | Erforderliche Pull-Request-Checks bis zu einem terminalen Zustand beobachtet werden sollen. | [github_pr-checks-beobachten.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-checks-beobachten.md) | Pull-Request-Checks beobachten. |
| `github-pr-erstellen` | GitHub PR Erstellen | - | Ein Pull Request mit Titel, Body, Base und Head erstellt oder wiederverwendet werden soll. | [github_pr-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Pull Request bereitstellen. |
| `github-pr-merge` | GitHub PR Merge | - | Ein freigegebener Pull Request regelkonform gemergt werden soll. | [github_pr-merge.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-merge.md) | Pull Request mergen. |
| `github-relationship-setzen` | GitHub Relationship Setzen | - | Native GitHub-Relationships wie Blocked-by oder Parent/Child gesetzt werden sollen. | [github_relationship-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setzen.md) | Issue-Beziehungen pflegen. |
| `github-type-setzen` | GitHub Type Setzen | - | Der native GitHub-Issue-Type eines bestehenden oder neu erstellten Issues gesetzt werden soll. | [github_type-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_type-setzen.md) | Issue-Type pflegen. |
| `research` | Research | - | Web-, Repository-, Issue- oder PR-Kontext recherchiert und zusammengefasst werden soll. | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Kontext recherchieren. |
