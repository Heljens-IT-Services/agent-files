# DEVELOPER.CSharpNet.md

Stand: 2026-10-18

## Zweck

Diese Datei gilt für C#- und .NET-Projekte aller Einstiegstypen. Anwendungs- und hostspezifische Regeldateien werden über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Sprach- und Coderichtlinien

[MUST] File-scoped namespaces müssen verwendet werden.

[MUST] Alle Namespaces müssen ausschließlich über `GlobalUsings.cs` verwaltet werden.

[SHOULD] Primäre Konstruktoren sollen wann immer möglich bevorzugt verwendet werden.

[MUST] Jeder öffentliche Typ muss in einer eigenen Datei liegen.

[SHOULD] Records sollen für immutable DTOs, Value Objects und Ergebnisobjekte verwendet werden. Abweichungen sind erlaubt, wenn Framework-Binding, Serialisierung oder bestehende API-Verträge Klassen erfordern.

## Datenbankzugriff

[MUST] C#-Anwendungen müssen Entity Framework Core für Datenbank-Anbindungen und datenbankbezogene Implementierungen verwenden.

[ALLOW] Eine projektspezifische Regel darf ausdrücklich eine abweichende Technologie oder Vorgehensweise vorgeben.

## Repository-Pattern und Persistenzgrenze

[MUST] Für datenbankgestützte Persistenz in C#/.NET muss das Repository-Pattern als technische Persistenzgrenze verwendet werden.

[MUST] Repository-Verträge müssen fachlich oder use-case-orientiert nur die tatsächlich benötigten Operationen exponieren und fachliche, anwendungsinterne DTOs, Modelle, Value Objects oder fachlich geeignete primitive Werte verwenden.

[MUST] Repository-Implementierungen müssen das Mapping zwischen EF-Core-Entities und den anwendungsinternen Vertragsmodellen an der technischen Persistenzgrenze durchführen.

[MUST_NOT] Repository-Verträge dürfen keine EF-Core-Entities oder technischen Adapter- beziehungsweise Persistenztypen nach außen exponieren.

[MUST_NOT] Ein generisches `IRepository<TEntity>`-Framework darf nicht pauschal als Standard vorgeschrieben werden.

[MUST] Anwendungscode mit datenbankgestützter Persistenz muss die Factory-Regeln einhalten: Repository-Implementierungen konsumieren `IDbContextFactory<TContext>` und die Composition Root registriert `AddDbContextFactory<TContext>(...)`.

[MUST_NOT] Anwendungscode darf `TContext : DbContext` nicht direkt injizieren. Die durch `AddDbContextFactory` zusätzlich registrierte Scoped-Instanz ist kein erlaubter Konsumweg.

[MUST] Jeder Factory-erzeugte Context muss pro fachlicher Unit of Work erzeugt und deterministisch disposed werden; in Async-Code mit `CreateDbContextAsync(cancellationToken)` und `await using`.

[MUST_NOT] Ein Context darf nicht parallel verwendet oder über Requests, Jobs, Messages oder unabhängige Operationen hinweg gehalten werden. Zusammengehörige Vorgänge dürfen denselben Context innerhalb einer Unit of Work verwenden.

[MUST_IF] Wenn die Context-Konfiguration von scoped oder tenantabhängigen Daten abhängt, muss die Lifetime von `AddDbContextFactory` bewusst passend gewählt werden.

## Migrationen

[MUST] Schemaänderungen an EF-Core-verwalteten Datenbanken müssen ausschließlich über EF-Core-Migrationen erfolgen, die mit dem EF-Core-Tooling wie `dotnet ef migrations add` erzeugt werden.

[MUST_NOT] Migrationsdateien und Model-Snapshot dürfen nicht von Hand angelegt werden, und das Schema darf nicht per manuellem DDL außerhalb von Migrationen geändert werden.

[MUST_IF] Wenn ein `DbContext` in einer geschichteten .NET-Anwendung liegt, müssen seine Migrationen im selben `Infrastructure`-Projekt liegen.

[MUST_NOT] `EnsureCreated()` darf nicht in Projekten verwendet werden, die ihr Schema über Migrationen verwalten.

### Erzeugen und Prüfen

