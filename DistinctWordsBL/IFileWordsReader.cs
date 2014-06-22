using System.Collections.Generic;

namespace DistinctWordsBL
{
    public interface IFileWordsReader
    {
        IEnumerable<string> ReadWordsFromFile(string fileName);
    }
}
