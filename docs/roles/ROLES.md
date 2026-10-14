# ROLES.md

## Zweck

Diese Datei definiert die verfügbaren Rollen, ihre Lookup-Pfade und das Rollenmodell. Jede ausführende Rolle besitzt einen eigenen Eintrag mit ihren verfügbaren Skills, Workflows und Technologien.

## Verwendung

[MUST] Der Koordinator ist der Standard-Einstiegspunkt für Nutzeraufträge. Er delegiert Facharbeit ausschließlich an die direkt zuständigen operativen Rollen.

[MUST] Ein Agent arbeitet in genau einer ausdrücklich zugewiesenen Rolle. Ein fachfremder Scope wird an den Koordinator zurückgegeben und dort neu zugewiesen.

[MUST] Rollen sind klare, voneinander abgegrenzte Zuständigkeiten. Ein Task darf Beiträge mehrerer Rollen kombinieren; der Koordinator verteilt diese Beiträge und bündelt Ergebnisse.

[MUST] Nur der Koordinator weist Rollen und neue Aufträge zu. Bei einem gemeinsam zugewiesenen Planungspaket dürfen `product_owner` und `softwareentwicklung_architektur` fachliche Kriterien, technische Constraints und konzeptuelle Auswirkungen direkt austauschen; dadurch entsteht keine neue Rollen- oder Delegationsbefugnis.

[MUST_NOT] Eine Rolle darf nicht allein wegen ihres Vorhandenseins, einer Persona oder einer Skill- oder Workflow-Zuordnung aktiviert werden.

[MUST_IF] Eine benötigte Rolle oder Ausführungsressource nicht verfügbar ist, muss das Hindernis gemeldet werden. Eine andere Rolle oder der Koordinator darf die operative Facharbeit nicht stillschweigend übernehmen.

[MUST] Jede Rolle liest zunächst die globalen Einstiegsdateien und ihre eigene Rollenbeschreibung. Skills, Workflows und Technologien darf sie nur lesen, wenn der eigene Rollenindex sie freigibt und der konkrete Auftrag sie erfordert.

## Rollen

