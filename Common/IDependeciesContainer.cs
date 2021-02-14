using System;

namespace Common
{
    public interface IDependeciesContainer : IDisposable
    {
        public T Resolve<T>();

        public void Register<TInterface, T>() where T : TInterface;
        IDependeciesContainer CreateChildContainer();
    }
}
