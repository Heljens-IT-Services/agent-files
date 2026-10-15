namespace Example.Core.Pagination;

/// <summary>
/// Der Seitenvertrag, den jede Listenrückgabe entgegennimmt. <see cref="Page"/> und
/// <see cref="PageSize"/> sind eins-basiert; <see cref="QueryableExtensions"/> setzt beide in
/// <c>Skip</c>/<c>Take</c> um.
/// </summary>
public interface IPageable
{
    /// <summary>Die angeforderte Seite, eins-basiert (Seite 1 ist die erste Seite).</summary>
    int Page { get; }

    /// <summary>Die Anzahl der Elemente je Seite.</summary>
    int PageSize { get; }
}
