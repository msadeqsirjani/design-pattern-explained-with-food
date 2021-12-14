using CreationalPattern.Builder;
using CreationalPattern.Builder.Builders;
using Dependencies;

ConsoleLogger logger = new();
Database database = new(Configuration.ConnectionString, logger);

BakeryPurchaseOrderBuilder bakeryPoBuilder = new();
CoffeePurchaseOrderBuilder coffeePoBuilder = new();

PurchaseOrderProcessor purchaseOrderProcessor = new(database, logger);

await purchaseOrderProcessor.GenerateWeeklyPurchaseOrder(bakeryPoBuilder);
await purchaseOrderProcessor.GenerateWeeklyPurchaseOrder(coffeePoBuilder);

PurchaseOrderBuilder customOrder = new();

var items = new List<LineItem>
{
    new("cups", 100, 1.0m),
    new("napkins", 250, 0.3m),
};

Supplier supplier = new("Jenkins", "contact@productivedev.com", "C.I. Jenkins");

customOrder.WithId("Custom_Order")
    .AtAddress("123 Riverrun Lane")
    .ForCompany("Productive Dev")
    .FromSupplier(supplier)
    .ForItems(items);

await purchaseOrderProcessor.SavePurchaseOrderToDatabase(customOrder);
purchaseOrderProcessor.PrintPurchaseOrder(customOrder);