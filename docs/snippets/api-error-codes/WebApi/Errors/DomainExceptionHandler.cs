namespace Example.WebApi.Errors;

/// <summary>
/// Bildet jede <see cref="DomainException"/> zentral auf ProblemDetails mit Fehlercode ab. Andere
/// Exceptions bleiben unbehandelt und landen als generische 500-Antwort ohne interne Details.
/// </summary>
public sealed class DomainExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DomainException domainException)
        {
            return false;
        }

        var statusCode = ErrorProblem.ToStatusCode(domainException.Kind);
        httpContext.Response.StatusCode = statusCode;

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = ErrorProblem.Create(statusCode, domainException.ErrorCode, ReasonPhrases.GetReasonPhrase(statusCode)),
        }).ConfigureAwait(false);
    }
}
