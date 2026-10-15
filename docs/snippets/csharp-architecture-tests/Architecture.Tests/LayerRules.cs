namespace Example.Architecture.Tests;

/// <summary>Prüft Namensräume und die Referenzrichtung <c>WebApi -&gt; Infrastructure -&gt; Core</c>.</summary>
[Trait("Category", "Architecture")]
public sealed class LayerRules
{
    private static readonly IObjectProvider<IType> InfrastructureTypes =
        Types().That().ResideInAssembly(ArchitectureModel.InfrastructureAssembly).As("Infrastructure");

    private static readonly IObjectProvider<IType> WebApiTypes =
        Types().That().ResideInAssembly(ArchitectureModel.WebApiAssembly).As("WebApi");

    [Fact]
    public void Core_types_reside_in_the_core_namespace() =>
        Types().That().ResideInAssembly(ArchitectureModel.CoreAssembly)
            .Should().ResideInNamespaceMatching(@"^Example\.Core(\..+)?$")
            .Check(ArchitectureModel.Architecture);

    [Fact]
    public void Core_depends_neither_on_infrastructure_nor_on_web_api() =>
        Types().That().ResideInAssembly(ArchitectureModel.CoreAssembly)
            .Should().NotDependOnAny(InfrastructureTypes)
            .AndShould().NotDependOnAny(WebApiTypes)
            .Check(ArchitectureModel.Architecture);

    [Fact]
    public void Core_does_not_depend_on_entity_framework_or_asp_net_core() =>
        Types().That().ResideInAssembly(ArchitectureModel.CoreAssembly)
            .Should().NotDependOnAny(Types().That().ResideInNamespaceMatching(@"^Microsoft\.(EntityFrameworkCore|AspNetCore)(\..+)?$"))
            .Check(ArchitectureModel.Architecture);

    [Fact]
    public void Infrastructure_does_not_depend_on_web_api() =>
        Types().That().ResideInAssembly(ArchitectureModel.InfrastructureAssembly)
            .Should().NotDependOnAny(WebApiTypes)
            .Check(ArchitectureModel.Architecture);

    [Fact]
    public void Controllers_do_not_depend_on_infrastructure_or_entity_framework() =>
        Classes().That().HaveNameEndingWith("Controller")
            .Should().NotDependOnAny(InfrastructureTypes)
            .AndShould().NotDependOnAny(Types().That().ResideInNamespaceMatching(@"^Microsoft\.EntityFrameworkCore(\..+)?$"))
            .Check(ArchitectureModel.Architecture);
}
