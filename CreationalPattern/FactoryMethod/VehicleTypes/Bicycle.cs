namespace CreationalPattern.FactoryMethod.VehicleTypes;

public class Bicycle : IDeliveryFood
{
    public string Color { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Style { get; set; }

    public Task Delivery(int orderId)
    {
        return Task.FromResult($"Delivered Order: {orderId} via bicycle!");
    }
}