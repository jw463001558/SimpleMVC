using System.Collections.Generic;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Observer
{
    public class Notifier : INotifier
    {
        private readonly IDictionary<string, IObserver> _observerMap;

        public Notifier()
        {
            _observerMap = new Dictionary<string, IObserver>();
        }

        public bool HasObserver(string observerName)
        {
            return _observerMap.ContainsKey(observerName);
        }

        public void Subscribe(string observerName, IObserver observer)
        {
            _observerMap[observerName] = observer;
        }

        public void UnSubscribe(string observerName)
        {
            _observerMap.Remove(observerName);
        }

        public void Notify(string interestName)
        {
            foreach (var observerPair in _observerMap)
            {
                observerPair.Value.Update(interestName);
            }
        }
    }
}