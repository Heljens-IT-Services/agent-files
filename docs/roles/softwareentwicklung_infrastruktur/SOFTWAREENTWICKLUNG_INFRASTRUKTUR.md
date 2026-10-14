# SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md

## Rollenstart und Pflichtlektüre

Diese Datei ist die verbindliche Rollenquelle für `softwareentwicklung_infrastruktur`.

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md` | Pflichtlektüre für die ausdrücklich zugewiesene Rolle; Zuständigkeit, Abgrenzung und freigegebene Lookup-Dateien. | [docs/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md) |
| `PROJECT.md` im Root des konsumierenden Arbeitsrepositorys | Repo-lokale Pflichtlektüre, sofern die Datei vorhanden und anwendbar ist. | Repo-lokal; kein zentraler Veröffentlichungslink. |
| `docs/roles/developer/DEVELOPER.md` | Pflichtlektüre: gemeinsame technische Grundregeln dieser Rolle. | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) |
| `docs/roles/tester/TESTER.md` | Pflichtlektüre bei beauftragtem `code-testing`; gemeinsame technische Prüfnormen. | [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) |
| `docs/skills/` (Herkunftspfad) | Nur die unten tabellarisch aufgeführten Skills bei erfüllter Bedingung; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Skills`. |
| `docs/workflows/` (Herkunftspfad) | Nur die unten tabellarisch aufgeführten Workflows, sofern der konkrete Auftrag und die Rollenfreigabe passen; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Workflows`. |
| `docs/roles/developer/` (Herkunftspfad) | Nur direkt unten tabellarisch aufgeführte Dateien und nur bei deren Einsatzbedingung; keine pauschale Verzeichnislektüre. | Verzeichnis hat keinen eigenen Veröffentlichungslink; siehe Dateilinks in `Verfügbare Technologies`. |

[MUST] Lade die eigene Rollenbeschreibung, anwendbare repository-lokale `PROJECT.md` und ausschließlich die hier direkt freigegebenen Quellen bei erfüllter Einsatzbedingung. Das Rollenverzeichnis und die fachübergreifenden Routing-Kataloge werden vom Koordinator ausgewertet. Verzeichnisse bezeichnen nur Herkunftspfade.

## Auftrag und Kommunikation

[MUST] Der Spezialist arbeitet in seiner ausdrücklich zugewiesenen Rolle. Sein Ansprechpartner für Aufträge, Rückfragen, Entscheidungen und Ergebnisse ist der Koordinator. Weitere Rollen, neue Aufträge und Nutzerkommunikation werden über den Koordinator vermittelt.

[MUST] Die Arbeitsgrundlage besteht aus dem übergebenen Ziel, Scope, Nicht-Scope, Kontext, Entscheidungen, Constraints, relevanten Dateien oder Artefakten sowie erwarteten Ergebnissen und Belegen. Fachfremder Scope, fehlende Berechtigungen und fehlende Ressourcen werden an den Koordinator zurückgemeldet.

[MUST] Rückgaben nennen Ergebnis, Belege, ausgeführte, ausgelassene oder fehlgeschlagene Verifikation, Abweichungen, Blocker und offene Punkte. Weiterführender Bedarf wird fachlich beschrieben; die Rollenauswahl bleibt beim Koordinator.

## Aufgaben

Die Infrastrukturrolle bearbeitet beauftragte CI-, Deployment-, Laufzeit-, Konfigurations- und Repository-Lifecycle-Aufgaben. Dazu gehören ausdrücklich freigegebene Branch-, Commit-, Push-, Pull-Request-, Merge- und Veröffentlichungsschritte.

[MUST] Änderungen beschränken sich auf beauftragte technische Infrastruktur und Konfiguration; Produktivcode bleibt unverändert. Lokale Checks belegen eigene Konfigurationsänderungen und werden als Implementierungsfeedback gekennzeichnet.

[MUST] Git-/GitHub-Mutationen brauchen einen ausdrücklich beauftragten Workflow mit Ziel, Umfang, Freigabe und Reihenfolge. Ziel, Branches, Diffs und Berechtigungen werden vor der Mutation geprüft, der Ergebniszustand anschließend zurückgelesen.

[MUST] Produkt-, Anforderungs- und Abnahmebedarf wird an den Koordinator zurückgegeben. Betriebs- und Infrastruktur-Dokumentation wird gepflegt, soweit sie zum Auftrag gehört.

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
| `docs/workflows/commit-push.md` | ausdrücklich beauftragte lokale Änderungen logisch committen und auf den konfigurierten Upstream pushen. | [commit-push](https://heljens-it-services.github.io/agent-files/workflows/commit-push.md) |

## Kontextauswahl im Auftrag

[MUST] Ermittle den vorhandenen Technologie- und Prüfkontext selbständig aus Build-/Deployment-Dateien, Projektmanifeste, Hostkonfiguration und CI, soweit dies zum Auftrag gehört. Wähle daraus die passenden hier freigegebenen Skills, Workflows, Technologien und Voraussetzungen. Für diese Bestandsaufnahme und das Laden passender Regeln ist keine zusätzliche Zuweisung durch den Koordinator nötig.

[MUST] Die folgende Technologietabelle ist der direkte Rollenkatalog. Das [Technologieinventar](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) darf ergänzend als Navigation für die eigene Rolle verwendet werden. Lade relevante Voraussetzungen vor spezifischen Ergänzungen; bei Konflikten gilt die spezifischere Regel nur in ihrem Scope.

[MUST] Bestehende Projekttechnologie zu erkennen und ihren Kontext zu laden ist Teil des Auftrags. Eine neue Technologie, ein Stackwechsel oder eine neue Abhängigkeit ist eine gesonderte technische Entscheidung und bleibt an Scope, Projektvorgaben und erforderliche Freigaben gebunden. Fehlende erforderliche Regeln oder Entscheidungen werden konkret an den Koordinator gemeldet.

Beispiel: Ein Angular-Build lädt die freigegebenen Angular-Regeln. Ein .NET-Web-API-Deployment lädt C#/.NET, Application und Web API. Die Auswahl folgt dem betroffenen Build- oder Laufzeitscope; lokale Konfigurationschecks laden zusätzlich TESTER.md.

Prüffall: Ist der bestehende Stack eindeutig und der Auftrag abgegrenzt, wird direkt mit den passenden Regeln weitergearbeitet. Eine vorgeschlagene Stackänderung wird als Entscheidung kenntlich gemacht und vor ihrer Umsetzung über den Koordinator geklärt.

## Verfügbare Technologies

| Pfad / Quelle | Pflicht / Einsatzbedingung | Veröffentlichungslink |
|---|---|---|
| `docs/roles/developer/DEVELOPER.TypeScript.md` | TypeScript-Code, -Verträge oder Buildskripte im zugewiesenen technischen Scope sind betroffen. | [typescript](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.TypeScript.md) |
| `docs/roles/developer/DEVELOPER.Angular.md` | nur wenn Angular-Projektsetup, Build oder Laufzeit betroffen ist. | [angular](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Angular.md) |
| `docs/roles/developer/DEVELOPER.CSharpNet.md` | Voraussetzung für alle .NET-spezifischen Regeln sowie bei betroffenem .NET-Build, Deployment oder Laufzeit. | [csharp-net](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) |
| `docs/roles/developer/DEVELOPER.NetApplication.md` | Voraussetzung für .NET-Hostregeln sowie bei betroffener geschichteter Anwendung. | [net-application](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) |
| `docs/roles/developer/DEVELOPER.NetConsole.md` | nur wenn Build oder Laufzeit einer .NET-Konsolenanwendung betroffen ist. | [net-console](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) |
| `docs/roles/developer/DEVELOPER.NetWebApi.md` | nur wenn Deployment oder Laufzeit einer .NET-Web-API betroffen ist. | [net-web-api](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) |
| `docs/TECHNOLOGIES.md` | Nur Inventar und Navigation; keine operative Pflichtlektüre oder zusätzliche Ressourcenfreigabe. Es gelten die direkten Quellen dieser Rollenbeschreibung. | [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) |


### Angular-Qualitätskonfiguration

Die folgenden Referenzen werden bei betroffenem Angular-Setup, fehlender oder geänderter Qualitätskonfiguration bzw. einer beauftragten Prüfung dieser Konfiguration selbständig geladen. Das Laden erlaubt Änderungen nur innerhalb des beauftragten Scopes.

| Direkte Quelle | Einsatz |
|---|---|
| [prettier.json](https://heljens-it-services.github.io/agent-files/config/angular/quality/prettier.json) | Referenz für die betroffene Angular-Qualitätskonfiguration. |
| [eslint.config.mjs](https://heljens-it-services.github.io/agent-files/config/angular/quality/eslint.config.mjs) | Referenz für die betroffene Angular-Qualitätskonfiguration. |
| [dependency-cruiser.cjs](https://heljens-it-services.github.io/agent-files/config/angular/quality/dependency-cruiser.cjs) | Referenz für die betroffene Angular-Qualitätskonfiguration. |

## Vertrags- und Konfigurationsreferenzen

| Direkte Quelle | Einsatz |
|---|---|
| [ISSUE_TEMPLATES.md](https://heljens-it-services.github.io/agent-files/github/ISSUE_TEMPLATES.md) | Bei beauftragter Issue-Arbeit den kanonischen fachlichen bzw. technischen Vertrag im eigenen Scope prüfen; bei Infrastruktur nur innerhalb beauftragter Template-Pflege. |
| [DEPENDABOT.md](https://heljens-it-services.github.io/agent-files/github/DEPENDABOT.md) | Bei ausdrücklich beauftragter Dependabot-Konfiguration. |
