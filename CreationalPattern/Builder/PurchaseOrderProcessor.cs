using Dependencies;
using Newtonsoft.Json;

namespace CreationalPattern.Builder;

public class PurchaseOrderProcessor
{
    private readonly IDatabase _database;
    private readonly IApplicationLogger _logger;

    public PurchaseOrderProcessor(IDatabase database, IApplicationLogger logger)
    {
        _database = database;
        _logger = logger;
    }

    public async Task GenerateWeeklyPurchaseOrder(IBuildsPurchaseOrders purchaseOrderBuilder)
    {
        var purchaseOrder = purchaseOrderBuilder.BuildPurchaseOrder();
            
        PrintPurchaseOrder(purchaseOrder);
            
        await SavePurchaseOrderToDatabase(purchaseOrder);
    }

    public async Task SavePurchaseOrderToDatabase(PurchaseOrder purchaseOrder)
    {
        _logger.LogInfo($"Saving Purchase Order ({purchaseOrder.Id}) to database");
        await _database.Connect();
        await _database.WriteData(purchaseOrder.Id, JsonConvert.SerializeObject(purchaseOrder));
        await _database.Disconnect();
    }

    public void PrintPurchaseOrder(PurchaseOrder order)
    {
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"== Generated Purchase Order", ConsoleColor.Blue);
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"== ID: {order.Id} | {order.CreatedOn}", ConsoleColor.Blue);
        _logger.LogInfo($"== {order.Name}", ConsoleColor.Blue);
        _logger.LogInfo($"== {order.Address}", ConsoleColor.Blue);
        _logger.LogInfo($"----------------------------------------");
        _logger.LogInfo($"== Supplier: {order.Supplier.Name}", ConsoleColor.Blue);
        foreach (var item in order.LineItems)
        {
            _logger.LogInfo($"  - {item.Quantity} x {item.Name} @{Math.Round(item.UnitCost, 2)})", ConsoleColor.DarkBlue);
        }
        _logger.LogInfo($"== Purchase order Total: $ {Math.Round(order.TotalCost, 2) }", ConsoleColor.Blue);
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
    }
}