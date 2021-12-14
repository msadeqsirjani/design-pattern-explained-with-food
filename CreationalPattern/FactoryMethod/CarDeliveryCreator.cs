using CreationalPattern.FactoryMethod.VehicleTypes;
using Dependencies;

namespace CreationalPattern.FactoryMethod;

public class CarDeliveryCreator : DeliveryCreator
{
    public CarDeliveryCreator(IQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger)
    {
    }

    protected override IDeliveryFood RegisterVehicle()
    {
        Car car = new()
        {
            Year = 2010,
            Color = "black",
            Make = "Honda",
            Model = "Civic",
            LicensePlate = "123"
        };

        _logger.LogInfo("Registering a Car to deliver food!", ConsoleColor.Green);

        return car;
    }
}