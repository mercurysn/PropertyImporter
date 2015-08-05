using System;
using PropertyImporter.Common.ExtensionMethods;

namespace PropertyImporter.Common.Matcher
{
    public class GeoCodeMatcher : IPropertyMatcher
    {
        public bool IsMatch(Models.Property agencyProperty, Models.Property databaseProperty)
        {
            if (agencyProperty.AgencyCode != databaseProperty.AgencyCode)
                return false;

            decimal latitudeDifference = Math.Abs(agencyProperty.Latitude - databaseProperty.Latitude);
            decimal longitudeDifference = Math.Abs(agencyProperty.Longitude - databaseProperty.Longitude);

            if (latitudeDifference == 0 && longitudeDifference == 0)
                return true;

            if (latitudeDifference == 0)
                return (longitudeDifference.ConvertToKm() <= 200);

            if (longitudeDifference == 0)
                return (latitudeDifference.ConvertToKm() <= 200);

            decimal distanceBetweenProperties =
                (decimal)Math.Sqrt(Convert.ToDouble(latitudeDifference*latitudeDifference + longitudeDifference*longitudeDifference));

            return (distanceBetweenProperties.ConvertToKm() <= 200);
        }
    }
}
