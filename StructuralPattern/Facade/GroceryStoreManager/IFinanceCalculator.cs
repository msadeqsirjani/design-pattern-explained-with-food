namespace StructuralPattern.Facade.GroceryStoreManager;

public interface IFinanceCalculator
{
    Task CalculateMonthTotalRevenue();
    Task CalculateMonthTotalRevenueForVendor(string vendor);
}