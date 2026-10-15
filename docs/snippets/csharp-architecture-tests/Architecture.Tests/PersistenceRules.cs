namespace Example.Architecture.Tests;

/// <summary>Prüft die Persistenzgrenze aus dem Unit-of-Work-Muster.</summary>
[Trait("Category", "Architecture")]
public sealed class PersistenceRules
{
    [Fact]
    public void Only_the_unit_of_work_consumes_the_db_context_factory() =>
        Classes().That().ResideInAssembly(ArchitectureModel.InfrastructureAssembly)
            .And().DoNotHaveName(nameof(Example.Infrastructure.Persistence.UnitOfWork))
            .And().DoNotHaveNameEndingWith("Module")
            .Should().NotDependOnAny(Types().That().HaveFullNameContaining("Microsoft.EntityFrameworkCore.IDbContextFactory"))
            .Check(ArchitectureModel.Architecture);

    [Fact]
    public void Web_api_does_not_reference_entity_framework_outside_composition() =>
        Types().That().ResideInAssembly(ArchitectureModel.WebApiAssembly)
            .And().DoNotResideInNamespaceMatching(@"^Example\.WebApi\.Configuration(\..+)?$")
            .Should().NotDependOnAny(Types().That().ResideInNamespaceMatching(@"^Microsoft\.EntityFrameworkCore(\..+)?$"))
            .Check(ArchitectureModel.Architecture);
}
