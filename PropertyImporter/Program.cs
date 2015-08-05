using AutoMapper;
using Ninject;
using PropertyImporter.Common.AutoMapperProfile;
using PropertyImporter.Data.Ioc;
using PropertyImporter.FileAccess.AutoMapperProfile;
using PropertyImporter.Service;

namespace PropertyImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterIocContainer();
            RegisterAutoMapper();
            
            //string testFilePath = @"C:\data\visual studio 2013\Projects\PropertyImporter\PropertyImporter.IntegrationTest\SampleFiles\properties.xml";
            string testFilePath = args[0];

            

            PropertyImportController controller = new PropertyImportController();

            controller.ProcessFileImport(testFilePath);
        }

        private static void RegisterAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DataMapperProfile());
                cfg.AddProfile(new XmlModelMapperProfile());
            });
        }

        private static void RegisterIocContainer()
        {
            
            IKernel kernel = new StandardKernel(new DataInject());
            IocContainer.Instance.Initialize(kernel);
        
        }
    }
}
