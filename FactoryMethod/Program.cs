using CreationalPattern.FactoryMethod;
using Dependencies;

ConsoleLogger logger = new();
IQueue deliveryQueue = new Queue(logger);

logger.LogInfo("Welcome to the Food Delivery Service!");
logger.LogInfo("------------------------------------------");
logger.LogInfo("Please enter a delivery type.");

var deliveryType = Console.ReadLine();

if (string.IsNullOrWhiteSpace(deliveryType))
{
    logger.LogInfo("Error reading delivery type.");
    return 1;
}

try
{
    var deliveryCreator = BuildDeliveryCreator(deliveryType, deliveryQueue);
    deliveryCreator.QueueVehicleForDelivery();

}
catch (Exception ex)
{
    logger.LogInfo($"There was an error processing the delivery: {ex.Message}, {ex.StackTrace}");
    return 1;
}

return 0;

static DeliveryCreator BuildDeliveryCreator(string deliveryType, IQueue deliveryQueue)
{

    ConsoleLogger logger = new();

    List<string> validDeliveryOptions = new() { "bicycle", "car" };

    if (!validDeliveryOptions.Contains(deliveryType))
    {
        logger.LogInfo("Please enter a type of delivery [bicycle, car]");
        throw new InvalidOperationException("Cannot set up delivery without valid deliveryType.");
    }

    return deliveryType switch
    {
        "bicycle" => new BicycleDeliveryCreator(deliveryQueue, logger),
        "car" => new CarDeliveryCreator(deliveryQueue, logger),
        _ => throw new InvalidOperationException("Cannot set up delivery without valid Delivery Type."),
    };
}