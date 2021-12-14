namespace StructuralPattern.Facade.GroceryStoreManager;

public interface IVendorNotifier
{
    Task NotifyVendorOfCurrentStock(string vendor);
    List<string> GetVendorsForDepartment(string dept);
}