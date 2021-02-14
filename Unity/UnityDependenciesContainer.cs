using Common;
using System;

namespace Unity
{
    public class UnityDependenciesContainer : IDependeciesContainer
    {
        private readonly IUnityContainer _c;

        public UnityDependenciesContainer(IUnityContainer unityContainer = null)
        {
            _c = unityContainer ?? new UnityContainer();
#if DEBUG
            //c.AddExtension()
#endif
        }

        ~UnityDependenciesContainer()
        {
            Dispose(false);
        }

        public void Register<TInterface, T>()
            where T : TInterface
        {
            _c.RegisterType<TInterface, T>();
        }

        public T Resolve<T>()
        {
            return _c.Resolve<T>();
        }

        public IDependeciesContainer CreateChildContainer()
        {
            return new UnityDependenciesContainer(_c.CreateChildContainer());
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _c.Dispose();
            }
        }

        #endregion
    }
}
