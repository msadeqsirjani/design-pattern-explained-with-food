using CreationalPattern.AbstractFactory;
using CreationalPattern.AbstractFactory.MealPlanFactories;
using Dependencies;

ConsoleLogger logger = new();

logger.LogInfo("Please enter customer email.");
var customerEmail = Console.ReadLine();

if (string.IsNullOrWhiteSpace(customerEmail))
{
    logger.LogInfo("Error reading customer email.");
    return;
}

try
{
    var dietType = GetCustomerDietFromDatabase(customerEmail);
    var mealPlanFactory = GetFactoryForDietType(dietType, logger);
    ISendEmails emailer = new Emailer(logger);
    IMealPlanService mealPlanService = new MealPlanService(mealPlanFactory, emailer, logger);
    await mealPlanService.SendMealPlanToSubscriber(customerEmail);

}
catch (Exception ex)
{
    logger.LogError($"{$"Error processing the meal plan: {ex.Message}, {ex.StackTrace}"}");
    return;
}


static string GetCustomerDietFromDatabase(string customerEmail)
{
    return customerEmail == "msadeqsirjani@example.com"
        ? "keto"
        : "vegetarian";
}

static IMealPlanFactory GetFactoryForDietType(string dietType, IApplicationLogger logger)
{
    return dietType switch
    {
        "keto" => new KetoMealPlanFactory(logger),
        "vegetarian" => new VegetarianMealPlanFactory(logger),
        _ => new VegetarianMealPlanFactory(logger)
    };
}