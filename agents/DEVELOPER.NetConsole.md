# DEVELOPER.NetConsole.md

Stand: 2026-05-01

## Zweck

Diese Datei definiert die .NET-spezifischen Entwicklungsregeln fuer Konsolenanwendungen dieses Repositories. Allgemeine Regeln stehen in `DEVELOPER.md`. Sie gilt fuer fachlich relevante Konsolenanwendungen mit Eingabe, Konfiguration, externen Datenquellen, Parsing, Workflows, Berechnungen und strukturierten Exporten.

## Versionsbasis

.NET-Konsolenanwendungen zielen auf `net10.0`.

Verbindlich sind die Versionen in:

- `global.json`
- `.csproj`
- `Directory.Build.props`
- CI-Konfiguration

`Nullable` ist aktiviert. `ImplicitUsings` ist deaktiviert. File-scoped namespaces sind Standard. Projektweite Namespaces werden ausschliesslich ueber `GlobalUsings.cs` verwaltet.

## Zielbild

.NET-Konsolenanwendungen bestehen aus genau drei produktiven Projekten innerhalb einer Solution. Testprojekte sind zusaetzlich erlaubt:

- `<Name>.Console`
- `<Name>.Infrastructure`
- `<Name>.Core`

Die Referenzrichtung ist verbindlich:

```text
<Name>.Console --> <Name>.Infrastructure --> <Name>.Core
```

`Core` ist die fachliche Mitte mit Domain, Use Cases, Ports, Services, Ergebnisobjekten und fachlichen Fehlern. `Infrastructure` implementiert technische Details und Ports aus `Core`. `Console` ist Composition Root fuer Host, Konfiguration, DI sowie Ein- und Ausgabe.

```mermaid
flowchart TD
    Console[Console] --> Infrastructure[Infrastructure]
    Infrastructure --> Core[Core]
```

## Standardstruktur

Die Projektstruktur folgt Domain-Driven Design auf Solution-Ebene. Die drei Hauptprojekte liegen direkt auf oberster Ebene der Solution, nicht unterhalb eines `src/`-Ordners.

```text
<Name>.sln
<Name>.Console/
  Program.cs
  GlobalUsings.cs
  Module.cs
  appsettings.json
  Services/
<Name>.Infrastructure/
  GlobalUsings.cs
  Module.cs
  Common/
  Configuration/
  <Provider1>/
  <Provider2>/
  <Provider3>/
<Name>.Core/
  GlobalUsings.cs
  Module.cs
  Enums/
  Interfaces/
  Models/
  Services/
  Exceptions/
  Utilities/
tests/
  <Name>.Core.Tests/
  <Name>.Infrastructure.Tests/
  <Name>.Console.Tests/
```

| Pfad | Bereich | Zweck |
|---|---|---|
| `<Name>.sln` | Solution | Enthaelt `Console`, `Infrastructure`, `Core` sowie passende Testprojekte. |
| `<Name>.Console/` | Console | Startbares Projekt. Referenziert `Infrastructure`. |
| `<Name>.Console/Program.cs` | Console | Composition Root fuer Host, Konfiguration, Logging und DI. Keine Fachlogik. |
| `<Name>.Console/GlobalUsings.cs` | Console | Enthaelt alle globalen `using`-Direktiven des Projekts. |
| `<Name>.Console/Module.cs` | Console | Enthaelt `AddConsole(...)` fuer konsolenspezifische DI-Registrierung. |
| `<Name>.Console/appsettings.json` | Console | Runtime-Konfiguration fuer Provider, Timeouts, Retry, Export und fachliche Settings. Keine Secrets. |
| `<Name>.Console/Services/` | Console | Enthaelt Services fuer Ein- und Ausgabe sowie Startlogik. |
| `<Name>.Infrastructure/` | Infrastructure | Technische Implementierungen. Referenziert `Core`, wird von `Console` referenziert. |
| `<Name>.Infrastructure/GlobalUsings.cs` | Infrastructure | Enthaelt alle globalen `using`-Direktiven des Projekts. |
| `<Name>.Infrastructure/Module.cs` | Infrastructure | Enthaelt `AddInfrastructure(...)` fuer technische DI-Registrierung. |
| `<Name>.Infrastructure/Common/` | Infrastructure | Enthaelt provideruebergreifende technische Hilfen und Adapterbausteine. |
| `<Name>.Infrastructure/Configuration/` | Infrastructure | Enthält typisierte Konfiguration und Validierung technischer Settings. |
| `<Name>.Infrastructure/<Provider1>/` | Infrastructure | Enthaelt die Implementierung eines konkreten Providers oder Fremdsystems. |
| `<Name>.Infrastructure/<Provider2>/` | Infrastructure | Enthaelt die Implementierung eines weiteren Providers oder Fremdsystems. |
| `<Name>.Infrastructure/<Provider3>/` | Infrastructure | Enthaelt die Implementierung eines weiteren Providers oder Fremdsystems. |
| `<Name>.Core/` | Core | Fachliche Mitte. Keine Referenz auf `Console` oder `Infrastructure`. |
| `<Name>.Core/GlobalUsings.cs` | Core | Enthaelt alle globalen `using`-Direktiven des Projekts. |
| `<Name>.Core/Module.cs` | Core | Enthaelt `AddCore(...)` fuer fachliche DI-Registrierung. |
| `<Name>.Core/Enums/` | Core | Enthaelt zentrale fachliche Enums. |
| `<Name>.Core/Interfaces/` | Core | Enthaelt Ports, Vertraege und fachliche Schnittstellen. |
| `<Name>.Core/Models/` | Core | Enthaelt fachliche Modelle, DTOs, Value Objects und Ergebnisobjekte. |
| `<Name>.Core/Services/` | Core | Enthaelt fachliche Services, Use Cases und Workflows. |
| `<Name>.Core/Exceptions/` | Core | Enthaelt fachlich erwartbare Fehler. |
| `<Name>.Core/Utilities/` | Core | Enthaelt fachlich neutrale Hilfen im Core-Projekt. |
| `tests/<Name>.Core.Tests/` | Tests | Tests fuer Domain, Use Cases, Workflows, Ports und fachliche Regeln. |
| `tests/<Name>.Infrastructure.Tests/` | Tests | Tests fuer Adapter, Provider, Parser, Retry, Serialisierung, Export und Konfigurationsbindung. |
| `tests/<Name>.Console.Tests/` | Tests | Tests fuer Konsoleneingabe, Ausgabeformatierung, Host-Start und DI-Verkabelung. |

