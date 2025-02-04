using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class CosTanCombined : OneNumber
    {        
        public string IsDegree
        { get; set; }
        public double angle 
        {  get; set; }
        protected override void GetInput(OperationType x)
        {
            Console.Write("\nIn what format would you like to share details about Theta? press\n1 for Degrees\n2 for Radians\n\nYour Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice ==1 || choice == 2)
            {
                IsDegree = (choice == 1) ? "Degree(s)" : "Radian(s)";

                Console.Write($"\nEnter the value of Angle in {IsDegree} : ");
                Input = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nHow precise you want your results to be?(Maximum 15) : ");
                Precision = Convert.ToInt32(Console.ReadLine());

                if (Precision > 15)
                {
                    Precision = 15;
                    Console.WriteLine("\nPrecision of the result is set to be 15!");
                }

                angle = choice == 1 ? Input * Math.PI / 180 : Input;
            }
            else
            {
                throw new Exception("Invalid Input!");
            }
        }
        public void CalcCosTan( out string finalResult,OperationType isCos = OperationType.Cos)
        {
            double result;
            EventHolder eventHolder = new EventHolder();
            try
            {
                GetInput(OperationType.Theta);

                if (isCos == OperationType.Cos)
                {
                    result = (double)Math.Cos(angle);
                    eventHolder.OperationCompleted += NotifyCos;
                }
                else
                {
                    result = (double)Math.Tan(angle);
                    eventHolder.OperationCompleted += NotifyTan;
                }

                var isCos2 = isCos == OperationType.Cos  ? "Cos" : "Tan";
                finalResult = $"{isCos2}({Input}) {IsDegree} is {Math.Round(result, Precision)}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + finalResult + "\n");
                Console.ResetColor();
                eventHolder.OnOperationCompleted();
            }
            catch(Exception e)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{e.Message}\n");
                Console.ResetColor();
            }
        }
        private void NotifyTan()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Operation Tan completed Successfully\n");
            Console.ResetColor();
        }
        private void NotifyCos()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Operation Cos completed Successfully\n");
            Console.ResetColor();
        }
    }
}