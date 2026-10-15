namespace Example.Core.Pagination;

/// <summary>
/// Das Ergebnis einer paginierten Abfrage. <see cref="Count"/> ist die Gesamtzahl der Treffer VOR
/// dem Seitenschnitt, nicht die Länge von <see cref="Items"/> — eine Seite hinter dem Ende liefert
/// ein leeres <see cref="Items"/> bei unverändert positivem <see cref="Count"/>.
/// </summary>
/// <typeparam name="T">Der Elementtyp der angeforderten Seite.</typeparam>
public sealed class PageResult<T>
{
    /// <summary>Die Gesamtzahl der Treffer vor dem Seitenschnitt.</summary>
    public required int Count { get; init; }

    /// <summary>Die Elemente der angeforderten Seite.</summary>
    public required IEnumerable<T> Items { get; init; }
}
