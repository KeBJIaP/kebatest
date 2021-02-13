using Common;
using System;
using Unity;

namespace Factories
{
    public abstract class Factory
    {
       private IDependeciesContainer _cont;

        public Factory()
        {
            _cont = new UnityDependenciesContainer();
            RegisterTypes(ref _cont);
        }

        protected IDependeciesContainer GetContainer()
        {
            return _cont;
        }

        protected abstract void RegisterTypes(ref IDependeciesContainer cont);
    }
}
