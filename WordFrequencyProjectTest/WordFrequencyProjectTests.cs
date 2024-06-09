using Test;

namespace WordFrequencyProjectTest
{
    public class WordFrequencyProjectTests
    {
        public readonly WordFrequencyAnalyzer _wordFrequencyAnalyzer = new WordFrequencyAnalyzer();
        public readonly string _argumentOutOfRangeExceptionMessage = "Specified argument was out of the range of valid values. (Parameter 'The input text is invalid. It must contain word(s) that are made up from a-z or A-Z.')";

        [SetUp]
        public void Setup()
        {
        }

        public static object[] calculateMostFrequentWordsTestCases =
        {
            new object[] {
                "The sun shines over the lake",
                2,
                new List<IWordFrequency>()
                {
                    new WordFrequency("the", 2),
                    new WordFrequency("lake", 1),
                    new WordFrequency("over", 1)
                }
            },
            new object[] {
                "This TEst is a TEST for this is a test tEsT for testing frequency for teST words",
                3,
                new List<IWordFrequency>()
                {
                    new WordFrequency("test", 5),
                    new WordFrequency("for", 3),
                    new WordFrequency("a", 2),
                    new WordFrequency("is", 2),
                    new WordFrequency("this", 2),
                }
            },
            new object[] {
                "This TEst is a TEST for this is a test",
                10,
                new List<IWordFrequency>()
                {
                    new WordFrequency("test", 3),
                    new WordFrequency("a", 2),
                    new WordFrequency("is", 2),
                    new WordFrequency("this", 2),
                    new WordFrequency("for", 1),
                }
            },
        };

        [TestCaseSource(nameof(calculateMostFrequentWordsTestCases))]
        public void WordFrequencyAnalyzer_CalculateMostFrequentWords_ValidTests(string text, int count, List<IWordFrequency> expectedResult)
        {
            var result = _wordFrequencyAnalyzer.CalculateMostFrequentWords(text, count);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(result[i].Word, Is.EqualTo(expectedResult[i].Word));
                Assert.That(result[i].Frequency, Is.EqualTo(expectedResult[i].Frequency));
            }
        }

        public static object[] calculateHighestFrequencyTestCases =
        {
            new object[] { "The sun shines over the lake", 2},
            new object[] { "This TEst is a TEST for this is a test tEsT for testing frequency for teST words", 5 },
            new object[] { "Test", 1 },
        };

        [TestCaseSource(nameof(calculateHighestFrequencyTestCases))]
        public void WordFrequencyAnalyzer_CalculateHighestFrequency_ValidTests(string text, int count)
        {
            var result = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.That(result, Is.EqualTo(count));
        }

        public static object[] calculateFrequencyForWordTestCases =
        {
            new object[] { "The sun shines over the lake", "the", 2 },
            new object[] { "This TEst is a TEST for this is a test tEsT for testing frequency for teST words", "test", 5 },
            new object[] { "Test", "test", 1 },
            new object[] { "Testtest", "test", 0 }
        };

        [TestCaseSource(nameof(calculateFrequencyForWordTestCases))]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_ValidTests(string text, string word, int count)
        {
            var result = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            Assert.That(result, Is.EqualTo(count));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateMostFrequentWords_ExceptionThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => _wordFrequencyAnalyzer.CalculateMostFrequentWords("asx!v..dw adw82", 3));
            Assert.That(exception.Message, Is.EqualTo(_argumentOutOfRangeExceptionMessage));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateHighestFrequency_ExceptionThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => _wordFrequencyAnalyzer.CalculateHighestFrequency("asx!v..dw adw82"));
            Assert.That(exception.Message, Is.EqualTo(_argumentOutOfRangeExceptionMessage));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_ExceptionThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => _wordFrequencyAnalyzer.CalculateFrequencyForWord("asx!v..dw adw82", "adw"));
            Assert.That(exception.Message, Is.EqualTo(_argumentOutOfRangeExceptionMessage));
        }
    }
}