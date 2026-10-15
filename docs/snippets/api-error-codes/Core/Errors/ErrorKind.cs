namespace Example.Core.Errors;

/// <summary>
/// Die fachliche Fehlerart einer <see cref="DomainException"/>. Die WebApi bildet jede Art auf genau
/// einen HTTP-Statuscode ab; <c>Core</c> kennt keine Statuscodes.
/// </summary>
public enum ErrorKind
{
    /// <summary>Die Eingabe verletzt eine fachliche Regel (HTTP 400).</summary>
    Validation,

    /// <summary>Die adressierte Ressource existiert nicht oder ist nicht sichtbar (HTTP 404).</summary>
    NotFound,

    /// <summary>Die Operation kollidiert mit dem aktuellen Zustand, z. B. Eindeutigkeit (HTTP 409).</summary>
    Conflict,

    /// <summary>Die Operation ist für den aktuellen Benutzer fachlich nicht erlaubt (HTTP 403).</summary>
    Forbidden,
}
