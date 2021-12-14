namespace StructuralPattern.Composite;

public abstract class TeaCarton
{
    public abstract int GetNumberOfServing();
    public abstract bool ContainsSubCarton();

    public virtual void Add(TeaCarton carton)
    {
        throw new NotImplementedException("Override in concrete TeaCarton classes");
    }

    public virtual void BuildBundle(Dictionary<TeaCarton, int> order)
    {
        throw new NotImplementedException("Override in concrete TeaCarton classes");
    }

    public virtual void Remove(TeaCarton carton)
    {
        throw new NotImplementedException("Override in concrete TeaCarton classes");
    }
}