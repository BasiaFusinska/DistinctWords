using System.Linq;
using DistinctWordsBL;
using Xunit;
using Xunit.Extensions;

namespace DistinctWordsTests
{
    public class WordsParserTests
    {
        [Theory]
        [InlineData("aaa bbb ccc", "aaa", "bbb", "ccc")]
        [InlineData("a1aa bbb ccc2", "a1aa", "bbb", "ccc2")]
        [InlineData("aaa 1 bbb", "aaa", "1", "bbb")]
        public void line_with_words_should_be_splitted_to_proper_words(string line, string s1, string s2, string s3)
        {
            var parser = new WordsParser();
            var words = parser.ReadWords(line).ToList();

            Assert.Equal(words.Count, 3);
            Assert.Equal(words[0], s1);
            Assert.Equal(words[1], s2);
            Assert.Equal(words[2], s3);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\n")]
        public void line_with_empty_spaces_should_return_empty_collection(string line)
        {
            var parser = new WordsParser();
            var words = parser.ReadWords(line).ToList();

            Assert.Empty(words);
        }
    }
}
