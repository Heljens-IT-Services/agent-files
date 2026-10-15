namespace Example.Infrastructure.Persistence;

/// <summary>
/// Hält Context und Transaktion eines Scopes und erzeugt die Repositories bei Bedarf über genau
/// diesem Context. <see cref="DisposeAsync"/> entsorgt Transaktion und Context deterministisch; ohne
/// vorheriges <see cref="CommitAsync"/> rollt die Transaktion zurück.
/// </summary>
internal sealed class UnitOfWorkScope(AppDbContext context, IDbContextTransaction transaction, Action onDisposed) : IUnitOfWorkScope
{
    private TeamRepository? _teams;

    public ITeamRepository Teams => _teams ??= new TeamRepository(context);

    public Task CommitAsync(CancellationToken cancellationToken) => transaction.CommitAsync(cancellationToken);

    public async ValueTask DisposeAsync()
    {
        try
        {
            await transaction.DisposeAsync().ConfigureAwait(false);
            await context.DisposeAsync().ConfigureAwait(false);
        }
        finally
        {
            onDisposed();
        }
    }
}
