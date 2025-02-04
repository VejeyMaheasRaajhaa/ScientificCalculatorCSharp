//#define NotCompulsory
using System.Diagnostics;
using System.Text;

namespace CalculatorApp
{
    internal class Matrix : IMatrix
    {
        public int NcolsA { get; set; }
        public int NrowsA { get; set; }
        public int NcolsB { get; set; }
        public int NrowsB { get; set; }

        public int[,] MatrixA;
        public int[,] MatrixB;
        public int[,] MatrixR;
        public Matrix()
        {

        }
        public Matrix(int ncolsA, int nrowsA, int ncolsB, int nrowsB, int[,] matrixA, int[,] matrixB, int[,] matrixR)
        {
            NcolsA = ncolsA;
            NrowsA = nrowsA;
            NcolsB = ncolsB;
            NrowsB = nrowsB;
            MatrixA = matrixA;
            MatrixB = matrixB;
            MatrixR = matrixR;
        }
        public void GetMatrixDimensions()
        {
            Console.Write("\nEnter the Number of Rows of Matrix 'A' : ");
            NrowsA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Number of Columns of Matrix 'A' : ");
            NcolsA = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter the Number of Rows of Matrix 'B' : ");
            NrowsB = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Number of Columns of Matrix 'B' : ");
            NcolsB = Convert.ToInt32(Console.ReadLine());
        }
        public void GetMatrix(out string MatAB)
        {
            StringBuilder x = new StringBuilder();
            MatrixA = new int[NrowsA, NcolsA];
            MatrixB = new int[NrowsB, NcolsB];
            Console.WriteLine();
            for (int i = 0; i < NrowsA; i++)
            {
                for (int j = 0; j < NcolsA; j++)
                {
                    Console.Write($"Enter element A[{i + 1}][{j + 1}] : ");
                    MatrixA[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            for (int i = 0; i < NrowsB; i++)
            {
                for (int j = 0; j < NcolsB; j++)
                {
                    Console.Write($"Enter element B[{i + 1}][{j + 1}] : ");
                    MatrixB[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            x.Append("\nMatrix A\n");
            Console.WriteLine(x);
            DisplayMatrix(MatrixA,NrowsA,NcolsA,out MatAB);
            x.Append(MatAB);
            x.Append("\nMatrix B\n");
            Console.WriteLine("\nMatrix B\n");
            DisplayMatrix(MatrixB, NrowsB, NcolsB, out MatAB);
            x.Append(MatAB);
            MatAB = x.ToString();
        }
        [Conditional("NotCompulsory")]
        public void DisplayMatrix(int[,] Matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        /*
        This part executes when
        NotCompulsory is defined!
        */
        public void DisplayMatrix(int[,] Matrix, int rows, int cols, out string result2)
        {
            StringBuilder x = new();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    x.Append($"{Matrix[i, j]} ");
                }
                x.Append("\n");
            }
            result2 = x.ToString();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result2);
            Console.ResetColor();
        }
        public void MatrixProduct(out string finalResult)
        {
            try
            {
                StringBuilder x = new();
                string final2;
                GetMatrixDimensions();
                if (NcolsA == NrowsB)
                {
                    EventHolder eventHolder = new EventHolder();
                    eventHolder.OperationCompleted += NotifyProduct;
                    GetMatrix(out final2);
                    MatrixR = new int[NrowsA, NcolsB];

                    for (int i = 0; i < NrowsA; i++)
                    {
                        for (int j = 0; j < NcolsB; j++)
                        {
                            for (int k = 0; k < NrowsB; k++)
                            {
                                MatrixR[i, j] += MatrixA[i, k] * MatrixB[k, j];
                            }
                        }
                    }
                    x.Append(final2);
                    x.Append("\nMatrixA * MatrixB  : \n\n");
                    Console.WriteLine("\nMatrixA * MatrixB  : \n");
                    DisplayMatrix(MatrixR, NrowsA, NcolsB);
                    DisplayMatrix(MatrixR, NrowsA, NcolsB, out final2);
                    x.Append(final2);
                    finalResult = x.ToString();

                    eventHolder.OnOperationCompleted();
                }
                else
                {
                    finalResult = "";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nDimensions of the Matrices do not support Matrix Multiplication!\n");
                    Console.ResetColor();
                }
            }
            catch (System.FormatException Exception1)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Input!\n");
                Console.ResetColor();
            }
        }
        public void MatrixSubtract(out string finalResult)
        {
            try
            {
                StringBuilder x = new();
                string final2;
                GetMatrixDimensions();
                if (NcolsA == NcolsB && NrowsA == NrowsB)
                {
                    EventHolder eventHolder = new EventHolder();
                    eventHolder.OperationCompleted += NotifyDifference;
                    GetMatrix(out final2);
                    MatrixR = new int[NrowsA, NcolsB];

                    for (int i = 0; i < NrowsA; i++)
                    {
                        for (int j = 0; j < NcolsB; j++)
                        {
                            MatrixR[i, j] = MatrixA[i, j] - MatrixB[i, j];
                        }
                    }
                    x.Append(final2);
                    x.Append("\nMatrixA - MatrixB  : \n");
                    Console.WriteLine("\nMatrixA - MatrixB  : \n");
                    DisplayMatrix(MatrixR, NrowsA, NcolsB, out final2);
                    x.Append(final2);
                    finalResult = x.ToString();

                    eventHolder.OnOperationCompleted();
                }
                else
                {
                    finalResult = "";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nDimensions of the Matrices do not support Matrix Subtraction!\n");
                    Console.ResetColor();
                }
            }
            catch (System.FormatException Exception1)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Input!\n");
                Console.ResetColor();
            }
        }
        public void NotifyDifference()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calculation of Matrix Subtraction completed Successfully!\n");
            Console.ResetColor();
        }
        public void NotifyProduct()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calculation of Matrix Multiplication completed Successfully!\n");
            Console.ResetColor();
        }
    }
}