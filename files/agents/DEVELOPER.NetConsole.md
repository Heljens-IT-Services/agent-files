# DEVELOPER.NetConsole.md

Stand: 2026-05-13

## Zweck

Diese Datei definiert .NET-spezifische Entwicklungsregeln fuer Konsolenanwendungen dieses Repositories. Allgemeine Regeln stehen in `DEVELOPER.md`. Sie gilt fuer fachlich relevante Konsolenanwendungen mit Eingabe, Konfiguration, externen Datenquellen, Parsing, Workflows, Berechnungen und strukturierten Exporten.

[PRIORITY] Diese Regeln gelten in ihrem Scope vorrangig vor allgemeineren Regeln aus `DEVELOPER.md`.

## Versionsbasis

[MUST] .NET-Konsolenanwendungen muessen auf `net10.0` zielen.

[MUST] Die Versionen in `global.json`, `.csproj`, `Directory.Build.props` und CI-Konfiguration sind verbindlich.

[MUST] `Nullable` muss aktiviert sein.

[MUST] `ImplicitUsings` muss deaktiviert sein.

[MUST] File-scoped namespaces muessen verwendet werden.

[MUST] Projektweite Namespaces muessen ausschliesslich ueber `GlobalUsings.cs` verwaltet werden.

## Zielbild

[MUST] .NET-Konsolenanwendungen muessen aus genau drei produktiven Projekten innerhalb einer Solution bestehen: `<Name>.Console`, `<Name>.Infrastructure` und `<Name>.Core`.

[ALLOW] Testprojekte duerfen zusaetzlich angelegt werden.

[MUST] Die Referenzrichtung muss `Console -> Infrastructure -> Core` sein.

[MUST] `Core` muss die fachliche Mitte mit Domain, Use Cases, Ports, Services, Ergebnisobjekten und fachlichen Fehlern sein.

[MUST] `Infrastructure` muss technische Details und Ports aus `Core` implementieren.

[MUST] `Console` muss Composition Root fuer Host, Konfiguration, DI sowie Ein- und Ausgabe sein.

## Standardstruktur

[SHOULD] Die Projektstruktur soll Domain-Driven Design auf Solution-Ebene folgen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aufgabe keine Strukturmigration ist.

[MUST] Die drei Hauptprojekte muessen direkt auf oberster Ebene der Solution liegen.

[MUST_NOT] Die drei Hauptprojekte duerfen nicht unterhalb eines `src/`-Ordners liegen.

[MUST] `<Name>.Console/Program.cs` muss Composition Root fuer Host, Konfiguration, Logging und DI sein.

[MUST_NOT] `<Name>.Console/Program.cs` darf keine Fachlogik enthalten.

[ALLOW] `<Name>.Console/appsettings.json` darf Runtime-Konfiguration fuer Provider, Timeouts, Retry, Export und fachliche Settings enthalten.

[MUST_NOT] `<Name>.Console/appsettings.json` darf keine Secrets enthalten.

[MUST] `<Name>.Infrastructure/` muss technische Implementierungen enthalten, `Core` referenzieren und von `Console` referenziert werden.

[MUST] `<Name>.Core/` muss fachliche Modelle, Ports, Use Cases, Workflows und fachliche Regeln enthalten.

[MUST_NOT] `<Name>.Core/` darf `Console` oder `Infrastructure` nicht referenzieren.

## Module.cs und DI

[MUST] Jedes der drei Hauptprojekte muss eine `Module.cs` als zentralen Einstiegspunkt fuer die DI-Registrierung enthalten.

[MUST] Die Methodennamen muessen `AddConsole(...)`, `AddInfrastructure(...)` und `AddCore(...)` lauten.

[ALLOW] `Program.cs` darf wegen transitiver Referenzierung alle drei Module explizit registrieren.

[MUST] Die direkte Projektreferenz muss `Console -> Infrastructure -> Core` bleiben.

## Projekt- und Referenzregeln

[MUST] `Console` muss `Infrastructure` referenzieren.

[MUST] `Infrastructure` muss `Core` referenzieren.

[MUST_NOT] `Core` darf kein produktives Projekt referenzieren.

