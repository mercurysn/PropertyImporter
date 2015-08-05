using AutoMapper;
using NUnit.Framework;
using PropertyImporter.Common.AutoMapperProfile;
using PropertyImporter.Common.Models;
using PropertyImporter.FileAccess.AutoMapperProfile;
using PropertyImporter.FileAccess.XmlModel;

namespace PropertyImporter.UnitTest
{
    [TestFixture]
    public class AutoMapperTests
    {

        [Test]
        public void Assert_XmlModelMapperProfile_IsValid()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new XmlModelMapperProfile()));

            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Assert_XmlModelMapperProfile_Works()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new XmlModelMapperProfile()));

            PropertyDeserializer propertyDeserializer = new PropertyDeserializer
            {
                Name = "Property1",
                Address = "Address1",
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 200
            };

            Property property = new Property();

            Mapper.Map(propertyDeserializer, property);

            Assert.AreEqual("Property1", property.Name);
            Assert.AreEqual("Address1", property.Address);
            Assert.AreEqual("LRE", property.AgencyCode);
            Assert.AreEqual(100, property.Latitude);
            Assert.AreEqual(200, property.Longitude);
        }

        [Test]
        public void DataMapperProfile_IsValid()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new DataMapperProfile()));

            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Assert_DataMapperProfile_DataObjectToModel_Works()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new DataMapperProfile()));

            Data.Models.Property propertyDataObject = new Data.Models.Property()
            {
                Name = "Property1",
                Address = "Address1",
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 200
            };

            Property property = new Property();

            Mapper.Map(propertyDataObject, property);

            property = Mapper.Map<Property>(propertyDataObject);

            Assert.AreEqual("Property1", property.Name);
            Assert.AreEqual("Address1", property.Address);
            Assert.AreEqual("LRE", property.AgencyCode);
            Assert.AreEqual(100, property.Latitude);
            Assert.AreEqual(200, property.Longitude);
        }

        [Test]
        public void Assert_DataMapperProfile_ModelToDataObject_Works()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new DataMapperProfile()));

            Property property = new Property()
            {
                Name = "Property1",
                Address = "Address1",
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 200
            };

            Data.Models.Property propertyDataObject = new Data.Models.Property();

            Mapper.Map(property, propertyDataObject);

            propertyDataObject = Mapper.Map<Data.Models.Property>(property);

            Assert.AreEqual("Property1", propertyDataObject.Name);
            Assert.AreEqual("Address1", propertyDataObject.Address);
            Assert.AreEqual("LRE", propertyDataObject.AgencyCode);
            Assert.AreEqual(100, propertyDataObject.Latitude);
            Assert.AreEqual(200, propertyDataObject.Longitude);
        }
    }
}
