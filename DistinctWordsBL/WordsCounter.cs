using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DistinctWordsBL
{
    public class WordsCounter
    {
        private readonly WordsMap _wordsMap = new WordsMap();

        public WordsMap CountDistinctWordsInFile(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = SplitLine(line);
                    _wordsMap.FillWithWords(words);
                }
            }

            return _wordsMap;
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
