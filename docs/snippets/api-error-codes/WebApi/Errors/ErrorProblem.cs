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

    /// <summary>Baut ProblemDetails mit Status, englischem Titel und Fehlercode.</summary>
    public static ProblemDetails Create(int statusCode, string errorCode, string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorCode);

        var problemDetails = new ProblemDetails { Status = statusCode, Title = title };
        problemDetails.Extensions[ErrorCodeKey] = errorCode;
        return problemDetails;
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

    /// <summary>Erzeugt ein <see cref="ObjectResult"/> für Controller-Actions.</summary>
    public static ObjectResult ToResult(int statusCode, string errorCode, string title) =>
        new(Create(statusCode, errorCode, title)) { StatusCode = statusCode };
}
