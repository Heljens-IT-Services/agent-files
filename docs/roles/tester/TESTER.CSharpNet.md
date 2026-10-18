# TESTER.CSharpNet.md

Stand: 2026-10-18

## Zweck

Diese Datei definiert Testregeln für C#- und .NET-Projekte. Allgemeine Tester-Regeln werden über [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md), weitere technologiespezifische Regeldateien über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst. Schichtbezogene Testpflichten stehen in [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md), [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetWebApi.md) und [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetConsole.md) und werden hier nicht wiederholt.

## Testprojekte

[MUST] Jedes Testprojekt muss genau einem produktiven Projekt zugeordnet sein und dessen Namen mit dem Suffix `.Tests` oder `.IntegrationTests` tragen, zum Beispiel `<Name>.Core.Tests`, `<Name>.Infrastructure.Tests` oder `<Name>.WebApi.Tests`.

[SHOULD] Integrationstests mit echter Infrastruktur sollen in einem eigenen Projekt mit dem Suffix `.IntegrationTests` liegen, damit Unit Tests ohne Container-Laufzeit ausführbar bleiben. Abweichungen sind erlaubt, wenn das Projekt Integrationstests bereits einheitlich über Traits oder Kategorien trennt.

[SHOULD] Testprojekte sollen in einem eigenen Verzeichnis wie `tests/` getrennt von den produktiven Projekten liegen. Eine bestehende Verzeichnisstruktur des Projekts hat Vorrang.

[MUST] Ordner- und Namespace-Struktur eines Testprojekts müssen die Struktur des getesteten Projekts spiegeln.

[MUST] Eine Testklasse muss nach dem getesteten Typ mit dem Suffix `Tests` benannt werden, zum Beispiel `OrderServiceTests`.

[MUST_NOT] Produktive Projekte dürfen Testprojekte nicht referenzieren.

[MUST_IF] Wenn Tests eigene Builder, Fakes, Fixtures oder Testdaten benötigen, müssen diese im Testprojekt liegen. Wiederverwendbare Testinfrastruktur mehrerer Testprojekte darf nur in ein eigenes, nicht produktives Projekt wie `<Name>.Testing` ausgelagert werden.

## Framework und Abhängigkeiten

[SHOULD] Neue Testprojekte sollen xUnit als Testframework verwenden.

[MUST_IF] Wenn ein Projekt bereits ein anderes Testframework wie NUnit oder MSTest verwendet, muss dieses beibehalten werden.

[MUST_NOT] Innerhalb einer Solution dürfen nicht mehrere Testframeworks gemischt werden, außer `PROJECT.md` sieht dies ausdrücklich vor.

[MUST_IF] Wenn Testframework, Assertion-, Mocking-, Container- oder Architekturtest-Bibliothek neu eingeführt werden sollen, gilt die Freigaberegel für neue Abhängigkeiten aus [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md).

[SHOULD] Ports aus `Core` sollen in Unit Tests durch handgeschriebene Fakes ersetzt werden. Mocking-Bibliotheken sind erlaubt, wenn das Projekt sie bereits verwendet und Interaktionen selbst Teil des Vertrags sind.

## Testaufbau

[MUST] Testmethoden müssen das erwartete Verhalten englisch und sprechend benennen, bevorzugt im Schema `<Methode>_<Bedingung>_<Erwartung>`, zum Beispiel `PlaceOrder_WithEmptyCart_ReturnsValidationError`. Ein bestehendes einheitliches Namensschema des Projekts hat Vorrang.

[MUST] Tests müssen nach Arrange, Act und Assert gegliedert sein und genau eine fachliche Aktion ausführen.

[ALLOW] Die Abschnitte dürfen durch Leerzeilen oder die Kommentare `// Arrange`, `// Act` und `// Assert` getrennt werden.

[SHOULD] Datengetriebene Varianten desselben Verhaltens sollen über parametrisierte Tests wie `[Theory]` mit `[InlineData]` oder `[MemberData]` abgebildet werden statt über kopierte Testmethoden.

[MUST] Asynchroner Code muss mit `async Task`-Tests und `await` getestet werden.

[MUST_NOT] Tests dürfen nicht über `.Result`, `.Wait()` oder `GetAwaiter().GetResult()` blockierend auf asynchronen Code warten.

[MUST_IF] Wenn ein Fehlerpfad über eine Exception signalisiert wird, muss der Test den konkreten Exception-Typ und relevante fachliche Eigenschaften prüfen, zum Beispiel über `Assert.ThrowsAsync<TException>`.

## Unit Tests und Integrationstests

