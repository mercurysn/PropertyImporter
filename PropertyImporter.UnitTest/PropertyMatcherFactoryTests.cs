using NUnit.Framework;
using PropertyImporter.Common.Matcher;

namespace PropertyImporter.UnitTest
{
    [TestFixture]
    public class PropertyMatcherFactoryTests
    {
        [Test]
        public void AgencyCode_OBTRE_Should_Return_NameAddressMatcher_Instance()
        {
            PropertyMatcherFactory factory = new PropertyMatcherFactory();

            IPropertyMatcher matcher = factory.GetPropertyMatcher("OBTRE");

            Assert.IsInstanceOf<NameAddressMatcher>(matcher);
        }

        [Test]
        public void AgencyCode_LRE_Should_Return_NameAddressMatcher_Instance()
        {
            PropertyMatcherFactory factory = new PropertyMatcherFactory();

            IPropertyMatcher matcher = factory.GetPropertyMatcher("LRE");

            Assert.IsInstanceOf<GeoCodeMatcher>(matcher);
        }

        [Test]
        public void AgencyCode_CRE_Should_Return_NameAddressMatcher_Instance()
        {
            PropertyMatcherFactory factory = new PropertyMatcherFactory();

            IPropertyMatcher matcher = factory.GetPropertyMatcher("CRE");

            Assert.IsInstanceOf<ReverseWordMatcher>(matcher);
        }
    }
}
