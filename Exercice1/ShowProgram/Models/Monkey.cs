public class Monkey
{
    private string Name;
    private List<Trick> Tricks;

    public Monkey(string name, List<Trick> tricks)
    {
        Name = name;
        Tricks = tricks;
    }

    public List<Trick> GetAllTricks()
    {
        return Tricks;
    }
}