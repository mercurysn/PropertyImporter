using PropertyImporter.Common.ExtensionMethods;

namespace PropertyImporter.Common.Matcher
{
    public class NameAddressMatcher : IPropertyMatcher
    {
        public bool IsMatch(Models.Property agencyProperty, Models.Property databaseProperty)
        {
            return (agencyProperty.Name.RemovePunctuation() == databaseProperty.Name.RemovePunctuation() &&
                    agencyProperty.Address.RemovePunctuation() == databaseProperty.Address.RemovePunctuation());
        }
    }
}
