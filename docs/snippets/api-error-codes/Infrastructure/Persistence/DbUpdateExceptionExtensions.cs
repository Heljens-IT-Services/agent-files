namespace Example.Infrastructure.Persistence;

/// <summary>
/// Erkennt Verletzungen von Datenbank-Constraints, damit Repositories Eindeutigkeitskonflikte ohne
/// vorgelagerte Existenzprüfung — und damit ohne Race Condition — in einen fachlichen
/// <see cref="DomainError"/> übersetzen können.
/// </summary>
public static class DbUpdateExceptionExtensions
{
    /// <summary>
    /// Liefert <see langword="true"/>, wenn <paramref name="exception"/> eine PostgreSQL-Unique-Verletzung
    /// (<c>23505</c>) genau des Constraints <paramref name="constraintName"/> ist.
    /// </summary>
    public static bool IsUniqueViolation(this DbUpdateException exception, string constraintName)
    {
        ArgumentNullException.ThrowIfNull(exception);

        return exception.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation } postgresException
            && string.Equals(postgresException.ConstraintName, constraintName, StringComparison.Ordinal);
    }
}
