using System.Collections.Generic;
using System.IO;

namespace DistinctWordsBL
{
    public class WordsReader : IWordsReader
    {
        private readonly IWordsParser _parser;

        public WordsReader(IWordsParser parser)
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
