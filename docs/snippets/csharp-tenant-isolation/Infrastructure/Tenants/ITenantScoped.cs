namespace Example.Infrastructure.Tenants;

/// <summary>
/// Markiert jede Entität, die zu genau einem Mandanten gehört. Jede Implementierung erhält
/// automatisch den globalen Query-Filter aus <c>AppDbContext</c> und in der Migration eine nicht
/// nullbare Integer-Spalte <c>tenant_id</c> mit Fremdschlüssel auf <c>tenants.id</c>, die in jedem
/// zusammengesetzten Index an erster Stelle steht, sowie eine Row-Level-Security-Policy.
/// </summary>
public interface ITenantScoped
{
    /// <summary>Der interne Schlüssel <c>tenants.id</c> des Mandanten dieser Zeile.</summary>
    int TenantId { get; }
}
