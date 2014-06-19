using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DistinctWordsBL
{
    public class WordsMap : IEnumerable<string>
    {
        private readonly IDictionary<string, int> _wordsMap = new Dictionary<string, int>();

        public void FillWithWords(IEnumerable<string> words)
        {
            foreach (var word in words.Select(w => w.ToUpperInvariant()))
            {
                if (_wordsMap.ContainsKey(word))
                {
                    _wordsMap[word]++;
                }
                else
                {
                    _wordsMap[word] = 1;
                }
            }
        }

        public int this[string word]
        {
            get { return _wordsMap[word]; }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _wordsMap.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
