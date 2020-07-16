using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Calculator
{
    public class Calculate
    {
        private string Input { get; set; }
        public string Result { get; set; }
        private List<double> GetNumbersList()
        {
            char[] operatorsList = { '+', '-', '*', '/' };
            List<string> numbersStr = this.Input.Split(operatorsList).ToList();
            List<double> numbersDbl = numbersStr.ConvertAll(item => double.Parse(item));
            return numbersDbl;
        }

        private List<string> GetOperatorsList()
        {
            char[] numbersList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<string> operators = this.Input.Split(numbersList).ToList();

            var count = operators.Count;
            for (var i = count - 1; i > -1; i--)
            {
                if (operators[i] == string.Empty) operators.RemoveAt(i);
            }

            return operators;
        }

        public Calculate(string input)
        {
            this.Input = input;
        }
        public void Calculation()
        {
            List<double> numbers = GetNumbersList();
            List<string> operators = GetOperatorsList();

            try
            {

                double total = 0;


                //Multiplications and Divisions
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == "*")
                    {
                        total = numbers[i] * numbers[i + 1];
                        numbers[i] = total;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        i--;
                    }
                    else if (operators[i] == "/")
                    {
                        total = numbers[i] / numbers[i + 1];
                        numbers[i] = total;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        i--;
                    }
                }


                //Subtractions and Additions
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == "-")
                    {
                        total = numbers[i] - numbers[i + 1];
                        numbers[i] = total;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        i--;
                    }
                    else if (operators[i] == "+")
                    {
                        total = numbers[i] + numbers[i + 1];
                        numbers[i] = total;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        i--;
                    }
                }

                this.Result = "\nResult: " + this.Input + " = " + total + "\n";
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }



        }
    }
}
