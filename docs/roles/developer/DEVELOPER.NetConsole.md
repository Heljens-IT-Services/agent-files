# DEVELOPER.NetConsole.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert hostspezifische Regeln fuer .NET-Konsolenanwendungen. Gemeinsame Regeln stehen in [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) und [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md).

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
