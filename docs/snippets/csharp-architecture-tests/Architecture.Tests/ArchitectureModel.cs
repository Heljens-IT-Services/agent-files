namespace Example.Architecture.Tests;

/// <summary>
/// Gemeinsame Grundlage aller Architekturregeln: die einmal geladene Assembly-Architektur und das
/// Repository-Wurzelverzeichnis für Regeln, die den Quellbestand prüfen.
/// </summary>
internal static class ArchitectureModel
{
    /// <summary>Ankertypen je produktivem Projekt. Bei neuen Projekten hier ergänzen.</summary>
    public static readonly System.Reflection.Assembly CoreAssembly = typeof(Example.Core.Tenants.ITenantContext).Assembly;

    public static readonly System.Reflection.Assembly InfrastructureAssembly = typeof(Example.Infrastructure.Database.AppDbContext).Assembly;

    public static readonly System.Reflection.Assembly WebApiAssembly = typeof(Program).Assembly;

    public static readonly ArchUnitNET.Domain.Architecture Architecture = new ArchLoader()
        .LoadAssemblies(CoreAssembly, InfrastructureAssembly, WebApiAssembly)
        .Build();

    /// <summary>Das Verzeichnis <c>src</c> mit den produktiven Projekten.</summary>
    public static string SourceDirectory => Path.Combine(FindRepositoryRoot(), "src");

    private static string FindRepositoryRoot([CallerFilePath] string sourceFilePath = "")
    {
        var directory = new DirectoryInfo(Path.GetDirectoryName(sourceFilePath)!);
        while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "global.json")))
        {
            directory = directory.Parent;
        }

        return directory?.FullName ?? throw new InvalidOperationException("global.json not found; repository root not locatable.");
    }
}
