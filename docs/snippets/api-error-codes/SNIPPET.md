# Snippet: API Error Codes

Stand: 2026-10-15

## Zweck

Einheitliche, maschinenlesbare Fehlercodes für HTTP-APIs: Erwartbare fachliche Fehler entstehen in `Core` als `DomainError` in einem `Result<T>`, werden über eine einzige Fabrik auf ProblemDetails mit der Erweiterung `errorCode` abgebildet und im Frontend über eine einzige Funktion gelesen. Benutzerseitige Texte entstehen ausschließlich im Frontend.

## Verwenden

- Wenn ein Endpunkt fachliche Fehler (Validierung, Nicht gefunden, Konflikt, fachlich verboten) an Clients meldet.
- Wenn das Frontend auf fachliche Fehler einer API reagiert.
- Wenn Eindeutigkeitskonflikte der Datenbank als fachlicher Fehler gemeldet werden sollen.
- Nicht verwenden für technische Fehler ohne fachliche Bedeutung; diese bleiben generische `500`-Antworten.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [ErrorKind.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/ErrorKind.cs) | `Core` | Fachliche Fehlerarten ohne HTTP-Bezug. |
| [DomainError.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/DomainError.cs) | `Core` | Fehlercode und Fehlerart. |
| [ResultOfT.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/ResultOfT.cs) | `Core` | `Result<T>` mit Wert oder `DomainError`. |
| [Result.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/Result.cs) | `Core` | Fabrik `Result.Success` und `Result.Failure`. |
| [DomainException.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/DomainException.cs) | `Core` | Ausnahmeweg für Fehler ohne sinnvolle lokale Behandlung. |
| [TeamErrors.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Teams/TeamErrors.cs) | `Core` | Beispiel: Fehlerkatalog eines Fachbereichs. |
| [DbUpdateExceptionExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Infrastructure/Persistence/DbUpdateExceptionExtensions.cs) | `Infrastructure` | `IsUniqueViolation` für PostgreSQL. |
| [ErrorProblem.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/WebApi/Errors/ErrorProblem.cs) | `WebApi` | Einzige Fabrik für ProblemDetails mit Fehlercode und Statusabbildung. |
| [DomainExceptionHandler.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/WebApi/Errors/DomainExceptionHandler.cs) | `WebApi` | Zentrales `IExceptionHandler` für `DomainException`. |
| [api-error.ts](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/frontend/src/app/core/data-access/api/api-error.ts) | Angular | `ApiResult<T>`, `readProblemErrorCode` und `toApiResult`. |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Core`: `System.Diagnostics.CodeAnalysis`, `<Name>.Core.Errors`
- `Infrastructure`: `Microsoft.EntityFrameworkCore`, `Npgsql`, `<Name>.Core.Errors`; Repositories zusätzlich `<Name>.Infrastructure.Persistence` für `IsUniqueViolation`
- `WebApi`: `Microsoft.AspNetCore.Diagnostics`, `Microsoft.AspNetCore.Mvc`, `Microsoft.AspNetCore.WebUtilities`, `<Name>.Core.Errors`

Registrierung in `AddWebApi(...)` und `Program.cs`:

```csharp
services.AddProblemDetails();
services.AddExceptionHandler<DomainExceptionHandler>();

