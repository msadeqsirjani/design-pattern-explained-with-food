namespace CreationalPattern.AbstractFactory.MealPlans.Vegetarian;

public class VegetarianShoppingList : IShoppingList
{
    public List<string> MakeShoppingList() => new() { "black beans, spices, kale, cucumber", "mangoes", "apples", "pears" };
}