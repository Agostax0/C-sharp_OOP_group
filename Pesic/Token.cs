using System;


namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// Tokens used for simplifying the process of recognizing operators, functions, numbers, variables and constant.
    /// </summary>
    interface Token
    {

        TokenType getTypeToken();

        string getSymbol();
    }
}
