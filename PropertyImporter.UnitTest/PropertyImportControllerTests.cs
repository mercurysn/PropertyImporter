using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PropertyImporter.Common.AutoMapperProfile;
using PropertyImporter.Data.Models;
using PropertyImporter.Data.Repositories;
using PropertyImporter.FileAccess;
using PropertyImporter.FileAccess.AutoMapperProfile;
using PropertyImporter.Service;

namespace PropertyImporter.UnitTest
{
    [TestFixture]
    public class PropertyImportControllerTests
    {
        private Mock<IPropertyRepository> _mockRepository = new Mock<IPropertyRepository>();
        private Mock<IPropertyFileReader> _mockFileReader = new Mock<IPropertyFileReader>();
        private List<Common.Models.Property> _mockProperties;
        private List<Property> _mockDatabaseProperties;

        [SetUp]
        public void Setup()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DataMapperProfile());
                cfg.AddProfile(new XmlModelMapperProfile());
            });

            

            
        }

        [Test]
        public void PropertyMatch_Should_Call_UpdateDb_Method()
        {
            SetupSamePropertyModels();

            PropertyImportController controller = new PropertyImportController(_mockRepository.Object, _mockFileReader.Object);

            controller.ProcessFileImport("");

            _mockRepository.Verify(x => x.UpdateProperty(It.IsAny<int>(), It.IsAny<Property>()));
        }

        

        [Test]
        public void Property_NOT_Match_Should_Call_UpdateDb_Method()
        {
            SetupDifferentPropertyModels();

            PropertyImportController controller = new PropertyImportController(_mockRepository.Object, _mockFileReader.Object);

            controller.ProcessFileImport("");

            _mockRepository.Verify(x => x.CreateNewProperty(It.IsAny<Property>()));
        }

        private void SetupSamePropertyModels()
        {
            _mockProperties = new List<Common.Models.Property>
            {
                new Common.Models.Property
                {
                    Name = "Property1",
                    AgencyCode = "OBTRE",
                    Address = "Address"
                }
            };

            _mockDatabaseProperties = new List<Property>
            {
                new Property
                {
                    Name = "Property1",
                    AgencyCode = "OBTRE",
                    Address = "Address"
                }
            };

            _mockRepository.Setup(x => x.UpdateProperty(It.IsAny<int>(), It.IsAny<Property>()));
            _mockRepository.Setup(x => x.GetAllProperties()).Returns(_mockDatabaseProperties);
            _mockFileReader.Setup(x => x.ExtractAllProperties(It.IsAny<string>())).Returns(_mockProperties);
        }

        private void SetupDifferentPropertyModels()
        {
            _mockProperties = new List<Common.Models.Property>
            {
                new Common.Models.Property
                {
                    Name = "Property1",
                    AgencyCode = "OBTRE",
                    Address = "Address"
                }
            };

            _mockDatabaseProperties = new List<Property>
            {
                new Property
                {
                    Name = "DifferentPropertyName",
                    AgencyCode = "OBTRE",
                    Address = "Address"
                }
            };

            _mockRepository.Setup(x => x.UpdateProperty(It.IsAny<int>(), It.IsAny<Property>()));
            _mockRepository.Setup(x => x.GetAllProperties()).Returns(_mockDatabaseProperties);
            _mockFileReader.Setup(x => x.ExtractAllProperties(It.IsAny<string>())).Returns(_mockProperties);
        }
    }
}
