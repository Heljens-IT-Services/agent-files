# PROJECT.md

## Zweck

Dieses Repository veroeffentlicht die zentralen Agent-, Developer-, Skill- und Workflow-Anweisungen von Heljens IT Services ueber GitHub Pages.

## Versionsbasis

Die veroeffentlichten Quelldateien liegen unter `docs/`. GitHub Pages stellt sie aus dem Branch `main` bereit.

## Fachliche Leitplanken

[MUST] Die Markdown-Dateien unter `docs/` bilden die fachliche Single Source of Truth fuer konsumierende Agenten und Projekt-Repositories.

[MUST] Repository-lokale Einstiegspunkte wie `AGENTS.md` duerfen auf die veroeffentlichten globalen Regeln verweisen, muessen dabei aber einen funktionsfaehigen Abrufweg fuer Agents beschreiben.

## Technische Leitplanken

[MUST] Aenderungen an veroeffentlichten Regeln muessen direkt in den Markdown-Dateien unter `docs/` erfolgen.

[MUST_NOT] Es darf kein separater Build- oder Generierungsschritt vorausgesetzt werden, solange die GitHub-Pages-Verteilung direkt aus Markdown-Dateien erfolgt.
