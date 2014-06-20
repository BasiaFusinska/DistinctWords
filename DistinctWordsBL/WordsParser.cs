using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DistinctWordsBL
{
    public class WordsParser : IWordsParser
    {
        public IEnumerable<string> ReadWords(string text)
        {
            return (from Match m
                    in Regex.Matches(text, @"\w+", RegexOptions.IgnorePatternWhitespace)
                    select m.Groups[0].Value)
                    .ToList();
        }

    }
}
