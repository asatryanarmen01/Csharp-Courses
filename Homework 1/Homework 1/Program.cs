using System;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Homework 1 - Armen Asatryan";

            Console.WriteLine("Please input 1 or 2 to choose solution");
            var input1 = Console.ReadLine();
            int option = Convert.ToInt32(input1);

            switch (option)
            {
                case 1:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please enter a mathematical expression.");
                            Console.WriteLine("Write 'exit' or press ESC key to close the application.");
                            Console.WriteLine("Use + - * / operations." + "\n");

                            string input = Console.ReadLine();

                            // Close Application with 'exit' command
                            if (input == "exit")
                            {
                                break; // or return;
                            }

                            var calculateMathExpression = new System.Data.DataTable().Compute(input, "");

                            Console.WriteLine("Answer: " + calculateMathExpression + "\n");

                            //// Close Application with ESC button
                            //if (Console.ReadKey().Key == ConsoleKey.Escape)
                            //{
                            //    Environment.Exit(0);
                            //}
                            //else
                            //{
                            //    continue;
                            //}

                            continue;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Answer: Not a math expression! Try again" + "\n");
                            continue;
                        }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please enter a mathematical expression.");
                            Console.WriteLine("Write 'exit' or press ESC key to close the application.");
                            Console.WriteLine("Use + - * / operations." + "\n");

                            string input = Console.ReadLine();

                            // Close Application with 'exit' command
                            if (input == "exit")
                            {
                                break; // or return;
                            }

                            var calculateMathExpression = new System.Data.DataTable().Compute(input, "");

                            Console.WriteLine("Answer: " + calculateMathExpression + "\n");

                            continue;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Answer: Not a math expression! Try again" + "\n");
                            continue;
                        }
                    }
                    break;
                default:
                    break;
            }
                    
        }
	}
}
