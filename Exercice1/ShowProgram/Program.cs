class Program
{
    static void Main(string[] args)
    {
        List<Trick> tricks = new List<Trick>()
        {
            new Trick("Dance", TrickType.Acrobatics),
            new Trick("Singing", TrickType.Music),
        };

        List<Tamer> tamers = new List<Tamer>(){
            new Tamer("Tamer1", new Monkey("Singe1", tricks)),
            new Tamer("Tamer2", new Monkey("Singe2", tricks))
        };

        Spectator spectator = new Spectator();

        foreach (Tamer currentTamer in tamers)
        {
            spectator.Reactie(currentTamer.GetAllMonkeyTricks());
        }
    }
}