using System;

namespace SimpleMVC.Core.Interfaces
{
    public interface IController
    {
        void RegisterCommand(string commandName, Type commandType);
        void RemoveCommand(string commandName);
        ICommand RetrieveCommand(string commandName);
    }
}