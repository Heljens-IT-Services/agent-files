namespace Example.Core.Teams;

/// <summary>
/// Beispiel für eine konkrete fachliche Ablehnung: ein Team mit diesem Namen existiert im Mandanten
/// bereits. Je fachlichem Fehler entsteht genau ein eigener Typ mit festem Fehlercode.
/// </summary>
public sealed class TeamNameConflictException(string name, Exception? innerException = null)
    : DomainException("team_name_conflict", ErrorKind.Conflict, $"A team named '{name}' already exists.", innerException);
