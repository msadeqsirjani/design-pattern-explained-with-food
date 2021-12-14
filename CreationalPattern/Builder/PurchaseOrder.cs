namespace CreationalPattern.Builder;

public class PurchaseOrder
{
    public string Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Supplier Supplier { get; set; }
    public IEnumerable<LineItem> LineItems { get; set; } 

    public decimal TotalCost => LineItems.Select(item => item.Quantity * item.UnitCost).Sum();
}