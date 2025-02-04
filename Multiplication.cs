using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Multiplication
    {
        public void CalcProduct(out string finalResult)
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.OperationCompleted += Notify;
            try
            {
                Console.Write("\nPress\n1 for Numbers Multiplication\n2 for Matrix Multiplication\n3 for Complex Number Multiplication\n\nEnter your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
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
                            if (!Char.IsLetter(carrier[0]) && (!Char.IsPunctuation(carrier[0]) || carrier[0] == '-'))
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
                    if (inputs.Count >= 2)
                    {
                        double result = 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        x.Append("The Result of Multiplication of ");
                        for (int i = 0; i < inputs.Count; i++)
                        {
                            result *= inputs[i];
                            if (inputs[i] < 0)
                            {
                                x.Append($"({inputs[i]}) " + (i != inputs.Count - 1 ? "* " : " "));
                            }
                            else
                            {
                                x.Append($"{inputs[i]} " + (i != inputs.Count - 1 ? "* " : " "));
                            }
                        }
                        x.Append($"= {result}");
                        finalResult = x.ToString();
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
                        return;
                    }
                }
                else if (choice == 2)
                {
                    Matrix M = new();
                    M.MatrixProduct(out finalResult);
                    return;
                }
                else if (choice == 3)
                {
                    ComplexNumbers C = new();
                    C.Calculate(OperationType.ComplexMultiplication, out finalResult);
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
            Console.WriteLine("Operation Multiplication of Numbers completed Successfully!\n");
            Console.ResetColor();
        }
    }
}