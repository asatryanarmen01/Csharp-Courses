using System;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Homework 1 - Armen Asatryan";

            Console.WriteLine("Please input 1 or 2 to choose calculator type");
            var input1 = Console.ReadLine();
            int option = Convert.ToInt32(input1);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Expression calculator");
                    Console.WriteLine("Please enter a mathematical expression. Like: 1+2*3-4");
                    Console.WriteLine("Write 'exit' or press ESC key to close the application.");
                    Console.WriteLine("You can use + - * / operations." + "\n");

                    while (true)
                    {
                        try
                        {
                            
                            string input = Console.ReadLine();

                            // Close Application with 'exit' command
                            if (input == "exit")
                            {
                                break; // or return;
                            }

                            var calculateMathExpression = new System.Data.DataTable().Compute(input, "").ToString();
                            
                            Console.WriteLine(input + " = " + calculateMathExpression + "\n");
                            Console.WriteLine("Try again or exit application" + "\n");


                            // Close Application with ESC button
                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                continue;
                            }


                            continue;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not a math expression! Try again" + "\n");
                            continue;
                        }
                    }
                    break;
                
                case 2:
 
                    while (true)
                    {

                        Console.WriteLine("Please enter a mathematical expression.");

                        while (true)
                        {

                            double answer;
                            string op = "";

                            double num1 = double.Parse(Console.ReadLine());



                            while (true)
                            {
                                var x = Console.ReadKey().Key;

                                double num2 = double.Parse(Console.ReadLine());

                                Console.WriteLine("Result");
                                switch (x)
                                {
                                    case ConsoleKey.Add:
                                        answer = num1 + num2;
                                        op = "+";
                                        break;
                                    case ConsoleKey.Subtract:
                                        answer = num1 - num2;
                                        op = "-";
                                        break;
                                    case ConsoleKey.Multiply:
                                        answer = num1 * num2;
                                        op = "*";
                                        break;
                                    case ConsoleKey.Divide:
                                        answer = num1 / num2;
                                        op = "/";
                                        break;
                                    default:
                                        answer = 0;
                                        break;
                                }
                                Console.WriteLine(num1 + " " + op + " " + num2 + " = " + answer);
                                num1 = answer;

                                continue;
                            }
                        }
                    }
                    
            }
                    
        }
	}
}
