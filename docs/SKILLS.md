# SKILLS.md

## Zweck

Diese Datei ist der zentrale Einstiegspunkt fuer wiederkehrende Agenten-Skills und Workflows.

Skills sind atomare, wiederverwendbare Faehigkeiten. Workflows kombinieren mehrere Skills zu einem zusammenhaengenden Ablauf.

## Verwendung

[MUST_IF] Der Agent muss diese Datei lesen, wenn ein Task einer wiederkehrenden Aufgabe entspricht, fuer die unter `skills/` oder `workflows/` eine passende Beschreibung existiert.

[MUST_IF] Der Agent muss einen passenden Workflow unter `workflows/` verwenden, wenn der Task mehrere zusammenhaengende Skills benoetigt.

[MUST_IF] Der Agent muss die in einem verwendeten Workflow referenzierten Skill-Dateien unter `skills/` lesen und befolgen.

[MUST_IF] Der Agent muss einen passenden Skill direkt verwenden, wenn kein Workflow erforderlich ist oder der User explizit einen einzelnen Arbeitsschritt verlangt.

[SHOULD] Der Agent soll die kleinste passende Einheit verwenden: Skill fuer einzelne Arbeitsschritte, Workflow fuer zusammenhaengende End-to-End-Aufgaben.

[MUST_IF] Der Agent muss Abweichungen von einem passenden Skill oder Workflow kurz begruenden, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund dafuer liefert.

## Skripte und Kommandos

[ALLOW] Skills duerfen CLI-, PowerShell- oder Shell-Kommandos direkt in der jeweiligen Skill-Markdown-Datei dokumentieren.

[MUST_IF] Der Agent muss dokumentierte Kommandos vor der Ausfuehrung gegen den aktuellen Arbeitskontext pruefen und Parameter wie Branch-Namen, Pfade oder Remote-Namen passend ersetzen.

[MUST_NOT] Der Agent darf dokumentierte Kommandos nicht blind ausfuehren, wenn sie destruktiv, extern wirksam oder fuer den aktuellen Kontext unpassend sind.

[SHOULD] Dokumentierte Kommandos sollen als Beispiele oder empfohlene Pruefschritte formuliert werden und nicht als separate Script-Dateien ausgelagert werden, solange der Skill mit wenigen Kommandos auskommt.

## Skills

| Skill | URL | Zweck |
|---|---|---|
| Anforderungsklaerung | [anforderungsklaerung.md](https://heljens-it-services.github.io/agent-files/skills/anforderungsklaerung.md) | Anforderungen, Ziele, Nicht-Ziele und Scope-Grenzen klaeren. |
| Brainstorming | [brainstorming.md](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Interaktiv Denk- oder Loesungsrichtungen entwickeln und abwaegen. |
| Code Analyse | [code_analyse.md](https://heljens-it-services.github.io/agent-files/skills/code_analyse.md) | Code, Branches, Legacy-Bereiche oder Fehlverhalten bewerten und einordnen. |
| Code Diff Review | [code_diff-review.md](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Aenderungssatz auf Scope, Risiken und Nebeneffekte pruefen. |
| Code Implementieren | [code_implementieren.md](https://heljens-it-services.github.io/agent-files/skills/code_implementieren.md) | Geklaerte Verhaltens-, Logik-, Feature- oder API-Aenderung umsetzen. |
| Code Implementierungsplanung | [code_implementierungsplanung.md](https://heljens-it-services.github.io/agent-files/skills/code_implementierungsplanung.md) | Vorhandenen Kontext in einen konkreten technischen Umsetzungsplan ueberfuehren. |
| Code Lesen | [code_lesen.md](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Bestehenden Code gezielt in den Agenten-Kontext laden. |
| Code Refactoring | [code_refactoring.md](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Struktur verbessern, ohne beabsichtigtes Verhalten zu aendern. |
| Code Testen | [code_testen.md](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Aenderung mit passenden Build-, Test- oder manuellen Pruefschritten verifizieren. |
| Dokumentation | [dokumentation.md](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Dokumentationsdateien gezielt erstellen oder aktualisieren. |
| GitHub Branch Checkout From Default | [github_branch-checkout-from-default.md](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Arbeitsbranch von aktueller Standardbasis erstellen oder bestaetigen. |
| GitHub Commit Push | [github_commit-push.md](https://heljens-it-services.github.io/agent-files/skills/github_commit-push.md) | Aenderungssatz logisch schneiden, committen und pushen. |
| GitHub Issue Erstellen | [github_issue-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | GitHub-Issue erstellen, Issue-Type setzen und Relationships pflegen. |
| GitHub Issue Lesen | [github_issue-lesen.md](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | GitHub-Issue und Kommentare atomar lesen. |
| GitHub PR Erstellen | [github_pr-erstellen.md](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Pull Request mit Titel, Body, Base und Head in GitHub erstellen. |
| Research | [research.md](https://heljens-it-services.github.io/agent-files/skills/research.md) | Web-, Repo-, Issue- oder PR-Kontext recherchieren und zusammenfassen. |

## Workflows

| Workflow | URL | Zweck |
|---|---|---|
| Bugfix | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler analysieren, beheben und absichern. |
| Feature Umsetzung | [feature-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/feature-umsetzung.md) | Feature von Anforderung bis verifizierter Implementierung bearbeiten. |
| Instruction Improvement Issue | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows im `agent-files`-Repository erfassen. |
| Insight To Issue | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue ueberfuehren. |
| Issue To Sub Issues | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Grosses GitHub-Issue in mehrere Sub-Issues schneiden und als Child-Issues anlegen. |
| Issue To PR | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ticket bis zur Pull-Request-Erstellung ueberfuehren. |
| Issue Umsetzung | [issue-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Einzelnes Issue oder Arbeitspaket umsetzen, verifizieren, committen und pushen. |
| Refactoring Secure | [refactoring-secure.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Code strukturieren und Verhalten absichern. |
