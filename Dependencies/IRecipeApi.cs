namespace Dependencies;

public interface IRecipeApi
{
    Task<string> MakeHttpRequestForRecipe(string recipe);
}