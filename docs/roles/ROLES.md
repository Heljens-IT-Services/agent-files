# ROLES.md

## Zweck

Diese Datei definiert das Rollenmodell und ist die Lookup-Datei für kontextabhängige Rollendateien.

## Verwendung

[MUST] Rollen sind unabhängige, kombinierbare Verantwortungs- und Qualitätsregelwerke; sie sind weder exklusive Personas noch Prozessschritte.

[MUST] Alle für den aktuellen Task relevanten Rollen müssen gelesen und angewendet werden.

[MUST_NOT] Rollen dürfen nicht allein wegen ihrer Existenz, einer Persona oder einer festen Workflow- oder Skill-Zuordnung geladen werden.

[MUST_IF] Wird ein weiterer Verantwortungsbereich im Task relevant, muss die zugehörige Rolle nachgeladen werden.

[MUST_IF] Wenn für eine relevante Rolle eine technologiespezifische Regeldatei über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) relevant ist, muss der Agent zusätzlich die allgemeine Regeldatei derselben Rolle lesen.

## Rollenagnostische Leitplanken

[MUST] Regeln für das Rollensystem oder alle Rollen gehören in diese Datei; rollenspezifische Regeln gehören in die passende Rollendatei.

[MUST] Allgemeine Agent-Governance ohne Rollenbezug gehört in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).

[MUST_IF] Rollen eingeführt oder entkoppelt werden, müssen bestehende Regeln auf ihren fachlich allgemeinsten Scope klassifiziert werden.

[MUST_NOT] Regeln dürfen nicht allein wegen ihrer historischen Ablage in einer Rollendatei verbleiben.

## Rollen

| Rolle | Regeldatei | Lesen und verwenden, wenn | Zweck |
|---|---|---|---|
| Designer | [DESIGNER.md](https://heljens-it-services.github.io/agent-files/roles/designer/DESIGNER.md) | Gestalterische Problemklärung, visuelle Exploration, Prototyping, Designentscheidungen oder Design-Reviews relevant sind. | Technologieübergreifende Designregeln. |
| Developer | [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) | Architektur, Implementierung, Refactoring, Code-Review oder technische Planung relevant sind. | Technologieübergreifende Entwicklungsregeln. |
| Planner | [PLANNER.md](https://heljens-it-services.github.io/agent-files/roles/planner/PLANNER.md) | GitHub Issues erstellt, fachlich geplant, strukturiert, zerlegt, typisiert, verknüpft, priorisiert oder auf Abschluss geprüft werden. | Leitplanken für GitHub Issues. |
| Tester | [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) | Teststrategie, Testentwurf, Testerstellung, Testwartung, Regression, Verifikation oder erforderliche Checks relevant sind. | Technologieübergreifende Testregeln. |

## Codex-Laufzeitabbildung

[MUST_IF] Wenn Codex-Custom-Agents verfügbar sind, muss Designer-Verantwortung an `designer`, Planner-Verantwortung an `planner`, Developer-Verantwortung an `developer` und Tester-Verantwortung an `tester` delegiert werden.

[ALLOW_IF] Bei kombinierten Verantwortungen darf der koordinierende Hauptagent die Arbeit sequenziell auf mehrere SubAgents verteilen, sofern jeder Agent nur seinen klar abgegrenzten Verantwortungsbereich übernimmt.

[MUST] Rollen bleiben unabhängige, kombinierbare Verantwortungs- und Qualitätsregelwerke. Die Codex-Zuordnung bildet ihre Ausführung ab und ersetzt oder dupliziert sie nicht.

[MUST] Der aufrufende Agent übergibt Ziel, Scope, Nicht-Scope, relevanten bereits geladenen Kontext, getroffene Entscheidungen, Constraints und erwartetes Ergebnis.

[MUST] Ein SubAgent gibt Ergebnis, Verifikation, Abweichungen, Blocker und den empfohlenen nächsten Verantwortungsbereich kompakt zurück.

[MUST_NOT] Verschiedene SubAgents dürfen nicht unkoordiniert parallel schreibend auf demselben Worktree arbeiten.

[ALLOW_IF] Wenn die Laufzeit keine Codex-Custom-Agents unterstützt, führt der aktuelle Agent dieselben Verantwortungen nach den fachlichen Rollenregeln selbst aus.
