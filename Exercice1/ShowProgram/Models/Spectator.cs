public class Spectator
{

    public Spectator() { }

    public void Reactie(List<Trick> tricks)
    {
        foreach (Trick currentTrick in tricks)
        {

            string reactie;

            if (currentTrick.GetTrickType() == TrickType.Acrobatics)
            {
                reactie = "applauds";
            }
            else
            {
                reactie = "whistles";
            }

            Console.WriteLine("The spectator " + reactie + " during " + currentTrick.ToString());
        }
    }
}