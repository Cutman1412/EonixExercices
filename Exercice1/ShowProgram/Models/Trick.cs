public class Trick
{
    private string Name;
    private TrickType Type;

    public Trick(string name, TrickType type)
    {
        Name = name;
        Type = type;
    }

    public TrickType GetTrickType()
    {
        return Type;
    }

    public override string ToString()
    {
        return "The " + Type + " trick of " + Name;
    }
}