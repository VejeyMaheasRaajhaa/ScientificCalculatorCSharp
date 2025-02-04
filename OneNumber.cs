using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class OneNumber
    {
        protected double Input;
        protected int Precision;
        protected virtual void GetInput(OperationType isCubeRoot)
        {
            Console.Write($"\nEnter the Number : ");
            if(!Double.TryParse(Console.ReadLine(),out Input))
            {
                throw new Exception("Invalid Input!");
            }
            if (Input - Convert.ToInt32(Input) != 0 || isCubeRoot == OperationType.CubeRoot)
            {
                Console.Write("\nHow precise you want your results to be?(Maximum 15) : ");
                if(!int.TryParse(Console.ReadLine(),out Precision) || !( Precision >=0 && Precision <= 15))
                {
                    Precision = 15;
                    Console.WriteLine("\nPrecision of the result is set to be 15!");
                }
            }
        }
    }
}