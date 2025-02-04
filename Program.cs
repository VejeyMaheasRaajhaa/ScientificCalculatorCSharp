using System.Runtime.CompilerServices;
using CalculatorApp;
using System.Reflection;
using System.IO;
internal class Program
{
    public static void Main(string[] args)
    {
        const int minChoice = 0;
        const int maxChoice = 9;
        int choice;
        string finalResult = "";
        string previouslyPrinted = finalResult;
        try
        {
            string directory = @"C:\Users\mraajha\Documents\Calculator\";
            string fileName = "History.txt";
            string path = $"{directory}{fileName}";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(finalResult);
            }
            using (StreamWriter sw = File.AppendText(@"C:\Users\mraajha\Documents\Calculator\OverallHistory.txt"))
            {
                sw.WriteLine(File.ReadAllText(path));
            }
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(finalResult);
            }
            do
            {
                Console.Write("Press\n1 for Subtraction\n2 for Multiplication\n3 for Cube-Root\n4 for Square\n5 for Cosine aka cos\n6 for Tangent aka tan\n7 for History\n8 to Clear Screen\n9 to learn about the app\n0 to Exit\n\nEnter your Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == minChoice)
                    break;
                else if (choice > maxChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInput must lie Between 0 to 9 and not {choice}!\n");
                    Console.ResetColor();
                    choice = 1;
                    continue; 
                }
                else
                {
                    if (choice == 1)
                    {
                        var s = new Subtraction();
                        s.CalcDifference(out finalResult);
                    }
                    else if (choice == 2)
                    {
                        var m = new Multiplication();
                        m.CalcProduct(out finalResult);
                    }
                    else if (choice == 3)
                    {
                        CubeRoot c = new();
                        c.CalcCRoot(out finalResult);
                    }
                    else if (choice == 4)
                    {
                        Square s = new();
                        s.CalcSquare(out finalResult);
                    }
                    else if (choice == 5)
                    {
                        CosTanCombined c = new();
                        c.CalcCosTan(out finalResult);
                    }
                    else if (choice == 6)
                    {
                        CosTanCombined c = new();
                        c.CalcCosTan(out finalResult , isCos: OperationType.Tan);
                    }
                    else if (choice == 7)
                    {
                        DisplayHistory(path);
                    }
                    else if (choice == 8)
                    {
                        Console.Clear();
                    }
                    else if(choice == maxChoice)
                    {
                        ReflectionHandler.Choice9();
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        if (finalResult != previouslyPrinted && finalResult != "")
                        {
                            sw.WriteLine(finalResult);
                            previouslyPrinted = finalResult;
                        }
                    }
                }
            } 
            while (choice > minChoice && choice <= maxChoice);
        }
        catch(System.FormatException Exception1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid Input!");
            Console.ResetColor ();
        }
    }
    public static void DisplayHistory(string path)
    {
        Console.WriteLine();
        for (int i = 0; i < Console.WindowWidth; i += Console.WindowWidth / 9)
        {
            Console.Write("History Loading!!!");
            Thread.Sleep(250);
            int currentLineCursor = Console.CursorTop;
            currentLineCursor = Console.CursorTop;
            if(Console.CursorLeft - 18>=0)
                Console.SetCursorPosition(Console.CursorLeft - 18, currentLineCursor);
            else
                Console.SetCursorPosition(0, currentLineCursor);
            Console.Write(new string(' ', 18));
            Console.SetCursorPosition(i, currentLineCursor);
        }
        Console.SetCursorPosition(0, Console.CursorTop-1);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nHistory : ");

        var fileContent = File.ReadAllText(path);
        foreach (var i in fileContent)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}