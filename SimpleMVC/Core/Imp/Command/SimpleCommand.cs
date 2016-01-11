using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Command
{
    public class SimpleCommand : ICommand
    {
        protected IModel Model;
        protected IView View;

        public void Init(IModel model, IView view)
        {
            Model = model;
            View = view;
        }

        public void Ready(object app = null)
        {
        }

        public void Execute(string interestName)
        {
        }

        public void Cancel()
        {
        }
    }
}