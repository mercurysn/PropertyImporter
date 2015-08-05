using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Syntax;

namespace PropertyImporter.Data.Ioc
{
    public class NinjectDependencyResolver 
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }


        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}
