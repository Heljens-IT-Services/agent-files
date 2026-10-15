namespace Example.Core.Tenants;

/// <summary>
/// Weist den Mandanten für den aktuellen Dependency-Injection-Scope ausdrücklich zu. Zwei
/// Verwendungen: der Transaktions-Interceptor hinterlegt den einmal aufgelösten internen Schlüssel,
/// und Hintergrundjobs ohne Benutzertoken beziehungsweise die Anlage eines neuen Mandanten weisen
/// den Mandanten selbst zu. Jede Verwendung muss in einer Architekturtest-Allowlist stehen.
/// </summary>
public interface ITenantAssignment
{
    /// <summary>Weist die Business-Id zu. Muss vor dem ersten Transaktionsbeginn des Scopes erfolgen.</summary>
    void AssignTenantId(Guid tenantId);

    /// <summary>Hinterlegt den internen Schlüssel <c>tenants.id</c> des zugewiesenen Mandanten.</summary>
    void AssignTenantKey(int tenantKey);
}
