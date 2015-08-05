using System.Collections.Generic;
using AutoMapper;
using NUnit.Framework;
using PropertyImporter.Common.Models;
using PropertyImporter.FileAccess;
using PropertyImporter.FileAccess.AutoMapperProfile;

namespace PropertyImporter.IntegrationTest
{
    [TestFixture]
    public class FileAccessTests
    {
        private string _testFilePath = @"C:\data\visual studio 2013\Projects\PropertyImporter\PropertyImporter.IntegrationTest\SampleFiles\properties.xml";

        [SetUp]
        public void Setup()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new XmlModelMapperProfile()));
        }

        [Test, Explicit]
        public void Test_Read_Xml_File_Into_Property_Object()
        {
            IPropertyFileReader fileReader = new PropertyXmlFileReader();

            List<Property> properties = fileReader.ExtractAllProperties(_testFilePath);

            Assert.AreEqual("“*Super*-High! APARTMENTS (Sydney)", properties[0].Name);
            Assert.AreEqual("Apple Store Apartments", properties[1].Name);
            Assert.AreEqual("Central Park Luxury Apartment", properties[2].Name);
        }
    }
}
