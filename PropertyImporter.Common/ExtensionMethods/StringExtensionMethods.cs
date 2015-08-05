using System.Text.RegularExpressions;

namespace PropertyImporter.Common.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string RemovePunctuation(this string value)
        {
            return Regex.Replace(value, "[.,!@\"#$%^&*()]", "").Replace("-"," ").Replace("  ", " ").ToLower();
        }
    }
}
