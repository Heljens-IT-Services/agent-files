namespace Example.WebApi.Errors;

/// <summary>
/// Bildet jede <see cref="DomainException"/> zentral auf ProblemDetails mit Fehlercode ab. Andere
/// Exceptions bleiben unbehandelt und landen als generische 500-Antwort ohne interne Details.
/// </summary>
public sealed class DomainExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        if (exception is not DomainException domainException)
        {
            return false;
        }

        var problemDetails = ErrorProblem.Create(domainException.Error);
        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = problemDetails,
        }).ConfigureAwait(false);
    }
}
