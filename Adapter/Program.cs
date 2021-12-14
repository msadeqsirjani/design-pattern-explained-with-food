using Dependencies;
using StructuralPattern.Adapter;

ConsoleLogger logger = new();

logger.LogInfo("Aggregating Recipes from the API...");

RecipeApi recipesApi = new(logger);

RecipeFinder recipeFinder = new(recipesApi);

var mashedPotatoesResult = recipeFinder.GetRecipeAsJson("mashed_potatoes");
var greenBeansResult = recipeFinder.GetRecipeAsJson("green_beans");
var redCurryResult = recipeFinder.GetRecipeAsJson("red_curry");

List<Task<string>> tasks = new()
{
    mashedPotatoesResult,
    greenBeansResult,
    redCurryResult
};

await Task.WhenAll(tasks);

PrintJsonRecipes(tasks);

static void PrintJsonRecipes(IEnumerable<Task<string>> recipes)
{
    ConsoleLogger logger = new();
    foreach (var recipe in recipes)
    {
        logger.LogInfo(recipe.Result);
    }
}