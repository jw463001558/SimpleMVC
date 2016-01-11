using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Observer
{
    public class Observer : IObserver
    {
        private readonly IMediator _mediator;

        public Observer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Update(string interestName)
        {
            _mediator.HandleIntersts(interestName);
        }
    }
}