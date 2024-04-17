namespace Dal.Schemas;

public sealed class Actor
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public int Rank {get; set;}
    public string Type {get; set;}
    public string Movie { get; set; }
    public string Source { get; set; }
}