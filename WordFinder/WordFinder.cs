using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Extentions;
using Common.Utils;

namespace WordFinder
{
    public class WordFinder : IWordFinder
    {
        public char[,] CharMatrix;
        private readonly int _matrixCols;
        private readonly int _matrixRows;
        private const int MaxResultOutput = 10;
        const int MaxMoveAllowed = 2;
        private static readonly int[] MoveToRight = { 1, 0};
        private static readonly int[] MoveToDown = { 0, 1 };
        
        public List<string> ResultList = new List<string>();

        public WordFinder(IEnumerable<string> wordstream)
        {
            int rows = wordstream.Count(), cols = rows;
            
            CharMatrix = MatrixBuilder
                .For(wordstream)
                .WithSize(rows, cols)
                .ToMatrix();

            _matrixRows = rows;
            _matrixCols = cols;
        }
    
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
            {
                using (new Benchmark("Search simple node comparation version Completed in:"))
                {
                    foreach (var word in wordstream)
                        for (var row = 0; row < _matrixRows; row++)
                        for (var col = 0; col < _matrixCols; col++)
                            if (SearchInMatrix(row, col, word))
                                ResultList.Add(word);
                }

                return ResultList.TakeRepeatedWords(MaxResultOutput);
            }


            private bool SearchInMatrix(int row, int col, string word)
            {
              
                if (!CharMatrix.NodeMatch(row, col, word.FirstChar())) return false;

                for (var steps = 0; steps < MaxMoveAllowed; steps++)
                {
                    var nextNode = new Node(row + MoveToRight[steps], col + MoveToDown[steps]);
                    var remaininChar = 1; 
                    while (remaininChar < word.Length) 
                    {
                        if (CharMatrix.OutOfBoundaries(nextNode) || !CharMatrix.NodeMatch(nextNode.Right, nextNode.Down, word.CurrentChar(remaininChar))) { break; }

                        nextNode.Right += MoveToRight[steps];
                        nextNode.Down += MoveToDown[steps];

                        remaininChar++;
                    }

                    if (remaininChar == word.Length) return true;
                }

                return false;
            }
    }
}

