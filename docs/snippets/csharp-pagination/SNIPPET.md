# Snippet: C# Pagination

Stand: 2026-10-15

## Zweck

Einheitliche, eins-basierte Pagination für C#-/.NET-Backends: Seitenangabe per HTTP-Header, Seitenschnitt über `IOrderedQueryable<T>` und Antwort als `{ count, items }`.

## Verwenden

- Wenn ein Listen-Endpunkt, ein Listen-Use-Case oder eine paginierte Repository-Abfrage entsteht oder geändert wird.
- Nicht verwenden für Streaming, Cursor- oder Keyset-Pagination über sehr große, laufend wachsende Datenmengen; dafür ist eine eigene Entscheidung erforderlich.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [IPageable.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/IPageable.cs) | `Core` | Seitenvertrag mit `Page` und `PageSize`. |
| [PageResult.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/PageResult.cs) | `Core` | Ergebnis mit Gesamtzahl `Count` und `Items`. |
| [QueryableExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/QueryableExtensions.cs) | `Core` | `AsPage` und `PageResponse` auf `IOrderedQueryable<T>`. |
| [PageRequest.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/WebApi/Contracts/PageRequest.cs) | `WebApi` | Header-Bindung und Validierung von `Page` und `Page-Size`. |
| [QueryableExtensionsTests.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core.Tests/Pagination/QueryableExtensionsTests.cs) | `Core.Tests` | Unit-Tests der Erweiterungsmethoden ohne Datenbank (xUnit, AwesomeAssertions). |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Core`: `System.Linq.Expressions`
- `WebApi`: `System.ComponentModel.DataAnnotations`, `Microsoft.AspNetCore.Mvc`, `<Name>.Core.Pagination`
- `Core.Tests`: `AwesomeAssertions`, `Xunit`, `<Name>.Core.Pagination`

## Regeln

### Vertrag

[MUST] `IPageable`, `PageResult<T>` und `QueryableExtensions` müssen im `Core`-Projekt unter `<Name>.Core.Pagination` liegen; `PageRequest` muss in `WebApi/Contracts/` liegen.

[MUST] `Page` und `PageSize` müssen eins-basiert sein; der Seitenschnitt ist `Skip((Page - 1) * PageSize).Take(PageSize)`.

[MUST] Die Seitenangabe muss über die HTTP-Header `Page` und `Page-Size` übertragen werden. Beide Header sind Pflicht und mindestens `1`; serverseitige Defaults sind nicht vorgesehen.

[MUST] Filter- und Sortierparameter müssen als endpunktspezifische `[FromQuery]`-Klasse übergeben und in ein Core-Kriterienobjekt gemappt werden. Sie dürfen nicht über Header übertragen werden.

[MUST] Die Antwort muss `PageResult<TResponse>` mit genau den JSON-Feldern `count` und `items` sein. `count` ist die Gesamtzahl vor dem Seitenschnitt.

[MUST_NOT] Zusätzliche Paging-Felder wie `page`, `pageSize` oder `totalPages` sowie Paging-Response-Header wie `Total-Count` oder `Link` dürfen nicht ergänzt werden.

[MUST_IF] Wenn ein Endpunkt eine maximale Seitengröße benötigt, muss der Controller sie als Konstante im zugehörigen Contracts-Typ prüfen und bei Überschreitung `400` als ProblemDetails mit `extensions.errorCode = "PageSizeTooLarge"` liefern.

[MUST_IF] Wenn die API CORS mit expliziter Header-Liste konfiguriert, muss diese `Page` und `Page-Size` erlauben.

### Sortierung und Abfrage

[MUST] Repository-Methoden für paginierte Listen müssen `IOrderedQueryable<TDto>` liefern und nach dem Muster `GetAll...Ordered...` beziehungsweise `Get...Ordered` benannt sein.

[MUST] Jede Sortierung muss mit einem eindeutigen Schlüssel als letztem `ThenBy` enden, in der Regel `Id`, damit Seiten über wiederholte Abrufe stabil bleiben.

[MUST] Repository-Abfragen müssen `AsNoTracking()` verwenden und erst sortieren, dann in das Core-DTO projizieren.

[MUST_NOT] Paginierte Abfragen dürfen nicht über `IQueryable<T>` ohne Sortierung an `AsPage` oder `PageResponse` übergeben werden.

[SHOULD] Wenn die Projektion in SQL erfolgen kann und keine weitere Nachbearbeitung der Elemente nötig ist, soll `PageResponse` statt `AsPage` mit nachgelagertem `Select` verwendet werden.

[MUST] Abhängige Daten einer Seite müssen nach dem Seitenschnitt gesammelt für alle Elemente der Seite geladen werden, nicht pro Element.

### Schichten

[MUST] Controller-Actions müssen `PageRequest page` ohne Bindungsattribut entgegennehmen, den Use Case mit `IPageable` aufrufen und `Items` in Response-DTOs mappen.

[MUST] Service-Methoden müssen `ListAsync(IPageable page, ..., CancellationToken cancellationToken)` heißen und `PageResult<TDto>` liefern.

[MUST] Interne Aufrufer ohne HTTP-Kontext müssen ein eigenes privates `IPageable`-Record verwenden statt `PageRequest`.

## Beispiel

```csharp
// WebApi/Teams/TeamsController.cs
[HttpGet]
[ProducesResponseType(typeof(PageResult<TeamResponse>), StatusCodes.Status200OK)]
public async Task<IActionResult> ListAsync(PageRequest page, CancellationToken cancellationToken)
{
    var result = await teamService.ListAsync(page, cancellationToken).ConfigureAwait(false);
    return Ok(new PageResult<TeamResponse> { Count = result.Count, Items = result.Items.Select(ToResponse) });
}

