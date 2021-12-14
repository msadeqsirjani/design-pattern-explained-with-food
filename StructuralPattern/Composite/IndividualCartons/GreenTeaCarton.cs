namespace StructuralPattern.Composite.IndividualCartons;

public class GreenTeaCarton : TeaCarton
{
    public override bool ContainsSubCarton() => false;

    public override int GetNumberOfServing() => 24;
}