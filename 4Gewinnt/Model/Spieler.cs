using System.Collections.Generic;

namespace _4Gewinnt.Model
{
    public class Spieler : IObservable
    {
        public bool player1 = true;
        public bool player2 = false;
        List<IObserver> observers = new List<IObserver>();

        public void SwitchPlayer()
        {
            player1 = (player1 == true) ? false : true;
            player2 = (player2 == true) ? false : true;
        }

        public bool Spieler1
        {
            get { return player1; }
            set
            {
                player1 = value;
                notify();
            }
        }

        public bool Spieler2
        {
            get { return player2; }
            set
            {
                player2 = value;
                notify();
            }
        }
        public void add(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.update();
            }
        }

    }
}