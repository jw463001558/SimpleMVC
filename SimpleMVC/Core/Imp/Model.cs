using System.Collections.Generic;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp
{
    public class Model : IModel
    {
        private readonly IDictionary<string, IProxy> _proxyMap;

        public Model()
        {
            _proxyMap = new Dictionary<string, IProxy>();
        }

        public void Subscribe(string proxyName, string observerName, IObserver observer)
        {
            if (!HasProxy(proxyName)) return;

            var proxy = _proxyMap[proxyName] as Proxy.Proxy;
            if (proxy == null) return;

            if (!proxy.HasObserver(observerName))
            {
                proxy.Subscribe(observerName, observer);
            }
        }

        public void UnSubscribe(string proxyName, string observerName)
        {
            if (!HasProxy(proxyName)) return;

            var proxy = _proxyMap[proxyName] as Proxy.Proxy;
            if (proxy == null) return;

            if (proxy.HasObserver(observerName))
            {
                proxy.UnSubscribe(observerName);
            }
        }

        public virtual void RegisteProxy(string proxyName, IProxy proxy)
        {
            if (!HasProxy(proxyName))
            {
                _proxyMap[proxyName] = proxy;
            }
        }

        public virtual void RemoveProxy(string proxyName)
        {
            if (HasProxy(proxyName))
            {
                _proxyMap.Remove(proxyName);
            }
        }

        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return HasProxy(proxyName) ? _proxyMap[proxyName] : null;
        }

        private bool HasProxy(string proxyName)
        {
            return _proxyMap.ContainsKey(proxyName);
        }
    }
}