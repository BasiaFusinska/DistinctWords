using System.Collections.Generic;
using System.IO;

namespace DistinctWordsBL
{
    public class WordsReader : IWordsReader
    {
        private readonly WordsParser _parser;

        public WordsReader(WordsParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<string> ReadWords(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (var word in _parser.ReadWords(line))
                {
                    yield return word;
                }
            }
        }
    }
}
