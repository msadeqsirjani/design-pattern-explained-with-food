namespace CreationalPattern.AbstractFactory;

public interface IMealPlanService
{
    Task SendMealPlanToSubscriber(string subscriberEmail);
}