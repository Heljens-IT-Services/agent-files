# DEVELOPER.CSharpNet.md

Stand: 2026-05-15

## Zweck

Diese Datei definiert allgemeine C#- und .NET-Entwicklungsregeln. Sie gilt fuer .NET-Projekte unabhaengig vom konkreten Einstiegstyp wie Worker, Console, WebApi, Bibliothek oder Testprojekt. Anwendungs- oder hostspezifische Regeln stehen in passenderen [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.*.md)-Dateien.

[PRIORITY] Diese Regeln gelten fuer .NET- und C#-Code, sofern keine passendere projektspezifische oder anwendungstypspezifische Regel innerhalb ihres ausdruecklichen Scopes eine engere Vorgabe macht.

## Sprach- und Coderichtlinien

[MUST] File-scoped namespaces muessen verwendet werden.

[MUST] Projektweite Namespaces muessen ausschliesslich ueber `GlobalUsings.cs` verwaltet werden.

[MUST] Jeder oeffentliche Typ muss in einer eigenen Datei liegen.

[SHOULD] Records sollen fuer immutable DTOs, Value Objects und Ergebnisobjekte verwendet werden. Abweichungen sind erlaubt, wenn Framework-Binding, Serialisierung oder bestehende API-Vertraege Klassen erfordern.

## Module.cs und DI

[MUST] Produktive .NET-Projekte mit eigener DI-Registrierung muessen eine `Module.cs` als zentralen Einstiegspunkt fuer diese Registrierungen verwenden.

[MUST] Wiederverwendbare Schichten oder Projekte mit eigener Registrierungsverantwortung muessen ihre DI-Registrierung ueber klar benannte Erweiterungsmethoden kapseln.

[MUST_IF] Der Methodenname einer DI-Erweiterungsmethode muss zur Projektrolle passen, zum Beispiel `AddCore(...)`, `AddInfrastructure(...)`, `AddConsole(...)`, `AddWebApi(...)` oder `AddWorker(...)`.

[ALLOW] `Program.cs` oder ein anderer Composition Root darf Module wegen transitiver Referenzierung explizit registrieren.

[MUST] Direkte Projektreferenzen muessen die vorgesehenen Architekturgrenzen respektieren und duerfen nicht allein fuer bequeme DI-Registrierung aufgeweicht werden.
