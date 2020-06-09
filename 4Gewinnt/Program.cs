using _4Gewinnt.Model;
using _4Gewinnt.View;
using System;

namespace _4Gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wähle Anzahl Spalten für Spielfeld: ");
            string anzahlSpalte = Console.ReadLine();
            Console.WriteLine("Wähle Anzahl Zeilen für Spielfeld: ");
            string anzahlZeilen = Console.ReadLine();
            GameTUI game = new GameTUI(Convert.ToInt32(anzahlZeilen)+1, Convert.ToInt32(anzahlSpalte));

        }
    }
}
