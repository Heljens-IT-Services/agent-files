namespace Example.Infrastructure.Tenants;

/// <summary>
/// Liest den Mandanten aus dem Claim <c>tenant_id</c> des validierten Zugriffstokens. Ein über
/// <see cref="ITenantAssignment"/> zugewiesener Mandant hat Vorrang — er wird nur dort gesetzt, wo
/// kein Benutzertoken existiert. Scoped registriert, damit der Zustand nie Scopes überlebt.
/// </summary>
public sealed class TenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext, ITenantAssignment
{
    private const string TenantClaimType = "tenant_id";

    private Guid? _assignedTenantId;

    public Guid TenantId => TryGetTenantId(out var tenantId)
        ? tenantId
        : throw new InvalidOperationException($"The claim '{TenantClaimType}' is missing or not a valid Guid and no tenant was assigned.");

    public bool TryGetTenantId(out Guid tenantId)
    {
        if (_assignedTenantId is { } assigned)
        {
            tenantId = assigned;
            return true;
        }

        var claimValue = httpContextAccessor.HttpContext?.User.FindFirst(TenantClaimType)?.Value;
        return Guid.TryParse(claimValue, out tenantId);
    }

    public void AssignTenantId(Guid tenantId)
    {
        if (tenantId == Guid.Empty)
        {
            throw new ArgumentException("The tenant id must not be empty.", nameof(tenantId));
        }

        _assignedTenantId = tenantId;
    }
}
