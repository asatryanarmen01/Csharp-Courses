using System;
using System.Collections.Generic;
using System.Text;

class NullOrEmptyException : Exception
{
    public NullOrEmptyException(string input) : base(String.Format("!!! Input cannot be empty: {0} \n", input))
    {

    }
}

class IncludesBracketsException : Exception
{
    public IncludesBracketsException(string input) : base(String.Format("!!! Input should not contain parenthesis: {0} \n", input))
    {

    }

}

class MultipleJointOperatorsException : Exception
{
    public MultipleJointOperatorsException(string input) : base(String.Format("!!! Input contains two or more consecutive operators: {0} \n", input))
    {

    }

}

class InputStartsWithNonDigitException : Exception
{
    public InputStartsWithNonDigitException(string input) : base(String.Format("!!! Input should start with a digit: {0} \n", input))
    {

    }

}

