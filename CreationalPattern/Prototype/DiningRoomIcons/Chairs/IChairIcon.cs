namespace CreationalPattern.Prototype.DiningRoomIcons.Chairs;

public interface IChairIcon : IDeepCloneable
{
    bool HasSeatCushions { get; }
}