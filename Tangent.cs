using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Tangent 
    {
        public double OriginalAngle
        { get; set; }
        public string IsDegree
        { get; set; }
        public int Precision
        { get; set; }
        public double GetTheta()
        {
            Console.Write("\nIn what format would you like to share details about Theta? press\n1 for Degrees\n2 for Radians\n\nYour Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            IsDegree = choice == 1 ? "Degree(s)" : "Radian(s)";

            Console.Write($"\nEnter the value of Angle in {IsDegree} : ");
            OriginalAngle = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nHow precise you want your results to be?(Maximum 15) : ");
            Precision = Convert.ToInt32(Console.ReadLine());

            return choice == 1 ? OriginalAngle * Math.PI / 180 : OriginalAngle;
        }
        public double CalcTangent()
        {
            double angle = GetTheta();

            double result = (double)Math.Tan(angle);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTan({OriginalAngle}) {IsDegree} is {Math.Round(result, Precision)}\n");
            Console.ResetColor();
            return result;
        }
    }
}
