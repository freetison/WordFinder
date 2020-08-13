using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extentions
{
    public static class CoreEx
    {
        public static char[,] To2DArray(this IEnumerable<string> source, int size)
        {
            var result = new char[size, size];

            foreach (var item in source.Select((value, index) => (value, index)))
                for (var col = 0; col < size; col++)
                    result[item.index, col] = item.value[col];
            return result;
        }

        public static void PrintFrecuency(this List<string> list)
        {
            var frecuencyWords = list
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count());

            foreach (var word in frecuencyWords) Console.WriteLine($"{word.Key} found {word.Count()} time ");
        }

        public static IEnumerable<string> PrintList(this IEnumerable<string> list)
        {
            foreach (var item in list) Console.WriteLine($"{item}");

            return list;
        }

        public static void PrintMatrix(this char[,] matrix)
        {
            Console.WriteLine();
            for (var row = 0; row < matrix.GetUpperBound(0) + 1; row++)
            {
                for (var col = 0; col < matrix.GetUpperBound(1) + 1; col++) Console.Write(matrix[row, col]);

                Console.WriteLine();
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source != null && !source.Any();

        public static char FirstChar(this string str) => str[0];

        public static char CurrentChar(this string str, int index) => str[index];

        public static bool NodeMatch(this char[,] nodeValue, int row, int col, char criteria) => nodeValue[row, col] == criteria;

        public static bool OutOfBoundaries(this char[,] matrix, Node nextNode) => nextNode.Right >= matrix.GetUpperBound(0) + 1 || nextNode.Down >= matrix.GetUpperBound(1) + 1;

        public static List<string> TakeRepeatedWords(this List<string> source, int numberToTake)
        {
            return source
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .Distinct()
                .Take(numberToTake)
                .Select(x => x.Key)
                .ToList();

        }
    }
}
