namespace StructuralPattern.Composite.IndividualCartons;

public class WhiteTeaCarton : TeaCarton
{
    public override bool ContainsSubCarton() => false;

    public override int GetNumberOfServing() => 60;
}