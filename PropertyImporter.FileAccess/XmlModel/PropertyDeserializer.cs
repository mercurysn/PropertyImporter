using System.Xml.Serialization;

namespace PropertyImporter.FileAccess.XmlModel
{
    public class PropertyDeserializer
    {
        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlElement("AgencyCode")]
        public string AgencyCode { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Latitude")]      
        public decimal Latitude { get; set; }

        [XmlElement("Longitude")]
        public decimal Longitude { get; set; }
    }
}
