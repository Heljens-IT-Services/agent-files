# PROJECT.md

## Zweck

Dieses Repository veröffentlicht die zentralen Agent-, Developer-, Skill- und Workflow-Anweisungen von Heljens IT Services über GitHub Pages.

## Versionsbasis

Die veröffentlichten Quelldateien liegen unter `docs/`. GitHub Pages stellt sie aus dem Branch `main` bereit.

## Fachliche Leitplanken

[MUST] Die Markdown-Dateien unter `docs/` bilden die fachliche Single Source of Truth für konsumierende Agenten und Projekt-Repositories.

[MUST] Repository-lokale Einstiegspunkte wie `AGENTS.md` dürfen auf die veröffentlichten globalen Regeln verweisen, müssen dabei aber einen funktionsfähigen Abrufweg für Agents beschreiben.

## Technische Leitplanken

[MUST] Änderungen an veröffentlichten Regeln müssen direkt in den Markdown-Dateien unter `docs/` erfolgen.

[MUST] Die online veröffentlichten Codex-Agent-Vorlagen unter `docs/codex/agents/` müssen inhaltsgleich mit den ausführbaren Mustervorlagen unter `.codex/agents/` gepflegt werden.

[MUST_NOT] Es darf kein separater Build- oder Generierungsschritt vorausgesetzt werden, solange GitHub Pages die versionierten Dateien unter `docs/` direkt verteilt.

[MUST] Jede Markdown-Datei unter `docs/` muss für konsumierende Agents bestimmt, über GitHub Pages abrufbar und ausgehend von `docs/AGENTS.md` durch interne Markdown-Links erreichbar sein.

### Interner Workflow: Online-Publikation prüfen

Der Workflow `online-publikation-pruefen` wird nach einem Release oder bei Zweifeln an Erreichbarkeit, Vernetzung oder Aktualität der veröffentlichten Agent Files verwendet. Er verändert keine versionierten Dateien und keinen externen Zustand.

| Schritt | Prüfung | Erfolgsbedingung |
|---|---|---|
| 1. Referenzstand | `origin/main` aktualisieren und dessen Commit-SHA erfassen. | Der erwartete Referenzstand ist eindeutig. |
| 2. Pages-Quelle | GitHub-Pages-Konfiguration und letzten Build über die GitHub API lesen. | Quelle ist Branch `main` mit Pfad `/docs`; Build-Status ist `built`; Build-Commit entspricht `origin/main`. |
| 3. Einstiegspunkt | `https://heljens-it-services.github.io/agent-files/AGENTS.md` per HTTP abrufen. | HTTP-Status ist `200`. |
| 4. Vernetzung | Aus allen internen Markdown-Links einen Graphen ab `docs/AGENTS.md` bilden und mit den auf `origin/main` versionierten `docs/**/*.md`-Dateien vergleichen. | Kein Linkziel fehlt und jede Markdown-Datei unter `docs/` ist erreichbar. |
| 5. Online-Abruf | Für jede versionierte Markdown-Datei sowie jede Codex-Agent-Vorlage unter `docs/codex/agents/` den Pages-Pfad aus dem Pfad relativ zu `docs/` bilden und abrufen. | Jede URL liefert HTTP-Status `200`. |
| 6. Inhaltsabgleich | Online-Inhalt jeder geprüften Datei nach Vereinheitlichung der Zeilenenden mit dem zugehörigen Blob aus `origin/main` vergleichen; zusätzlich die veröffentlichten Codex-Agent-Vorlagen mit `.codex/agents/` abgleichen. | Keine Inhaltsabweichung besteht. |
| 7. Ergebnis | Referenz-SHA, Datei- und Linkanzahl sowie Abweichungen zusammenfassen. | Quelle, Erreichbarkeit, Vernetzung und Aktualität sind getrennt bewertet. |

Empfohlene Basisabfragen:

```powershell
git fetch origin
git rev-parse origin/main
gh api repos/Heljens-IT-Services/agent-files/pages
gh api repos/Heljens-IT-Services/agent-files/pages/builds/latest
git ls-tree -r --name-only origin/main -- docs
Invoke-WebRequest -Uri "https://heljens-it-services.github.io/agent-files/AGENTS.md" -UseBasicParsing
```

[MUST_IF] Wenn Browser- oder Web-Tools eine Markdown-URL nicht direkt abrufen können, muss vor einem Fehlerurteil der HTTP-Abruf per Shell versucht werden.

[MUST_NOT] Nicht verlinkte Dateien unter `docs/` dürfen nicht stillschweigend als interne Dateien eingestuft werden. Interne Pflegehinweise gehören außerhalb von `docs/`.

[MUST_IF] Die Prüfung muss mit konkreten Pfaden, URLs und erwarteter beziehungsweise tatsächlicher Commit-SHA fehlschlagen, sobald eine Erfolgsbedingung nicht erfüllt ist.
