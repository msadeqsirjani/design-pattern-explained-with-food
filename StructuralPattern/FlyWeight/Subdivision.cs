namespace StructuralPattern.FlyWeight;

public record Subdivision(string Name, int MedianHousePrice)
{
    public string Name { get; set; } = Name;
    public int MedianHousePrice { get; set; } = MedianHousePrice;
}