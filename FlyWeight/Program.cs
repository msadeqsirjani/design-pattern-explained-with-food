using StructuralPattern.FlyWeight;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Starting City Planning Simulation for new Grocery Store Location");
Console.WriteLine("--------------------------------------------------------------------");

var rng = new Random();
const int simulationPopulationSize = 100000;
const int simulationHeightWidth = 100;
const int flyweightBankSize = 5;

var transportModes = new TransportationMethod[]
{
    new("walk", 1),
    new("bicycle", 2)
};

var subdivisions = new Subdivision[]
{
    new("north_side", 120),
    new("east_side", 210),
    new("downtown", 300),
    new("lakeside", 310)
};

var neighborhoodMembers = new NeighborhoodMember[flyweightBankSize];

for (var i = 0; i < flyweightBankSize; i++)
{
    NeighborhoodMember member = new();
    var (x, y) = GetRandomCoordinates(rng, simulationHeightWidth);
    var modeOfTransport = GetRandomTransportation(rng, transportModes);
    var subdivision = GetRandomSubdivision(rng, subdivisions);
    member.PositionX = x;
    member.PositionY = y;
    member.TransportationMethod = modeOfTransport;
    member.Subdivision = subdivision;
    neighborhoodMembers[i] = member;
}

SharedStateFactory factory = new(neighborhoodMembers);
factory.DisplayCache();

for (var i = 0; i < simulationPopulationSize; i++)
{
    NeighborhoodMember member = new();
    var (item1, item2) = GetRandomCoordinates(rng, simulationHeightWidth);
    var modeOfTransport = GetRandomTransportation(rng, transportModes);
    var subdivision = GetRandomSubdivision(rng, subdivisions);
    member.PositionX = item1;
    member.PositionY = item2;
    member.TransportationMethod = modeOfTransport;
    member.Subdivision = subdivision;
    AddMemberToSimulation(factory, member, i);
}

Console.WriteLine("Simulation Complete.");
Console.WriteLine("--------------------------------------------------------------------");


static void AddMemberToSimulation(SharedStateFactory factory, NeighborhoodMember member, int i)
{

    var flyweight = factory.GetFlyweight(new NeighborhoodMember
    {
        TransportationMethod = member.TransportationMethod,
        Subdivision = member.Subdivision
    });

    if (i % 10000 != 0) return;
    Console.WriteLine($"Iteration # {i}");
    flyweight.RenderPosition(member);
}

static Subdivision GetRandomSubdivision(Random rng, IReadOnlyList<Subdivision> subdivisions)
{
    var randomIndex = rng.Next(subdivisions.Count);
    return subdivisions[randomIndex];
}

static TransportationMethod GetRandomTransportation(Random rng, IReadOnlyList<TransportationMethod> transportMethods)
{
    var randomIndex = rng.Next(transportMethods.Count);
    return transportMethods[randomIndex];
}

static Tuple<int, int> GetRandomCoordinates(Random rng, int limit)
{
    return new Tuple<int, int>(rng.Next(0, limit), rng.Next(0, limit));
}