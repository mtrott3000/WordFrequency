// See https://aka.ms/new-console-template for more information
using Test;

Console.WriteLine("Hello, World!");

var test = new WordFrequencyAnalyzer();
Console.WriteLine(test.CalculateMostFrequentWords("The sun shines over the lake", 3).ToString());