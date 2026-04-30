# Architecture.NETConsole.md

Stand: 2026-04-30

## Versionsbasis

Diese Datei enthält eine Momentaufnahme der empfohlenen Plattformversionen. Die Angaben müssen beim Einsatz in einem Repository und vor jedem Major Upgrade gegen die offiziellen Release- und Kompatibilitätsseiten geprüft werden.

.NET-Konsolenanwendungen zielen auf `net10.0`, sofern `Repository.md` nichts anderes festlegt. .NET 10 ist laut Microsoft aktuell Long Term Support und bis November 2028 unterstützt. .NET 9 ist STS bis November 2026, .NET 8 LTS bis November 2026.

Vor Scaffold, Major Upgrade oder Runtime-Wechsel werden `https://learn.microsoft.com/en-us/dotnet/core/releases-and-support` und die Microsoft Lifecycle-Seite geprüft.

Repository-spezifisch verbindlich sind die Versionen in:

- `global.json`
- `.csproj`
- `Directory.Build.props`
- CI-Konfiguration
- Container-/Deployment-Dateien
- `Repository.md`

## Zielbild

Eine Konsolenanwendung ist keine Sammlung statischer Skripte. Sie hat einen klaren Composition Root, typisierte Konfiguration, Dependency Injection, Logging, testbare Use Cases und getrennte Adapter für Console-I/O, HTTP, Dateisystem und externe Dienste.

## Skalierung der Architektur

Für sehr kleine Konsolenprogramme dürfen Ordner zusammenfallen, solange die Grenzen klar bleiben.

Sobald HTTP, Dateisystem, komplexes Parsing, mehrere Commands, Konfiguration oder fachliche Regeln hinzukommen, werden Application, Domain, Infrastructure und ConsoleUi getrennt.

## Standardstruktur

```text
<Project>/
  Program.cs
  Application/
  Domain/
  Infrastructure/
  ConsoleUi/
  Configuration/
  DependencyInjection/
  Exceptions/
<Project>.Tests/
```

- `Program.cs` ist der Composition Root und enthält nur Bootstrap, Konfiguration, DI und Exit-Code-Behandlung.
- `Application/` enthält Workflows, Use Cases, Commands, Queries und Orchestrierung.
- `Domain/` enthält fachliche Modelle, Value Objects, reine Regeln und Domain-Services.
- `Infrastructure/` enthält HTTP-Clients, Dateisystem, externe APIs, Parser, Persistenz und technische Adapter.
- `ConsoleUi/` enthält Eingabe, Ausgabe, Prompting, Tabellen, Fortschritt und Formatierung.
- `Configuration/` enthält typisierte Optionsklassen und Validierung.
- `DependencyInjection/` enthält Registrierungs-Extensions für Services, Options und typed HttpClients.
- `Exceptions/` enthält fachlich oder technisch relevante Exception-Typen, wenn Exceptions Teil des Vertrags sind.

## Bootstrap und Host

- Anwendungen verwenden `Host.CreateApplicationBuilder(args)` oder ein äquivalentes Generic-Host-Setup.
- `Program.cs` registriert Services und startet genau einen Application-Service, zum Beispiel `ConsoleApplication` oder `IApplicationRunner`.
- `Main` ist async und gibt kontrollierte Exit Codes zurück.
- `CancellationToken` wird von `Console.CancelKeyPress` oder Host-Lifetime bis in Workflows und I/O-Adapter weitergereicht.
- Startup-Validierung prüft Pflichtkonfiguration früh und bricht mit verständlicher Fehlermeldung ab.
- `Program.cs` enthält keine Fachlogik, keine HTTP-Aufrufe, kein Parsing und keine direkte Dateiverarbeitung.

## SOLID und Clean Code

- Single Responsibility: Eine Klasse hat einen Grund, sich zu ändern. Parsing, Abruf, Matching, Formatierung und Export sind getrennte Verantwortlichkeiten.
- Open/Closed: Neue Datenquellen, Exportformate oder Strategien werden über Interfaces/Strategien erweiterbar gemacht, nicht über wachsende `switch`-Blöcke im Workflow.
- Liskov Substitution: Implementierungen eines Interfaces halten dieselben Fehler-, Null- und Ergebnisverträge ein.
- Interface Segregation: Kleine, fachlich benannte Interfaces statt großer Service-Sammelinterfaces.
- Dependency Inversion: Anwendungsschicht hängt von Abstraktionen ab; Infrastruktur implementiert sie.
- Methoden bleiben kurz genug, dass Kontrollfluss und fachliche Absicht ohne mentale Simulation erkennbar sind.
- Records und Value Objects werden genutzt, wenn Daten immutable und fachlich zusammengehörig sind.
- Primitive Werte mit fachlichen Regeln werden nicht überall als `string`, `int` oder `double` herumgereicht.

## Dependency Injection

- Constructor Injection ist Standard.
- Kein Service Locator, keine statischen Zugriffspunkte für fachliche Services.
- Lifetimes werden bewusst gewählt: stateless Services meist Singleton oder Scoped nach Host-Modell, zustandsbehaftete Services vorsichtig transient/scoped, HTTP über `IHttpClientFactory`.
- Options werden mit `IOptions<T>`, `IOptionsMonitor<T>` oder validierten Optionsklassen genutzt.
- Externe Clients werden als typed clients oder klar benannte Adapter registriert.
- DI-Registrierung wird in Tests validiert, wenn sie komplexer als wenige Services ist.
- Interfaces werden dort eingeführt, wo Austauschbarkeit, Testbarkeit oder Schichtgrenzen davon profitieren.

