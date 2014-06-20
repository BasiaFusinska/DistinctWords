using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DistinctWordsBL
{
    public class WordsReader
    {
        public IEnumerable<string> ReadWords(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (var word in SplitLine(line))
                {
                    yield return word;
                }
            }
        }

        private static IEnumerable<string> SplitLine(string line)
        {
            return (from Match m
                    in Regex.Matches(line, @"\w+", RegexOptions.IgnorePatternWhitespace)
                    select m.Groups[0].Value)
                    .ToList();
        }

    }
}
