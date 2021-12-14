namespace StructuralPattern.Adapter;

public interface IAdaptRecipeToJson
{
    Task<string> GetRecipeAsJson(string recipeName);
}