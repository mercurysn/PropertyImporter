using System.Collections.Generic;
using System.Linq;

namespace PropertyImporter.Common.Matcher
{
    public class ReverseWordMatcher : IPropertyMatcher
    {
        public bool IsMatch(Models.Property agencyProperty, Models.Property databaseProperty)
        {
            List<string> agencyPropertyNameWordsReversed = agencyProperty.Name.Split(' ').Reverse().ToList();
            List<string> databasePropertyNameWords = databaseProperty.Name.Split(' ').ToList();

            return agencyPropertyNameWordsReversed.SequenceEqual(databasePropertyNameWords);
        }
    }
}
