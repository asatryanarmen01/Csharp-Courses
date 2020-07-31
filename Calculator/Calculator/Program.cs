using System;


class Program
{
    static void Main()
    {
        //Console.Title("Homework 4");
        Console.WriteLine("Enter Math Expression");

        while (true)
        {

            var input = Console.ReadLine();

            Calculator calc = new Calculator(input);

            calc.Calculate(input);

        }
    }
}

