using System.Collections.Generic;

namespace DistinctWordsBL
{
    public interface IWordsParser
    {
        IEnumerable<string> ReadWords(string text);
    }
}
