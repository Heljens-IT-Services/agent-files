namespace Example.Core.Persistence;

/// <summary>
/// Der Transaktions-Port für Use Cases: öffnet je fachlicher Operation genau einen
/// <see cref="IUnitOfWorkScope"/> mit eigenem Context und offener Transaktion. <c>Core</c> kennt
/// dadurch weder EF Core noch <c>DbContext</c>.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Erzeugt Context und Transaktion in einem Zug. Wirft <see cref="InvalidOperationException"/>,
    /// wenn bereits ein Scope offen ist — ein zweiter Scope liefe auf einer zweiten Verbindung und
    /// sähe weder deren Änderungen noch deren Sitzungsvariablen.
    /// </summary>
    Task<IUnitOfWorkScope> BeginAsync(CancellationToken cancellationToken);
}
