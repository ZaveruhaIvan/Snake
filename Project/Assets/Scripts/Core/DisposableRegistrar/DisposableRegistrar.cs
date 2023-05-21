using System;
using System.Collections.Generic;

namespace Core.DisposableRegistrar
{
    public class DisposableRegistrar : IDisposableRegistrar
    {
        private readonly LinkedList<Action> _actions = new();

        public void Dispose()
        {
            foreach (var action in _actions)
            {
                action.Invoke();
            }
        }

        public void Register(Action action)
        {
            _actions.AddLast(action);
        }
    }
}