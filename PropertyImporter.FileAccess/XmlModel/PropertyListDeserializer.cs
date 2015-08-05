using System.Collections.Generic;
using System.Xml.Serialization;

namespace PropertyImporter.FileAccess.XmlModel
{
    [XmlRoot("properties")]
    public class PropertyListDeserializer
    {
        [XmlElement("property")]
        public List<PropertyDeserializer> Properties = new List<PropertyDeserializer>(); 
    }
}
