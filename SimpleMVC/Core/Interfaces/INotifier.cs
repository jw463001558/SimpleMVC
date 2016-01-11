namespace SimpleMVC.Core.Interfaces
{
    public interface INotifier
    {
        bool HasObserver(string observerName);
        void Subscribe(string observerName, IObserver observer);
        void UnSubscribe(string observerName);
        void Notify(string interestName);
    }
}