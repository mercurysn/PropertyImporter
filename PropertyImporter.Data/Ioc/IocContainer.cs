﻿using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

namespace PropertyImporter.Data.Ioc
{
    public class IocContainer
    {
        private static IocContainer instance;
        private IKernel kernel;

        private IocContainer()
        {
        }

        public static IocContainer Instance
        {
            get { return instance ?? (instance = new IocContainer()); }
        }

        public void Initialize(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Get<T>()
        {
            return kernel.Get<T>();
        }

        public T Get<T>(string name)
        {
            return kernel.Get<T>(name);
        }

        public void Load(List<NinjectModule> ninjectModules)
        {
            kernel.Load(ninjectModules);
        }
    }
}
