namespace StructuralPattern.Composite;

public class MixAndMatchBundle : TeaCarton
{
    private readonly List<TeaCarton> _subCartons = new();

    public override bool ContainsSubCarton() => false;

    public override int GetNumberOfServing() => _subCartons.Sum(x => x.GetNumberOfServing());

    public override void Add(TeaCarton carton)
    {
        Console.WriteLine($"Adding a carton of {carton} to the MixAndMatchBundle.");
        _subCartons.Add(carton);
    }

    public override void Remove(TeaCarton carton)
    {
        Console.WriteLine($"Removing a carton of {carton} to the MixAndMatchBundle.");
        _subCartons.Remove(carton);
    }

    public override void BuildBundle(Dictionary<TeaCarton, int> order)
    {
        foreach (var (teaCarton, quantity) in order)
        {
            for (var i = 0; i < quantity; i++)
            {
                _subCartons.Add(teaCarton);
            }
        }
    }
}