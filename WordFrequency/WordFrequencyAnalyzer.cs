using System.Text.RegularExpressions;

namespace Test
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateHighestFrequency(string text) 
        {
            return SortWordsIntoFrequencyOrder(text)[0].Frequency;
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            var list = SortWordsIntoFrequencyOrder(text);
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
            var sortedList = SortWordsIntoFrequencyOrder(text);

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

        public List<IWordFrequency> SortWordsIntoFrequencyOrder(string text)
        {
            var splitWords = text.Split(" ");
            var sortedList = new List<IWordFrequency>();

            if (!Regex.IsMatch(String.Join(string.Empty, splitWords), @"^[a-zA-Z]+$"))
            {
                throw new ArgumentOutOfRangeException("The input text is invalid. It must contain word(s) that are made up from a-z or A-Z.");
            }

            foreach (var word in splitWords)
            {
                var index = sortedList.FindIndex(i => i.Word.Equals(word.ToLower()));
                if (index >= 0)
                {
                    sortedList[index].Frequency += 1;
                }
                else
                {
                    sortedList.Add(new WordFrequency(word.ToLower(), 1));
                }
            }

            return sortedList.OrderBy(i => i.Word).OrderByDescending(i => i.Frequency).ToList();
        }
    }
}
