using System.IO;

namespace DistinctWordsBL
{
    public class WordsCounter
    {
        private readonly IWordsReader _wordsReader;
        private readonly WordsMap _wordsMap = new WordsMap();

        public WordsCounter(IWordsReader wordsReader)
        {
            _wordsReader = wordsReader;
        }

        public WordsMap CountDistinctWordsInFile(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                _wordsMap.FillWithWords(_wordsReader.ReadWords(reader));
            }
            return _wordsMap;
        }
    }
}
