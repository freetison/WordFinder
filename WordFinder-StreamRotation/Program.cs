using System;
using System.Collections.Generic;
using Common;
using Common.Extentions;
using Common.Utils;

namespace WordFinder_StreamRotation
{
    internal class Program
    {
        //private IEnumerable<string> CombinedMatrix = Enumerable.Empty<string>();

        private static void Main(string[] args)
        {
            const int matrixCols = 64;
            const int matrixRows = 64;
            var words = new List<string> {"cold", "wind", "snow", "chill", "Hope", "Linux", "Hat", "Sky", "Fish", "Dog", "Love"};

            var combinedMatrix = MatrixBuilder
                .For(Mock.Data())
                .WithSize(matrixRows, matrixCols)
                .AddRotate();

            var wordFinder = new WordFinder(combinedMatrix);
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