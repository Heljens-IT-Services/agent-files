# agent-files

`agent-files` enthält die verbindlich veröffentlichten Agent- und Developer-Anweisungen von Heljens IT Services.

Das Repository ist bewusst einfach aufgebaut: Die relevanten Markdown-Dateien liegen unter `docs/` und werden von GitHub Pages unmittelbar veröffentlicht. Es gibt keine separate HTML-, CSS- oder Build-Schicht.

## GitHub Pages

Die veröffentlichte Referenz liegt unter:

[GitHub Pages](https://heljens-it-services.github.io/agent-files/)

Dieses Repository ist ein GitHub-Pages-Projekt. Die Pages-Ausgabe wird aus dem Branch `main` und dem Ordner `docs/` bereitgestellt.

Die Dateien sind direkt unter festen Markdown-URLs erreichbar, zum Beispiel:

- [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md)
- [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md)
- [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md)
- [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md)

Andere Repositories und Projekte sollen auf diese URLs verweisen, wenn sie die aktuell gültigen Arbeitsanweisungen für KI-Agenten, Codex oder vergleichbare Entwicklungsassistenten referenzieren wollen.

## Zweck

Das Repository dient als zentrale, online referenzierbare Single Source of Truth für Agent- und Developer-Anweisungen.

Die Markdown-Dateien sind von deontischer Logik inspiriert. Sie arbeiten mit expliziten Regelmarkern, um Verpflichtungen, Verbote, Erlaubnisse, Prioritäten und bedingte Geltungsbereiche für Agents und Entwicklungsassistenten klar und maschinenlesbar zu formulieren.

Typische Nutzung:

- `AGENTS.md` sowie die Lookup-Dateien `ROLES.md`, `SKILLS.md` und `WORKFLOWS.md` als Pflichtlektüre referenzieren
- Rollen-, Skill- und Workflow-Dateien anhand der beschriebenen Situationen nur bei Task-Relevanz einlesen
- eine zusätzliche `PROJECT.md` für Versionsbasis sowie fachliche und technische Projektspezifika pflegen
- projektbezogene und technologiespezifische Developer-Regeln zentral bereitstellen
- andere Repositories auf stabile, direkt aufrufbare Markdown-Dateien verweisen lassen

## Struktur

Die allgemeinen Arbeitsregeln liegen unter `docs/`. Rollen, Skills und Workflows liegen in eigenen Unterordnern und sind über verpflichtende Lookup-Dateien erschlossen.

Aktuell relevante Dateien sind:

| Pfad | URL | Zweck |
|---|---|---|
| `docs/AGENTS.md` | [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Pflichtlektüre, Prioritäten und Konfliktlogik für Agents. |
| `docs/roles/ROLES.md` | [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Lookup-Datei für Rollen. |
| `docs/roles/developer/DEVELOPER.md` | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Allgemeine technologieübergreifende Entwicklungsregeln. |
| `docs/roles/developer/DEVELOPER.*.md` | [Developer-Rollen](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Technologiespezifische Entwicklungsregeln. |
| `docs/skills/SKILLS.md` | [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Lookup-Datei für atomare Agenten-Skills. |
| `docs/workflows/WORKFLOWS.md` | [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Lookup-Datei für Workflows. |

## Pflege

Die Dateien unter `docs/` sind die veröffentlichten Quelldateien.

Änderungen an den Agent- und Developer-Anweisungen erfolgen direkt in diesen Markdown-Dateien. Es gibt bewusst keine separate Generierung und keinen zusätzlichen Sync-Schritt.

Die Regeln verwenden dazu Marker wie `MUST`, `MUST_IF`, `MUST_NOT`, `ALLOW`, `ALLOW_IF`, `SHOULD`, `OPTIONAL` und `PRIORITY`, damit die normative Bedeutung jeder Anweisung möglichst eindeutig bleibt.

Konsumierende Projekt-Repositories müssen zusätzlich eine eigene `PROJECT.md` halten. Diese Datei enthält mindestens die Versionsbasis des konkreten Projekts und kann fachliche oder technische Leitplanken festhalten, die nur für dieses Projekt gelten. Sie ist nicht Teil der allgemeinen veröffentlichten Referenz unter GitHub Pages, sondern bewusst als projektspezifische Ergänzung gedacht.

### Skills und Workflows pflegen

Die verbindlichen Pflegekonventionen für Skills und Workflows, die Abschnittsstruktur und die automatische Konsistenzprüfung stehen in [PROJECT.md](PROJECT.md).

## Verwendung in Projekten

Andere Repositories können direkt auf die Pflichtlektüre unter GitHub Pages verweisen: [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md), [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md), [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) und [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md).

Damit ist klar, welche Fassung jeweils veröffentlicht und referenziert wird.
