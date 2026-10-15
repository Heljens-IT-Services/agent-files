namespace Example.Core.Persistence;

/// <summary>
/// Kapselt Öffnen, Bestätigen und Verwerfen einer Unit of Work, damit Use Cases keinen
/// <c>try</c>/<c>finally</c>-Rahmen wiederholen.
/// </summary>
public static class UnitOfWorkExtensions
{
    /// <summary>Führt <paramref name="work"/> in einer Unit of Work aus und bestätigt sie bei Erfolg.
    /// Eine Exception verwirft die Transaktion.</summary>
    public static async Task<T> ExecuteAsync<T>(
        this IUnitOfWork unitOfWork, Func<IUnitOfWorkScope, CancellationToken, Task<T>> work, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);
        ArgumentNullException.ThrowIfNull(work);

        var scope = await unitOfWork.BeginAsync(cancellationToken).ConfigureAwait(false);
        await using (scope.ConfigureAwait(false))
        {
            var result = await work(scope, cancellationToken).ConfigureAwait(false);
            await scope.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }

    /// <summary>Wie <see cref="ExecuteAsync{T}"/>, bestätigt aber nur bei <see cref="Result{T}.Succeeded"/>.
    /// Ein fachlicher Fehler verwirft alle Änderungen des Scopes.</summary>
    public static async Task<Result<T>> ExecuteResultAsync<T>(
        this IUnitOfWork unitOfWork, Func<IUnitOfWorkScope, CancellationToken, Task<Result<T>>> work, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);
        ArgumentNullException.ThrowIfNull(work);

        var scope = await unitOfWork.BeginAsync(cancellationToken).ConfigureAwait(false);
        await using (scope.ConfigureAwait(false))
        {
            var result = await work(scope, cancellationToken).ConfigureAwait(false);
            if (result.Succeeded)
            {
                await scope.CommitAsync(cancellationToken).ConfigureAwait(false);
            }

            return result;
        }
    }
}
