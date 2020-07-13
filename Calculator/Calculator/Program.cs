using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    static int Main()
    {
        Console.WriteLine("Enter Math Expression");
        while (true)
        {
            try
            {
                var input = Console.ReadLine();//"79-66+53*64/99*33-55+66*2";

                if (input == "exit")
                {
                    break;
                }
                
                if (input.Contains('(') || input.Contains(')'))
                {
                    Console.WriteLine("Input should not contain parenthesis.");
                    break;
                };

                char[] operatorsList = { '+', '-', '*', '/' };
                char[] numbersList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


                try
                {

                    //Numbers List 
                    List<string> numbersStr = input.Split(operatorsList).ToList();
                    List<double> numbersDbl = numbersStr.ConvertAll(item => double.Parse(item));

                    //Operators List 
                    List<string> operators = input.Split(numbersList).ToList();

                    var count = operators.Count;
                    for (var i = count - 1; i > -1; i--)
                    {
                        if (operators[i] == string.Empty) operators.RemoveAt(i);
                    }

                    double total = 0;


                    //Multiplications and Divisions
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == "*")
                        {
                            total = numbersDbl[i] * numbersDbl[i + 1];
                            numbersDbl[i] = total;
                            numbersDbl.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                            i--;
                        }
                        else if (operators[i] == "/")
                        {
                            total = numbersDbl[i] / numbersDbl[i + 1];
                            numbersDbl[i] = total;
                            numbersDbl.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                            i--;
                        }
                    }


                    //Subtractions and Additions
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == "-")
                        {
                            total = numbersDbl[i] - numbersDbl[i + 1];
                            numbersDbl[i] = total;
                            numbersDbl.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                            i--;
                        }
                        else if (operators[i] == "+")
                        {
                            total = numbersDbl[i] + numbersDbl[i + 1];
                            numbersDbl[i] = total;
                            numbersDbl.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                            i--;
                        }
                    }

                    Console.WriteLine("\nResult: " + input + " = " + total + "\n");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

                Console.WriteLine("\nEnter new math expression or input exit to close calculator.");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
        return 0;
    }
}