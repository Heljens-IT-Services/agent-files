namespace Example.WebApi.Tests.Support;

/// <summary>
/// Hostet die WebApi in-process gegen die Testdatenbank. Ersetzt ausschließlich die
/// Authentifizierung durch <see cref="TestAuthHandler"/> und ergänzt den Abfragezähler; DI, Routing,
/// Middleware, Mandantenfilter und RLS bleiben die Produktionsverkabelung.
/// </summary>
public sealed class ApiFactory(string connectionString) : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:AppDb", connectionString);

        builder.ConfigureTestServices(services =>
        {
            services
                .AddAuthentication(TestAuthHandler.SchemeName)
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.SchemeName, _ => { });

            // Ergänzt die bestehende Context-Konfiguration um den Zähler, statt sie zu ersetzen.
            services.AddSingleton<TestQueryCounter>();
            services.ConfigureDbContext<AppDbContext>(
                (serviceProvider, options) => options.AddInterceptors(
                    new CountingDbCommandInterceptor(serviceProvider.GetRequiredService<TestQueryCounter>())),
                ServiceLifetime.Scoped);
        });
    }
}
