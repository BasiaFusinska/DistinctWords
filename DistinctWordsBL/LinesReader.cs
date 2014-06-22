using System.Collections.Generic;
using System.IO;

namespace DistinctWordsBL
{
    public class LinesReader : IWordsReader
    {
        private readonly IWordsParser _parser;

        public LinesReader(IWordsParser parser)
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

        public IEnumerable<string> ReadWords(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                //foreach (var word in ReadWords(reader))
                //{
                //    yield return word;
                //}

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
}