| ID | Rolle | Rollenbeschreibung | Codex-Vorlage | Zuständigkeit |
|---|---|---|---|---|
| `koordinator` | Koordinator | [KOORDINATOR.md](https://heljens-it-services.github.io/agent-files/roles/koordinator/KOORDINATOR.md) | [koordinator.toml](https://heljens-it-services.github.io/agent-files/codex/agents/koordinator.toml) | Nutzerziele aufnehmen, Rollenaufträge verteilen, Ergebnisse bündeln und eskalieren. Keine Facharbeit. |
| `product_manager` | Product Manager | [PRODUCT_MANAGER.md](https://heljens-it-services.github.io/agent-files/roles/product_manager/PRODUCT_MANAGER.md) | [product_manager.toml](https://heljens-it-services.github.io/agent-files/codex/agents/product_manager.toml) | Solution Vision, Produktstrategie, Ziele und messbare Outcomes, Roadmap sowie begründete Featurehypothesen im beauftragten Scope erarbeiten und überprüfen. |
| `product_owner` | Product Owner | [PRODUCT_OWNER.md](https://heljens-it-services.github.io/agent-files/roles/product_owner/PRODUCT_OWNER.md) | [product_owner.toml](https://heljens-it-services.github.io/agent-files/codex/agents/product_owner.toml) | Fachliche Anforderungen, User Stories und User Epics, Backlog-Priorisierung innerhalb freigegebener Strategie, Issue-Scope und fachliche Black-Box-Abnahme verantworten. |
| `softwareentwicklung_architektur` | Softwareentwicklung Architektur | [SOFTWAREENTWICKLUNG_ARCHITEKTUR.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_architektur/SOFTWAREENTWICKLUNG_ARCHITEKTUR.md) | [softwareentwicklung_architektur.toml](https://heljens-it-services.github.io/agent-files/codex/agents/softwareentwicklung_architektur.toml) | Technische Architektur und Abhängigkeiten entwerfen, Technical Stories und Epics samt Kriterien erstellen und deren technische Umsetzung prüfen. |
| `softwareentwicklung_backend` | Softwareentwicklung Backend | [SOFTWAREENTWICKLUNG_BACKEND.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_backend/SOFTWAREENTWICKLUNG_BACKEND.md) | [softwareentwicklung_backend.toml](https://heljens-it-services.github.io/agent-files/codex/agents/softwareentwicklung_backend.toml) | Backend-Services, APIs, Geschäftslogik und Persistenz implementieren. |
| `softwareentwicklung_frontend` | Softwareentwicklung Frontend | [SOFTWAREENTWICKLUNG_FRONTEND.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_frontend/SOFTWAREENTWICKLUNG_FRONTEND.md) | [softwareentwicklung_frontend.toml](https://heljens-it-services.github.io/agent-files/codex/agents/softwareentwicklung_frontend.toml) | Benutzeroberflächen, Interaktionen und clientseitige Funktionen implementieren. |
| `softwareentwicklung_infrastruktur` | Softwareentwicklung Infrastruktur | [SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_infrastruktur/SOFTWAREENTWICKLUNG_INFRASTRUKTUR.md) | [softwareentwicklung_infrastruktur.toml](https://heljens-it-services.github.io/agent-files/codex/agents/softwareentwicklung_infrastruktur.toml) | CI, Deployment, Laufzeit, Infrastruktur und ausdrücklich beauftragte Git-/GitHub-Lifecycle-Schritte bearbeiten. |
| `softwareentwicklung_qualitaetssicherung` | Softwareentwicklung Qualitätssicherung | [SOFTWAREENTWICKLUNG_QUALITAETSSICHERUNG.md](https://heljens-it-services.github.io/agent-files/roles/softwareentwicklung_qualitaetssicherung/SOFTWAREENTWICKLUNG_QUALITAETSSICHERUNG.md) | [softwareentwicklung_qualitaetssicherung.toml](https://heljens-it-services.github.io/agent-files/codex/agents/softwareentwicklung_qualitaetssicherung.toml) | Softwareverhalten unabhängig verifizieren und reproduzierbare Befunde liefern. |
| `designer` | Designer | [DESIGNER.md](https://heljens-it-services.github.io/agent-files/roles/designer/DESIGNER.md) | [designer.toml](https://heljens-it-services.github.io/agent-files/codex/agents/designer.toml) | Nutzungsszenarien, Nutzerabläufe, Informationsstrukturen, Oberflächen, Interaktionen und visuelle Systeme ganzheitlich entwerfen und prüfen. |

## Gemeinsame Fachbasen

Die folgenden bestehenden Regeln enthalten rollenübergreifende Fachstandards. Sie werden von der jeweils zuständigen Spezialrolle direkt gelesen und sind keine zusätzlichen oder spawnbaren Rollen.

| Fachbasis | Anwenden durch | Zweck |
|---|---|---|
| [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Architektur, Backend, Frontend und Infrastruktur | Allgemeine technische Regeln zu Architektur, Umsetzung, Schnittstellen, UI, Fehlerbehandlung und Sicherheit. |
| [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) | Qualitätssicherung, Architektur und Implementierungsrollen bei ausdrücklich freigegebenem `code-testing` | Gemeinsame technische Prüfnormen für lokale Implementierer- und Architekturchecks sowie unabhängige QA-Prüfung; die Anwendung aktiviert keine zusätzliche Rolle. |

Die gemeinsame Fachbasis enthält keine zusätzliche Laufzeit-Delegation. Sie aktiviert weder zusätzliche Rollen noch rekursive Delegation.

[PLANNER.md](https://heljens-it-services.github.io/agent-files/roles/planner/PLANNER.md) ist ein Migrationshinweis zur früheren Rollen-ID `planner`; die aktive Rollenbeschreibung ist [PRODUCT_OWNER.md](https://heljens-it-services.github.io/agent-files/roles/product_owner/PRODUCT_OWNER.md).

## Codex-Laufzeitabbildung

[MUST_IF] Wenn Codex-Custom-Agents verfügbar sind, muss jede Facharbeit direkt an den Custom Agent delegiert werden, dessen `name` exakt der zuständigen Rollen-ID entspricht.

[MUST] Die Codex-Vorlagen bilden nur die jeweilige Laufzeitrolle ab. Kanonische Fachregeln bleiben in den verlinkten Markdown-Dateien.

[MUST] Übergaben enthalten Nutzerziel, Auftrag, Scope, Nicht-Scope, Kontext, Entscheidungen, Constraints, relevante Dateien oder Artefakte sowie erwartetes Ergebnis und erforderliche Belege.

[MUST] Rückgaben enthalten Ergebnis, ausgeführte, ausgelassene oder fehlgeschlagene Verifikation, Abweichungen, Blocker und offene Punkte.

[MUST_NOT] Der Koordinator und andere Rollen dürfen fehlende Agenten oder Ressourcen nicht durch eigene operative Facharbeit ersetzen.

[MUST_NOT] Verschiedene schreibende Agenten dürfen nicht unkoordiniert gleichzeitig auf demselben Worktree arbeiten.

[MUST_IF] Der aktuelle Task eine externe Mutation oder Veröffentlichung enthält, muss die dafür zuständige Rolle innerhalb des ausdrücklich freigegebenen Workflows handeln und den Zustand zurücklesen.
