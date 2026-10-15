# Snippet: API Error Codes

Stand: 2026-10-15

## Zweck

Einheitliche, maschinenlesbare Fehlercodes für HTTP-APIs: Fachliche Ablehnungen entstehen in `Core` als `DomainException`, werden zentral auf ProblemDetails mit der Erweiterung `errorCode` abgebildet und im Frontend über eine einzige Funktion gelesen. Benutzerseitige Texte entstehen ausschließlich im Frontend.

## Verwenden

- Wenn ein Endpunkt fachliche Fehler (Validierung, Nicht gefunden, Konflikt, fachlich verboten) an Clients meldet.
- Wenn das Frontend auf fachliche Fehler einer API reagiert.
- Wenn Eindeutigkeitskonflikte der Datenbank als fachlicher Fehler gemeldet werden sollen.
- Nicht verwenden für technische Fehler ohne fachliche Bedeutung; diese bleiben generische `500`-Antworten.

## Dateien

| Datei | Projekt | Zweck |
|---|---|---|
| [ErrorKind.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/ErrorKind.cs) | `Core` | Fachliche Fehlerarten ohne HTTP-Bezug. |
| [DomainException.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Errors/DomainException.cs) | `Core` | Basistyp mit `ErrorCode` und `Kind`. |
| [TeamNameConflictException.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Core/Teams/TeamNameConflictException.cs) | `Core` | Beispiel für eine konkrete fachliche Ablehnung. |
| [DbUpdateExceptionExtensions.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/Infrastructure/Persistence/DbUpdateExceptionExtensions.cs) | `Infrastructure` | `IsUniqueViolation` für PostgreSQL. |
| [ErrorProblem.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/WebApi/Errors/ErrorProblem.cs) | `WebApi` | Einzige Fabrik für ProblemDetails mit Fehlercode und Statusabbildung. |
| [DomainExceptionHandler.cs](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/WebApi/Errors/DomainExceptionHandler.cs) | `WebApi` | Zentrales `IExceptionHandler` für `DomainException`. |
| [api-error.ts](https://heljens-it-services.github.io/agent-files/snippets/api-error-codes/frontend/src/app/core/data-access/api/api-error.ts) | Angular | `ApiResult<T>`, `readProblemErrorCode` und `toApiResult`. |

Der Namespace-Präfix `Example` ist durch den Projektnamen zu ersetzen. Benötigte Einträge in `GlobalUsings.cs`:

- `Core`: `<Name>.Core.Errors`
- `Infrastructure`: `Microsoft.EntityFrameworkCore`, `Npgsql`, `<Name>.Core.Errors`
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

[MUST_NOT] Fehlercodes dürfen nicht aus `enum.ToString()`, Exception-Typnamen oder Fehlermeldungen abgeleitet werden.

[MUST_NOT] Ein veröffentlichter Fehlercode darf ohne API-Versionierung oder dokumentierte Migration nicht umbenannt oder entfernt werden.

[MUST] Die ProblemDetails-Erweiterung muss `errorCode` heißen. Zusätzliche fachliche Felder dürfen als weitere Erweiterungen ergänzt werden, ersetzen aber nie `errorCode`.

### Backend

[MUST] Fachliche Ablehnungen in `Core` müssen als eigener, von `DomainException` abgeleiteter Typ mit festem Fehlercode und passender `ErrorKind` geworfen werden.

[MUST] ProblemDetails mit Fehlercode dürfen ausschließlich über `ErrorProblem` entstehen; Controller dürfen keine eigenen Hilfsmethoden für Fehlercode-Erweiterungen besitzen.

[MUST] `DomainExceptionHandler` muss über `AddExceptionHandler` registriert und mit `UseExceptionHandler()` in die Pipeline eingebunden sein.

[MUST_IF] Wenn ein Use Case statt einer Exception ein Ergebnisobjekt mit Fehlerfall liefert, muss der Controller den Fehlerfall über `ErrorProblem.ToResult` mit Fehlercode abbilden.

[MUST] Eindeutigkeitskonflikte müssen über den Unique-Constraint der Datenbank erkannt werden: `SaveChangesAsync` in `try`, `catch (DbUpdateException ex) when (ex.IsUniqueViolation("<constraint>"))` und Übersetzung in eine `DomainException` mit `ErrorKind.Conflict`.

[MUST_NOT] Eindeutigkeit darf nicht allein über eine vorgelagerte Existenzabfrage gesichert werden.

[MUST_NOT] `Exception.Message`, Stacktraces oder interne Details dürfen nicht an Clients ausgeliefert werden.

[MUST] Jeder fachliche Fehlerpfad eines Endpunkts muss mit `ProducesResponseType` im OpenAPI-Vertrag dokumentiert sein.

### Frontend

[MUST] Fehlercodes müssen ausschließlich über `readProblemErrorCode` gelesen werden; eigene Extraktionsfunktionen sind nicht erlaubt.

[MUST] Data-Access-Services müssen fachliche Fehler als `ApiResult<T>` zurückgeben, zum Beispiel über `toApiResult`. Eigene Ergebnis-Unions je Feature sind nicht erlaubt.

[MUST] Benutzerseitige Meldungen müssen im Frontend aus dem Fehlercode abgeleitet werden. Für `unknown` und nicht gemappte Codes muss eine allgemeine Meldung existieren.

## Beispiel

```csharp
// Infrastructure/Teams/TeamRepository.cs
try
{
    await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
}
catch (DbUpdateException exception) when (exception.IsUniqueViolation("ix_teams_tenant_id_name"))
{
    throw new TeamNameConflictException(team.Name, exception);
}

// WebApi/Teams/TeamsController.cs
[HttpPost]
[ProducesResponseType(typeof(TeamResponse), StatusCodes.Status201Created)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
public async Task<IActionResult> CreateAsync(CreateTeamRequest request, CancellationToken cancellationToken)
{
    var team = await teamService.CreateAsync(request.Name, cancellationToken).ConfigureAwait(false);
    return Created($"/api/teams/{team.BusinessId}", ToResponse(team));
}
```

```json
{ "status": 409, "title": "Conflict", "errorCode": "team_name_conflict" }
```

```ts
// features/teams/data-access/teams-api.service.ts
createTeam(name: string): Promise<ApiResult<TeamResponse>> {
  return toApiResult(() => firstValueFrom(this.teamsService.createTeam({ name })));
}
```

## Tests

[MUST] WebApi-Tests müssen je fachlichem Fehlerpfad Statuscode und `errorCode` der Antwort prüfen.

[MUST] Ein Infrastrukturtest muss nachweisen, dass ein Eindeutigkeitskonflikt gegen eine echte Datenbank in die erwartete `DomainException` übersetzt wird.

[MUST] `readProblemErrorCode` muss mit Code, ohne Code, mit leerem Code und mit Nicht-HTTP-Fehler getestet sein.

## Grenzen

- `IsUniqueViolation` ist PostgreSQL-spezifisch; für andere Provider muss der Fehlercode des Providers geprüft werden.
- Validierungsfehler der Modellbindung erzeugt ASP.NET Core weiterhin als `ValidationProblemDetails` ohne `errorCode`.
