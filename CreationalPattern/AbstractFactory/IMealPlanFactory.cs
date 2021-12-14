namespace CreationalPattern.AbstractFactory;

public interface IMealPlanFactory
{
    IMenu GenerateLunchesMenu();
    IMenu GenerateDessertsMenu();
    IShoppingList GenerateShoppingList();
}