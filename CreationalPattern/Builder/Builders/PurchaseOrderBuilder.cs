namespace CreationalPattern.Builder.Builders;

public class PurchaseOrderBuilder : IPurchaseOrderBuilder
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public Supplier Supplier { get; private set; }
    public List<LineItem> LineItems { get; private set; }

    public IPurchaseOrderBuilder WithId(string id)
    {
        Id = id;
        return this;
    }

    public IPurchaseOrderBuilder AtAddress(string address)
    {
        Address = address;
        return this;
    }

    public IPurchaseOrderBuilder ForCompany(string name)
    {
        Name = name;
        return this;
    }

    public IPurchaseOrderBuilder ForItems(List<LineItem> lineItems)
    {
        LineItems = lineItems;
        return this;
    }

    public IPurchaseOrderBuilder FromSupplier(Supplier supplier)
    {
        Supplier = supplier;
        return this;
    }

    public PurchaseOrder BuildPurchaseOrder()
    {
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

    public static implicit operator PurchaseOrder(PurchaseOrderBuilder builder)
    {
        return builder.BuildPurchaseOrder();
    }
}