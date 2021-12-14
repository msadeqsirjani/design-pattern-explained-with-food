namespace CreationalPattern.Prototype.DiningRoomIcons.Tables;

public class CafeTableIcon : ITableIcon
{
    public IDeepCloneable DeepClone() => this.Clone();

    public int GetTableNumberOfLegs() => 3;

    public string GetTableTopShape() => "round";
}