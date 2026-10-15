namespace Example.Infrastructure.Tenants;

/// <summary>
/// Liest die Business-Id des Mandanten aus dem Claim <c>tenant_id</c> des validierten
/// Zugriffstokens. Eine über <see cref="ITenantAssignment"/> zugewiesene Business-Id hat Vorrang — sie
/// wird nur dort gesetzt, wo kein Benutzertoken existiert. Scoped registriert, damit der Zustand nie
/// einen Scope überlebt.
/// </summary>
public sealed class TenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext, ITenantAssignment
{
    private const string TenantClaimType = "tenant_id";

    private Guid? _assignedTenantId;
    private int? _tenantKey;

    public Guid TenantId => TryGetTenantId(out var tenantId)
        ? tenantId
        : throw new InvalidOperationException($"The claim '{TenantClaimType}' is missing or not a valid Guid and no tenant was assigned.");

    public int TenantKey => TryGetTenantKey(out var tenantKey)
        ? tenantKey
        : throw new InvalidOperationException("The internal tenant key has not been resolved for the current scope.");

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

    public bool TryGetTenantKey(out int tenantKey)
    {
        tenantKey = _tenantKey ?? 0;
        return _tenantKey.HasValue;
    }

    public void AssignTenantId(Guid tenantId)
    {
        if (tenantId == Guid.Empty)
        {
            throw new ArgumentException("The tenant id must not be empty.", nameof(tenantId));
        }

        _assignedTenantId = tenantId;
        _tenantKey = null;
    }

    public void AssignTenantKey(int tenantKey)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(tenantKey);
        _tenantKey = tenantKey;
    }
}
