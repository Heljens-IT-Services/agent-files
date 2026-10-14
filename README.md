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

- über `AGENTS.md` in den Koordinator oder die ausdrücklich zugewiesene Spezialistenrolle einsteigen
- Spezialisten mit ihrer eigenen Rollenbeschreibung und den dort direkt freigegebenen, auftragsrelevanten Quellen versorgen
- eine zusätzliche `PROJECT.md` für Versionsbasis sowie fachliche und technische Projektspezifika pflegen
- projektbezogene und technologiespezifische Developer-Regeln zentral bereitstellen
- andere Repositories auf stabile, direkt aufrufbare Markdown-Dateien verweisen lassen

## Struktur

Die allgemeinen Arbeitsregeln liegen unter `docs/`. Rollen, Skills und Workflows liegen in eigenen Unterordnern und sind über rollenbezogene Quellenfreigaben und Routing-Kataloge erschlossen.

Aktuell relevante Dateien sind:

| Pfad | URL | Zweck |
|---|---|---|
| `docs/AGENTS.md` | [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Navigation zum Koordinator oder zur zugewiesenen Rolle. |
| `docs/roles/ROLES.md` | [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Kompaktes Rollenverzeichnis für den Koordinator. |
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

Skills bilden einzelne, klar abgegrenzte Fähigkeiten ab. Sie führen benötigte Vor- oder Nacharbeit nicht stillschweigend aus. Workflows kombinieren Skills in einer festgelegten Reihenfolge und definieren Bedingungen sowie Rücksprünge, ohne Skill-Regeln zu duplizieren, abzuschwächen oder zu überschreiben.

| Dateityp | Verbindliche Abschnitte | Bedingte Abschnitte |
|---|---|---|
| Skill | `Zweck`, `Verwenden`, `Vorgehen`, `Grenzen`, `Output`, `Qualitaetskriterien` | `Kommandos`, wenn konkrete Tool- oder CLI-Aufrufe relevant sind; `Artefakt`, wenn Dateien entstehen. |
| Workflow | `Ziel`, `Verwenden`, `Verwendete Skills`, `Ablauf`, `Ruecksprungregeln`, `Endergebnis` | `Verwendete Workflows` bei Orchestrierung weiterer Workflows; `Grenzen` bei besonderen Stop- oder Verbotsregeln. |

`Zweck` beziehungsweise `Ziel` beschreibt den Nutzen in ein bis zwei Sätzen. `Verwenden` grenzt Trigger und Nicht-Trigger ab; `Vorgehen` beziehungsweise `Ablauf` ordnet die Schritte. `Grenzen` benennt erlaubte und verbotene Aktionen, `Output` beziehungsweise `Endergebnis` den Abschlusszustand und `Qualitaetskriterien` kurze, prüfbare Regeln. Ein `Artefakt` legt Pfad, Namensschema, Inhalt und Stil fest.

Zusätzliche fachliche Steuerungsabschnitte wie `Reifekriterien`, `Schnittkriterien`, `Entscheidungskriterien` oder `Priorisierung` sind erlaubt, wenn sie konkrete Entscheidungen prüfbar machen.

Für die Pflege gelten folgende Konventionen:

- Skill-Dateinamen beschreiben den fachlichen Scope; die Präfixe `code_` und `github_` kennzeichnen den jeweiligen Kontext.
- Command-IDs verwenden Kleinbuchstaben und Bindestriche. Bestehende Unterstrich-Konventionen in Dateinamen dürfen erhalten bleiben.
- Referenzierte Skills müssen vollständig aufgeführt und befolgt werden; ihre Grenzen gelten auch für extern wirksame Workflow-Schritte. Fehlt ein benötigter Skill, wird der Workflow nachgeschärft oder die Abweichung begründet. Bei blockierten Schritten gilt die Rücksprungregel oder der Blocker wird gemeldet.
- Formulierungen bleiben knapp und operativ, bevorzugen Listen und vermeiden allgemeine Agentenphilosophien.

## Verwendung in Projekten

Andere Repositories verweisen auf den Einstieg und die Routing-Kataloge unter GitHub Pages: [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md), [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md), [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) und [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md).

Damit ist klar, welche Fassung jeweils veröffentlicht und referenziert wird.


Die Agent-TOMLs konfigurieren Rollen und Modellparameter. Routing, Kommunikation und Kontextgrenzen sind Instruktionen für den ausführenden Host. Spezialisten erhalten ihre Rollenquelle und einen begrenzten Auftragskontext; der Koordinator verwendet die Routing-Kataloge.
