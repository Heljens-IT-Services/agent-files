namespace Example.Core.Tenants;

/// <summary>
/// Liefert den Mandanten der aktuellen Anfrage beziehungsweise des aktuellen Jobs. Die einzige
/// reguläre Quelle ist der Mandanten-Claim des validierten Zugriffstokens; es gibt bewusst keinen
/// Weg, den Mandanten aus Request-Parametern zu setzen.
/// </summary>
public interface ITenantContext
{
    /// <summary>Der aktuelle Mandant. Wirft, wenn keiner vorliegt — für fachlichen Code ein
    /// Programmfehler, kein erwartbarer Zustand.</summary>
    Guid TenantId { get; }

    /// <summary>Nicht werfende Variante von <see cref="TenantId"/>; ausschließlich für technische
    /// Infrastruktur wie den Transaktions-Interceptor gedacht.</summary>
    bool TryGetTenantId(out Guid tenantId);
}
