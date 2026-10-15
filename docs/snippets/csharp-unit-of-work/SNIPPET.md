# Snippet: C# Unit of Work

Stand: 2026-10-15

## Zweck

Eine explizite Transaktion je fachlicher Operation für C#-/.NET-Anwendungen mit EF Core: `Core` öffnet über den Port `IUnitOfWork` einen Scope, alle Repositories dieses Scopes teilen Context und Transaktion, und Commit beziehungsweise Rollback sind zentral gekapselt.

## Verwenden

- Wenn ein Use Case lesend oder schreibend auf datenbankgestützte Persistenz zugreift.
- Wenn mehrere Repository-Aufrufe atomar zusammengehören.
- Nicht verwenden für reine Leseabfragen außerhalb relationaler Persistenz oder für Adapter ohne Datenbank.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [IUnitOfWork.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/Core/Persistence/IUnitOfWork.cs) | `Core` | Port zum Öffnen eines Scopes. |
| [IUnitOfWorkScope.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/Core/Persistence/IUnitOfWorkScope.cs) | `Core` | Repositories des Scopes, Commit und Rollback bei Dispose. |
| [UnitOfWorkExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/Core/Persistence/UnitOfWorkExtensions.cs) | `Core` | `ExecuteAsync` und `ExecuteResultAsync` ohne `try`/`finally` im Use Case. |
| [UnitOfWork.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/Infrastructure/Persistence/UnitOfWork.cs) | `Infrastructure` | Implementierung über `IDbContextFactory`. |
| [UnitOfWorkScope.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/Infrastructure/Persistence/UnitOfWorkScope.cs) | `Infrastructure` | Context, Transaktion und Repository-Erzeugung je Scope. |

`ExecuteResultAsync` verwendet `Result<T>` aus [API Error Codes](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/SNIPPET.md).

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Core`: `<Name>.Core.Errors`, `<Name>.Core.Teams` (je Fachbereich mit Repository im Scope)
- `Infrastructure`: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Storage`, `<Name>.Core.Persistence`, `<Name>.Core.Teams`, `<Name>.Infrastructure.Database`, `<Name>.Infrastructure.Teams`

Registrierung in `AddInfrastructure(...)`:

```csharp
services.AddDbContextFactory<AppDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
services.AddScoped<IUnitOfWork, UnitOfWork>();
```

## Regeln

[MUST] Use Cases müssen datenbankgestützte Persistenz ausschließlich über `IUnitOfWork` und die Repository-Eigenschaften von `IUnitOfWorkScope` erreichen.

[MUST] `UnitOfWork` muss die einzige Komponente sein, die `IDbContextFactory<TContext>` konsumiert; Repositories erhalten den Context ihres Scopes über den Konstruktor.

[MUST_NOT] Repository-Implementierungen dürfen nicht im DI-Container registriert werden; sie entstehen ausschließlich in `UnitOfWorkScope`.

[MUST] Je Fachbereich muss `IUnitOfWorkScope` genau eine Repository-Eigenschaft besitzen, die ein Repository-Interface aus `Core` liefert.

[MUST] Use Cases müssen einen Scope über `ExecuteAsync` oder `ExecuteResultAsync` öffnen. Wenn das nicht möglich ist, muss der Scope mit `await using` verwendet werden.

[MUST_NOT] Innerhalb eines Scopes darf kein zweiter Scope geöffnet werden; `UnitOfWork` wirft in diesem Fall.

[MUST] Ein Scope muss genau eine fachliche Operation umfassen. Er darf nicht über Requests, Jobs, Messages oder parallele Operationen hinweg gehalten werden.

[MUST] Repositories dürfen `SaveChangesAsync` aufrufen, aber keine eigene Transaktion beginnen oder bestätigen.

[MUST_IF] Wenn ein Use Case einen fachlichen Fehler als `Result<T>` liefert, muss er über `ExecuteResultAsync` laufen, damit Teiländerungen verworfen werden.

[MUST_NOT] Externe Aufrufe wie HTTP, Messaging oder Dateisystem dürfen nicht innerhalb eines offenen Scopes ausgeführt werden, sofern die Operation nicht ausdrücklich deren Ergebnis atomar mit der Datenbankänderung verknüpfen muss.

## Beispiel

```csharp
// Core/Teams/TeamService.cs
public Task<PageResult<TeamDto>> ListAsync(IPageable page, CancellationToken cancellationToken) =>
    unitOfWork.ExecuteAsync(
        (scope, _) => Task.FromResult(scope.Teams.GetAllOrderedByName().AsPage(page)),
        cancellationToken);

public Task<Result<TeamDto>> CreateAsync(string name, CancellationToken cancellationToken) =>
    unitOfWork.ExecuteResultAsync(
        (scope, token) => scope.Teams.CreateAsync(new TeamDto(Guid.NewGuid(), name), token),
        cancellationToken);
```

## Tests

[MUST] Ein Infrastrukturtest gegen echte Datenbank muss nachweisen, dass Änderungen ohne `CommitAsync` und bei einem fachlichen Fehler über `ExecuteResultAsync` verworfen werden.

[MUST] Ein Test muss nachweisen, dass ein zweites `BeginAsync` bei offenem Scope wirft.

[MUST] Core-Tests müssen Use Cases mit einem Fake von `IUnitOfWork` und `IUnitOfWorkScope` prüfen, nicht mit EF Core.

## Grenzen

- Der Scope bündelt Repositories aller Fachbereiche in einem Interface; bei sehr vielen Fachbereichen kann er je Bounded Context geteilt werden.
- Zusammen mit [C# Tenant Isolation](https://heljens-it-services.github.io/agent-files/snippets/csharp-tenant-isolation/SNIPPET.md) setzt der Transaktionsbeginn die Mandanten-Sitzungsvariablen.
