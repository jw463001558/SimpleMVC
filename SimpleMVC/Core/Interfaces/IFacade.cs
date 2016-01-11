namespace SimpleMVC.Core.Interfaces
{
    public interface IFacade : IController
    {
        void Start();
        void Stop();
    }
}