namespace SimpleMVC.Core.Interfaces
{
    public interface ICommand
    {
        void Init(IModel model, IView view);
        void Ready(object app = null);
        void Execute(string interestName);
        void Cancel();
    }
}