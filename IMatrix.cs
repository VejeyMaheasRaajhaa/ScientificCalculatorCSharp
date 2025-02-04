using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal interface IMatrix : IDiffProd
    {
        public void GetMatrixDimensions();
        public void GetMatrix(out string MatAB);
        public void DisplayMatrix(int[,] Matrix, int rows, int cols, out string result2);
        public void MatrixProduct(out string finalResult);
        public void MatrixSubtract(out string finalResult);
    }
}