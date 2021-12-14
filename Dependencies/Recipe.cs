namespace Dependencies;

public struct Recipe
{
    public Recipe(string name, int prepareTimeInMinute) : this()
    {
        Name = name;
        PrepareTimeInMinute = prepareTimeInMinute;
    }

    public string Name { get; set; }
    public int PrepareTimeInMinute { get; set; }
}