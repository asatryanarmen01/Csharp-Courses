using System;


class Program
{
    static void Main()
    {
        //Console.Title("Homework 4");
        Console.WriteLine("Enter Math Expression");
        string newCalcMsg = "\nEnter new math expression or input exit to close calculator.";
        while (true)
        {

            var input = Console.ReadLine();

            Calculator calc = new Calculator(input);
            try
            {
                calc.Calculate(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + newCalcMsg);
            }
            

        }
    }
}

