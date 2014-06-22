namespace DistinctWordsBL
{
    public class WordsCounter
    {
        private readonly IFileWordsReader _fileWordsReader;
        private readonly WordsMap _wordsMap = new WordsMap();

        public WordsCounter(IFileWordsReader fileWordsReader)
        {
            _fileWordsReader = fileWordsReader;
        }

        public WordsMap CountDistinctWordsInFile(string fileName)
        {
            _wordsMap.FillWithWords(_fileWordsReader.ReadWordsFromFile(fileName));
            return _wordsMap;
        }
    }
}
