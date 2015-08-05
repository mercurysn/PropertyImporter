using NUnit.Framework;
using PropertyImporter.Common.ExtensionMethods;

namespace PropertyImporter.UnitTest.ExtensionMethods
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void Test_RemovePunctuation()
        {
            const string test_string = "\"*Super*-High! APARTMENTS (Sydney).!@#$%^&*()";
            const string test_string2 = "32 Sir John-Young Crescent, Sydney, NSW";

            string stringWithoutPunctuation = test_string.RemovePunctuation();
            string stringWithoutPunctuation2 = test_string2.RemovePunctuation();

            Assert.AreEqual("super high apartments sydney", stringWithoutPunctuation);
            Assert.AreEqual("32 sir john young crescent sydney nsw", stringWithoutPunctuation2);
        }

        [Test]
        public void Test_ConvertToKm()
        {
            const decimal degree = 2;

            decimal result = degree.ConvertToKm();

            Assert.AreEqual(222, result);
        }
    }
}
