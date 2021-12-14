namespace CreationalPattern.Builder;

public struct LineItem
{
    public LineItem(string name, int auantity, decimal unitCost) => (Name, Quantity, UnitCost) = (name, auantity, unitCost);

    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
}