using System;
using DistinctWordsBL;

namespace DistinctWords
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Wrong arguments amount", "args");

            var wordsCounter = new WordsCounter(new FileWordsReader(new LinesReader(new WordsParser())));
            var wordsMap = wordsCounter.CountDistinctWordsInFile(args[0]);

            DisplayWordsMap(wordsMap);
            
            Console.ReadLine();
        }

        private static void DisplayWordsMap(WordsMap wordsMap)
        {
            foreach (var word in wordsMap)
            {
                Console.WriteLine("{0}: {1}", word, wordsMap[word]);
            }
            
        }
    }
}
