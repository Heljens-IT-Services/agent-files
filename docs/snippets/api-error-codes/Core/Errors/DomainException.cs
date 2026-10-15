namespace Example.Core.Errors;

/// <summary>
/// Transportiert einen <see cref="DomainError"/> als Exception — nur für Fälle, in denen eine
/// lokale Behandlung als Ergebnisobjekt nicht sinnvoll ist, etwa tief in Infrastrukturpfaden. Der
/// Standardweg für erwartbare fachliche Fehler ist <see cref="Result{T}"/>.
/// <see cref="Exception.Message"/> ist ein englischer Diagnosetext und wird nicht an Clients
/// ausgeliefert.
/// </summary>
public sealed class DomainException(DomainError error, string message, Exception? innerException = null)
    : Exception(message, innerException)
{
    /// <summary>Der transportierte fachliche Fehler.</summary>
    public DomainError Error { get; } = error ?? throw new ArgumentNullException(nameof(error));
}
