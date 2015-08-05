using System;
using System.Collections.Generic;
using System.Linq;
using PropertyImporter.Data.Context;
using PropertyImporter.Data.Models;

namespace PropertyImporter.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public List<Property> GetAllProperties()
        {
            using (var context = new PropertyDb())
            {
                return (from property in context.Property select property).ToList();
            }
        }

        public Property GetPropertyByNameAndAddress(string name, string address)
        {
            using (var context = new PropertyDb())
            {
                return context.Property.FirstOrDefault(x => x.Name == name && x.Address == address);
            }
        }

        public void UpdateProperty(int id, Property property)
        {
            using (var context = new PropertyDb())
            {
                Property updateProperty = context.Property.SingleOrDefault(p => p.PropertyId == id);

                if (updateProperty != null)
                {
                    updateProperty.Address = property.Address;
                    updateProperty.Latitude = property.Latitude;
                    updateProperty.Longitude = property.Longitude;
                    updateProperty.Name = property.Name;

                    context.SaveChanges();
                }
            }
        }

        public void CreateNewProperty(Property property)
        {
            using (var context = new PropertyDb())
            {
                context.Property.Add(property);

                context.SaveChanges();
            }
        }
    }
}
