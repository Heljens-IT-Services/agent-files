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

[MUST] Jede Markdown-Datei unter `docs/` muss fuer konsumierende Agents bestimmt, ueber GitHub Pages abrufbar und ausgehend von `docs/AGENTS.md` durch interne Markdown-Links erreichbar sein.

### Interner Workflow: Online-Publikation pruefen

Der Workflow `online-publikation-pruefen` wird nach einem Release oder bei Zweifeln an Erreichbarkeit, Vernetzung oder Aktualitaet der veroeffentlichten Agent Files verwendet. Er veraendert keine versionierten Dateien und keinen externen Zustand.

| Schritt | Pruefung | Erfolgsbedingung |
|---|---|---|
| 1. Referenzstand | `origin/main` aktualisieren und dessen Commit-SHA erfassen. | Der erwartete Referenzstand ist eindeutig. |
| 2. Pages-Quelle | GitHub-Pages-Konfiguration und letzten Build ueber die GitHub API lesen. | Quelle ist Branch `main` mit Pfad `/docs`; Build-Status ist `built`; Build-Commit entspricht `origin/main`. |
| 3. Einstiegspunkt | `https://heljens-it-services.github.io/agent-files/AGENTS.md` per HTTP abrufen. | HTTP-Status ist `200`. |
| 4. Vernetzung | Aus allen internen Markdown-Links einen Graphen ab `docs/AGENTS.md` bilden und mit den auf `origin/main` versionierten `docs/**/*.md`-Dateien vergleichen. | Kein Linkziel fehlt und jede Markdown-Datei unter `docs/` ist erreichbar. |
| 5. Online-Abruf | Fuer jede versionierte Markdown-Datei den Pages-Pfad aus dem Pfad relativ zu `docs/` bilden und abrufen. | Jede URL liefert HTTP-Status `200`. |
| 6. Inhaltsabgleich | Online-Inhalt jeder Datei nach Vereinheitlichung der Zeilenenden mit dem zugehoerigen Blob aus `origin/main` vergleichen. | Keine Inhaltsabweichung besteht. |
| 7. Ergebnis | Referenz-SHA, Datei- und Linkanzahl sowie Abweichungen zusammenfassen. | Quelle, Erreichbarkeit, Vernetzung und Aktualitaet sind getrennt bewertet. |

Empfohlene Basisabfragen:

```powershell
git fetch origin
git rev-parse origin/main
gh api repos/Heljens-IT-Services/agent-files/pages
gh api repos/Heljens-IT-Services/agent-files/pages/builds/latest
git ls-tree -r --name-only origin/main -- docs
Invoke-WebRequest -Uri "https://heljens-it-services.github.io/agent-files/AGENTS.md" -UseBasicParsing
```

[MUST_IF] Wenn Browser- oder Web-Tools eine Markdown-URL nicht direkt abrufen koennen, muss vor einem Fehlerurteil der HTTP-Abruf per Shell versucht werden.

[MUST_NOT] Nicht verlinkte Dateien unter `docs/` duerfen nicht stillschweigend als interne Dateien eingestuft werden. Interne Pflegehinweise gehoeren ausserhalb von `docs/`.

[MUST_IF] Die Pruefung muss mit konkreten Pfaden, URLs und erwarteter beziehungsweise tatsaechlicher Commit-SHA fehlschlagen, sobald eine Erfolgsbedingung nicht erfuellt ist.
