# SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md

## Rollenstart und Pflichtlektüre

Diese Datei ist die verbindliche Rollenquelle für `softwareentwicklung_infrastruktur`.

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md` | Pflichtlektüre für die ausdrücklich zugewiesene Rolle; Zuständigkeit, Abgrenzung und freigegebene Lookup-Dateien. | [docs/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md) |
| `docs/AGENTS.md` | Nur Einstiegspunkt; keine Rollen-Pflichtlektüre. | [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) |
| `docs/roles/ROLES.md` | Kein Pflicht-Lookup für operative Spezialisten; der Koordinator nutzt den Index ausschließlich für Routing-Metadaten. | [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) |
| `PROJECT.md` im Root des konsumierenden Arbeitsrepositorys | Repo-lokale Pflichtlektüre, sofern die Datei vorhanden und anwendbar ist. | Repo-lokal; kein zentraler Veröffentlichungslink. |
| `docs/roles/developer/DEVELOPER.md` | Pflichtlektüre: gemeinsame technische Grundregeln dieser Rolle. | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) |
| `docs/roles/tester/TESTER.md` | Pflichtlektüre bei beauftragtem `code-testing`; gemeinsame technische Prüfnormen. | [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) |
| `docs/skills/` (Herkunftspfad) | Nur die unten tabellarisch aufgeführten Skills bei erfüllter Bedingung; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Skills`. |
| `docs/workflows/` (Herkunftspfad) | Nur die unten tabellarisch aufgeführten Workflows, sofern der konkrete Auftrag und die Rollenfreigabe passen; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Workflows`. |
| `docs/roles/developer/` (Herkunftspfad) | Nur direkt unten tabellarisch aufgeführte Dateien und nur bei deren Einsatzbedingung; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Technologies`. |

Verzeichnisse sind Herkunftspfade, keine pauschale Lesefreigabe. Maßgeblich sind nur die in den folgenden Tabellen direkt aufgeführten Dateien bei erfüllter Einsatzbedingung.

## Beschreibung

[MUST] Infrastruktur bearbeitet keine Produktivcode-Änderungen; technische Konfigurationsänderungen darf sie im zugewiesenen Scope lokal mit `code-testing` verifizieren.

Bearbeitet ausdrücklich beauftragte Infrastruktur-, CI-, Deployment-, Laufzeit- und Repository-Lifecycle-Themen. Dazu gehören im freigegebenen Scope Git- und GitHub-Schritte wie Branch, Commit, Push, Pull Request, Merge und Veröffentlichung.

[MUST] Git-/GitHub-Mutationen müssen durch den aufrufenden Workflow ausdrücklich beauftragt und eingegrenzt sein. Prüfe Ziel, Branches, Diffs, Freigaben und Ergebniszustand vor und nach einer Mutation.

[MUST] Arbeite nur an beauftragter technischer Infrastruktur; Produktlogik, Anforderungen und unabhängige Abnahme gehören zu den jeweils zuständigen Rollen.

[MUST] Pflege die passende Infrastruktur- und Betriebsdokumentation, wenn der Auftrag sie erfordert.

Allgemeine technische Fachbasis: [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md). Diese Basis ist nicht als zusätzlicher Agent delegierbar und aktiviert keine weitere Rolle. Bei `code-testing` gelten ergänzend die gemeinsamen Teststandards [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md), ohne eine QA-Rolle zu aktivieren.

