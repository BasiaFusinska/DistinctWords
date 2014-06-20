using System.IO;

namespace DistinctWordsBL
{
    public class WordsCounter
    {
        private readonly WordsReader _wordsReader;
        private readonly WordsMap _wordsMap = new WordsMap();

        public WordsCounter(WordsReader wordsReader)
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
