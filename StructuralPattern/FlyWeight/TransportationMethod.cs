namespace StructuralPattern.FlyWeight;

public record TransportationMethod(string Name, int InfrastructureCost)
{
    public string Name { get; set; } = Name;
    public int InfrastructureCost { get; set; } = InfrastructureCost;
}