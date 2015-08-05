using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyImporter.Data.Models
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }
        public string Address { get; set; }
        public string AgencyCode { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
