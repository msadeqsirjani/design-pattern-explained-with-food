namespace CreationalPattern.Prototype.DiningRoomIcons.Tables;

public interface ITableIcon : IDeepCloneable
{
    string GetTableTopShape();
    int GetTableNumberOfLegs();
}