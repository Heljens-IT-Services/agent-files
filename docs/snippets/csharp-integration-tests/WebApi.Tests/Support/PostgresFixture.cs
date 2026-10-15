namespace Example.WebApi.Tests.Support;

/// <summary>
/// Startet einen echten PostgreSQL-Container, wendet die EF-Migrationen als Superuser an und legt
/// danach die eingeschränkte Anwendungsrolle an. Tests verbinden sich über
/// <see cref="AppConnectionString"/>, damit Row-Level-Security tatsächlich greift — der Superuser
/// umgeht sie. Passwörter werden je Lauf zufällig erzeugt und nie über Umgebungsvariablen gereicht.
/// </summary>
public sealed class PostgresFixture : IAsyncLifetime
{
    private const string AppRole = "app_user";

    private readonly PostgreSqlContainer _container = new PostgreSqlBuilder("postgres:18-alpine").Build();
    private readonly string _appPassword = Guid.NewGuid().ToString("N");

    /// <summary>Verbindung mit der Anwendungsrolle ohne <c>BYPASSRLS</c>.</summary>
    public string AppConnectionString => new NpgsqlConnectionStringBuilder(_container.GetConnectionString())
    {
        Username = AppRole,
        Password = _appPassword,
    }.ConnectionString;

    /// <summary>Superuser-Verbindung; nur zum Herrichten von Testdaten mehrerer Mandanten.</summary>
    public string AdminConnectionString => _container.GetConnectionString();

    public async ValueTask InitializeAsync()
    {
        await _container.StartAsync().ConfigureAwait(false);

        var options = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(AdminConnectionString).UseSnakeCaseNamingConvention().Options;
        await using (var context = new AppDbContext(options, new FakeTenantContext()))
        {
            await context.Database.MigrateAsync().ConfigureAwait(false);
        }

        await CreateAppRoleAsync().ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync() => await _container.DisposeAsync().ConfigureAwait(false);

    private async Task CreateAppRoleAsync()
    {
        await using var connection = new NpgsqlConnection(AdminConnectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        // CREATE ROLE akzeptiert keine Parameter. Das Passwort besteht nur aus Hex-Zeichen einer Guid
        // und ist deshalb sicher einbettbar.
        await using var command = new NpgsqlCommand($"""
            CREATE ROLE {AppRole} LOGIN PASSWORD '{_appPassword}' NOSUPERUSER NOBYPASSRLS;
            GRANT USAGE ON SCHEMA public TO {AppRole};
            GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO {AppRole};
            GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO {AppRole};
            """, connection);
        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}
