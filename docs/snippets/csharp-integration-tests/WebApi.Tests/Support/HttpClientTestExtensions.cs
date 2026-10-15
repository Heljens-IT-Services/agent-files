namespace Example.WebApi.Tests.Support;

/// <summary>Setzt die Testheader des <see cref="TestAuthHandler"/> an einem Client.</summary>
public static class HttpClientTestExtensions
{
    /// <summary>Authentifiziert alle Anfragen des Clients als <paramref name="subject"/> im Mandanten
    /// <paramref name="tenantId"/> mit optionalen Rollen.</summary>
    public static HttpClient AsUser(this HttpClient client, string subject, Guid? tenantId = null, params string[] roles)
    {
        ArgumentNullException.ThrowIfNull(client);

        client.DefaultRequestHeaders.Add(TestAuthHandler.SubjectHeader, subject);
        if (tenantId is { } tenant)
        {
            client.DefaultRequestHeaders.Add(TestAuthHandler.TenantIdHeader, tenant.ToString());
        }

        if (roles.Length > 0)
        {
            client.DefaultRequestHeaders.Add(TestAuthHandler.RolesHeader, string.Join(',', roles));
        }

        return client;
    }
}
