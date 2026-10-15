namespace Example.Infrastructure.Database;

/// <summary>
/// Die zweite Mandantensperre: setzt nach jedem Transaktionsbeginn die PostgreSQL-Sitzungsvariablen
/// <c>app.tenant_id</c> (Business-Id) und <c>app.tenant_key</c> (interner Schlüssel), die die
/// Row-Level-Security-Policies lesen. <c>set_config(..., true)</c> hat <c>SET LOCAL</c>-Semantik und
/// verfällt mit dem Transaktionsende — unabhängig vom Verbindungspool.
///
/// <para>
/// Den internen Schlüssel löst der Interceptor höchstens einmal je Scope über <c>tenants</c> auf und
/// hinterlegt ihn per <see cref="ITenantAssignment"/>. Die Reihenfolge ist zwingend: erst
/// <c>app.tenant_id</c>, dann die Abfrage, weil die Policy auf <c>tenants</c> nur die eigene Zeile
/// freigibt. Ohne Mandant oder ohne passende Zeile bleiben die Variablen ungesetzt und RLS liefert
/// keine Zeilen.
/// </para>
/// </summary>
public sealed class TenantTransactionInterceptor(ITenantContext tenantContext, ITenantAssignment tenantAssignment) : DbTransactionInterceptor
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
            await SetSessionVariableAsync(connection, result, "app.tenant_id", tenantId.ToString(), cancellationToken).ConfigureAwait(false);

            var tenantKey = await ResolveTenantKeyAsync(connection, result, tenantId, cancellationToken).ConfigureAwait(false);
            if (tenantKey is { } key)
            {
                await SetSessionVariableAsync(connection, result, "app.tenant_key", key.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);
            }
        }

        return await base.TransactionStartedAsync(connection, eventData, result, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Synchrone Transaktionen werden abgelehnt, statt blockierend auf den asynchronen Pfad zu warten
    /// oder still ohne Sitzungsvariablen zu laufen.
    /// </summary>
    public override DbTransaction TransactionStarted(DbConnection connection, TransactionEndEventData eventData, DbTransaction result) =>
        throw new NotSupportedException("Tenant-scoped transactions must be started asynchronously.");

    private async Task<int?> ResolveTenantKeyAsync(DbConnection connection, DbTransaction transaction, Guid tenantId, CancellationToken cancellationToken)
    {
        if (tenantContext.TryGetTenantKey(out var knownTenantKey))
        {
            return knownTenantKey;
        }

        var command = CreateCommand(connection, transaction, "SELECT id FROM tenants WHERE business_id = @value", tenantId);
        object? scalar;
        await using (command.ConfigureAwait(false))
        {
            scalar = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
        }

        if (scalar is not int tenantKey)
        {
            return null;
        }

        tenantAssignment.AssignTenantKey(tenantKey);
        return tenantKey;
    }

    private static async Task SetSessionVariableAsync(
        DbConnection connection, DbTransaction transaction, string name, string value, CancellationToken cancellationToken)
    {
        // Der Variablenname ist eine Konstante dieses Typs, nie eine Eingabe; nur der Wert ist Parameter.
        var command = CreateCommand(connection, transaction, $"SELECT set_config('{name}', @value, true)", value);
        await using (command.ConfigureAwait(false))
        {
            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private static DbCommand CreateCommand(DbConnection connection, DbTransaction transaction, string commandText, object value)
    {
        var command = connection.CreateCommand();
        command.CommandText = commandText;
        command.Transaction = transaction;

        var parameter = command.CreateParameter();
        parameter.ParameterName = "value";
        parameter.Value = value;
        command.Parameters.Add(parameter);

        return command;
    }
}
