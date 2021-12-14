namespace StructuralPattern.FlyWeight;

public class NeighborhoodMemberSharedState
{

    private readonly NeighborhoodMember _sharedState;

    public NeighborhoodMemberSharedState(NeighborhoodMember person)
    {
        _sharedState = person;
    }

    public void RenderPosition(NeighborhoodMember uniqueState)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Adding new member to ({uniqueState.PositionX}, {uniqueState.PositionY})");
        Console.WriteLine($"Shared State ({_sharedState.TransportationMethod}, {_sharedState.Subdivision})");
        Console.ResetColor();
    }
}