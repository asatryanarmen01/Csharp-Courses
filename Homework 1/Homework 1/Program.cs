using System;
using System.Security.Cryptography.X509Certificates;

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
                    Console.WriteLine("E.g. 1+2*(2)+3/3+4*(-4)-5");
                    string operationA = Console.ReadLine();
                    var operationB = new System.Data.DataTable().Compute(operationA, "");
                    Console.WriteLine("Answer: " + operationB);
                    break;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Not a math expression! Try again");
                    continue;
                    //throw;
                }
            }


            //int temp;
            //bool isNumber = Int32.TryParse(operationA, out temp);

            //public static bool IsNumeric(object Expression);

            //if (isNumber)
            //{

            //}
            //else
            //{
            //    Console.WriteLine("Please enter Mathematical Expression");
            //}           
        }
	}
}
