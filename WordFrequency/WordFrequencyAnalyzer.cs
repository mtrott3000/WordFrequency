using System.Text.RegularExpressions;

namespace Test
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateHighestFrequency(string text) 
        {
            return GetAllWords(text)[0].Frequency;
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            var list = GetAllWords(text);
            var index = list.FindIndex(i => i.Word.Equals(word));

            if (index >= 0)
            {
                return list[index].Frequency;
            }
            else
            {
                return 0;
            }
        }

        public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
        {
            var sortedList = GetAllWords(text);

            if (sortedList.Count < number)
            {
                return sortedList;
            }
            else
            {
                var subList = sortedList.GetRange(0, number);
                return sortedList.Where(i => i.Frequency >= subList[^1].Frequency).ToList();
            }
        }

        public static List<IWordFrequency> GetAllWords(string text)
        {
            var splitWords = text.Split(" ");
            var words = new List<IWordFrequency>();

            if (!Regex.IsMatch(String.Join(string.Empty, splitWords), @"^[a-zA-Z]+$"))
            {
                throw new ArgumentOutOfRangeException("The input text is invalid. It must contain word(s) that are made up from a-z or A-Z.");
            }

            foreach (var word in splitWords)
            {
                var index = words.FindIndex(i => i.Word.Equals(word.ToLower()));
                if (index >= 0)
                {
                    words[index].Frequency += 1;
                }
                else
                {
                    words.Add(new WordFrequency(word.ToLower(), 1));
                }
            }

            return words.OrderBy(i => i.Word).OrderByDescending(i => i.Frequency).ToList();
        }
    }
}
