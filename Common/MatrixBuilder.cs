using System.Collections.Generic;
using System.Linq;
using Common.Exceptions;
using Common.Extentions;

namespace Common
{
    public class MatrixBuilder : IMatrixProcessor
    {
        private int _matrixCols;
        private int _matrixRows;

        private List<string> _matrixSource;
        
        private MatrixBuilder(IEnumerable<string> source) => _matrixSource = source.ToList();

        public IMatrixProcessor WithSize(int rows, int cols)
        {
            if (!IsvalidStringMatrixSize(_matrixSource, rows, cols)) throw new InValidSizeException();

            _matrixRows = rows;
            _matrixCols = cols;
            return this;
        }

        public char[,] ToMatrix()
        {
            var matrix = _matrixSource.To2DArray(_matrixRows);
            return matrix;
        }

        public IEnumerable<string> AddRotate()
        {
            var tempMatrix = new List<string>();
            for (var col = 0; col < _matrixCols; col++)
            {
                var rotatedLine = string.Empty;
                foreach (var item in _matrixSource) rotatedLine += item[col];
                tempMatrix.Add(rotatedLine);
            }

            var fullMatrix = _matrixSource.Concat(tempMatrix);
            _matrixSource = fullMatrix.ToList();
            return _matrixSource;
        }

        public static IMatrixProcessor For(IEnumerable<string> source)
        {
            if (source.IsNullOrEmpty()) throw new InValidException();
            return new MatrixBuilder(source);
        }

        private static bool IsvalidStringMatrixSize(IEnumerable<string> source, int rows, int cols)
        {
            var sourceRows = source.Count();
            var sourceCols = source.Count(x => x.Length == rows);
            return sourceRows == sourceCols && sourceCols == cols && sourceRows == cols;
        }
    }
}