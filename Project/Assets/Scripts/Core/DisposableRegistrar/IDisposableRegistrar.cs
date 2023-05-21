using System;

namespace Core.DisposableRegistrar
{
    public interface IDisposableRegistrar : IDisposable
    {
        void Register(Action action);
    }
}