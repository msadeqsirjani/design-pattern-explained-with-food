namespace CreationalPattern.FactoryMethod;

public interface IDeliveryFood
{
    Task Delivery(int orderId);
}