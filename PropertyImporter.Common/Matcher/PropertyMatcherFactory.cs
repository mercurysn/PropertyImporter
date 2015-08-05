using System;

namespace PropertyImporter.Common.Matcher
{
    public class PropertyMatcherFactory : IPropertyMatcherFactory
    {
        public IPropertyMatcher GetPropertyMatcher(string agencyCode)
        {
            switch (agencyCode)
            {
                case "OBTRE":
                    return new NameAddressMatcher();
                case "LRE":
                    return new GeoCodeMatcher();
                case "CRE":
                    return new ReverseWordMatcher();
                default:
                    throw new ArgumentException("Unknown agency code");
            }
        }
    }
}
