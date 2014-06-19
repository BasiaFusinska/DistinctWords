using System;
using System.Linq;
using DistinctWordsBL;
using Xunit;

namespace DistinctWordsTests
{
    public class WordsMapTests
    {
        [Fact]
        public void newly_created_map_should_be_empty()
        {
            var wordsMap = new WordsMap();
            Assert.Equal(wordsMap.Count(), 0);
        }

        [Fact]
        public void map_filled_with_distinct_words_should_contain_them_with_1()
        {
            var wordsMap = new WordsMap();
            wordsMap.FillWithWords(new [] {"a", "b", "c"});
            Assert.Equal(wordsMap.Count(), 3);

            Assert.Equal(wordsMap["a"], 1);
            Assert.Equal(wordsMap["b"], 1);
            Assert.Equal(wordsMap["c"], 1);
        }

        [Fact]
        public void map_filled_with_same_words_should_contain_them_with_proper_amount()
        {
            var wordsMap = new WordsMap();
            wordsMap.FillWithWords(new[] { "a", "b", "c", "a", "b", "d", "b" });
            Assert.Equal(wordsMap.Count(), 4);

            Assert.Equal(wordsMap["a"], 2);
            Assert.Equal(wordsMap["b"], 3);
            Assert.Equal(wordsMap["c"], 1);
            Assert.Equal(wordsMap["d"], 1);
        }

        [Fact]
        public void map_filled_with_empty_collection_should_not_contain_data()
        {
            var wordsMap = new WordsMap();
            wordsMap.FillWithWords(Enumerable.Empty<string>());
            Assert.Equal(wordsMap.Count(), 0);            
        }

        [Fact]
        public void map_filled_with_null_should_throw_argument_null_exception()
        {
            var wordsMap = new WordsMap();
            Assert.Throws<ArgumentNullException>(() => wordsMap.FillWithWords(null));
        }

    }
}
