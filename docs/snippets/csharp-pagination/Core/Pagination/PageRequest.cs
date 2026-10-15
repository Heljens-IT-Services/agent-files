namespace Example.Core.Pagination;

/// <summary>
/// Die Standardumsetzung von <see cref="IPageable"/>. Controller erzeugen sie aus den im Vertrag
/// definierten Headern <c>Page</c> und <c>Page-Size</c>; Validierung und Bindung übernimmt der aus
/// dem Vertrag erzeugte Controller.
/// </summary>
public sealed record PageRequest(int Page, int PageSize) : IPageable;