// Program.cs, vor MapControllers()
app.UseExceptionHandler();
```

## Regeln

### Fehlercodes

[MUST] Fehlercodes müssen englisch, stabil und in `snake_case` nach dem Schema `<bereich>_<fehler>` geschrieben sein, zum Beispiel `team_name_conflict`.

[MUST] Jeder `DomainError` muss als statisches Feld in einer Klasse `<Bereich>Errors` des jeweiligen Fachbereichs definiert sein.

[MUST_NOT] Fehlercodes dürfen nicht aus `enum.ToString()`, Typnamen oder Fehlermeldungen abgeleitet werden.

[MUST_NOT] Ein veröffentlichter Fehlercode darf ohne API-Versionierung oder dokumentierte Migration nicht umbenannt oder entfernt werden.

[MUST] Die ProblemDetails-Erweiterung muss `errorCode` heißen. Zusätzliche fachliche Felder dürfen als weitere Erweiterungen ergänzt werden, ersetzen aber nie `errorCode`.

### Backend

[MUST] Use Cases und Repositories mit erwartbarem fachlichem Fehlerfall müssen `Result<T>` mit einem `DomainError` liefern.

[ALLOW_IF] `DomainException` darf nur geworfen werden, wenn eine lokale Behandlung als Ergebnisobjekt nicht sinnvoll ist; der `DomainExceptionHandler` bildet sie dann zentral ab.

[MUST] ProblemDetails mit Fehlercode dürfen ausschließlich über `ErrorProblem` entstehen; Controller dürfen keine eigenen Hilfsmethoden für Fehlercode-Erweiterungen besitzen.

[MUST] `DomainExceptionHandler` muss über `AddExceptionHandler` registriert und mit `UseExceptionHandler()` in die Pipeline eingebunden sein.

[MUST] Eindeutigkeitskonflikte müssen über den Unique-Constraint der Datenbank erkannt werden: `SaveChangesAsync` in `try`, `catch (DbUpdateException ex) when (ex.IsUniqueViolation("<constraint>"))` und Rückgabe des passenden `DomainError`.

[MUST_NOT] Eindeutigkeit darf nicht allein über eine vorgelagerte Existenzabfrage gesichert werden.

[MUST_NOT] `Exception.Message`, Stacktraces oder interne Details dürfen nicht an Clients ausgeliefert werden.

[MUST] Jeder fachliche Fehlerpfad eines Endpunkts muss im Vertrag mit seinem Statuscode auf `components/responses/Problem` verweisen. Das Schema `Problem` besitzt die Pflichtfelder `status` und `errorCode`; siehe [OpenAPI Contract First](https://heljens-it-services.github.io/agent-files/snippets/openapi-contract-first/SNIPPET.md).

### Frontend

[MUST] Fehlercodes müssen ausschließlich über `readProblemErrorCode` gelesen werden; eigene Extraktionsfunktionen sind nicht erlaubt.

[MUST] Data-Access-Services unter `core/data-access/` müssen fachliche Fehler als `ApiResult<T>` zurückgeben, zum Beispiel über `toApiResult`. Eigene Ergebnis-Unions je Feature sind nicht erlaubt.

[MUST] Benutzerseitige Meldungen müssen im Frontend aus dem Fehlercode abgeleitet werden. Für `unknown` und nicht gemappte Codes muss eine allgemeine Meldung existieren.

## Beispiel

```csharp
// Infrastructure/Teams/TeamRepository.cs
dbContext.Teams.Add(entity);
try
{
    await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
}
catch (DbUpdateException exception) when (exception.IsUniqueViolation("ix_teams_tenant_id_name"))
{
    return Result.Failure<TeamDto>(TeamErrors.NameConflict);
}

return Result.Success(ToDto(entity));

// WebApi/Teams/TeamsController.cs, CreateTeam ist aus dem Vertrag erzeugt
public override async Task<IActionResult> CreateTeam(CreateTeamRequest createTeamRequest, CancellationToken cancellationToken)
{
    var result = await teamService.CreateAsync(createTeamRequest.Name, cancellationToken).ConfigureAwait(false);
    return result.Succeeded
        ? Created($"/api/teams/{result.Value.BusinessId}", ToResponse(result.Value))
        : ErrorProblem.ToResult(result.Error);
}
```

```json
{ "status": 409, "title": "Conflict", "errorCode": "team_name_conflict" }
```

```ts
// core/data-access/teams/teams-api.service.ts
async create(name: string): Promise<ApiResult<Team>> {
  const result = await toApiResult(() => firstValueFrom(this.teamsService.createTeam({ name })));
  return result.succeeded ? { succeeded: true, value: toTeam(result.value) } : result;
}
```

## Tests

[MUST] WebApi-Tests müssen je fachlichem Fehlerpfad Statuscode und `errorCode` der Antwort prüfen.

[MUST] Ein Infrastrukturtest muss nachweisen, dass ein Eindeutigkeitskonflikt gegen eine echte Datenbank den erwarteten `DomainError` liefert.

[MUST] `readProblemErrorCode` muss mit Code, ohne Code, mit leerem Code und mit Nicht-HTTP-Fehler getestet sein.

## Grenzen

- `IsUniqueViolation` ist PostgreSQL-spezifisch; für andere Provider muss der Fehlercode des Providers geprüft werden.
- Validierungsfehler der Modellbindung erzeugt ASP.NET Core weiterhin als `ValidationProblemDetails` ohne `errorCode`.
