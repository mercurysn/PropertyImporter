using Ninject.Modules;
using PropertyImporter.Data.Repositories;

namespace PropertyImporter.Data.Ioc
{
    public class DataInject : NinjectModule
    {
        public override void Load()
        {
            Bind<IPropertyRepository>().To<PropertyRepository>();
        }
    }
}
