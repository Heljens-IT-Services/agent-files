namespace Example.Core.Errors;

/// <summary>
/// Ergebnis eines Use Cases oder Repository-Aufrufs mit erwartbarem fachlichem Fehlerfall. Genau
/// eines von <see cref="Value"/> und <see cref="Error"/> ist gesetzt. Instanzen entstehen über
/// <see cref="Result.Success{T}(T)"/> und <see cref="Result.Failure{T}(DomainError)"/>.
/// </summary>
public sealed class Result<T>
{
    internal Result(T? value, DomainError? error)
    {
        Value = value;
        Error = error;
    }

    /// <summary>Der Wert bei Erfolg.</summary>
    public T? Value { get; }

    /// <summary>Der fachliche Fehler bei Misserfolg.</summary>
    public DomainError? Error { get; }

    /// <summary>Liefert <see langword="true"/>, wenn kein fachlicher Fehler vorliegt.</summary>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    public bool Succeeded => Error is null;
}
