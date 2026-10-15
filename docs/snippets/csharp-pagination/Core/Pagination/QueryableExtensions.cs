namespace Example.Core.Pagination;

/// <summary>
/// Die beiden Erweiterungsmethoden, über die jede Listenrückgabe entsteht. Beide verlangen
/// <see cref="IOrderedQueryable{T}"/> statt <see cref="IQueryable{T}"/> — bewusst schärfer: ein
/// Aufrufer ohne vorheriges <c>OrderBy</c>/<c>OrderByDescending</c> erhält einen Compilerfehler statt
/// einer unsortierten, zwischen zwei Aufrufen instabilen Seite.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Schneidet <paramref name="source"/> auf die durch <paramref name="page"/> angegebene Seite
    /// zu. Ermittelt zuerst <see cref="Queryable.Count{T}(IQueryable{T})"/> als Gesamtzahl und wendet
    /// dann <c>Skip</c>/<c>Take</c> an — erst danach wird materialisiert.
    /// </summary>
    public static PageResult<T> AsPage<T>(this IOrderedQueryable<T> source, IPageable page)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(page);

        var count = source.Count();
        var items = source
            .Skip((page.Page - 1) * page.PageSize)
            .Take(page.PageSize)
            .ToList();

        return new PageResult<T> { Count = count, Items = items };
    }

    /// <summary>
    /// Wie <see cref="AsPage{T}"/>, projiziert aber über <paramref name="selector"/> VOR der
    /// Materialisierung — die Projektion landet dadurch in der erzeugten SQL-Abfrage, statt die
    /// ganze Zeile zu laden.
    /// </summary>
    public static PageResult<TOut> PageResponse<T, TOut>(
        this IOrderedQueryable<T> source, IPageable page, Expression<Func<T, TOut>> selector)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(page);
        ArgumentNullException.ThrowIfNull(selector);

        var count = source.Count();
        var items = source
            .Skip((page.Page - 1) * page.PageSize)
            .Take(page.PageSize)
            .Select(selector)
            .ToList();

        return new PageResult<TOut> { Count = count, Items = items };
    }
}
