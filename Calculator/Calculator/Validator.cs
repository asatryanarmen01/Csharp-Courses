using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Validator
    {
        private string Input { get; set; }
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; }

        public Validator(string input)
        {
            this.Input = input;
            this.Validate();
        }

        public void Validate()
        {
            try
            {
                if (this.Input.Contains('(') || this.Input.Contains(')'))
                {
                    this.ErrorMessage = "Input should not contain parenthesis.";
                    this.IsValid = false;
                };

                bool tempValid = true;
                for (int i = 0; i < this.Input.Length; i++)
                {
                    
                    switch (this.Input[i])
                    {
                        case '*':
                        case '/':
                        case '+':
                        case '-':
                            {
                                if (!char.IsDigit(this.Input[i - 1]) || !char.IsDigit(this.Input[i + 1]))
                                {
                                    this.IsValid = false;
                                    tempValid = false;
                                }
                                this.ErrorMessage = "Incorrect math expression, operator is followd by other symbol.";
                                break;
                            }
                        
                    }
                    if (!tempValid)
                    {
                        break;
                    }
                }
            }
            catch (Exception Ex)
            {
                this.ErrorMessage = Ex.Message;
                this.IsValid = false;
            }

            //this.IsValid = true;
        }
    }
}
