namespace Example.Architecture.Tests;

/// <summary>Prüft Controller-Bauform und HTTP-Verträge der WebApi.</summary>
[Trait("Category", "Architecture")]
public sealed class ContractRules
{
    [Fact]
    public void Controllers_derive_from_controller_base_and_carry_the_api_controller_attribute() =>
        Classes().That().ResideInAssembly(ArchitectureModel.WebApiAssembly).And().HaveNameEndingWith("Controller")
            .Should().BeAssignableTo(typeof(ControllerBase))
            .AndShould().HaveAnyAttributes(typeof(ApiControllerAttribute))
            .Check(ArchitectureModel.Architecture);

    /// <summary>
    /// Jeder Controller implementiert einen aus <c>contracts/api.yaml</c> erzeugten Vertrag; Endpunkte
    /// am Vertrag vorbei sind damit ausgeschlossen.
    /// </summary>
    [Fact]
    public void Controllers_implement_a_generated_contract() =>
        Classes().That().ResideInAssembly(ArchitectureModel.WebApiAssembly).And().HaveNameEndingWith("Controller")
            .Should().FollowCustomCondition(
                controller => controller is Class { BaseClass: { } baseClass } && IsGeneratedContract(baseClass),
                "von einer erzeugten Vertragsbasis *ControllerBase erben",
                "erbt nicht von einer erzeugten Vertragsbasis")
            .Check(ArchitectureModel.Architecture);

    /// <summary>Jede erzeugte Vertragsbasis hat genau eine Implementierung, sonst fehlen Endpunkte zur Laufzeit.</summary>
    [Fact]
    public void Every_generated_contract_has_exactly_one_controller()
    {
        var controllers = ArchitectureModel.Architecture.Classes
            .Where(type => !type.IsAbstract.GetValueOrDefault() && type.BaseClass is { } baseClass && IsGeneratedContract(baseClass))
            .ToList();

        var violations = ArchitectureModel.Architecture.Classes
            .Where(IsGeneratedContract)
            .Select(contract => (Contract: contract.Name, Count: controllers.Count(controller => controller.BaseClass!.Equals(contract))))
            .Where(entry => entry.Count != 1)
            .Select(entry => $"{entry.Contract}: {entry.Count} Implementierungen");

        violations.Should().BeEmpty("jede Vertragsbasis braucht genau einen Controller");
    }

    private static bool IsGeneratedContract(Class type) =>
        type.Namespace.FullName.EndsWith(".Contracts.Generated.Controllers", StringComparison.Ordinal)
        && type.Name.EndsWith("ControllerBase", StringComparison.Ordinal);

    /// <summary>
    /// Kein Vertragstyp gibt eine technische Integer-Id nach außen. Erfasst jeden Namensraum
    /// <c>…WebApi…Contracts</c>, also auch Vertragsordner in Fachbereichsordnern; Eigenschaften wie
    /// <c>Page</c> oder <c>PageSize</c> bleiben erlaubt, weil sie nicht auf <c>Id</c> enden.
    /// </summary>
    [Fact]
    public void No_contract_exposes_an_integer_identity() =>
        Types().That().ResideInNamespaceMatching(@"^Example\.WebApi(\..+)?\.Contracts(\..+)?$")
            .Should().FollowCustomCondition(
                type => !type.Members.OfType<PropertyMember>().Any(IsIntegerIdentity),
                "keine Eigenschaft *Id vom Typ int, int?, long oder long? besitzen; extern wird eine Guid-Business-Id verwendet",
                "trägt eine Integer-Id-Eigenschaft")
            .Check(ArchitectureModel.Architecture);

    private static bool IsIntegerIdentity(PropertyMember property)
    {
        string[] integerTypes = [typeof(int).FullName!, typeof(int?).FullName!, typeof(long).FullName!, typeof(long?).FullName!];
        return property.Name.EndsWith("Id", StringComparison.Ordinal) && integerTypes.Contains(property.Type.FullName, StringComparer.Ordinal);
    }
}
