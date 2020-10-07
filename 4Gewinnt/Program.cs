using _4Gewinnt.Controller;
using _4Gewinnt.Model;
using _4Gewinnt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{
    class Program
    {

        public static void Main(string[] args)
        {
            /*
            Parallel.Invoke(() =>
                {
                    */
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    /*
                },

                () =>
                {
                    GameController gameTui = new GameController();
                }
            );
            */
            
        }
    }
}
