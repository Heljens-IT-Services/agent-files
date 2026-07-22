# TASK.Coding.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert den Kontext fuer Aufgaben, deren primaeres Ergebnis eine Codeaenderung, ein technischer Plan oder eine technische Codebewertung ist.

## Scope

| Als primaeren Task-Typ verwenden, wenn | Als sekundaeren Task-Typ verwenden, wenn |
|---|---|
| Code implementiert, refaktoriert, technisch analysiert oder reviewt werden soll. | Ein anderer Task einen klar abgegrenzten Coding-Anteil wie eine notwendige Testcode-Aenderung enthaelt. |

## Erlaubte Aktionen

[ALLOW] Der Agent darf Code, Tests und unmittelbar betroffene technische Dokumentation innerhalb des autorisierten Scopes lesen und aendern.

[ALLOW_IF] Der Agent darf Builds, Tests und andere lokale Verifikationen ausfuehren, wenn sie die Aenderung pruefen.

## Verbotene Aktionen

[MUST_NOT] Der Agent darf fachliche Anforderungen oder den autorisierten Scope nicht stillschweigend erweitern.

[MUST_NOT_IF] Der Agent darf keine extern wirksame Veroeffentlichung ausfuehren, wenn sie weder vom User noch von einem passenden Workflow verlangt wird.

## Zusatzkontext

| Kontext | Laden, wenn |
|---|---|
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Code, Architektur, technische Planung, Code-Review oder Testcode betroffen sind. |
| `README.md` | Setup, Build, Tests oder lokale Projektkonventionen relevant sind. |

## Skill-Verweise

| Skill oder Workflow | Verwenden, wenn |
|---|---|
| [code_lesen](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Codekontext gezielt geladen werden muss. |
| [code_analyse](https://heljens-it-services.github.io/agent-files/skills/code_analyse.md) | Verhalten, Risiken oder Architektur bewertet werden sollen. |
| [code_implementierungsplanung](https://heljens-it-services.github.io/agent-files/skills/code_implementierungsplanung.md) | Eine nicht-triviale Umsetzung geplant werden muss. |
| [code_implementieren](https://heljens-it-services.github.io/agent-files/skills/code_implementieren.md) | Verhalten oder Logik geaendert werden soll. |
| [code_refactoring](https://heljens-it-services.github.io/agent-files/skills/code_refactoring.md) | Struktur bei beabsichtigtem Verhaltenserhalt verbessert werden soll. |
| [code_testen](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Eine Aenderung verifiziert werden soll. |
| [code_diff-review](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Ein Aenderungssatz geprueft werden soll. |
| [bugfix](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Ein Fehler end-to-end behoben werden soll. |
| [feature-umsetzung](https://heljens-it-services.github.io/agent-files/workflows/feature-umsetzung.md) | Ein Feature end-to-end umgesetzt werden soll. |
| [refactoring-secure](https://heljens-it-services.github.io/agent-files/workflows/refactoring-secure.md) | Ein Refactoring mit nachgewiesenem Verhaltenserhalt umgesetzt werden soll. |

## Abschlussanforderungen

[MUST] Der Arbeitsabschluss muss geaenderte Bereiche, ausgefuehrte Verifikationen und offene Risiken nennen.

[MUST_IF] Der Agent muss fehlgeschlagene oder ausgelassene relevante Checks begruenden, wenn die Aufgabe Code oder Testcode veraendert hat.
