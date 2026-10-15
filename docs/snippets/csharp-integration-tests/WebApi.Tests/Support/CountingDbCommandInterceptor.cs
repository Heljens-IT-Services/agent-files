namespace Example.WebApi.Tests.Support;

/// <summary>Erhöht <see cref="TestQueryCounter"/> bei jedem Reader-, NonQuery- und Scalar-Befehl.</summary>
public sealed class CountingDbCommandInterceptor(TestQueryCounter counter) : DbCommandInterceptor
{
    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
    {
        counter.Increment();
        return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        counter.Increment();
        return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
        DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
    {
        counter.Increment();
        return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        counter.Increment();
        return base.ReaderExecuting(command, eventData, result);
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        counter.Increment();
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override InterceptionResult<object> ScalarExecuting(
        DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    {
        counter.Increment();
        return base.ScalarExecuting(command, eventData, result);
    }
}
