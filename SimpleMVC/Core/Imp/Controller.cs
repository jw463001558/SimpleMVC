using System;
using System.Collections.Generic;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp
{
    public class Controller : IController
    {
        private readonly IDictionary<string, ICommand> _commandMap;
        private readonly IModel _model;
        private readonly IView _view;

        public Controller(IModel model, IView view)
        {
            _model = model;
            _view = view;
            _commandMap = new Dictionary<string, ICommand>();
        }

        public void RegisterCommand(string commandName, Type commandType)
        {
            if (HasCommand(commandName)) return;

            var obj = Activator.CreateInstance(commandType);
            var command = obj as ICommand;
            if (command == null) return;

            command.Init(_model, _view);
            _commandMap[commandName] = command;
        }

        public void RemoveCommand(string commandName)
        {
            if (HasCommand(commandName))
            {
                _commandMap.Remove(commandName);
            }
        }

        public ICommand RetrieveCommand(string commandName)
        {
            return HasCommand(commandName) ? _commandMap[commandName] : null;
        }

        private bool HasCommand(string commandName)
        {
            return _commandMap.ContainsKey(commandName);
        }
    }
}