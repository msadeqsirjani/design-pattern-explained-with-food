namespace CreationalPattern.FactoryMethod.VehicleTypes;

public class Car : IDeliveryFood
{
    public string LicensePlate { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }

    public Task Delivery(int orderId)
    {
        return Task.FromResult($"Delivered Order: {orderId} via car!");
    }
}