using System;
using System.Collections.Generic;
using System.Linq;
using SimpleMVC.Core.Interfaces;

namespace SimpleMVC.Core.Imp.Mediator
{
    public abstract class Mediator : IMediator
    {
        protected readonly IDictionary<string, Action> InterestActionMap;
        protected IController Controller;
        protected IModel Model;

        protected Mediator(object app)
        {
            InterestActionMap = new Dictionary<string, Action>();
        }

        public void Init(IModel model, IController controller)
        {
            Model = model;
            Controller = controller;
            RegisterIntersts();
        }

        public IList<string> Interests
        {
            get { return InterestActionMap.Keys.ToList(); }
        }

        public abstract void RegisterIntersts();

        public void HandleIntersts(string interestName)
        {
            if (InterestActionMap.ContainsKey(interestName))
            {
                InterestActionMap[interestName].Invoke();
            }
        }
    }
}