## Module.cs und DI

Jedes der drei Hauptprojekte enthaelt eine `Module.cs` als zentralen Einstiegspunkt fuer die DI-Registrierung.

```csharp
public static class Module
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
```

Die Methodennamen sind verbindlich:

- `<Name>.Console/Module.cs`: `AddConsole(...)`
- `<Name>.Infrastructure/Module.cs`: `AddInfrastructure(...)`
- `<Name>.Core/Module.cs`: `AddCore(...)`

`Program.cs` darf wegen transitiver Referenzierung alle drei Module explizit registrieren. Die direkte Projektreferenz bleibt `Console -> Infrastructure -> Core`.

## Projekt- und Referenzregeln

- `Console` referenziert `Infrastructure`; `Infrastructure` referenziert `Core`; `Core` referenziert kein produktives Projekt.
- `Console` kennt technische Implementierungen nur ueber DI; Ports liegen in `Core`, Adapter in `Infrastructure`.
- `Core` kennt keine Konsole, keinen Host, keinen `HttpClient`, keine Options-Bindings und keinen DI-Container als Laufzeitdetail.

## Domain-Driven-Design-Regeln

- Fachliche Begriffe, Value Objects, Domain Services, Regeln und fachliche Fehler liegen in `Core`.
- Workflows in `Core` orchestrieren Use Cases ueber Ports, verstecken aber keine fachlichen Regeln in langen Ablaufbloecken.
- Exportmodelle sind Austauschformate und nicht automatisch Domainmodelle.

## Console und Bootstrap

- `Program.cs` baut Generic Host, Konfiguration, Logging und DI auf und startet genau eine Console Application oder einen Use Case Runner.
- Ein- und Ausgabelogik liegt in `Services/` und ist deterministisch testbar.
- Konsolentexte sind knapp, fachlich und frei von technischen Interna.

## Core-Regeln

- Use Cases und Workflows haben klare fachliche Namen und liefern explizite Ergebnis- und Statusobjekte.
- Lang laufende Operationen akzeptieren `CancellationToken`.
- DTOs enthalten keine rohen Transportobjekte externer APIs.

## Infrastructure, Provider und externe Dienste

- Externe Dienste werden ueber Ports aus `Core` angesprochen und in `Infrastructure` implementiert.
- Retry, Timeout, Backoff, Fallback und Konfigurationsbindung liegen in `Infrastructure`.
- Parser wandeln Rohdaten an der Grenze in interne Modelle und erhalten relevante Quelleninformationen.

## Konfiguration

- Konfiguration wird in `Console` geladen und in `Infrastructure` typisiert gebunden und validiert.
- Pflichtkonfiguration scheitert frueh mit klarer Fehlermeldung.
- `Core` liest keine Konfiguration direkt; fachlich relevante Parameter werden explizit uebergeben.

## Fehler, Logging und Status

- Fachliche Fehler und Statusmodelle liegen in `Core`; technische Fehler entstehen in `Infrastructure` und werden dort mit Kontext angereichert.
- Logs erklaeren technische Ursachen, ersetzen aber keine fachlichen Statusobjekte.

## Code-Regeln

- File-scoped namespaces und `Nullable` sind Standard. `ImplicitUsings` ist deaktiviert. Namespaces werden ueber `GlobalUsings.cs` verwaltet.
- Jeder oeffentliche Typ liegt in einer eigenen Datei; Records sind fuer immutable DTOs, Value Objects und Ergebnisobjekte bevorzugt.
- Keine rohen API-DTOs in `Core` oder `Console`.

## Unit Tests, Workflow-Tests und Infrastrukturtests

- Fachliche Regeln und Workflows werden in `Core.Tests` mit Fake-Ports und kontrollierten Testdaten abgesichert.
- Infrastrukturtests pruefen Adapter, Provider, Parser, Retry, Serialisierung, Export und Konfigurationsbindung ohne instabile Live-Dienste.
- Konsolentests pruefen Eingabe, Ausgabe, Host-Start und DI-Verkabelung deterministisch.
