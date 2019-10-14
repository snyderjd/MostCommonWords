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

            // char[] goodChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            //      'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '};"

            List<char> goodChars = new List<char>(){
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '
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

            // Console.WriteLine(wordsOnly);

            // Split the wordsOnly string on a space to get a list of strings

            string[] allWords = wordsOnly.Split(" ");

            foreach(string word in allWords)
            {
                // Console.WriteLine(word);
            }

            var wordCount = allWords.GroupBy(word => word, (key, value) => new WordCount 
                {
                    Word = key,
                    Count = value.Count()
                }).OrderByDescending(result => result.Count).ToList();

            foreach(WordCount item in wordCount)
            {
                Console.WriteLine($"{item.Word}: {item.Count}");
            }

            // Print out the top ten words
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{wordCount[i].Word}: {wordCount[i].Count}");
            }


        }
    }
}
