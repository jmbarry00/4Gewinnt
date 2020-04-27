using _4Gewinnt.Model;
using System;

namespace _4Gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Spielfeld spielfeld = new Spielfeld(5,6);
            int x = spielfeld.posX;
            int y = spielfeld.posY;
            Spielstein spielstein = new Spielstein(x, y, "blau");
            spielfeld.FeldBesetzen(4);
            Console.WriteLine(spielstein.zeile);
        }
    }
}
