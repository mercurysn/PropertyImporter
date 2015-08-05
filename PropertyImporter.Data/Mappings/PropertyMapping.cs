using System.Data.Entity.ModelConfiguration;
using PropertyImporter.Data.Models;

namespace PropertyImporter.Data.Mappings
{
    public class PropertyMapping : EntityTypeConfiguration<Property>
    {
        public PropertyMapping()
        {
            HasKey(t => t.PropertyId);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Address)
                .IsRequired();

            Property(t => t.AgencyCode)
                .IsRequired()
                .HasMaxLength(10);

            ToTable("Property");
            Property(p => p.PropertyId).HasColumnName("PropertyId");
        }
    }
}
