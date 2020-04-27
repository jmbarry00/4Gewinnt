using _4Gewinnt.Model;
using System;

namespace _4Gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Spielfeld spielfeld = new Spielfeld(5,6);        
            spielfeld.FeldBesetzen(4);
            int x = spielfeld.posX;
            int y = spielfeld.posY;
            Spielstein spielstein = new Spielstein(x, y, "blau");
            Console.WriteLine(spielstein.zeile);
        }
    }
}