[MUST] `Console` muss technische Implementierungen ueber DI kennen.

[MUST] Ports muessen in `Core` liegen.

[MUST] Adapter muessen in `Infrastructure` liegen.

[MUST_NOT] `Core` darf keine Konsole, keinen Host, keinen `HttpClient`, keine Options-Bindings und keinen DI-Container als Laufzeitdetail kennen.

## Domain-Driven-Design-Regeln

[MUST] Fachliche Begriffe, Value Objects, Domain Services, Regeln und fachliche Fehler muessen in `Core` liegen.

[MUST] Workflows in `Core` muessen Use Cases ueber Ports orchestrieren.

[MUST_NOT] Workflows duerfen fachliche Regeln nicht in langen Ablaufbloecken verstecken.

[MUST] Exportmodelle muessen als Austauschformate behandelt werden.

[MUST_NOT] Exportmodelle duerfen nicht automatisch als Domainmodelle verwendet werden.

## Console und Bootstrap

[MUST] `Program.cs` muss Generic Host, Konfiguration, Logging und DI aufbauen und genau eine Console Application oder einen Use Case Runner starten.

[MUST] Ein- und Ausgabelogik muss in `Services/` liegen und deterministisch testbar sein.

[MUST] Konsolentexte muessen knapp, fachlich und frei von technischen Interna sein.

## Core-Regeln

[MUST] Use Cases und Workflows muessen klare fachliche Namen haben.

[MUST] Use Cases und Workflows muessen explizite Ergebnis- und Statusobjekte liefern.

[MUST] Lang laufende Operationen muessen `CancellationToken` akzeptieren.

[MUST_NOT] DTOs duerfen keine rohen Transportobjekte externer APIs enthalten.

## Infrastructure, Provider und externe Dienste

[MUST] Externe Dienste muessen ueber Ports aus `Core` angesprochen und in `Infrastructure` implementiert werden.

[MUST] Retry, Timeout, Backoff, Fallback und Konfigurationsbindung muessen in `Infrastructure` liegen.

[MUST] Parser muessen Rohdaten an der Grenze in interne Modelle wandeln und relevante Quelleninformationen erhalten.

## Konfiguration

[MUST] Konfiguration muss in `Console` geladen und in `Infrastructure` typisiert gebunden und validiert werden.

[MUST] Pflichtkonfiguration muss frueh mit klarer Fehlermeldung scheitern.

[MUST_NOT] `Core` darf keine Konfiguration direkt lesen.

[MUST] Fachlich relevante Parameter muessen explizit uebergeben werden.

## Fehler, Logging und Status

[MUST] Fachliche Fehler und Statusmodelle muessen in `Core` liegen.

[MUST] Technische Fehler muessen in `Infrastructure` entstehen und dort mit Kontext angereichert werden.

[MUST] Logs muessen technische Ursachen erklaeren.

[MUST_NOT] Logs duerfen fachliche Statusobjekte nicht ersetzen.

## Code-Regeln

[MUST] File-scoped namespaces und `Nullable` muessen verwendet werden.

[MUST] `ImplicitUsings` muss deaktiviert sein.

[MUST] Namespaces muessen ueber `GlobalUsings.cs` verwaltet werden.

[MUST] Jeder oeffentliche Typ muss in einer eigenen Datei liegen.

[SHOULD] Records sollen fuer immutable DTOs, Value Objects und Ergebnisobjekte verwendet werden. Abweichungen sind erlaubt, wenn Framework-Binding, Serialisierung oder bestehende API-Vertraege Klassen erfordern.

[MUST_NOT] Rohe API-DTOs duerfen nicht in `Core` oder `Console` verwendet werden.

## Unit Tests, Workflow-Tests und Infrastrukturtests

[MUST] Fachliche Regeln und Workflows muessen in `Core.Tests` mit Fake-Ports und kontrollierten Testdaten abgesichert werden.

[MUST] Infrastrukturtests muessen Adapter, Provider, Parser, Retry, Serialisierung, Export und Konfigurationsbindung ohne instabile Live-Dienste pruefen.

[MUST] Konsolentests muessen Eingabe, Ausgabe, Host-Start und DI-Verkabelung deterministisch pruefen.
