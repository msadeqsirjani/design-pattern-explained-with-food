using Dependencies;
using Newtonsoft.Json;

namespace CreationalPattern.FactoryMethod;

public abstract class DeliveryCreator
{
    protected readonly IQueue _deliveryQueue;
    protected readonly IApplicationLogger _logger;

    public DeliveryCreator(IQueue deliveryQueue, IApplicationLogger logger)
    {
        _deliveryQueue = deliveryQueue;
        _logger = logger;
    }

    protected abstract IDeliveryFood RegisterVehicle();

    public void QueueVehicleForDelivery()
    {
        var vehicle = RegisterVehicle();
        var vehiclePayload = JsonConvert.SerializeObject(vehicle);
        QueueMessage queueMessage = new(vehiclePayload);
        _deliveryQueue.Add(queueMessage);
        _logger.LogInfo($"Queued up vehicle of type {vehicle.GetType()} for food delivery.");
    }
}