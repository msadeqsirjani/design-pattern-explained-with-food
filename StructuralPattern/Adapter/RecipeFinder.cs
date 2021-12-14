using Dependencies;
using Newtonsoft.Json;
using System.Xml;

namespace StructuralPattern.Adapter;

public class RecipeFinder : IAdaptRecipeToJson
{
    private readonly IRecipeApi _recipeApi;

    public RecipeFinder(IRecipeApi recipeApi)
    {
        _recipeApi = recipeApi;
    }

    public async Task<string> GetRecipeAsJson(string recipeName)
    {
        var recipeXml = await _recipeApi.MakeHttpRequestForRecipe(recipeName);
            
        XmlDocument document = new();
        document.LoadXml(recipeXml);
            
        var jsonResult = JsonConvert.SerializeXmlNode(document);
            
        return jsonResult;
    }
}