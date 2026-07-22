# agent-files

`agent-files` enthaelt die verbindlich veroeffentlichten Agent- und Developer-Anweisungen von Heljens IT Services.

Das Repository ist bewusst einfach aufgebaut: Die relevanten Markdown-Dateien liegen unter `docs/` und werden von GitHub Pages unmittelbar veroeffentlicht. Es gibt keine separate HTML-, CSS- oder Build-Schicht.

## GitHub Pages

Die veroeffentlichte Referenz liegt unter:

[GitHub Pages](https://heljens-it-services.github.io/agent-files/)

Dieses Repository ist ein GitHub-Pages-Projekt. Die Pages-Ausgabe wird aus dem Branch `main` und dem Ordner `docs/` bereitgestellt.

Die Dateien sind direkt unter festen Markdown-URLs erreichbar, zum Beispiel:

- [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md)
- [TASK.Coding.md](https://heljens-it-services.github.io/agent-files/TASK.Coding.md)
- [TASK.Testing.md](https://heljens-it-services.github.io/agent-files/TASK.Testing.md)
- [TASK.GitHub.md](https://heljens-it-services.github.io/agent-files/TASK.GitHub.md)
- [TASK.Issue.md](https://heljens-it-services.github.io/agent-files/TASK.Issue.md)
- [TASK.General.md](https://heljens-it-services.github.io/agent-files/TASK.General.md)
- [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md)
- [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md)
- [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md)

Andere Repositories und Projekte sollen auf diese URLs verweisen, wenn sie die aktuell gueltigen Arbeitsanweisungen fuer KI-Agenten, Codex oder vergleichbare Entwicklungsassistenten referenzieren wollen.

## Zweck

Das Repository dient als zentrale, online referenzierbare Single Source of Truth fuer Agent- und Developer-Anweisungen.

Die Markdown-Dateien sind von deontischer Logik inspiriert. Sie arbeiten mit expliziten Regelmarkern, um Verpflichtungen, Verbote, Erlaubnisse, Prioritaeten und bedingte Geltungsbereiche fuer Agents und Entwicklungsassistenten klar und maschinenlesbar zu formulieren.

Typische Nutzung:

- `AGENTS.md` und eine projektspezifische `PROJECT.md` als Pflichtlektuere referenzieren
- anhand des Hauptergebnisses genau einen primaeren Task-Typ bestimmen und die passende `TASK.*.md` laden
- hoechstens einen sekundaeren Task-Typ fuer ein eindeutig abgrenzbares zweites Ergebnis verwenden
- Rollen-, Technologie-, Skill- und Workflow-Dateien nur anhand der Task-Datei und bei konkreter Relevanz einlesen
- projektbezogene und technologiespezifische Developer-Regeln zentral bereitstellen
- andere Repositories auf stabile, direkt aufrufbare Markdown-Dateien verweisen lassen

## Struktur

Die allgemeinen Arbeitsregeln und Task-Dateien liegen direkt unter `docs/`. Rollen, Skills und Workflows liegen in eigenen Unterordnern und werden von den Task-Dateien situationsbezogen referenziert. Ihre Lookup-Dateien dienen als optionale Gesamtindizes.

Aktuell relevante Dateien sind:

| Pfad | URL | Zweck |
|---|---|---|
| `docs/AGENTS.md` | [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Pflichtlektuere, Prioritaeten und Konfliktlogik fuer Agents. |
| `docs/TASK.*.md` | [Task-Auswahl](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Primaerer oder optionaler sekundaerer Kontext fuer Coding, Testing, GitHub, Issue und General. |
| `docs/roles/ROLES.md` | [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Optionaler Gesamtindex fuer Rollen. |
| `docs/roles/developer/DEVELOPER.md` | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Allgemeine technologieuebergreifende Entwicklungsregeln. |
| `docs/roles/developer/DEVELOPER.*.md` | [Developer-Rollen](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Technologiespezifische Entwicklungsregeln. |
| `docs/skills/SKILLS.md` | [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Optionaler Gesamtindex fuer atomare Agenten-Skills. |
| `docs/skills/README.md` | [skills/README.md](https://heljens-it-services.github.io/agent-files/skills/README.md) | Struktur- und Stilvorgaben fuer Skills. |
| `docs/workflows/WORKFLOWS.md` | [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Optionaler Gesamtindex fuer Workflows. |
| `docs/workflows/README.md` | [workflows/README.md](https://heljens-it-services.github.io/agent-files/workflows/README.md) | Struktur- und Stilvorgaben fuer Workflows. |

## Kontextmodell

Der primaere Task-Typ richtet sich nach dem beabsichtigten Hauptergebnis:

| Beispiel | Primaerer Task-Typ | Sekundaerer Task-Typ |
|---|---|---|
| Feature implementieren und gemaess Workflow verifizieren | `Coding` | keiner |
| Bestehende Test-Suite ausfuehren und Ergebnis berichten | `Testing` | keiner |
| Fertigen Aenderungssatz committen und pushen | `GitHub` | keiner |
| GitHub-Issue lesen oder issue-getrieben umsetzen | `Issue` | keiner |
| Dokumentation pflegen oder eine Frage beantworten | `General` | keiner |
| Dokumentation aktualisieren und anschliessend als separaten Auftrag einen Pull Request erstellen | `General` | `GitHub` fuer den Veroeffentlichungs-Scope |

Ein Workflow darf Schritte aus mehreren Bereichen kombinieren, ohne dadurch weitere Task-Typen vorzuladen. Ein sekundaerer Task-Typ ist nur fuer ein eigenstaendiges, klar abgegrenztes zweites Ergebnis vorgesehen.

## Migration veroeffentlichter Pfade

Die frueher direkt unter `docs/` veroeffentlichten Developer- und Skill-Pfade besitzen keine dauerhaften Alias-Dateien. Konsumierende Repositories muessen ihre Links wie folgt aktualisieren:

| Alter Pfad | Neuer Pfad |
|---|---|
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` | `https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md` |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.<TECHNOLOGY>.md` | `https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.<TECHNOLOGY>.md` |
| `https://heljens-it-services.github.io/agent-files/SKILLS.md` | `https://heljens-it-services.github.io/agent-files/skills/SKILLS.md` |

## Pflege

Die Dateien unter `docs/` sind die veroeffentlichten Quelldateien.

Aenderungen an den Agent- und Developer-Anweisungen erfolgen direkt in diesen Markdown-Dateien. Es gibt bewusst keine separate Generierung und keinen zusaetzlichen Sync-Schritt.

Die Regeln verwenden dazu Marker wie `MUST`, `MUST_IF`, `MUST_NOT`, `ALLOW`, `ALLOW_IF`, `SHOULD`, `OPTIONAL` und `PRIORITY`, damit die normative Bedeutung jeder Anweisung moeglichst eindeutig bleibt.

Konsumierende Projekt-Repositories muessen zusaetzlich eine eigene `PROJECT.md` halten. Diese Datei enthaelt mindestens die Versionsbasis des konkreten Projekts und kann fachliche oder technische Leitplanken festhalten, die nur fuer dieses Projekt gelten. Sie ist nicht Teil der allgemeinen veroeffentlichten Referenz unter GitHub Pages, sondern bewusst als projektspezifische Ergaenzung gedacht.

## Verwendung in Projekten

Andere Repositories sollen [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) als globale Pflichtlektuere referenzieren und eine lokale `PROJECT.md` bereitstellen. Der Agent waehlt danach genau einen primaeren Task-Typ aus der Tabelle in `AGENTS.md` und laedt nur dessen Task-Datei sowie den dort situationsbezogen geforderten Zusatzkontext.

Damit ist klar, welche Fassung jeweils veroeffentlicht und referenziert wird.
