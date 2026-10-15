namespace Example.Infrastructure.Database;

/// <summary>
/// Die zweite Mandantensperre: setzt nach jedem Transaktionsbeginn die PostgreSQL-Sitzungsvariable
/// <c>app.tenant_id</c>, die die Row-Level-Security-Policies lesen. <c>set_config(..., true)</c> hat
/// <c>SET LOCAL</c>-Semantik und verfällt mit dem Transaktionsende — unabhängig vom Verbindungspool.
/// Ohne Mandant bleibt die Variable ungesetzt und RLS liefert keine Zeilen.
/// </summary>
public sealed class TenantTransactionInterceptor(ITenantContext tenantContext) : DbTransactionInterceptor
{
    public override async ValueTask<DbTransaction> TransactionStartedAsync(
        DbConnection connection,
        TransactionEndEventData eventData,
        DbTransaction result,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(connection);

        if (tenantContext.TryGetTenantId(out var tenantId))
        {
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT set_config('app.tenant_id', @tenant_id, true)";
            command.Transaction = result;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "tenant_id";
            parameter.Value = tenantId.ToString();
            command.Parameters.Add(parameter);

            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        return await base.TransactionStartedAsync(connection, eventData, result, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Synchrone Transaktionen werden abgelehnt, statt blockierend auf den asynchronen Pfad zu warten
    /// oder still ohne Sitzungsvariable zu laufen.
    /// </summary>
    public override DbTransaction TransactionStarted(DbConnection connection, TransactionEndEventData eventData, DbTransaction result) =>
        throw new NotSupportedException("Tenant-scoped transactions must be started asynchronously.");
}
