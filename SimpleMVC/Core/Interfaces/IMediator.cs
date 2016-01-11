using System.Collections.Generic;

namespace SimpleMVC.Core.Interfaces
{
    public interface IMediator
    {
        IList<string> Interests { get; }
        void Init(IModel model, IController controller);
        void RegisterIntersts();
        void HandleIntersts(string interestName);
    }
}