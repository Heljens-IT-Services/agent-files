namespace Example.Core.Persistence;

/// <summary>
/// Eine offene fachliche Unit of Work. Alle Repositories des Scopes arbeiten auf demselben Context
/// und derselben Transaktion. Ohne <see cref="CommitAsync"/> rollt
/// <see cref="IAsyncDisposable.DisposeAsync"/> zurück.
/// </summary>
public interface IUnitOfWorkScope : IAsyncDisposable
{
    /// <summary>Beispiel: das Repository des Fachbereichs Teams. Je Fachbereich eine Eigenschaft.</summary>
    ITeamRepository Teams { get; }

    /// <summary>Bestätigt die Transaktion.</summary>
    Task CommitAsync(CancellationToken cancellationToken);
}
