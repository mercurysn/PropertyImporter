using PropertyImporter.Common.Models;

namespace PropertyImporter.Common.Matcher
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }

}
