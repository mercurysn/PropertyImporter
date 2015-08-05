namespace PropertyImporter.Common.ExtensionMethods
{
    public static class DistanceExtensionMethods
    {
        public static decimal ConvertToKm(this decimal degree)
        {
            return degree*111;
        }
    }
}
