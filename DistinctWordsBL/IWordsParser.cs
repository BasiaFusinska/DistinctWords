using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctWordsBL
{
    public interface IWordsParser
    {
        IEnumerable<string> ReadWords(string text);
    }
}
