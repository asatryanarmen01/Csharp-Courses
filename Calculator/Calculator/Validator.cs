using System;

public class Validator
{
    private string Input { get; set; }
    public bool IsValid { get; set; } = true;
    public string ErrorMessage { get; set; }

    public Validator(string input)
    {
        this.Input = input;
    }

    public void Validate(string input)
    {

        if (String.IsNullOrEmpty(this.Input))
        {
            throw new NullOrEmptyException(this.Input);
        }

        if (this.Input == "exit")
        {
            Environment.Exit(0);
        }

        

        if (this.Input.Contains('(') || this.Input.Contains(')'))
        {
            this.IsValid = false;
            throw new IncludesBracketsException(this.Input);
        };

        bool tempValid = true;
        for (int i = 0; i < this.Input.Length; i++)
        {
            if (i == 0)
            {
                if (!char.IsDigit(this.Input[0]))
                {
                    throw new InputStartsWithNonDigitException(this.Input);
                }
            }

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
                            throw new MultipleJointOperatorsException(this.Input);
                        }
                        break;
                    }
            }
            if (!tempValid)
            {
                break;
            }
        }
    }
}

