# DEVELOPER.TypeScript.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert TypeScript-spezifische Entwicklungsregeln. Allgemeine Regeln stehen in [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md). Framework- oder technologiespezifische Regeln stehen in passenderen [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.*.md)-Dateien.

## Qualitaet und Code

[MUST] TypeScript `strict` muss aktiviert bleiben.

[ALLOW_IF] `any` darf nur an technischen Grenzen mit begruendeter Kapselung verwendet werden.

[MUST] TypeScript-Modelle, DTOs und Objektvertraege muessen standardmaessig als `type` definiert werden.

[MUST_NOT] TypeScript-Modelle, DTOs und Objektvertraege duerfen nicht ohne technischen Grund als `interface` definiert werden.

[MUST] Die `type`-Konvention muss ueber `@typescript-eslint/consistent-type-definitions` erzwungen werden.

[ALLOW_IF] Abweichungen von der `type`-Konvention sind erlaubt, wenn ein technischer Grund vorliegt und das aktive Lint-Regelwerk die Abweichung erlaubt.
