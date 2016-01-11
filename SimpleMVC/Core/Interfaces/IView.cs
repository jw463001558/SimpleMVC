namespace SimpleMVC.Core.Interfaces
{
    public interface IView
    {
        void Init(IModel model, IController controller);
        void RegisterMediator(string proxyname, string mediatorName, IMediator mediator);
        void RemoveMediator(string proxyname, string mediatorName);
        IMediator RetrieveMediator(string mediatorName);
    }
}