using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DistinctWords
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Wrong arguments amount", "args");

            var fileName = args[0];

            if (!File.Exists(fileName))
                throw new FileNotFoundException("File doesn't exist", fileName);

            var words = CountDistinctWordsInFile(fileName);
            foreach (var word in words.Keys)
            {
                Console.WriteLine("{0}: {1}", word, words[word]);
            }

            Console.ReadLine();
        }

        private static IDictionary<string, int> CountDistinctWordsInFile(string fileName)
        {
            var wordsCount = new Dictionary<string, int>();

            using (var reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = SplitLine(line);
                    FillWordsMap(words, wordsCount);
                }
            }

            return wordsCount;
        }

        private static IEnumerable<string> SplitLine(string line)
        {
            var pattern = new Regex(@"\w+", RegexOptions.IgnorePatternWhitespace);

            return (from Match m in pattern.Matches(line) select m.Groups[0].Value).ToList();
        }
        private static void FillWordsMap(IEnumerable<string> words, IDictionary<string, int> wordsMap)
        {
            foreach (var word in words.Select(w => w.ToUpperInvariant()))
            {
                if (wordsMap.ContainsKey(word))
                {
                    wordsMap[word]++;
                }
                else
                {
                    wordsMap.Add(word, 1);
                }
            }
        }
    }
}
