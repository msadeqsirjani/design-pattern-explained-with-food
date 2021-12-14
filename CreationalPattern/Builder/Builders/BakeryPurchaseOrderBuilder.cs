namespace CreationalPattern.Builder.Builders;

public class BakeryPurchaseOrderBuilder : IBuildsPurchaseOrders
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public Supplier Supplier { get; private set; }
    public List<LineItem> LineItems { get; private set; }

    public void SetId()
    {
        var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        Id = $"bakery_{date}";
    }

    public void SetAddress()
    {
        Address = "18 Riverrun Lane";
    }

    public void SetName()
    {
        Name = "Riverrun Dry Goods";
    }

    public void SetItems()
    {
        List<LineItem> orderItems = new()
        {
            new("bread flour", 4, 1.2m),
            new("salt", 2, 0.3m),
            new("yeast", 8, 0.75m),
        };

        LineItems = orderItems;
    }

    public void SetSupplier()
    {
        Supplier = new()
        {
            Name = "Riverrun Dry Goods",
            ContactName = "Wes",
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

        return new PurchaseOrder
        {
            Id = Id,
            CreatedOn = DateTime.UtcNow,
            Name = Name,
            Address = Address,
            LineItems = LineItems,
            Supplier = Supplier,
        };
    }

    public static implicit operator PurchaseOrder(BakeryPurchaseOrderBuilder builder)
    {
        return builder.BuildPurchaseOrder();
    }
}