using System;
using System.Collections.Generic;
using Common;
using Common.Extentions;
using Common.Utils;

namespace WordFinder
{
    class Program
    {

        static void Main(string[] args)
        {
            var words = new List<string> {"cold", "wind", "snow", "chill", "Hope", "Linux", "Hat", "Sky", "Fish", "Dog", "Love"};

            var wordFinder = new WordFinder(Mock.Data());
            var foundWords = wordFinder.Find(words);

            // Print it
            Console.WriteLine("---------------------------- Frecuency ----------------------------");
            wordFinder.ResultList.PrintFrecuency();
            Console.WriteLine("--------------------  Top 10 order by Frecuency --------------------");
            foundWords.PrintList();


            Console.ReadLine();
        }
    }
}
