using Dependencies;

namespace StructuralPattern.Facade.GroceryStoreManager;

public class VendorNotifier : IVendorNotifier
{
    private readonly IDatabase _database;
    private readonly ISendEmails _mailer;

    public VendorNotifier(
        IDatabase database,
        ISendEmails mailer)
    {
        _database = database;
        _mailer = mailer;
    }

    public Task NotifyVendorOfCurrentStock(string vendor)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Notifying vendor: {vendor}");
        Console.ResetColor();

        _mailer.SendMessage(new EmailMessage("exampl@example.com", "..."));

        return Task.CompletedTask;
    }

    public List<string> GetVendorsForDepartment(string department)
    {
        _database.Connect();

        if (department == "produce")
        {
            return new List<string> {
                "Organic Orchards",
                "Mc-Kane Farm",
                "Pleasant Valley Farms"
            };
        }

        _database.Disconnect();

        return new List<string>();
    }
}