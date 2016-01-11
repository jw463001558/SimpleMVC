using SimpleMVC.Core.Imp.Observer;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Proxy
{
    public class Proxy : IProxy, INotifier
    {
        private readonly INotifier _notifier;

        public Proxy()
        {
            _notifier = new Notifier();
        }

        public bool HasObserver(string observerName)
        {
            return _notifier.HasObserver(observerName);
        }

        public void Subscribe(string observerName, IObserver observer)
        {
            _notifier.Subscribe(observerName, observer);
        }

        public void UnSubscribe(string observerName)
        {
            _notifier.UnSubscribe(observerName);
        }

        public void Notify(string interestName)
        {
            _notifier.Notify(interestName);
        }

        public virtual object Data { set; get; }
    }
}