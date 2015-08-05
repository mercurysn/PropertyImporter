using System.Data.Entity;
using PropertyImporter.Data.Models;

namespace PropertyImporter.Data.Context
{
    public class PropertyDb : DbContext
    {
        public PropertyDb() : base ("PropertyDb")
        {
            
        }

        public DbSet<Property> Property { get; set; }
    }
}
