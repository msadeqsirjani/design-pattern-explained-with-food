using CreationalPattern.FactoryMethod.VehicleTypes;
using Dependencies;

namespace CreationalPattern.FactoryMethod;

public class BicycleDeliveryCreator : DeliveryCreator
{
    public BicycleDeliveryCreator(IQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger)
    {
    }

    protected override IDeliveryFood RegisterVehicle()
    {
        Bicycle bicycle = new()
        {
            Color = "blue",
            Style = "Road",
            Make = "Trek",
            Model = "Foo",
        };

        _logger.LogInfo("Registering a Bicycle to deliver food!", ConsoleColor.Cyan);
           
        return bicycle;
    }
}