[MUST] Migrationsnamen müssen die fachliche Schemaänderung in PascalCase beschreiben, zum Beispiel `AddShippingAddressToOrder`. Generische Namen wie `Update`, `Fix` oder `Migration2` sind nicht zulässig.

[MUST] Generierte `Up`- und `Down`-Methoden sowie das daraus erzeugte SQL müssen vor dem Commit geprüft werden, insbesondere auf Datenverlust, Sperrverhalten und korrekte Typen, Längen, Defaults, Indizes und Constraints.

[MUST_IF] Wenn das Tooling eine Umbenennung als Entfernen und Neuanlegen erzeugt, muss die Migration vor ihrer Veröffentlichung auf `RenameColumn` beziehungsweise `RenameTable` korrigiert oder nach dem Expand-/Contract-Vorgehen aufgeteilt werden.

[ALLOW_IF] Generierter Migrationscode darf nur angepasst werden, solange die Migration noch nicht veröffentlicht ist, etwa für Umbenennungen, `migrationBuilder.Sql(...)` oder providerspezifische Optionen.

[MUST] Model-Snapshot und zugehörige Migration müssen gemeinsam im selben Commit versioniert werden.

[MUST_IF] Wenn der Model-Snapshot einen Merge-Konflikt hat, darf er nicht manuell zusammengeführt werden; die eigene unveröffentlichte Migration muss entfernt und auf dem integrierten Stand neu erzeugt werden.

[MUST] Vor dem Abschluss einer Änderung am EF-Core-Modell muss `dotnet ef migrations has-pending-model-changes` (ab EF Core 8) ohne ausstehende Modelländerungen durchlaufen. Bei älteren EF-Core-Versionen muss gleichwertig geprüft werden, dass eine probeweise erzeugte Migration leer ist; sie muss danach mit `dotnet ef migrations remove` entfernt werden.

[SHOULD] Die Prüfung auf ausstehende Modelländerungen soll zusätzlich in CI ausgeführt werden.

[SHOULD] Neue Migrationen sollen vor dem Abschluss gegen eine leere und gegen eine auf dem vorherigen Migrationsstand befindliche Datenbank derselben Engine erfolgreich angewendet werden.

### Veröffentlichte Migrationen

Eine Migration gilt als veröffentlicht, sobald sie in einen gemeinsam genutzten Branch integriert oder auf eine gemeinsam genutzte Datenbank angewendet wurde.

[MUST_NOT] Veröffentlichte Migrationen dürfen nicht geändert, umbenannt, umsortiert oder gelöscht werden. Korrekturen müssen als neue Migration erfolgen.

[ALLOW_IF] `dotnet ef migrations remove` darf nur für die jüngste, noch nicht veröffentlichte Migration verwendet werden.

### Kompatible Schemaänderungen

[MUST] Schemaänderungen müssen mit der zuletzt ausgerollten Anwendungsversion kompatibel bleiben, bis diese nicht mehr gegen die Datenbank läuft.

[MUST] Umbenennen, Entfernen oder inkompatible Typänderungen von Tabellen und Spalten müssen nach Expand/Contract erfolgen: neue Struktur ergänzen, Daten übertragen, Code umstellen und die alte Struktur erst in einer späteren, separat ausgerollten Migration entfernen.

[MUST_IF] Wenn eine bestehende Tabelle eine neue Pflichtspalte erhält, muss die Migration einen fachlich gültigen Default setzen oder die Spalte zunächst nullable anlegen und erst nach der Datenbefüllung verschärfen.

[SHOULD] Bei PostgreSQL sollen Indizes auf großen oder stark genutzten Tabellen ohne Schreibsperre angelegt werden, etwa über `IsCreatedConcurrently()` des Npgsql-Providers.

### Destruktive Änderungen

[MUST_NOT] Migrationen dürfen ohne ausdrückliche Freigabe des Users keine Tabellen, Spalten, Schemata oder Daten entfernen und keine Typen oder Längen verlustbehaftet ändern.

[MUST_IF] Wenn eine destruktive Migration freigegeben wurde, müssen Freigabe, betroffene Daten und Rollback-Strategie im Pull Request oder Arbeitsabschluss genannt werden.

### Datenmigrationen

