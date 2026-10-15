namespace Example.WebApi.Contracts;

/// <summary>
/// Der HTTP-Transportvertrag für <see cref="IPageable"/>. Er liegt in <c>WebApi</c>, weil die
/// Header-Bindung aus <c>Microsoft.AspNetCore.Mvc</c> stammt, die <c>Core</c> nicht referenzieren darf.
///
/// <para>
/// <c>required</c> ist für die Modellbindung folgenlos — ein fehlender Header löst bei einem
/// <c>int</c> ohnehin einen Bindungsfehler und damit die automatische 400-Antwort von
/// <c>[ApiController]</c> aus. Der Modifikator weist beide Eigenschaften im OpenAPI-Schema als
/// Pflichtfeld aus.
/// </para>
/// </summary>
public sealed class PageRequest : IPageable
{
    /// <summary>Die angeforderte Seite, eins-basiert.</summary>
    [FromHeader(Name = "Page")]
    [Range(1, int.MaxValue, MinimumIsExclusive = false)]
    public required int Page { get; init; }

    /// <summary>Die Anzahl der Elemente je Seite.</summary>
    [FromHeader(Name = "Page-Size")]
    [Range(1, int.MaxValue, MinimumIsExclusive = false)]
    public required int PageSize { get; init; }
}
