namespace Example.Worker.Tenancy;

/// <summary>
/// Öffnet für Hintergrundjobs je Mandant einen eigenen Dependency-Injection-Scope und weist ihm den
/// Mandanten zu, bevor irgendein Dienst daraus eine Transaktion beginnt. Alle Dienste des Jobs müssen
/// über <see cref="ServiceProvider"/> aufgelöst werden, nie über den Root-Provider.
/// </summary>
public sealed class WorkerTenantScope : IAsyncDisposable
{
    private readonly AsyncServiceScope _scope;

    private WorkerTenantScope(AsyncServiceScope scope) => _scope = scope;

    /// <summary>Der Dienstanbieter dieses Mandanten-Scopes.</summary>
    public IServiceProvider ServiceProvider => _scope.ServiceProvider;

    /// <summary>Öffnet einen Scope und weist ihm <paramref name="tenantId"/> zu.</summary>
    public static async Task<WorkerTenantScope> OpenAsync(IServiceScopeFactory serviceScopeFactory, Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(serviceScopeFactory);

        var scope = serviceScopeFactory.CreateAsyncScope();
        try
        {
            scope.ServiceProvider.GetRequiredService<ITenantAssignment>().AssignTenantId(tenantId);
            return new WorkerTenantScope(scope);
        }
        catch
        {
            await scope.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }

    public ValueTask DisposeAsync() => _scope.DisposeAsync();
}
