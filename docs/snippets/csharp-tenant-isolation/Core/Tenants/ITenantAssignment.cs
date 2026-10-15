namespace Example.Core.Tenants;

/// <summary>
/// Die einzige benannte Ausnahme von der Token-Quelle: weist den Mandanten für den aktuellen
/// Dependency-Injection-Scope ausdrücklich zu. Erlaubt nur für Hintergrundjobs ohne Benutzertoken und
/// für die Anlage eines neuen Mandanten. Jede Verwendung muss in einer Architekturtest-Allowlist stehen.
/// </summary>
public interface ITenantAssignment
{
    /// <summary>Weist den Mandanten zu. Muss vor dem ersten Transaktionsbeginn des Scopes erfolgen.</summary>
    void AssignTenantId(Guid tenantId);
}
