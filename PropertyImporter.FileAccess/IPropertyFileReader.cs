using System.Collections.Generic;
using PropertyImporter.Common.Models;

namespace PropertyImporter.FileAccess
{
    public interface IPropertyFileReader
    {
        List<Property> ExtractAllProperties(string filePath);
    }
}
