using _4Gewinnt.View;
using System.Windows.Forms;

namespace _4Gewinnt
{
    class Program
    {

        public static void Main()
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
