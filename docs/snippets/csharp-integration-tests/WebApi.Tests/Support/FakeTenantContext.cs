namespace Example.WebApi.Tests.Support;

/// <summary>
/// Fester Mandantenkontext für Migrationen und Repository-Tests ohne HTTP-Anfrage. Ohne gesetzte
/// Werte meldet er keinen Mandanten; der Query-Filter liefert dann keine Zeilen.
/// </summary>
public sealed class FakeTenantContext : ITenantContext
{
    public Guid? Id { get; init; }

    public int? Key { get; init; }

    public Guid TenantId => Id ?? throw new InvalidOperationException("No tenant id configured.");

    public int TenantKey => Key ?? throw new InvalidOperationException("No tenant key configured.");

    public bool TryGetTenantId(out Guid tenantId)
    {
        tenantId = Id ?? Guid.Empty;
        return Id.HasValue;
    }

    public bool TryGetTenantKey(out int tenantKey)
    {
        tenantKey = Key ?? 0;
        return Key.HasValue;
    }
}
