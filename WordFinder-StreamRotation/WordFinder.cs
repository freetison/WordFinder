using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common;
using Common.Extentions;
using Common.Utils;

namespace WordFinder_StreamRotation
{
    public class WordFinder : IWordFinder
    {
        private const int MaxResultOutput = 10;
        private readonly IEnumerable<string> Matrix;
        public List<string> ResultList = new List<string>();
        
        public WordFinder(IEnumerable<string> matrix) => Matrix = matrix;

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            using (new Benchmark("Search Rotated Stream version Completed in:"))
            {
                foreach (var word in wordstream)
                {
                    foreach (var item in Matrix)
                    {
                        var occurrenceWordCount = Regex.Matches(item, word).Count();
                        ResultList.AddRange(Enumerable.Repeat(word, occurrenceWordCount));
                    }
                }                    
            }

            return ResultList.TakeRepeatedWords(MaxResultOutput);
        }

    }
}
