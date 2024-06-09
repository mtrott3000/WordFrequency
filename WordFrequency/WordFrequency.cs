using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test
{
    public class WordFrequency : IWordFrequency
    {
        public string Word { get; set; }
        public int Frequency { get; set; }

        public WordFrequency(string word, int frequency) 
        {
            Word = word;
            Frequency = frequency;
        }
    }
}
