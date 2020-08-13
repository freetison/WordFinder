using System.Collections.Generic;

namespace Common
{
    public interface IMatrixProcessor
    {
        IMatrixProcessor WithSize(int rows, int cols);
        char[,] ToMatrix();
        IEnumerable<string> AddRotate();
    }
}