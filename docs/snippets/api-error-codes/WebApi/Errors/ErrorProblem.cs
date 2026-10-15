namespace Example.WebApi.Errors;

/// <summary>
/// Die einzige Stelle, an der ProblemDetails mit Fehlercode entstehen. Controller und
/// <see cref="DomainExceptionHandler"/> verwenden ausschließlich diese Fabrik, damit Schlüssel,
/// Schreibweise und Statusabbildung überall identisch bleiben.
/// </summary>
public static class ErrorProblem
{
    /// <summary>Der Name der ProblemDetails-Erweiterung, die den Fehlercode trägt.</summary>
    public const string ErrorCodeKey = "errorCode";

    /// <summary>Baut ProblemDetails mit Status, Standardtitel und Fehlercode.</summary>
    public static ProblemDetails Create(DomainError error)
    {
        ArgumentNullException.ThrowIfNull(error);

        var statusCode = ToStatusCode(error.Kind);
        var problemDetails = new ProblemDetails { Status = statusCode, Title = ReasonPhrases.GetReasonPhrase(statusCode) };
        problemDetails.Extensions[ErrorCodeKey] = error.Code;
        return problemDetails;
    }

    /// <summary>Erzeugt ein <see cref="ObjectResult"/> für Controller-Actions.</summary>
    public static ObjectResult ToResult(DomainError error)
    {
        var problemDetails = Create(error);
        return new ObjectResult(problemDetails) { StatusCode = problemDetails.Status };
    }

    /// <summary>Bildet eine <see cref="ErrorKind"/> auf ihren HTTP-Statuscode ab.</summary>
    public static int ToStatusCode(ErrorKind kind) => kind switch
    {
        ErrorKind.Validation => StatusCodes.Status400BadRequest,
        ErrorKind.NotFound => StatusCodes.Status404NotFound,
        ErrorKind.Conflict => StatusCodes.Status409Conflict,
        ErrorKind.Forbidden => StatusCodes.Status403Forbidden,
        _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Unknown error kind."),
    };
}
