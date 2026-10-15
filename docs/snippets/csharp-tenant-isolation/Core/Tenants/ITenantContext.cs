namespace Example.Core.Tenants;

/// <summary>
/// Liefert den Mandanten der aktuellen Anfrage beziehungsweise des aktuellen Jobs. Die einzige
/// reguläre Quelle ist der Claim <c>tenant_id</c> des validierten Zugriffstokens, der die
/// Business-Id des Mandanten trägt; es gibt bewusst keinen Weg, den Mandanten aus Request-Parametern
/// zu setzen. Der interne Integer-Schlüssel (<see cref="TenantKey"/>) wird daraus höchstens einmal
/// je Dependency-Injection-Scope aufgelöst.
/// </summary>
public interface ITenantContext
{
    /// <summary>Die Business-Id des aktuellen Mandanten. Wirft, wenn keine vorliegt.</summary>
    Guid TenantId { get; }

    /// <summary>Nicht werfende Variante von <see cref="TenantId"/>; nur für technische Infrastruktur.</summary>
    bool TryGetTenantId(out Guid tenantId);

    /// <summary>Der interne Schlüssel <c>tenants.id</c> des aktuellen Mandanten. Wirft, wenn er für
    /// den aktuellen Scope noch nicht aufgelöst wurde.</summary>
    int TenantKey { get; }

    /// <summary>Nicht werfende Variante von <see cref="TenantKey"/>; nur für technische Infrastruktur.</summary>
    bool TryGetTenantKey(out int tenantKey);
}
