using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class ComplexNumbers : MyComplex
    {
        public Complex a;
        public Complex b;
        public Complex result;
        protected override void GetInput()
        {
            double real, imaginary;
            Console.Write("\nEnter Real part of Complex Number A : ");
            real = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Imaginary part of Complex Number A : ");
            imaginary = Convert.ToDouble(Console.ReadLine());
            a = new Complex(real,imaginary);
            Console.Write("Enter Real part of Complex Number B : ");
            real = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Imaginary part of Complex Number B : ");
            imaginary = Convert.ToDouble(Console.ReadLine());
            b = new Complex(real, imaginary);
        }
        public override void Calculate(OperationType operationName, out string finalResult)
        {
            try
            {
                EventHolder eventHolder = new EventHolder();
                GetInput();
                if (operationName == OperationType.ComplexSubtraction )
                {
                    eventHolder.OperationCompleted += NotifyDifference;
                    result = a - b;
                }
                else
                {
                    eventHolder.OperationCompleted += NotifyProduct;
                    result = a * b;
                }
                char operation = operationName == OperationType.ComplexSubtraction ? '-' : '*';
                Console.ForegroundColor = ConsoleColor.Green;
                finalResult = $"{a.DisplayComplex()} {operation} {b.DisplayComplex()} = {result.DisplayComplex()}";
                Console.WriteLine($"\n{finalResult}\n");
                Console.ResetColor();
                eventHolder.OnOperationCompleted();
            }
            catch (System.FormatException Exception1)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Input!\n");
                Console.ResetColor();
            }
        }
        public override void NotifyDifference()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calculation of Complex Number Subtraction completed Successfully!\n");
            Console.ResetColor();
        }
        public override void NotifyProduct()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calculation of Complex Number Multiplication completed Successfully!\n");
            Console.ResetColor();
        }
    }
}