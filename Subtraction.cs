using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Subtraction
    {
        private double result = 1;
        public double Result
        {
            get
            {
                return result;
            }
        }
        public void CalcDifference(out string finalResult)
        {
            try
            {
                Console.Write("\nPress\n1 for Numbers Subtraction\n2 for Matrix Subtraction\n3 for Complex Number Subtraction\n\nEnter your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    EventHolder eventHolder = new EventHolder();
                    eventHolder.OperationCompleted += Notify;
                    StringBuilder x = new();
                    List<double> inputs = new List<double>();
                    string carrier = string.Empty;
                    int ctr = 1;
                    Console.WriteLine("\nStart entering the numbers and To exit, Press any Non-Number\n");
                    while (true)
                    {
                        try
                        {
                            Console.Write($"Enter the number {ctr++} : ");
                            carrier = Console.ReadLine();
                            if (!Char.IsLetter(carrier[0]))
                            {
                                inputs.Add(Convert.ToDouble(carrier));
                            }
                            else
                                break;
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                    }
                    if (inputs.Count == 0)
                    {
                        result = 0;
                    }
                    else if (inputs.Count == 1)
                    {
                        result = inputs[0];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        x.Append("The Result of Subtraction ");
                        result = inputs.Aggregate((a, b) => a - b);
                        if (inputs[0] < 0)
                            x.Append($"({inputs[0]}) " + (0 != inputs.Count - 1 ? "- " : " "));
                        else
                            x.Append($"{inputs[0]} " + (0 != inputs.Count - 1 ? "- " : " "));
                        for (int i = 1; i < inputs.Count; i++)
                        {
                            if (inputs[i] < 0)
                                x.Append($"({inputs[i]}) " + (i != inputs.Count - 1 ? "- " : " "));
                            else
                                x.Append($"{inputs[i]} " + (i != inputs.Count - 1 ? "- " : " "));
                        }
                        x.Append($"= {result}");
                        finalResult = new string(x.ToString());
                        Console.WriteLine($"\n{finalResult}\n");
                        Console.ResetColor();
                        eventHolder.OnOperationCompleted();
                        return;
                    }
                    if (inputs.Count < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        finalResult = "";
                        Console.WriteLine("\nThe number of Parameters must be atleast 2!\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 2)
                {
                    Matrix M = new();
                    M.MatrixSubtract(out finalResult);
                    return;
                }
                else if (choice == 3)
                {
                    ComplexNumbers C = new();
                    C.Calculate(OperationType.ComplexSubtraction, out finalResult);
                    return;
                }
                else
                {
                    throw new Exception("Invalid Input!");
                }
                finalResult = "";
            }
            catch (Exception e)
            {
                finalResult = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Input\n");
                Console.ResetColor();
            }
        }
        private void Notify()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Operation Subtraction completed Successfully\n");
            Console.ResetColor();
        }
        public void sub(int a,int b,out int result)
        {
            result = a - b;
        }
    }
}