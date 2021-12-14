namespace CreationalPattern.Prototype.DiningRoomIcons.Chairs;

public class CafeChairIcon : IChairIcon
{
    public bool HasSeatCushions => false;

    public IDeepCloneable DeepClone() => this.Clone();
}