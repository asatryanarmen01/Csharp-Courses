using System;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                try
                {
                    Console.WriteLine("Please enter the mathematical expression.");
                    Console.WriteLine("Write 'exit' or press ESC key to close the application.");
                    Console.WriteLine("E.g. 1+2*(2)+3/3+4*(-4)-5 \n");
                    
                    string operationA = Console.ReadLine();

                    var operationB = new System.Data.DataTable().Compute(operationA, "");
                    
                    Console.WriteLine("Answer: " + operationB + "\n");
                    
                    // Close Application
                    if (operationA == "exit")
                    {
                        break; // or return
                    } 

                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        break;
                    }

                    continue;

                }
                catch (Exception)
                {
                    Console.WriteLine("Answer: Not a math expression! Try again" + "\n");
                    continue;
                }
            }           
        }
	}
}
