using System.Reflection.Metadata.Ecma335;

public class Tamer
{
    private string Name;
    private Monkey Monkey;

    public Tamer(string name, Monkey monkey)
    {
        Name = name;
        Monkey = monkey;
    }

    public List<Trick> GetAllMonkeyTricks()
    {
        Console.WriteLine(Name + " asks his monkey to do his tricks");
        return Monkey.GetAllTricks();
    }
}