[MUST] Unit Tests müssen ohne Datenbank, Netzwerk, Dateisystem, Container und gestarteten Host auskommen.

[MUST] Integrationstests müssen das Zusammenspiel mit echter Infrastruktur prüfen, zum Beispiel Repository-Implementierungen, EF-Core-Mappings, Abfragen, Constraints, Transaktionen, Serialisierung oder den gestarteten HTTP-Host.

[MUST_NOT] Persistenzverhalten darf nicht mit dem EF-Core-InMemory-Provider oder einer anderen Datenbank-Engine als der produktiven, etwa SQLite statt PostgreSQL, als nachgewiesen gelten.

[MUST_IF] Wenn Persistenzverhalten getestet wird, müssen die Integrationstests gegen dieselbe Datenbank-Engine in derselben Major-Version wie in Produktion laufen, bevorzugt über Testcontainers.

[MUST_IF] Wenn ein Testschema benötigt wird, muss es über die Migrationen des Projekts erzeugt werden statt über `EnsureCreated()`, sofern das Projekt Migrationen verwendet.

[SHOULD] WebApi-Tests sollen den Host über `WebApplicationFactory<TEntryPoint>` starten und Infrastruktur nur an Port- oder Konfigurationsgrenzen ersetzen.

[MUST_IF] Wenn für Integrationstests keine Container-Laufzeit verfügbar ist, müssen diese Tests im Arbeitsabschluss als ausgelassen mit Begründung genannt werden.

## Fixtures und Isolation

[MUST] Teure Ressourcen wie Datenbank-Container oder `WebApplicationFactory` müssen über Fixtures wie `IClassFixture<T>` oder `ICollectionFixture<T>` geteilt und über `IAsyncLifetime` asynchron gestartet und beendet werden.

[MUST] Jeder Test muss mit einem definierten Datenzustand beginnen, etwa durch eigene Datenbank pro Testklasse, Zurücksetzen der Tabellen vor jedem Test oder eine pro Test zurückgerollte Transaktion.

[MUST_NOT] Tests dürfen nicht von der Ausführungsreihenfolge oder von Daten anderer Tests abhängen.

[MUST_IF] Wenn Tests einen gemeinsamen veränderlichen Zustand nicht isolieren können, müssen sie in einer gemeinsamen Test-Collection ohne Parallelisierung laufen.

[MUST_NOT] Integrationstests dürfen keine festen Ports, Hostnamen oder lokal vorinstallierten Dienste voraussetzen; Verbindungsdaten müssen aus der Fixture stammen.

## Zeit und Nebenläufigkeit

[MUST] Zeitabhängiges Verhalten muss über einen injizierten `TimeProvider` gesteuert und in Tests mit einem kontrollierbaren Ersatz wie `FakeTimeProvider` geprüft werden.

[MUST_NOT] Tests dürfen nicht von der realen Systemzeit, `DateTime.Now`, `DateTime.UtcNow` oder `DateTimeOffset.UtcNow` abhängen.

[MUST_NOT] Tests dürfen nicht mit `Thread.Sleep`, `Task.Delay` oder festen Wartezeiten synchronisiert werden.

[MUST] Warten auf asynchrone Effekte muss über `await`, `TaskCompletionSource`, das Vorspulen eines `FakeTimeProvider` oder ein begrenztes Polling mit Timeout erfolgen.

[MUST_IF] Wenn zu testender Code Zeit, Zufall oder Nebenläufigkeit nicht steuerbar macht, muss der Tester die fehlende Testbarkeit benennen statt instabile Tests zu schreiben.

## Architekturtests

[OPTIONAL] Architekturtests dürfen die Referenzrichtung und Kapselung aus [DEVELOPER.NetApplication.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.NetApplication.md) automatisiert prüfen, zum Beispiel dass `Core` weder EF Core noch Infrastructure- oder Entry-Projekte referenziert.

[MUST_IF] Wenn ein Projekt Architekturtests besitzt, müssen sie bei Änderungen an Projektreferenzen, Namespaces oder Schichtzuordnungen ausgeführt werden.

## Ausführung

[MUST] Tests müssen über `dotnet test` ausführbar sein, ohne zusätzliche manuelle Vorbereitung außer einer verfügbaren Container-Laufzeit für Integrationstests.

## Kommandos

```bash
# Alle Tests der Solution
dotnet test <solution>.sln

# Ein einzelnes Testprojekt
dotnet test tests/<Projekt>.Tests/<Projekt>.Tests.csproj

# Gefilterte Ausführung für den kleinsten sinnvollen Checkumfang
dotnet test <solution>.sln --filter "FullyQualifiedName~<Namespace oder Testklasse>"
```