## Verfügbare Skills

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/skills/code-testing.md` | lokale technische Verifikation eigener Änderungen. | [code-testing](https://heljens-it-services.github.io/agent-files/skills/code-testing.md) |
| `docs/skills/code-analysis.md` | Infrastruktur, CI und Laufzeit analysieren. | [code-analysis](https://heljens-it-services.github.io/agent-files/skills/code-analysis.md) |
| `docs/skills/code-reading.md` | relevante Konfigurationen und Betriebsgrenzen lesen. | [code-reading](https://heljens-it-services.github.io/agent-files/skills/code-reading.md) |
| `docs/skills/code-implementation.md` | beauftragte CI-, Deployment- oder Laufzeitkonfiguration anpassen. | [code-implementation](https://heljens-it-services.github.io/agent-files/skills/code-implementation.md) |
| `docs/skills/documentation.md` | Infrastruktur- und Betriebsentscheidungen dokumentieren. | [documentation](https://heljens-it-services.github.io/agent-files/skills/documentation.md) |
| `docs/skills/github_branch-checkout-from-default.md` | Arbeitsbranch anlegen oder bestätigen. | [github-branch-checkout-from-default](https://heljens-it-services.github.io/agent-files/skills/github_branch-checkout-from-default.md) |
| `docs/skills/github_commit.md` | ausdrücklich beauftragte lokale Commits erstellen. | [github-commit](https://heljens-it-services.github.io/agent-files/skills/github_commit.md) |
| `docs/skills/github_commit-history-reading.md` | Commit- und Merge-Historie lesen. | [commit-history-reading](https://heljens-it-services.github.io/agent-files/skills/github_commit-history-reading.md) |
| `docs/skills/github_default-branch-update.md` | Standardbranch nach freigegebenem Merge aktualisieren. | [default-branch-update](https://heljens-it-services.github.io/agent-files/skills/github_default-branch-update.md) |
| `docs/skills/github_integration-branch-update.md` | Integrationsbranch nach freigegebenem Merge aktualisieren. | [integration-branch-update](https://heljens-it-services.github.io/agent-files/skills/github_integration-branch-update.md) |
| `docs/skills/github_push.md` | ausdrücklich beauftragte Commits pushen. | [github-push](https://heljens-it-services.github.io/agent-files/skills/github_push.md) |
| `docs/skills/github_repository-baseline-configuration.md` | Repository-Basiskonfiguration prüfen oder im beauftragten Scope ergänzen. | [repository-baseline-configuration](https://heljens-it-services.github.io/agent-files/skills/github_repository-baseline-configuration.md) |
| `docs/skills/github_pr-creation.md` | freigegebenen Pull Request erstellen oder wiederverwenden. | [pr-creation](https://heljens-it-services.github.io/agent-files/skills/github_pr-creation.md) |
| `docs/skills/github_pr-merge.md` | freigegebenen Pull Request nach erfüllten Gates mergen. | [github-pr-merge](https://heljens-it-services.github.io/agent-files/skills/github_pr-merge.md) |
| `docs/skills/github_pr-checks-observation.md` | erforderliche Laufzeit-Checks beobachten. | [pr-checks-observation](https://heljens-it-services.github.io/agent-files/skills/github_pr-checks-observation.md) |

## Verfügbare Workflows

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/workflows/specialist-implementation.md` | beauftragte Infrastrukturänderungen ausführen. | [specialist-implementation](https://heljens-it-services.github.io/agent-files/workflows/specialist-implementation.md) |

## Verfügbare Technologies

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/roles/developer/DEVELOPER.Angular.md` | nur wenn Angular-Projektsetup, Build oder Laufzeit betroffen ist. | [angular](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) |
| `docs/roles/developer/DEVELOPER.CSharpNet.md` | Voraussetzung für alle .NET-spezifischen Regeln sowie bei betroffenem .NET-Build, Deployment oder Laufzeit. | [csharp-net](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) |
| `docs/roles/developer/DEVELOPER.NetApplication.md` | Voraussetzung für .NET-Hostregeln sowie bei betroffener geschichteter Anwendung. | [net-application](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) |
| `docs/roles/developer/DEVELOPER.NetConsole.md` | nur wenn Build oder Laufzeit einer .NET-Konsolenanwendung betroffen ist. | [net-console](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) |
| `docs/roles/developer/DEVELOPER.NetWebApi.md` | nur wenn Deployment oder Laufzeit einer .NET-Web-API betroffen ist. | [net-web-api](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) |
| `docs/TECHNOLOGIES.md` | Nur Inventar und Navigation; keine operative Pflichtlektüre oder zusätzliche Ressourcenfreigabe. Die Zuordnungen aktivieren keine weitere Rolle. | [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) |
