namespace Example.Core.Teams;

/// <summary>
/// Die fachlichen Fehler des Bereichs Teams. Je Fachbereich genau eine solche Klasse; die Codes sind
/// Teil des öffentlichen API-Vertrags.
/// </summary>
public static class TeamErrors
{
    /// <summary>Ein Team mit diesem Namen existiert im Mandanten bereits.</summary>
    public static readonly DomainError NameConflict = new("team_name_conflict", ErrorKind.Conflict);

    /// <summary>Das adressierte Team existiert nicht oder ist nicht sichtbar.</summary>
    public static readonly DomainError NotFound = new("team_not_found", ErrorKind.NotFound);
}
