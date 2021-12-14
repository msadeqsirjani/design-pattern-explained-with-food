using Dependencies;

namespace CreationalPattern.AbstractFactory;

public class MealPlanService : IMealPlanService
{
    private readonly IMealPlanFactory _factory;
    private readonly ISendEmails _emailer;
    private readonly IApplicationLogger _logger;

    public MealPlanService(IMealPlanFactory factory, ISendEmails emailer, IApplicationLogger logger)
    {
        _factory = factory;
        _emailer = emailer;
        _logger = logger;
    }

    public async Task SendMealPlanToSubscriber(string subscriberEmail)
    {
        _logger.LogInfo($"--------------------------------------------------------------");
        var lunchMenu = _factory.GenerateLunchesMenu();
        var dessertMenu = _factory.GenerateDessertsMenu();
        var shoppingList = _factory.GenerateShoppingList();

        lunchMenu.PrintDescription();
        _logger.LogInfo($"== Compiling Lunches Menu for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
        lunchMenu.PrintMenu();

        dessertMenu.PrintDescription();
        _logger.LogInfo($"== Compiling Desserts Menu for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
        dessertMenu.PrintMenu();

        var ingredients = shoppingList.MakeShoppingList();

        var emailBody = string.Join(", ", ingredients);
        EmailMessage message = new(subscriberEmail, emailBody);

        _logger.LogInfo("== Sending Subscriber Email ==", ConsoleColor.Cyan);

        await _emailer.SendMessage(message);

        _logger.LogInfo($"--------------------------------------------------------------", ConsoleColor.Cyan);
    }
}