// Core/Teams/ITeamService.cs
Task<PageResult<TeamDto>> ListAsync(IPageable page, CancellationToken cancellationToken);

// Core/Teams/TeamService.cs
var result = teamRepository.GetAllOrderedByName().AsPage(page);

// Core/Teams/ITeamRepository.cs
IOrderedQueryable<TeamDto> GetAllOrderedByName();

// Infrastructure/Teams/TeamRepository.cs
public IOrderedQueryable<TeamDto> GetAllOrderedByName() =>
    (IOrderedQueryable<TeamDto>)dbContext.Teams
        .AsNoTracking()
        .OrderBy(t => t.Name)
        .ThenBy(t => t.Id)
        .Select(t => new TeamDto(t.Id, t.Name));
```

Der Cast auf `IOrderedQueryable<TDto>` ist zulässig, weil EF Core nach `OrderBy` ein geordnetes Queryable liefert; ein `OrderBy` nach einer Konstruktor-Projektion ist nicht in SQL übersetzbar.

Der Context-Lebenszyklus (`IDbContextFactory<TContext>`, Unit of Work) folgt unverändert [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md) und ist im Beispiel ausgelassen.

## Tests

[MUST] Die Erweiterungsmethoden müssen mit den Tests aus `QueryableExtensionsTests.cs` abgesichert werden.

[MUST] Jeder paginierte Endpunkt muss in WebApi-Tests nachweisen, dass zwei Abrufe mit `Page-Size: 1` zusammen genau die erwarteten Elemente in stabiler Reihenfolge liefern.

[MUST_IF] Wenn ein Endpunkt eine maximale Seitengröße besitzt, muss ein Test nachweisen, dass `Maximum + 1` mit `400` und `PageSizeTooLarge` abgelehnt wird.

## Grenzen

- `AsPage` und `PageResponse` sind synchron und führen zwei Abfragen aus: `COUNT` und Seitenabfrage.
- Mandantentrennung erfolgt über globale EF-Query-Filter, nicht über Paging-Parameter.
