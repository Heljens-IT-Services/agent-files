# SKILLS.md

## Zweck

Diese Datei ist die Lookup-Datei fuer atomare, wiederverwendbare Agenten-Skills.

## Verwendung

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass diese Datei im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, damit passende Skills vor der eigenstaendigen Ausfuehrung erkannt werden koennen.

[ALLOW_IF] Wenn diese Datei in der laufenden Unterhaltung bereits gelesen wurde und kein Hinweis auf eine zwischenzeitliche Aenderung besteht, darf der Agent die vorhandene Kontextfassung wiederverwenden, statt sie erneut vollstaendig abzurufen.

[MUST_IF] Der Agent muss diese Datei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST] Der Agent muss die Situationstabelle in dieser Datei verwenden, um passende Skills zu bestimmen.

[MUST_IF] Der Agent muss die verlinkte Skill-Datei vor der Ausfuehrung lesen und befolgen, wenn die beschriebene Situation fuer den aktuellen Task eintritt.

[MUST_IF] Der Agent muss mehrere passende Skill-Dateien lesen und befolgen, wenn mehrere beschriebene Situationen eintreten und kein passender Workflow den zusammenhaengenden Ablauf festlegt.

[MUST_IF] Der Agent muss Abweichungen von einem passenden Skill kurz begruenden, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund dafuer liefert.

## Skripte und Kommandos

[ALLOW] Skills duerfen CLI-, PowerShell- oder Shell-Kommandos direkt in der jeweiligen Skill-Markdown-Datei dokumentieren.

[MUST_IF] Der Agent muss dokumentierte Kommandos vor der Ausfuehrung gegen den aktuellen Arbeitskontext pruefen und Parameter wie Branch-Namen, Pfade oder Remote-Namen passend ersetzen.

[MUST_NOT] Der Agent darf dokumentierte Kommandos nicht blind ausfuehren, wenn sie destruktiv, extern wirksam oder fuer den aktuellen Kontext unpassend sind.

[SHOULD] Dokumentierte Kommandos sollen als Beispiele oder empfohlene Pruefschritte formuliert werden und nicht als separate Script-Dateien ausgelagert werden, solange der Skill mit wenigen Kommandos auskommt.

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
| GitHub Issue Erstellen | Ein GitHub-Issue erstellt und mit Type oder Relationships gepflegt werden soll. | [github_issue-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | Issue erstellen. |
| GitHub Issue Lesen | Ein GitHub-Issue und seine Kommentare gelesen werden muessen. | [github_issue-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | Issue-Kontext erfassen. |
| GitHub PR Erstellen | Ein Pull Request mit Titel, Body, Base und Head erstellt werden soll. | [github_pr-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Pull Request erstellen. |
| GitHub Relationship Setzen | Native GitHub-Relationships wie Blocked-by oder Parent/Child gesetzt werden sollen. | [github_relationship-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setzen.md) | Issue-Beziehungen pflegen. |
| GitHub Type Setzen | Der native GitHub-Issue-Type eines bestehenden Issues gesetzt werden soll. | [github_type-setzen.md](https://heljens-it-services.github.io/agent-files/skills/github_type-setzen.md) | Issue-Type pflegen. |
| Research | Web-, Repository-, Issue- oder PR-Kontext recherchiert und zusammengefasst werden soll. | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Kontext recherchieren. |
