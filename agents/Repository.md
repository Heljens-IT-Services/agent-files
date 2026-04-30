# Repository.md

Diese Datei enthält die projektspezifischen Regeln, Fakten und Arbeitskommandos dieses Repositories. Sie ergänzt `AGENTS.md`, `agents/Architecture.md` und die passenden `agents/Architecture.*.md`-Dateien.

## Kopierhinweis

Diese Datei ist nach dem Kopieren vollständig projektspezifisch auszufüllen. Nicht ersetzte Platzhalter in spitzen Klammern gelten als offene Aufgabe und dürfen bei strukturellen Code-Änderungen nicht ignoriert werden.

Vor der ersten größeren Änderung müssen mindestens ausgefüllt sein:

- Projektüberblick
- Wichtigste Regeln
- Wichtige Pfade
- Build, Tests und lokaler Start
- Technologieentscheidungen
- Test-Regeln

## Projektüberblick

- Name: `<Projektname>`
- Typ: `<Angular | .NET Console | anderes>`
- Primäre Architekturdatei: `<agents/Architecture.Angular.md | agents/Architecture.NETConsole.md | ...>`
- Kurzbeschreibung: `<Was macht das Projekt fachlich?>`
- Hauptnutzer oder Zielsysteme: `<Wer nutzt das System?>`
- Kritische Qualitätsmerkmale: `<z. B. Korrektheit, Performance, Offline-Fähigkeit, Datenschutz, Stabilität>`

## Wichtigste Regeln

- `<Die wichtigste fachliche Regel dieses Repositories>`
- `<Die wichtigste technische Grenze, die nicht verletzt werden darf>`
- `<Der wichtigste Qualitäts- oder Testanspruch>`

## Wichtige Pfade

| Pfad | Zweck |
|---|---|
| `<Pfad>` | `<Zweck>` |
| `<Pfad>` | `<Zweck>` |
| `<Pfad>` | `<Zweck>` |

## Build, Tests und lokaler Start

| Aufgabe | Kommando |
|---|---|
| Installation | `<Kommando>` |
| Build | `<Kommando>` |
| Unit Tests | `<Kommando>` |
| Integration/E2E Tests | `<Kommando oder nicht zutreffend>` |
| Lokaler Start | `<Kommando>` |
| Format/Lint | `<Kommando oder nicht zutreffend>` |

## Technologieentscheidungen

- Runtime/Framework: `<Version und Begründung>`
- UI/State/Test/DI/Persistenz: `<wichtige Libraries und lokale Standards>`
- Externe Dienste: `<APIs, Datenbanken, Message Broker, Dateien>`
- Deployment/Betrieb: `<Hosting, Container, Scheduler, CI/CD>`
- Nicht verwenden: `<bewusst ausgeschlossene Libraries, Patterns oder Versionen>`

## Nicht-Ziele

- `<Was dieses Projekt bewusst nicht lösen soll>`
- `<Welche Integrationen, Plattformen oder Betriebsarten ausgeschlossen sind>`
- `<Welche Qualitätsmerkmale nicht priorisiert werden>`

## Architekturgrenzen

- Presentation: `<lokale Regel für UI, Console oder API-Schicht>`
- Application: `<lokale Regel für Use Cases, Workflows, Commands, Queries>`
- Domain: `<lokale Regel für Fachmodelle und Invarianten>`
- Infrastructure: `<lokale Regel für HTTP, Datenbank, Dateien, externe Systeme>`
- Cross-cutting: `<lokale Regel für Logging, Auth, Konfiguration, Telemetrie>`

## Fachliche Leitplanken

- `<Fachregel 1>`
- `<Fachregel 2>`
- `<Fachregel 3>`

## Daten, Schnittstellen und Verträge

- Öffentliche APIs: `<Pfad/Link/Beschreibung>`
- Exportformate: `<Pfad/Schema/Beschreibung>`
- Importformate: `<Pfad/Schema/Beschreibung>`
- Datenbankschema oder Migrationen: `<Pfad/Beschreibung>`
- Konfigurationsschema: `<Pfad/Beschreibung>`
- Rückwärtskompatibilität: `<Welche Verträge stabil bleiben müssen>`

## Fehler, Logging und Betrieb

- Erwartbare Fachfehler: `<Wie werden sie modelliert?>`
- Technische Fehler: `<Wie werden sie geloggt und gemeldet?>`
- Retry/Timeout/Fallback: `<Lokale Regeln>`
- Observability: `<Logs, Metriken, Traces, Korrelation>`
- Datenschutz/Security: `<Was darf nicht geloggt oder gespeichert werden?>`

## Test-Regeln

- Kritische Fachregeln werden in `<Testprojekt/Pfad>` abgesichert.
- Externe Dienste werden in normalen Unit Tests gefaked.
- Live-Tests werden separat markiert und dürfen Standard-CI-Läufe nicht destabilisieren.
- Bei Änderungen an Schnittstellen, Exporten oder Persistenz werden passende Vertrags-/Schema-Tests aktualisiert.
- Testdaten liegen unter `<Pfad>` und enthalten keine echten vertraulichen oder personenbezogenen Daten.

## Dokumentationspflege

- `agents/Repository.md` wird aktualisiert, wenn sich Projektziel, wichtige Pfade, Build-/Test-Kommandos, fachliche Leitplanken oder externe Verträge ändern.
- `agents/Architecture.md` und `agents/Architecture.*.md` werden nur angepasst, wenn eine Regel dauerhaft und technologie- bzw. repositoryübergreifend gelten soll.
- `STRUCTURE.md` oder lokale Struktur-Dokumentation wird gepflegt, wenn das Repository so eine Datei verwendet.
- Architekturentscheidungen mit langfristiger Wirkung werden unter `<ADR-Pfad oder Dokumentationsort>` festgehalten.
