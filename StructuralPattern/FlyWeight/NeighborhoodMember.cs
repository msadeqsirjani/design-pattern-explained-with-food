namespace StructuralPattern.FlyWeight;

public class NeighborhoodMember
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public TransportationMethod? TransportationMethod { get; set; }
    public Subdivision? Subdivision { get; set; }
}