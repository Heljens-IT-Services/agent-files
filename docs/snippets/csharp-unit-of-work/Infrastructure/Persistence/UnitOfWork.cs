namespace Example.Infrastructure.Persistence;

/// <summary>
/// Implementiert <see cref="IUnitOfWork"/> gegen <see cref="IDbContextFactory{AppDbContext}"/>. Die
/// Unit of Work ist die einzige Komponente, die die Factory konsumiert; Repositories erhalten den
/// Context ihres Scopes. Scoped registriert.
/// </summary>
public sealed class UnitOfWork(IDbContextFactory<AppDbContext> contextFactory) : IUnitOfWork
{
    private bool _hasOpenScope;

    public async Task<IUnitOfWorkScope> BeginAsync(CancellationToken cancellationToken)
    {
        if (_hasOpenScope)
        {
            throw new InvalidOperationException("This unit of work already has an open scope; nested or parallel scopes are not supported.");
        }

        var context = await contextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Zwischen Context und Transaktion darf keine Abfrage liegen, sonst liefe sie ohne
            // die Sitzungsvariablen, die Interceptors beim Transaktionsbeginn setzen.
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
            _hasOpenScope = true;
            return new UnitOfWorkScope(context, transaction, () => _hasOpenScope = false);
        }
        catch
        {
            await context.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }
}
