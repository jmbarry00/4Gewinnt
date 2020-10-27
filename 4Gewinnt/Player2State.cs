using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    class Player2State : IState
    {
        readonly Spielfeld state;

        public Player2State(Spielfeld state)
        {
            this.state = state;
        }

        public int SpielerNummer()
        {
            this.state.ChangeState(new Player1State(this.state));
            return 2;
        }
    }
}
