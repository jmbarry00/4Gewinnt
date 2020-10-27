using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    class Player1State : IState
    {
        readonly Spielfeld state;

        public Player1State(Spielfeld state)
        {
            this.state = state;
        }

        public int SpielerNummer()
        {
            this.state.ChangeState(new Player2State(this.state));
            return 1;
        }
    }
}
