﻿using System.Collections.Generic;
using System.IO;

namespace DistinctWordsBL
{
    public class FileWordsReader : IFileWordsReader
    {
        private readonly IWordsReader _wordsReader;

        public FileWordsReader(IWordsReader wordsReader)
        {
            _wordsReader = wordsReader;
        }
        public IEnumerable<string> ReadWordsFromFile(string fileName)
        {
            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var bs = new BufferedStream(fs))
                {
                    using (var reader = new StreamReader(bs))
                    {
                        foreach (var word in _wordsReader.ReadWords(reader))
                        {
                            yield return word;
                        }
                    }
                }
            }
        }
    }
}
