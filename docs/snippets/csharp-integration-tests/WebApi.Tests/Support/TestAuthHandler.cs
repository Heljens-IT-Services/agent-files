namespace Example.WebApi.Tests.Support;

/// <summary>
/// Ersetzt die JWT-Bearer-Authentifizierung in Tests. Claims entstehen aus Testheadern statt aus
/// einem validierten Token:
/// <list type="bullet">
/// <item>ohne <see cref="SubjectHeader"/>: unauthentifiziert (401 wie ohne Token),</item>
/// <item>mit <see cref="SubjectHeader"/>: authentifiziert, optional mit Mandant und Rollen.</item>
/// </list>
/// Nur im Testprojekt verwenden; der Handler darf nie in Produktionscode registriert werden.
/// </summary>
public sealed class TestAuthHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    public const string SchemeName = "Test";
    public const string SubjectHeader = "X-Test-Subject";
    public const string TenantIdHeader = "X-Test-Tenant-Id";
    public const string RolesHeader = "X-Test-Roles";

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var subject = Request.Headers[SubjectHeader].ToString();
        if (string.IsNullOrEmpty(subject))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, subject) };

        var tenantId = Request.Headers[TenantIdHeader].ToString();
        if (!string.IsNullOrEmpty(tenantId))
        {
            claims.Add(new Claim("tenant_id", tenantId));
        }

        var roles = Request.Headers[RolesHeader].ToString()
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, SchemeName));
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, SchemeName)));
    }
}
