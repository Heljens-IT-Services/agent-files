namespace Example.WebApi.Tests.Support;

/// <summary>
/// Teilt genau einen <see cref="PostgresFixture"/> zwischen allen Testklassen der Collection, statt je
/// Klasse einen Container zu starten. Testklassen treten mit <c>[Collection(PostgresCollectionDefinition.Name)]</c> bei.
/// </summary>
[CollectionDefinition(Name)]
public sealed class PostgresCollectionDefinition : ICollectionFixture<PostgresFixture>
{
    public const string Name = "Postgres";
}
