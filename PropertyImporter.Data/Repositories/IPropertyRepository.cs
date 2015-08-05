using System.Collections.Generic;
using PropertyImporter.Data.Models;

namespace PropertyImporter.Data.Repositories
{
    public interface IPropertyRepository
    {
        List<Property> GetAllProperties();

        void CreateNewProperty(Property agencyProperty);

        void UpdateProperty(int id, Property agencyProperty);
    }
}