using System.Collections.Generic;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp
{
    public class View : IView
    {
        private readonly IDictionary<string, IMediator> _mediatorMap;
        private IController _controller;
        private IModel _model;

        public View()
        {
            _mediatorMap = new Dictionary<string, IMediator>();
        }

        public void RegisterMediator(string proxyname, string mediatorName, IMediator mediator)
        {
            if (HasMediator(mediatorName)) return;

            mediator.Init(_model, _controller);
            _mediatorMap[mediatorName] = mediator;

            IObserver observer = new Observer.Observer(mediator);

            _model.Subscribe(proxyname, mediatorName, observer);
        }

        public void RemoveMediator(string proxyname, string mediatorName)
        {
            if (!HasMediator(mediatorName)) return;

            _model.UnSubscribe(proxyname, mediatorName);
            _mediatorMap.Remove(mediatorName);
        }

        public IMediator RetrieveMediator(string mediatorName)
        {
            return HasMediator(mediatorName) ? _mediatorMap[mediatorName] : null;
        }

        public void Init(IModel model, IController controller)
        {
            _model = model;
            _controller = controller;
        }

        private bool HasMediator(string mediatorName)
        {
            return _mediatorMap.ContainsKey(mediatorName);
        }
    }
}