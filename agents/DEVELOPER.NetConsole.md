# DEVELOPER.NetConsole.md

Stand: 2026-04-30

## Zweck

Diese Datei definiert die .NET-spezifischen Entwicklungsregeln dieses Repositories. Allgemeine Regeln stehen in `DEVELOPER.md`.

## Versionsbasis

.NET-Konsolenanwendungen zielen auf `net10.0`.

Verbindlich sind die Versionen in:

- `global.json`
- `.csproj`
- `Directory.Build.props`
- CI-Konfiguration

## Architektur

.NET-Anwendungen folgen Domain-Driven Design.

Typische Struktur:

```text
<Project>/
  Program.cs
  Application/
  Domain/
  Infrastructure/
  ConsoleUi/
  Configuration/
  DependencyInjection/
<Project>.Tests/
```

- `Program.cs` ist der Composition Root.
- `Domain/` enthält fachliche Modelle, Value Objects und Domain-Logik.
- `Application/` enthält Use Cases und Orchestrierung.
- `Infrastructure/` enthält technische Adapter.
- `ConsoleUi/` enthält Ein- und Ausgabe.

## Code-Regeln

- File-scoped namespaces sind Pflicht.
- Es werden ausschließlich `global using` verwendet.
- Lokale `using`-Direktiven in einzelnen Dateien sind nicht erlaubt.
- Jeder Typ liegt in einer eigenen Datei.
- DTOs werden bevorzugt als `record` modelliert.
- Fachliche Primitive werden bei Bedarf als Value Objects modelliert.

## Bootstrap und DI

- Anwendungen verwenden den Generic Host.
- `Program.cs` enthält keine Fachlogik.
- Constructor Injection ist Standard.
- Externe Abhängigkeiten werden über Interfaces oder Adapter getrennt.

## Konfiguration

- Konfiguration ist typisiert und validiert.
- Secrets werden nicht versioniert.
- Pflichtkonfiguration wird beim Start geprüft.

## Fehler und Logging

- Fachliche Fehler werden bewusst modelliert.
- Technische Fehler werden mit Kontext geloggt.
- Keine Secrets oder personenbezogenen Daten in Logs.

## Tests

- Fachlogik wird mit Unit Tests abgesichert.
- Workflows werden getrennt von Infrastruktur getestet.
- Tests sind deterministisch und isoliert.
