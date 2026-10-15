namespace Example.Core.Errors;

/// <summary>
/// Ein erwartbarer fachlicher Fehler. <see cref="Code"/> ist ein stabiler, maschinenlesbarer Code in
/// <c>snake_case</c> (<c>&lt;bereich&gt;_&lt;fehler&gt;</c>, z. B. <c>team_name_conflict</c>), den das
/// Frontend in eine benutzerseitige Meldung übersetzt. Jeder Fehler wird einmal als statisches Feld
/// je Fachbereich definiert, nie ad hoc an der Verwendungsstelle.
/// </summary>
public sealed record DomainError(string Code, ErrorKind Kind);
