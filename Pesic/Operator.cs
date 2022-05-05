using System;
using System.Collections.Generic;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// it contains all the operators implemented.
    /// </summary>
    class Operator
    {
        private enum Precedence
        {
            SUM = 1,
            SUB = 1,
            MUL = 2,
            DIV = 2,
            UNARYMINUS = 3,
            UNARYPLUS = 3,
            POW = 4
        }

        public static ISet<String> AVAILABLECHARS = new HashSet<String>() 
        { "+", "-", "*", "/", "^", "÷", "\u00D7" };

        public static bool isAllowedOperator(String s) 
        {
            return AVAILABLECHARS.Contains(s);
        }

        public static int getPrecedences(String symbol, int numArguments)
        {
            switch (symbol)
            {
                case "+":
                    if (numArguments > 1)
                    {
                        return ((int)Precedence.SUM);
                    }
                    return ((int)Precedence.UNARYPLUS);

                case "-":
                    if (numArguments > 1)
                    {
                        return ((int)Precedence.SUB);
                    }
                    return ((int)Precedence.UNARYMINUS);
                case "\u00D7":
                case "*":
                    return ((int)Precedence.MUL);
                case "÷":
                case "/":
                    return ((int)Precedence.DIV);
                case "^":
                    return ((int)Precedence.POW);
                default:
                    return -1;
            }
        }

        public static Operator getOperatorBySymbolAndArgs(String symbol, int numArguments)
        {
            switch (symbol)
            {
                case "+":
                    if (numArguments > 1)
                    {
                        return new Operator(symbol, numArguments, true);
                    }
                    return new Operator(symbol, numArguments, false);

                case "-":
                    if (numArguments > 1)
                    {
                        return new Operator(symbol, numArguments, true);
                    }
                    return new Operator(symbol, numArguments, false);
                case "*":
                case "\u00D7":
                    return new Operator("\u00D7", numArguments, true);
                case "÷":
                case "/":
                    return new Operator("÷", numArguments, true);
                case "^":
                    return new Operator(symbol, numArguments, false);
                default:
                    return null;
            }
        }

        private int numOperands;
        private bool leftAssociative;
        private String symbol;
        private int precedence;

        public Operator(String symbol, int numberOfOperands, bool leftAssociative) 
        {
            if (!isAllowedOperator(symbol))
            {
                throw new ArgumentException();
            }
            this.numOperands = numberOfOperands;
            this.leftAssociative = leftAssociative;
            this.symbol = symbol;
            this.precedence = Operator.getPrecedences(symbol, numberOfOperands);
        }

        public bool LeftAssociative => leftAssociative;

        public int getPrecedence => precedence;

        public String Symbol => symbol;

        public int NumOperands => numOperands;
    }
}
