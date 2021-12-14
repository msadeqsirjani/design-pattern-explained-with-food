namespace CreationalPattern.Builder.Builders;

public class CoffeePurchaseOrderBuilder : IBuildsPurchaseOrders
{

    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public Supplier Supplier { get; private set; }
    public List<LineItem> LineItems { get; private set; }

    public void SetId()
    {
        var date = DateTime.UtcNow.ToString("yy-MMM-dd");
        Id = $"coffee_{date}";
    }

    public void SetAddress()
    {
        Address = "23 Riverrun Lane";
    }

    public void SetName()
    {
        Name = "Riverrun Roasters";
    }

    public void SetItems()
    {
        List<LineItem> orderItems = new()
        {
            new("light roast", 3, 30.0m),
            new("dark roast", 3, 30.0m),
        };

        LineItems = orderItems;
    }

    public void SetSupplier()
    {
        Supplier = new()
        {
            Name = "Riverrun Roasters",
            ContactName = "Sam",
            Email = "contact@productivedev.com"
        };
    }

    public PurchaseOrder BuildPurchaseOrder()
    {
        SetId();
        SetAddress();
        SetName();
        SetItems();
        SetSupplier();

        return new()
        {
            Id = Id,
            CreatedOn = DateTime.UtcNow,
            Name = Name,
            Address = Address,
            LineItems = LineItems,
            Supplier = Supplier,
        };
    }

    public static implicit operator PurchaseOrder(CoffeePurchaseOrderBuilder builder)
    {
        return builder.BuildPurchaseOrder();
    }
}