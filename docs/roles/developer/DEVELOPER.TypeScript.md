# DEVELOPER.TypeScript.md

Stand: 2026-07-22

## Zweck

Diese Datei gilt fuer TypeScript. Zugehoerige allgemeine und technologiespezifische Regeldateien werden ueber [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgeloest.

## Qualitaet und Code

[MUST] TypeScript `strict` muss aktiviert bleiben.

[ALLOW_IF] `any` darf nur an technischen Grenzen mit begruendeter Kapselung verwendet werden.

[MUST] TypeScript-Modelle, DTOs und Objektvertraege muessen als `type` definiert werden, ausser ein technischer Grund liegt vor und das aktive Lint-Regelwerk erlaubt ein `interface`.

[MUST] Die `type`-Konvention muss ueber `@typescript-eslint/consistent-type-definitions` erzwungen werden.
