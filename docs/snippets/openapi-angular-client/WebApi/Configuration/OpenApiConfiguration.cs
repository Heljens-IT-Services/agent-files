namespace Example.WebApi.Configuration;

/// <summary>
/// Registriert Controller und OpenAPI so, dass <c>contracts/api.json</c> bei unverändertem Code
/// byteidentisch bleibt: ausschließlich <c>application/json</c> und deterministisch sortierte Pfade
/// und Tags.
/// </summary>
public static class OpenApiConfiguration
{
    private const string JsonContentType = "application/json";

    public static IServiceCollection AddControllersWithStableContract(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            // Ohne diese Filter listet der Vertrag zusätzlich text/plain, text/json und application/*+json.
            options.Filters.Add(new ProducesAttribute(JsonContentType));
            options.Filters.Add(new ConsumesAttribute(JsonContentType));
        });

        services.AddOpenApi(options => options.AddDocumentTransformer((document, _, _) =>
        {
            SortPathsAndTags(document);
            RestrictRequestBodiesToJson(document);
            return Task.CompletedTask;
        }));

        return services;
    }

    private static void SortPathsAndTags(OpenApiDocument document)
    {
        var sortedPaths = new OpenApiPaths();
        foreach (var (path, pathItem) in document.Paths.OrderBy(entry => entry.Key, StringComparer.Ordinal))
        {
            sortedPaths[path] = pathItem;
        }

        document.Paths = sortedPaths;

        if (document.Tags is { Count: > 0 } tags)
        {
            // HashSet behält ohne Entfernungen die Einfügereihenfolge bei.
            document.Tags = new HashSet<OpenApiTag>(tags.OrderBy(tag => tag.Name, StringComparer.Ordinal));
        }
    }

    private static void RestrictRequestBodiesToJson(OpenApiDocument document)
    {
        var jsonRequestBodies = document.Paths.Values
            .Where(pathItem => pathItem.Operations is not null)
            .SelectMany(pathItem => pathItem.Operations!.Values)
            .Select(operation => operation.RequestBody?.Content)
            .OfType<IDictionary<string, OpenApiMediaType>>()
            .Where(content => content.ContainsKey(JsonContentType));

        foreach (var content in jsonRequestBodies)
        {
            foreach (var contentType in content.Keys.Where(key => !string.Equals(key, JsonContentType, StringComparison.Ordinal)).ToList())
            {
                content.Remove(contentType);
            }
        }
    }
}
