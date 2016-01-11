using System;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Facade
{
    public class Facade : IFacade
    {
        private readonly IController _controller;
        private readonly IModel _model;
        private readonly IView _view;

        public Facade()
        {
            _model = new Model();
            _view = new View();
            _controller = new Controller(_model, _view);

            _view.Init(_model, _controller);
        }

        public void RegisterCommand(string commandName, Type commandType)
        {
            _controller.RegisterCommand(commandName, commandType);
        }

        public void RemoveCommand(string commandName)
        {
            _controller.RemoveCommand(commandName);
        }

        public ICommand RetrieveCommand(string commandName)
        {
            return _controller.RetrieveCommand(commandName);
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}