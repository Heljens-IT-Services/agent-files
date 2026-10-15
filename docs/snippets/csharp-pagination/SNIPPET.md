# Snippet: C# Pagination

Stand: 2026-10-15

## Zweck

Einheitliche, eins-basierte Pagination für C#-/.NET-Backends: Seitenangabe per HTTP-Header aus dem API-Vertrag, Seitenschnitt über `IOrderedQueryable<T>` und Antwort als `{ count, items }`.

## Verwenden

- Wenn ein Listen-Endpunkt, ein Listen-Use-Case oder eine paginierte Repository-Abfrage entsteht oder geändert wird.
- Nicht verwenden für Streaming, Cursor- oder Keyset-Pagination über sehr große, laufend wachsende Datenmengen; dafür ist eine eigene Entscheidung erforderlich.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [IPageable.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/IPageable.cs) | `Core` | Seitenvertrag mit `Page` und `PageSize`. |
| [PageResult.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/PageResult.cs) | `Core` | Ergebnis mit Gesamtzahl `Count` und `Items`. |
| [QueryableExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/QueryableExtensions.cs) | `Core` | `AsPage` und `PageResponse` auf `IOrderedQueryable<T>`. |
| [PageRequest.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core/Pagination/PageRequest.cs) | `Core` | Standardumsetzung von `IPageable`. |
| [QueryableExtensionsTests.cs](https://heljens-it-services.github.io/agent-files/snippets/csharp-pagination/Core.Tests/Pagination/QueryableExtensionsTests.cs) | `Core.Tests` | Unit-Tests der Erweiterungsmethoden ohne Datenbank (xUnit, AwesomeAssertions). |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Core`: `System.Linq.Expressions`
- `WebApi`: `<Name>.Core.Pagination`
- `Core.Tests`: `AwesomeAssertions`, `Xunit`, `<Name>.Core.Pagination`

## Regeln

### Vertrag

[MUST] `IPageable`, `PageRequest`, `PageResult<T>` und `QueryableExtensions` müssen im `Core`-Projekt unter `<Name>.Core.Pagination` liegen.

[MUST] `Page` und `PageSize` müssen eins-basiert sein; der Seitenschnitt ist `Skip((Page - 1) * PageSize).Take(PageSize)`.

[MUST] Die Seitenangabe muss über die HTTP-Header `Page` und `Page-Size` übertragen werden, die im Vertrag einmal unter `components/parameters` definiert und je Listenoperation per `$ref` eingebunden werden. Beide Header sind Pflicht; serverseitige Defaults sind nicht vorgesehen.

[MUST] Beide Header-Parameter müssen im Vertrag `minimum` und `maximum` besitzen, weil der Generator `[Range]` nur bei beiden Grenzen erzeugt. `Page` erhält `maximum: 2147483647`, `Page-Size` die fachliche Obergrenze des Endpunkts.

[MUST] Filter- und Sortierparameter müssen als endpunktspezifische `[FromQuery]`-Klasse übergeben und in ein Core-Kriterienobjekt gemappt werden. Sie dürfen nicht über Header übertragen werden.

[MUST] Die Antwort muss je Ressource ein Vertragsschema `<Ressource>Page` mit genau den Pflichtfeldern `count` (`integer`, `int32`) und `items` sein. `count` ist die Gesamtzahl vor dem Seitenschnitt.

[MUST_NOT] Zusätzliche Paging-Felder wie `page`, `pageSize` oder `totalPages` sowie Paging-Response-Header wie `Total-Count` oder `Link` dürfen nicht ergänzt werden.

[MUST] Die maximale Seitengröße eines Endpunkts steht ausschließlich als `maximum` von `Page-Size` im Vertrag; Überschreitungen lehnt die Modellvalidierung mit `400` ab.

[MUST_IF] Wenn die API CORS mit expliziter Header-Liste konfiguriert, muss diese `Page` und `Page-Size` erlauben.

### Sortierung und Abfrage

[MUST] Repository-Methoden für paginierte Listen müssen `IOrderedQueryable<TDto>` liefern und nach dem Muster `GetAll...Ordered...` beziehungsweise `Get...Ordered` benannt sein.

[MUST] Jede Sortierung muss mit einem eindeutigen Schlüssel als letztem `ThenBy` enden, in der Regel `Id`, damit Seiten über wiederholte Abrufe stabil bleiben.

[MUST] Repository-Abfragen müssen `AsNoTracking()` verwenden und erst sortieren, dann in das Core-DTO projizieren.

[MUST_NOT] Paginierte Abfragen dürfen nicht über `IQueryable<T>` ohne Sortierung an `AsPage` oder `PageResponse` übergeben werden.

[SHOULD] Wenn die Projektion in SQL erfolgen kann und keine weitere Nachbearbeitung der Elemente nötig ist, soll `PageResponse` statt `AsPage` mit nachgelagertem `Select` verwendet werden.

[MUST] Abhängige Daten einer Seite müssen nach dem Seitenschnitt gesammelt für alle Elemente der Seite geladen werden, nicht pro Element.

### Schichten

[MUST] Controller müssen die aus dem Vertrag erzeugte Methode überschreiben, aus `page` und `pageSize` ein `PageRequest` erzeugen, den Use Case mit `IPageable` aufrufen und das Ergebnis in das erzeugte `<Ressource>Page`-Modell mappen.

[MUST] Service-Methoden müssen `ListAsync(IPageable page, ..., CancellationToken cancellationToken)` heißen und `PageResult<TDto>` liefern.

[MUST] Interne Aufrufer ohne HTTP-Kontext verwenden ebenfalls `PageRequest`.

## Beispiel

```yaml
# contracts/api.yaml
paths:
  /api/teams:
    get:
      operationId: listTeams
      parameters:
        - $ref: '#/components/parameters/Page'
        - $ref: '#/components/parameters/PageSize'
      responses:
        '200':
          content:
            application/json:
              schema: { $ref: '#/components/schemas/TeamPage' }
```

```csharp
// WebApi/Teams/TeamsController.cs, TeamsControllerBase ist aus dem Vertrag erzeugt
public override async Task<IActionResult> ListTeams(int page, int pageSize, CancellationToken cancellationToken)
{
    var result = await teamService.ListAsync(new PageRequest(page, pageSize), cancellationToken).ConfigureAwait(false);
    return Ok(new TeamPage { Count = result.Count, Items = result.Items.Select(ToResponse).ToList() });
}

// Core/Teams/ITeamService.cs
Task<PageResult<TeamDto>> ListAsync(IPageable page, CancellationToken cancellationToken);

// Core/Teams/TeamService.cs, Unit of Work siehe C# Unit of Work
public Task<PageResult<TeamDto>> ListAsync(IPageable page, CancellationToken cancellationToken) =>
    unitOfWork.ExecuteAsync((scope, _) => Task.FromResult(scope.Teams.GetAllOrderedByName().AsPage(page)), cancellationToken);

// Core/Teams/ITeamRepository.cs
IOrderedQueryable<TeamDto> GetAllOrderedByName();

// Infrastructure/Teams/TeamRepository.cs
public IOrderedQueryable<TeamDto> GetAllOrderedByName() =>
    (IOrderedQueryable<TeamDto>)dbContext.Teams
        .AsNoTracking()
        .OrderBy(t => t.Name)
        .ThenBy(t => t.Id)
        .Select(t => new TeamDto(t.BusinessId, t.Name));
```

Der Cast auf `IOrderedQueryable<TDto>` ist zulässig, weil EF Core nach `OrderBy` ein geordnetes Queryable liefert; ein `OrderBy` nach einer Konstruktor-Projektion ist nicht in SQL übersetzbar.

Der Context-Lebenszyklus folgt [C# Unit of Work](https://heljens-it-services.github.io/agent-files/snippets/csharp-unit-of-work/SNIPPET.md): `AsPage` materialisiert innerhalb des offenen Scopes.

## Tests

[MUST] Die Erweiterungsmethoden müssen mit den Tests aus `QueryableExtensionsTests.cs` abgesichert werden.

[MUST] Jeder paginierte Endpunkt muss in WebApi-Tests nachweisen, dass zwei Abrufe mit `Page-Size: 1` zusammen genau die erwarteten Elemente in stabiler Reihenfolge liefern.

[MUST] Ein WebApi-Test muss nachweisen, dass `Page-Size` oberhalb des Vertragsmaximums und `Page` kleiner als `1` mit `400` abgelehnt werden.

## Grenzen

- `AsPage` und `PageResponse` sind synchron und führen zwei Abfragen aus: `COUNT` und Seitenabfrage.
- Mandantentrennung erfolgt über globale EF-Query-Filter, nicht über Paging-Parameter.
