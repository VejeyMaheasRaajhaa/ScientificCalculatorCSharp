using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class ReflectionHandler
    {
        public static void Choice9()
        {
            Console.Write("\nPress\n1 to know about the list of classes used\n2 to know about the list of methods used\n\nEnter your choice : ");
            int choice9 = Convert.ToInt32(Console.ReadLine());
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] type = assembly.GetTypes();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (choice9)
            {
                case 1:
                {
                    Console.WriteLine();
                    var classNames = type.Where(t => t.IsClass).Select(t => t.FullName).ToArray();
                    foreach (var i in classNames)
                
                            Console.WriteLine(i);
                    Console.WriteLine();
                    break;
                }
                case 2:
                {
                    foreach (Type t in type)
                    {
                        if (t.IsClass)
                        {
                            Console.WriteLine($"Class: {t.FullName}\n");
                            MethodInfo[] methods = t.GetMethods();
                            foreach (MethodInfo method in methods)
                                Console.WriteLine($"\tMethod: {method.Name}");
                            Console.WriteLine();
                        }
                    }
                    break;
                }
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input\n");
                    break;
                }
            }//end of switch
            Console.ResetColor();
        }
    }
}