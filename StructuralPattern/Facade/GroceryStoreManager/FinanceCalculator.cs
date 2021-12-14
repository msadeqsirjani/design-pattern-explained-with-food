namespace StructuralPattern.Facade.GroceryStoreManager;

public class FinanceCalculator : IFinanceCalculator
{
    public Task CalculateMonthTotalRevenue()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Calculated revenue for the month");
        Console.ResetColor();
        return Task.CompletedTask;
    }

    public Task CalculateMonthTotalRevenueForVendor(string vendor)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Calculated revenue for the month for {vendor}: $100");
        Console.ResetColor();
        return Task.CompletedTask;
    }
}