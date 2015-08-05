using System;
using System.Text.RegularExpressions;

namespace PropertyImporter.FileAccess
{
    public class PropertyFieldValidator
    {
        public static void Validate(XmlModel.PropertyDeserializer property)
        {
            if (!Regex.IsMatch(property.AgencyCode, "[a-zA-Z0-9!@#$%^&*()_+ ]*"))
                throw new ArgumentException("Agency Code Not Valid");

            if (!Regex.IsMatch(property.Name, "[a-zA-Z0-9!@#$%^&*()_+ ]*"))
                throw new ArgumentException("Name Not Valid");

            if (!Regex.IsMatch(property.Address, "[a-zA-Z0-9!@#$%^&*()_+ ]*"))
                throw new ArgumentException("Address Not Valid");
        }
    }
}
