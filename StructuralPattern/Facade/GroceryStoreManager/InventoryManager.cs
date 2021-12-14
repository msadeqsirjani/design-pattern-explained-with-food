using Dependencies;

namespace StructuralPattern.Facade.GroceryStoreManager;

public class InventoryManager : IInventoryManager
{
    private readonly ISendEmails _sendEmails;
    private readonly IQueue _queue;
    private readonly IDatabase _database;
    private readonly IRecipeApi _recipeApi;

    public InventoryManager(
        ISendEmails sendEmails,
        IQueue queue,
        IDatabase database,
        IRecipeApi recipeApi)
    {
        _sendEmails = sendEmails;
        _queue = queue;
        _database = database;
        _recipeApi = recipeApi;
    }

    public async Task ProcessCurrentInventoryReport()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Processing Inventory...");
        Thread.Sleep(1000);
        Console.WriteLine("Sending Report to buyers...");
        Thread.Sleep(1000);
        var email = new EmailMessage("buyers@example.com", "inventory report...");
        await _sendEmails.SendMessage(email);
        Thread.Sleep(500);
        Console.ResetColor();
    }

    public Task UpdateInventory()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Updating Inventory...");
        Thread.Sleep(1000);
        Console.WriteLine("Persisting Changes to Database...");
        Thread.Sleep(1000);
        Console.WriteLine("Database updated!");
        Console.ResetColor();
        return Task.CompletedTask;
    }
}