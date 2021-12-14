namespace CreationalPattern.Prototype.DiningRoomIcons.Tables;

public class RestaurantTableIcon : ITableIcon
{
    public IDeepCloneable DeepClone() => this.Clone();

    public int GetTableNumberOfLegs() => 4;

    public string GetTableTopShape() => "rectangle";
}