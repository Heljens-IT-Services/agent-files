namespace Example.Core.Errors;

/// <summary>Erzeugt <see cref="Result{T}"/>-Instanzen.</summary>
public static class Result
{
    public static Result<T> Success<T>(T value) => new(value, null);

    public static Result<T> Failure<T>(DomainError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result<T>(default, error);
    }
}
