# DEVELOPER.NetConsole.md

Stand: 2026-07-22

## Zweck

Diese Datei gilt fuer .NET-Konsolenanwendungen. Zugehoerige allgemeine und anwendungsbezogene Regeldateien werden ueber [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgeloest.

## Zielbild

[MUST] Eine .NET-Konsolenanwendung muss mindestens ein Entry-Projekt fuer die Konsole sowie `<Name>.Infrastructure` und `<Name>.Core` enthalten.

[ALLOW_IF] Mehrere Entry-Projekte duerfen angelegt werden, wenn sie getrennte Use-Case- oder Streckenverantwortungen haben.

[MUST] Jedes Entry-Projekt muss genau einen Use Case Runner oder eine Console Application starten.

## Module und Bootstrap

[MUST] Die DI-Erweiterungsmethoden muessen `AddConsole(...)`, `AddInfrastructure(...)` und `AddCore(...)` heissen.

[MUST] `Program.cs` muss Generic Host, Konfiguration, Logging und Dependency Injection aufbauen.

[MUST] Ein- und Ausgabelogik muss ausserhalb von `Program.cs` liegen und deterministisch testbar sein.

[MUST] Konsolentexte muessen fachlich formuliert sein und duerfen keine technischen Interna offenlegen.

## Konsolenspezifische Grenzen

[MUST] Exportmodelle muessen als Austauschformate behandelt und an der Systemgrenze gemappt werden.

[MUST_NOT] Rohe API-DTOs duerfen nicht in `Core` oder Entry-Projekten verwendet werden.

## Tests

[MUST] Konsolentests muessen Eingabe, Ausgabe, Host-Start und DI-Verkabelung deterministisch pruefen.

[MUST] Infrastrukturtests muessen zusaetzlich relevante Parser- und Exportpfade abdecken.
