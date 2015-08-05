namespace PropertyImporter.Common.Matcher
{
    public interface IPropertyMatcherFactory
    {
        IPropertyMatcher GetPropertyMatcher(string agencyCode);
    }
}