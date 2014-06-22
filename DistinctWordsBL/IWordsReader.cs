using System.Collections.Generic;
using System.IO;

namespace DistinctWordsBL
{
    public interface IWordsReader
    {
        IEnumerable<string> ReadWords(StreamReader reader);
        IEnumerable<string> ReadWords(string fileName);
    }
}
