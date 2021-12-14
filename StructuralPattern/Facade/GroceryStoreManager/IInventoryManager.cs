namespace StructuralPattern.Facade.GroceryStoreManager;

public interface IInventoryManager
{
    Task ProcessCurrentInventoryReport();
    Task UpdateInventory();
}