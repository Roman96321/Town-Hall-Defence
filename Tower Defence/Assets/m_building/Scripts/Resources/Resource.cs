public class Resource : IResource
{
    public ResourceType Type { get;}

    public int Count { get => _count;set{_count = value;}}

    private int _count{get;set;}

    public Resource(ResourceType type, int defaultAmount = default)
    {
        Type = type;
        Count = defaultAmount; 
    }
}   