[MUST] Datenmigrationen müssen von Schemamigrationen getrennt in eigenen Migrationen oder eigenen Deployment-Schritten erfolgen.

[MUST] Datenmigrationen müssen idempotent sein und bei erneuter Ausführung denselben Endzustand ohne Fehler oder Duplikate erzeugen.

[MUST_NOT] Datenmigrationen dürfen keine EF-Core-Entities, `DbContext`-Instanzen oder Anwendungsservices des aktuellen Modells verwenden, sondern müssen mit SQL beziehungsweise `migrationBuilder.Sql(...)` auf dem Schema ihres Migrationsstands arbeiten.

[SHOULD] Datenmigrationen auf großen Tabellen sollen in Batches laufen, um lange Sperren und Transaktionen zu vermeiden.

### Anwendung in Deployments

[MUST] Migrationen müssen in gemeinsam genutzten und produktiven Umgebungen als eigener Deployment-Schritt vor dem Start der neuen Anwendungsversion angewendet werden, über ein idempotentes SQL-Skript (`dotnet ef migrations script --idempotent`) oder ein Migration Bundle (`dotnet ef migrations bundle`).

[MUST_NOT] Produktive Anwendungen dürfen Migrationen nicht beim Start über `Database.Migrate()` oder `MigrateAsync()` anwenden.

[ALLOW_IF] `Database.Migrate()` beim Start darf nur in lokaler Entwicklung und in Testumgebungen verwendet werden.

[SHOULD] Der Deployment-Schritt soll einen Datenbankbenutzer mit Schema-Rechten verwenden, der von dem Laufzeitbenutzer der Anwendung getrennt ist.

### Rollback

[MUST] Die `Down`-Methode einer Migration muss deren `Up`-Methode umkehren, soweit dies ohne Datenverlust möglich ist.

[MUST_IF] Wenn eine Migration nicht verlustfrei umkehrbar ist, muss dies in der Migration kommentiert und eine Rollback-Strategie über Backup und Wiederherstellung oder eine korrigierende Folgemigration beschrieben werden.

[SHOULD] Fehler in produktiven Umgebungen sollen per Roll-forward über eine neue korrigierende Migration behoben werden; `Down`-Migrationen sollen vorrangig in Entwicklungs- und Testumgebungen eingesetzt werden.

### Kommandos

```bash
# Migration erzeugen
dotnet ef migrations add <MigrationName> --project <Infrastructure-Projekt> --startup-project <Entry-Projekt>

# Auf ausstehende Modelländerungen prüfen
dotnet ef migrations has-pending-model-changes --project <Infrastructure-Projekt> --startup-project <Entry-Projekt>

# Jüngste unveröffentlichte Migration entfernen
dotnet ef migrations remove --project <Infrastructure-Projekt> --startup-project <Entry-Projekt>

# Idempotentes Deployment-Skript erzeugen
dotnet ef migrations script --idempotent --output <Pfad>/migrations.sql --project <Infrastructure-Projekt> --startup-project <Entry-Projekt>

# Migration Bundle erzeugen
dotnet ef migrations bundle --output <Pfad>/efbundle --project <Infrastructure-Projekt> --startup-project <Entry-Projekt>
```

## Module.cs und DI

[MUST] Produktive .NET-Projekte mit eigener DI-Registrierung müssen eine `Module.cs` als zentralen Einstiegspunkt für diese Registrierungen verwenden.

[MUST] Wiederverwendbare Schichten oder Projekte mit eigener Registrierungsverantwortung müssen ihre DI-Registrierung über klar benannte Erweiterungsmethoden kapseln.

[MUST] Der Methodenname einer DI-Erweiterungsmethode muss zur Projektrolle passen, zum Beispiel `AddCore(...)`, `AddInfrastructure(...)`, `AddConsole(...)`, `AddWebApi(...)` oder `AddWorker(...)`.

[ALLOW] `Program.cs` oder ein anderer Composition Root darf Module wegen transitiver Referenzierung explizit registrieren.

[MUST] Direkte Projektreferenzen müssen die vorgesehenen Architekturgrenzen respektieren und dürfen nicht allein für bequeme DI-Registrierung aufgeweicht werden.
