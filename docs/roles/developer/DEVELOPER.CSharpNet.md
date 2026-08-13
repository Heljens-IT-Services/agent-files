# DEVELOPER.CSharpNet.md

Stand: 2026-07-22

## Zweck

Diese Datei gilt für C#- und .NET-Projekte aller Einstiegstypen. Anwendungs- und hostspezifische Regeldateien werden über [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgelöst.

## Sprach- und Coderichtlinien

[MUST] File-scoped namespaces müssen verwendet werden.

[MUST] Alle Namespaces müssen ausschließlich über `GlobalUsings.cs` verwaltet werden.

[MUST] Jeder öffentliche Typ muss in einer eigenen Datei liegen.

[SHOULD] Records sollen für immutable DTOs, Value Objects und Ergebnisobjekte verwendet werden. Abweichungen sind erlaubt, wenn Framework-Binding, Serialisierung oder bestehende API-Verträge Klassen erfordern.

## Module.cs und DI

[MUST] Produktive .NET-Projekte mit eigener DI-Registrierung müssen eine `Module.cs` als zentralen Einstiegspunkt für diese Registrierungen verwenden.

[MUST] Wiederverwendbare Schichten oder Projekte mit eigener Registrierungsverantwortung müssen ihre DI-Registrierung über klar benannte Erweiterungsmethoden kapseln.

[MUST] Der Methodenname einer DI-Erweiterungsmethode muss zur Projektrolle passen, zum Beispiel `AddCore(...)`, `AddInfrastructure(...)`, `AddConsole(...)`, `AddWebApi(...)` oder `AddWorker(...)`.

[ALLOW] `Program.cs` oder ein anderer Composition Root darf Module wegen transitiver Referenzierung explizit registrieren.

[MUST] Direkte Projektreferenzen müssen die vorgesehenen Architekturgrenzen respektieren und dürfen nicht allein für bequeme DI-Registrierung aufgeweicht werden.
