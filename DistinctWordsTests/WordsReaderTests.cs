using System.IO;
using DistinctWordsBL;
using Moq;
using Xunit;

namespace DistinctWordsTests
{
    public class WordsReaderTests
    {
        private const string Word1 = "aaa";
        private const string Word2 = "bbb";

        private const string Line = "xxx\n";
        private const int NumberOfLines = 5;

        private static StreamReader PrepareStream()
        {
            MemoryStream original;
            using (original = new MemoryStream())
            {
                using (var sw = new StreamWriter(original))
                {
                    for (var lineNumber = 0; lineNumber < NumberOfLines; lineNumber++)
                    {
                        sw.Write(Line);
                    }
                }
            }

            return new StreamReader(new MemoryStream(original.ToArray()));
        }
        [Fact]
        public void reading_from_stream_should_parse_every_line()
        {
            var parserMock = new Mock<IWordsParser>();
            parserMock.Setup(p => p.ReadWords(It.IsAny<string>())).Returns(new[] { Word1, Word2 });

            var wordsReader = new LinesReader(parserMock.Object);

            var index = 0;
            using (var reader = PrepareStream())
            {
                foreach (var word in wordsReader.ReadWords(reader))
                {
                    Assert.Equal(word, index%2 == 0 ? Word1 : Word2);
                    index++;
                }
            }
            Assert.Equal(index, NumberOfLines*2);

            parserMock.Verify(p => p.ReadWords(It.IsAny<string>()), Times.Exactly(NumberOfLines));
        }
    }
}
