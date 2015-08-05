using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using PropertyImporter.Common.Models;
using PropertyImporter.FileAccess.XmlModel;

namespace PropertyImporter.FileAccess
{
    public class PropertyXmlFileReader : IPropertyFileReader
    {
        public List<Property> ExtractAllProperties(string filePath)
        {
            PropertyListDeserializer properties = new PropertyListDeserializer();

            XmlSerializer deserializer = new XmlSerializer(typeof(PropertyListDeserializer));
            using (TextReader reader = new StreamReader(filePath))
            {
                properties = (PropertyListDeserializer)deserializer.Deserialize(reader);
            }

            return MapToPropertyList(properties);
        }

        private static List<Property> MapToPropertyList(PropertyListDeserializer properties)
        {
            List<Property> propertyList = new List<Property>();

            foreach (var property in properties.Properties)
            {
                PropertyFieldValidator.Validate(property);

                Property agencyProperty = new Property();

                Mapper.Map(property, agencyProperty);

                propertyList.Add(agencyProperty);
            }
            return propertyList;
        }
    }
}
