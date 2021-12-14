namespace CreationalPattern.Builder;

public struct Supplier
{
    public Supplier(string name, string email, string contactName) => (Name, Email, ContactName) = (name, email, contactName);
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactName { get; set; }
}