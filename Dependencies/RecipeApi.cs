using System.Xml.Serialization;
using System.Xml;

namespace Dependencies;

public class RecipeApi : IRecipeApi
{
    private readonly Dictionary<string, Recipe> _database;
    private readonly IApplicationLogger _logger;

    public RecipeApi(IApplicationLogger logger)
    {
        _database = GenerateDatabase();
        _logger = logger;
    }

    public async Task<string> MakeHttpRequestForRecipe(string recipe)
    {
        _logger.LogInfo($"Making HTTP request returning XML for: {recipe}", ConsoleColor.Magenta);
           
        await Task.Delay(2000);
        var databaseResponse = _database[recipe];
        XmlSerializer xmlSerializer = new(databaseResponse.GetType());
            
        await using StringWriter stringWriter = new();
        await using var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Async = true });
            
        xmlSerializer.Serialize(writer, databaseResponse);
            
        return stringWriter.ToString();
    }

    private static Dictionary<string, Recipe> GenerateDatabase()
    {
        return new()
        {
            { "mashed_potatoes", new Recipe("Mashed Potatoes", 30) },
            { "green_beans", new Recipe("Steamed Green Beans", 10) },
            { "red_curry", new Recipe("Red Curry", 60) },
        };
    }
}