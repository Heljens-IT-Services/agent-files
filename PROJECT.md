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

### Online-Publikation prüfen

Nach einem Release oder bei Zweifeln an Erreichbarkeit, Vernetzung oder Aktualität der veröffentlichten Agent Files wird der Workflow [`online-publication-check`](https://heljens-it-services.github.io/agent-files/workflows/online-publication-check.md) verwendet. Er verändert keine versionierten Dateien und keinen externen Zustand; seine Schritte und Erfolgsbedingungen stehen ausschließlich in der Workflow-Datei.

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

### Skills und Workflows pflegen

Skills bilden einzelne, klar abgegrenzte Fähigkeiten ab. Sie führen benötigte Vor- oder Nacharbeit nicht stillschweigend aus. Workflows kombinieren Skills in einer festgelegten Reihenfolge und definieren Bedingungen sowie Rücksprünge, ohne Skill-Regeln zu duplizieren, abzuschwächen oder zu überschreiben.

| Dateityp | Verbindliche Abschnitte | Bedingte Abschnitte |
|---|---|---|
| Skill | `Zweck`, `Verwenden`, `Vorgehen`, `Grenzen`, `Output`, `Qualitätskriterien` | `Kommandos`, wenn konkrete Tool- oder CLI-Aufrufe relevant sind; `Artefakt`, wenn Dateien entstehen. |
| Workflow | `Ziel`, `Verwenden`, `Verwendete Skills`, `Ablauf`, `Rücksprungregeln`, `Endergebnis` | `Verwendete Workflows` bei Orchestrierung weiterer Workflows; `Grenzen` bei besonderen Stop- oder Verbotsregeln. |

`Zweck` beziehungsweise `Ziel` beschreibt den Nutzen in ein bis zwei Sätzen. `Verwenden` grenzt Trigger und Nicht-Trigger ab; `Vorgehen` beziehungsweise `Ablauf` ordnet die Schritte. `Grenzen` benennt erlaubte und verbotene Aktionen, `Output` beziehungsweise `Endergebnis` den Abschlusszustand und `Qualitätskriterien` kurze, prüfbare Regeln. Ein `Artefakt` legt Pfad, Namensschema, Inhalt und Stil fest.

Zusätzliche fachliche Steuerungsabschnitte wie `Reifekriterien`, `Schnittkriterien`, `Entscheidungskriterien` oder `Priorisierung` sind erlaubt, wenn sie konkrete Entscheidungen prüfbar machen.

Für die Pflege gelten folgende Konventionen:

- Skill-Dateinamen beschreiben den fachlichen Scope; die Präfixe `code_` und `github_` kennzeichnen den jeweiligen Kontext.
- Command-IDs verwenden Kleinbuchstaben und Bindestriche. Bestehende Unterstrich-Konventionen in Dateinamen dürfen erhalten bleiben.
- Referenzierte Skills müssen vollständig aufgeführt und befolgt werden; ihre Grenzen gelten auch für extern wirksame Workflow-Schritte. Fehlt ein benötigter Skill, wird der Workflow nachgeschärft oder die Abweichung begründet. Bei blockierten Schritten gilt die Rücksprungregel oder der Blocker wird gemeldet.
- Formulierungen bleiben knapp und operativ, bevorzugen Listen und vermeiden allgemeine Agentenphilosophien.

### Konsistenzprüfung

[MUST] Vor jedem Commit an Dateien unter `docs/`, `.codex/agents/` oder an der Prüfung selbst muss `python3 scripts/lint_docs.py` fehlerfrei durchlaufen. Der GitHub-Actions-Workflow `docs-lint` führt dieselbe Prüfung für Pull Requests und Pushes nach `develop` und `main` aus.

[MUST] Die Prüfung ist ein reiner Lesecheck und kein Build- oder Generierungsschritt; sie darf keine Dateien unter `docs/` erzeugen oder verändern.

[MUST_IF] Wenn eine Datei unter `docs/` eine `Stand:`-Zeile trägt, muss diese bei jeder inhaltlichen Änderung der Datei auf das Änderungsdatum gesetzt werden.
