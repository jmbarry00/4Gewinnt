namespace _4Gewinnt.Model
{
    public class Spiel
    {
        public Spieler spieler;
        public Spielfeld spielfeld;
        readonly int Y;
        readonly int X;


        public Spiel(int y, int x)
        {
            Y = y;
            X = x;
            spieler = new Spieler();
        }

        //Beim Start fängt Spieler 1 an und ein Feld wird erstellt
        public void SpielStarten()
        {
            spieler.player1 = true;
            spielfeld = new Spielfeld(Y, X);
        }
    }
}
