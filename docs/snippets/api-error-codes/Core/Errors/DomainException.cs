namespace Example.Core.Errors;

/// <summary>
/// Basistyp für erwartbare fachliche Ablehnungen. <see cref="ErrorCode"/> ist ein stabiler,
/// maschinenlesbarer Code in <c>snake_case</c> (<c>&lt;bereich&gt;_&lt;fehler&gt;</c>, z. B.
/// <c>team_name_conflict</c>), den das Frontend in eine benutzerseitige Meldung übersetzt.
/// <see cref="Exception.Message"/> ist ein englischer Diagnosetext und wird nicht an Clients
/// ausgeliefert.
/// </summary>
public abstract class DomainException(string errorCode, ErrorKind kind, string message, Exception? innerException = null)
    : Exception(message, innerException)
{
    /// <summary>Der stabile, maschinenlesbare Fehlercode in <c>snake_case</c>.</summary>
    public string ErrorCode { get; } = errorCode;

    /// <summary>Die fachliche Fehlerart, aus der die WebApi den Statuscode ableitet.</summary>
    public ErrorKind Kind { get; } = kind;
}
