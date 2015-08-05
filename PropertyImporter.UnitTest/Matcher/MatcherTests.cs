using NUnit.Framework;
using PropertyImporter.Common.Matcher;
using PropertyImporter.Common.Models;

namespace PropertyImporter.UnitTest.Matcher
{
    [TestFixture]
    public class MatcherTests
    {
        #region NameAddressMatcherTests
        [Test]
        public void Test_NameAddressMatcher()
        {
            Property agencyProperty = new Property
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };

            Property databaseProperty = new Property
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };

            IPropertyMatcher propertyMatcher = new NameAddressMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_GeoCodeMatcher_SameLocation_SameAgencyCode_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }
        #endregion NameAddressMatcherTests

        #region GeoCodeMatcherTests
        [Test]
        public void Test_GeoCodeMatcher_SameLocation_DifferentAdgencyCode_Expect_Return_NOT_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "OTBRE",
                Latitude = 100,
                Longitude = 105
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(isMatch);
        }


        [Test]
        public void Test_GeoCodeMatcher_SameLatitude_LongitudeWithin200_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 106 // should be 111, within 200
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_GeoCodeMatcher_SameLatitude_LongitudeOutside200_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 107 // should be 222, outside 200, expect false
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void Test_GeoCodeMatcher_SameLongitude_LatitudeWithin200_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 101, // should be 111, within 200
                Longitude = 105 
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_GeoCodeMatcher_SameLongitude_LatitudeOutside200_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100, 
                Longitude = 105
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 102, // should be 222, outside 200, expect false
                Longitude = 107 
            };

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(isMatch);
        }

        [Test, Description("Testing the distance of 100, 100 and 101, 101, should be within 200km")]
        public void Test_GeoCodeMatcher_DifferentLatitudeLongiture_1degreedifference_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 100
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 101, 
                Longitude = 101
            };

            // Distance should be squareroot (1 * 1 + 1 * 1) * 111 = 156km: within 200km

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }

        [Test, Description("Testing the distance of 100, 100 and 102, 102, should be outside 200km, should not match")]
        public void Test_GeoCodeMatcher_DifferentLatitudeLongiture_2degreedifference_Expect_Return_Matched()
        {
            Property agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 100,
                Longitude = 100
            };

            Property databaseProperty = new Property
            {
                AgencyCode = "LRE",
                Latitude = 102,
                Longitude = 102
            };

            // Distance should be squareroot (2 * 2 + 2 * 2) * 111 = 222km: outside 200km

            IPropertyMatcher propertyMatcher = new GeoCodeMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(isMatch);
        }
        #endregion GeoCodeTests

        #region ReverseWordMatcherTests
        [Test]
        public void Test_ReverseNameMatch()
        {
            Property agencyProperty = new Property
            {
                Name = "Apartments Summit The",
            };

            Property databaseProperty = new Property
            {
                Name = "The Summit Apartments",
            };

            IPropertyMatcher propertyMatcher = new ReverseWordMatcher();

            bool isMatch = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(isMatch);
        }
        #endregion ReverseWordMatcherTests
    }
}
