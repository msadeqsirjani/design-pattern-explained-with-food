namespace StructuralPattern.FlyWeight;

public class SharedStateFactory
{
    private readonly Dictionary<string, NeighborhoodMemberSharedState> _flyweights = new();

    public SharedStateFactory(params NeighborhoodMember[] members)
    {
        Console.WriteLine("Initializing Shared State (Flyweight) Factory");
        foreach (var member in members)
        {
            _flyweights[GetSharedStateHash(member)] = new NeighborhoodMemberSharedState(member);
        }
    }
    private static string GetSharedStateHash(NeighborhoodMember key)
    {
        var elements = new List<object?>
        {
            key.Subdivision,
            key.TransportationMethod,
        };
        return string.Join(":", elements);
    }

    public NeighborhoodMemberSharedState GetFlyweight(NeighborhoodMember sharedState)
    {
        var key = GetSharedStateHash(sharedState);
        if (_flyweights.ContainsKey(key))
        {
            return _flyweights[key];
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nFlyweightFactory: Can't find a flyweight, creating new one.\n");
        Console.ResetColor();
        _flyweights[key] = new NeighborhoodMemberSharedState(sharedState);
        return _flyweights[key];
    }

    public void DisplayCache()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"== Shared State Cache:\n{string.Join("\n", _flyweights.Keys)}");
        Console.ResetColor();
    }
}