## Konfiguration

- `appsettings.json`, `appsettings.Development.json`, Umgebungsvariablen und User Secrets werden klar getrennt.
- Secrets, Tokens und persönliche Pfade werden nicht versioniert.
- Optionsklassen enthalten keine Fachlogik außer einfacher Normalisierung oder Validierung.
- Fehlende Pflichtkonfiguration führt beim Start zu einer klaren Fehlermeldung.
- Konfigurationswerte haben sprechende Namen, Einheiten und Defaults.
- Feature Flags werden benannt, dokumentiert und entfernt, wenn sie nicht mehr gebraucht werden.

## Console UI

- Console-I/O ist ein Adapter und wird von Fachlogik getrennt.
- Prompts, Tabellen, Fortschritt und Fehlerausgaben werden zentral formatiert.
- Interaktive Eingaben werden validiert und in fachliche Modelle übersetzt.
- Automatisierbare Ausgaben verwenden stabile Formate und klare Exit Codes.
- Fehlerausgaben unterscheiden zwischen Nutzerfehlern, fachlichen Nichttreffern und technischen Störungen.

## Fehlerbehandlung und Logging

- Fachliche Fehler erhalten eigene Exception-Typen oder explizite Result-Modelle.
- Technische Exceptions werden an Adaptergrenzen mit Kontext angereichert.
- Console-Ausgaben sind für Nutzer verständlich; Logs enthalten technische Details für Diagnose.
- Exit Codes sind dokumentiert, wenn die Anwendung automatisiert genutzt wird.
- Retry wird nur für geeignete, idempotente Operationen eingesetzt und mit Timeout kombiniert.
- Logging nutzt Kategorien, Event-IDs oder strukturierte Properties, wenn Fehlerdiagnose davon profitiert.
- Keine Secrets, Tokens, personenbezogenen Daten oder vollständigen Rohdaten in Logs.

## Async, Cancellation und Performance

- I/O ist async. `.Result` und `.Wait()` werden nicht verwendet.
- CancellationTokens werden durchgereicht und in Schleifen, HTTP-Aufrufen und Dateioperationen beachtet.
- Große Dateien und Responses werden streaming-freundlich verarbeitet, wenn das Datenvolumen relevant ist.
- CPU-intensive oder parallelisierbare Arbeit wird bewusst gekapselt und getestet.
- Parallelisierung ist begrenzt und kontrolliert, besonders bei externen APIs und Dateisystemzugriffen.
- Ressourcen wie Streams, HttpResponses und temporäre Dateien werden zuverlässig freigegeben.

## Daten, Validierung und Verträge

- Eingaben werden früh validiert und in fachliche Modelle übersetzt.
- DTOs externer Dienste bleiben an der Infrastrukturgrenze und werden nicht unkontrolliert in die Domain durchgereicht.
- Dateiformate und Export-Schemas sind versioniert oder dokumentiert.
- Nullable Reference Types bleiben aktiviert; Nullfälle werden bewusst modelliert.
- Einheiten, Rundung, Kulturformat und Zeitzonen werden explizit behandelt.
- Parser sind tolerant gegenüber irrelevanten Zusatzfeldern, aber streng bei fachlich benötigten Daten.
- Export- und Importverträge werden mit Tests abgesichert.

## Unit Tests

- Teststandard ist xUnit, sofern das Repository nichts anderes vorgibt.
- Fachliche Services und Domain-Regeln werden mit kleinen, deterministischen Unit Tests abgedeckt.
- Workflows werden mit Fake-Implementierungen für externe Interfaces getestet.
- HTTP-Clients werden mit Fake-`HttpMessageHandler`, Testserver oder kontrollierten Responses getestet.
- Console-I/O wird über abstrahierte Reader/Writer oder temporäre Umleitung getestet.
- Dateisystemtests verwenden Temp-Verzeichnisse und räumen auf.
- DI-Tests prüfen, dass der ServiceProvider für typische Konfigurationen gebaut werden kann.
- Fehlerpfade, Timeouts, leere Antworten, ungültige Eingaben und Cancellation werden explizit getestet.
- Tests vermeiden echte Uhrzeit, echten Zufall und echte Netzwerke, außer sie sind klar als Live-Tests markiert.

## Build und Qualität

- `dotnet build` muss ohne Warnungsflut laufen. Neue Warnungen werden nicht ignoriert.
- `dotnet test` ist der Standard-Qualitätscheck.
- Formatierung folgt dem Repository: `.editorconfig`, `dotnet format` oder IDE-Formatierung.
- Public APIs und Exportverträge werden nur mit passenden Tests und Dokumentationsupdate geändert.
- Nullable, analyzers und TreatWarningsAsErrors werden verwendet, wenn das Repository sie aktiviert hat.
- Paketversionen werden bewusst aktualisiert; transitive Abhängigkeiten werden bei Sicherheits- oder Kompatibilitätsproblemen geprüft.
