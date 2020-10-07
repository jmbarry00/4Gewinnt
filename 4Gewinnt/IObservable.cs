namespace _4Gewinnt
{
    interface IObservable
    {
        void add(IObserver observer);
        void remove(IObserver observer);
        void notify();
    }
}
