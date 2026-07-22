# TASK.GitHub.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert den Kontext fuer Aufgaben, deren primaeres Ergebnis eine Branch-, Commit-, Push- oder Pull-Request-Aktion auf GitHub ist.

## Scope

| Als primaeren Task-Typ verwenden, wenn | Als sekundaeren Task-Typ verwenden, wenn |
|---|---|
| GitHub-Repositoryzustand, Branches, Commits, Pushes oder Pull Requests das primaere Ergebnis sind. | Ein anderer Task eine klar abgegrenzte GitHub-Veroeffentlichung ohne passenden End-to-End-Workflow enthaelt. |

## Erlaubte Aktionen

[ALLOW_IF] Der Agent darf den lokalen und entfernten Repositoryzustand lesen, wenn das Ziel-Repository eindeutig bestimmt ist.

[ALLOW_IF] Der Agent darf Branches, Commits, Pushes oder Pull Requests erstellen, wenn der User oder ein passender Workflow die konkrete Zustandsaenderung autorisiert.

## Verbotene Aktionen

[MUST_NOT] Der Agent darf keinen Push, Pull Request oder anderen extern wirksamen Schritt ohne vorherige Scope- und Zielpruefung ausfuehren.

[MUST_NOT] Der Agent darf im GitHub-Scope keine fachlichen Code- oder Dokumentationsaenderungen verstecken.

## Zusatzkontext

| Kontext | Laden, wenn |
|---|---|
| `README.md` | Branch-, Release- oder Beitragskonventionen des Repositories relevant sind. |

## Skill-Verweise

| Skill | Verwenden, wenn |
|---|---|
| [github_branch-checkout-from-default](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) | Ein Arbeitsbranch vorbereitet werden soll. |
| [code_diff-review](https://heljens-it-services.github.io/agent-files/skills/code_diff-review.md) | Ein Aenderungssatz vor der Veroeffentlichung bewertet werden muss. |
| [github_commit-push](https://heljens-it-services.github.io/agent-files/skills/github_commit-push.md) | Aenderungen committet und gepusht werden sollen. |
| [github_pr-erstellen](https://heljens-it-services.github.io/agent-files/skills/github_pr-erstellen.md) | Ein Pull Request erstellt werden soll. |

## Abschlussanforderungen

[MUST] Der Arbeitsabschluss muss ausgefuehrte GitHub-Aktionen, Ziel-Branch oder Ziel-Repository und erzeugte URLs oder Commit-Hashes nennen.

[MUST_IF] Der Agent muss einen blockierten oder uebersprungenen externen Schritt mit Grund nennen, wenn er zum angeforderten Ergebnis gehoerte.
