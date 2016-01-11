namespace SimpleMVC.Core.Interfaces
{
    public interface IModel
    {
        void RegisteProxy(string proxyName, IProxy proxy);
        void RemoveProxy(string proxyName);
        IProxy RetrieveProxy(string proxyName);
        void Subscribe(string proxyName, string observerName, IObserver observer);
        void UnSubscribe(string proxyName, string observerName);
    }
}