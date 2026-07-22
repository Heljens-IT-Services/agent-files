# TASK.Issue.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert den Kontext fuer Aufgaben, deren primaeres Ergebnis die Arbeit mit einem GitHub-Issue oder die issue-getriebene Umsetzung eines Arbeitspakets ist.

## Scope

| Als primaeren Task-Typ verwenden, wenn | Als sekundaeren Task-Typ verwenden, wenn |
|---|---|
| Ein Issue gelesen, erstellt, strukturiert, verknuepft oder als Arbeitspaket umgesetzt werden soll. | Ein anderer Task einen klar abgegrenzten Issue-Schritt wie Kontextlesen oder Verknuepfung enthaelt. |

## Erlaubte Aktionen

[ALLOW_IF] Der Agent darf Issue-Inhalt und direkt angeforderten Beziehungskontext lesen, wenn Repository und Issue eindeutig sind.

[ALLOW_IF] Der Agent darf ein Issue erstellen oder mutieren, wenn der User oder ein passender Workflow die konkrete Aktion autorisiert.

[ALLOW_IF] Der Agent darf Code oder Dokumentation aendern, testen, reviewen, committen und pushen, wenn ein ausgewaehlter issue-getriebener Workflow diese Schritte verlangt.

## Verbotene Aktionen

[MUST_NOT] Der Agent darf fehlende Issue-Anforderungen nicht erfinden oder stillschweigend erweitern.

[MUST_NOT] Der Agent darf Issue-Beziehungen, Status oder Metadaten nicht ohne passenden Skill und eindeutiges Ziel veraendern.

## Zusatzkontext

| Kontext | Laden, wenn |
|---|---|
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Das Issue Code, Architektur, technische Planung, Code-Review oder Testcode betrifft. |
| `README.md` | Projektsetup, lokale Kommandos oder Beitragskonventionen fuer die Issue-Umsetzung relevant sind. |

## Skill-Verweise

| Skill oder Workflow | Verwenden, wenn |
|---|---|
| [github_issue-lesen](https://heljens-it-services.github.io/agent-files/skills/github_issue-lesen.md) | Issue-Inhalt und Kommentare gelesen werden muessen. |
| [github_issue-erstellen](https://heljens-it-services.github.io/agent-files/skills/github_issue-erstellen.md) | Ein neues Issue erstellt werden soll. |
| [github_type-setzen](https://heljens-it-services.github.io/agent-files/skills/github_type-setzen.md) | Ein nativer Issue-Type gesetzt werden soll. |
| [github_relationship-setzen](https://heljens-it-services.github.io/agent-files/skills/github_relationship-setzen.md) | Parent-, Child- oder Blocked-by-Beziehungen gesetzt werden sollen. |
| [dokumentation](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Eine issue-getriebene Dokumentationsaenderung umgesetzt werden soll. |
| [insight-to-issue](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Eine Erkenntnis als Issue erfasst werden soll. |
| [instruction-improvement-issue](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Eine Instruction-Verbesserung als Issue erfasst werden soll. |
| [issue-to-sub-issues](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Ein Issue in Child-Issues zerlegt werden soll. |
| [issue-umsetzung](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Ein Issue oder Arbeitspaket umgesetzt, verifiziert, committet und gepusht werden soll. |
| [issue-to-pr](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Eine bereits umgesetzte Issue-Aenderung als Pull Request veroeffentlicht werden soll. |

## Abschlussanforderungen

[MUST] Der Arbeitsabschluss muss das bearbeitete Issue, das Ergebnis und ausgefuehrte Zustandsaenderungen nennen.

[MUST_IF] Der Agent muss Akzeptanzkriterien, Teststatus und Commit-Kontext nennen, wenn ein Issue umgesetzt wurde.
