using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Square : OneNumber
    {
        public double Result
        { get; set; }
        public void CalcSquare(out string finalResult)
        {
            try
            {
                EventHolder eventHolder = new EventHolder();
                eventHolder.OperationCompleted += Notify;

                GetInput(OperationType.Square);
                Result = Input * Input;

                finalResult = $"Square of {Input} is {Math.Round(Result, Precision)}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{finalResult}\n");
                Console.ResetColor();

                eventHolder.OnOperationCompleted();
            }
            catch(Exception e)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nInvalid Input!\n");
                Console.ResetColor();
            }
        }
        private void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calculation of Square completed Successfully!\n");
            Console.ResetColor();
        }
    }
}