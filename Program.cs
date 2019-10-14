using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace MostCommonWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // WebClient client = new WebClient();
            // string nightOceanWords = client.DownloadString("http://www.hplovecraft.com/writings/texts/fiction/no.aspx");
            // Console.WriteLine(nightOceanWords);
            NightOcean nightOcean = new NightOcean();

            string lowerCaseStory = nightOcean.Story.ToLower();

            List<char> goodChars = new List<char>(){
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            // Create a new string with only the letters and spaces
            string wordsOnly = "";

            foreach(char character in lowerCaseStory)
            {
                if (goodChars.Contains(character))
                {
                    wordsOnly += character;
                }
            }

            string wordsWithCaps = "";
            foreach(char character in nightOcean.Story)
            {
                if (goodChars.Contains(character))
                {
                    wordsWithCaps += character;
                }
            }


            // Console.WriteLine(wordsWithCaps);

            // Split the wordsOnly string on a space to get a list of strings

            string[] allWords = wordsOnly.Split(" ");
            string[] allWordsWithCaps = wordsWithCaps.Split(" ");

            foreach(string word in allWordsWithCaps)
            {
                // Console.WriteLine(word);
            }

            var wordCount = allWords.GroupBy(word => word, (key, value) => new WordCount
                {
                    Word = key,
                    Count = value.Count()
                }).OrderByDescending(result => result.Count).ToList();

            var wordCountWithCaps = allWordsWithCaps.GroupBy(word => word, (key, value) => new WordCount
                {
                    Word = key,
                    Count = value.Count()
                }).OrderByDescending(result => result.Count).ToList();

            foreach(WordCount item in wordCount)
            {
                // Console.WriteLine($"{item.Word}: {item.Count}");
            }

            // Print out counts for capitalized words
            foreach(WordCount item in wordCountWithCaps)
            {
                // Console.WriteLine($"{item.Word}: {item.Count}");
            
            }

            // Iterate over the top ten words from the lowercase list. Then for each top lowercase word, iterate over the 
            for (int i = 0; i < 10; i++)
            {
                List<string> topWords = new List<string>();
                foreach (string originalWord in allWordsWithCaps)
                {

                    if (wordCount[i].Word == originalWord.ToLower())
                    {
                        topWords.Add(originalWord);
                    }

                }

                var topWordCount = topWords.GroupBy(word => word, (key, value) => new WordCount
                {
                    Word = key,
                    Count = value.Count()
                }).OrderByDescending(result => result.Count).ToList();

                foreach (WordCount result in topWordCount)
                {
                    Console.Write($"{result.Word}: {result.Count}, ");
                }

                Console.WriteLine();

            }

        }
    }
}
