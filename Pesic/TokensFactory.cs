using System;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// All the tokens implemented. 
    /// </summary>
    class TokensFactory
    {

        public static Token ClosePToken() => new CloseParToken();
        public static Token OpenPToken() => new OpenParToken();
        public static Token VarToken(string var) => new VariableToken(var);
        public static Token FuncToken(Function func) => new FunctionToken(func);
        public static Token NumToken(double val) => new NumberToken(val);
        public static Token OpToken(Operator op) => new OperatorToken(op);
        public static Token ConstToken(string val) => new ConstantToken(val);
        private TokensFactory() { }

        private class CloseParToken : Token
        {
            public TokenType getTypeToken()
            {
                return TokenType.CLOSEPAR;
            }

            public String getSymbol()
            {
                return ")";
            }

        }

        private class OpenParToken : Token
        {
            public TokenType getTypeToken()
            {
                return TokenType.CLOSEPAR;
            }

            public String getSymbol()
            {
                return "(";
            }

        }

        private class VariableToken : Token
        {
            private string variable;
            public VariableToken(string variable) {
                this.variable = variable;
            }
            public TokenType getTypeToken()
            {
                return TokenType.VARIABLE;
            }

            public String getSymbol()
            {
                return variable;
            }

        }

        private class FunctionToken : SpecialToken<Function>
        {
            private Function func;

            public FunctionToken(Function func)
            {
                this.func = func;
            }

            public TokenType getTypeToken()
            {
                return TokenType.FUNCTION;
            }

            public String getSymbol()
            {
                return func.Name;
            }

            public Function getObjectToken()
            {
                return func;
            }


        }

        private class NumberToken : SpecialToken<Double>
        {
            private double value;
            public NumberToken(double value)
            {
                this.value = value;
            }
            public TokenType getTypeToken()
            {
                return TokenType.NUMBER;
            }

            public String getSymbol()
            {
                return value.ToString();
            }

            public Double getObjectToken()
            {
                return value;
            }
        }

        private class ConstantToken : Token
        {
            private string constant;
            public ConstantToken(string constant)
            {
                this.constant = constant;
            }
            public TokenType getTypeToken()
            {
                return TokenType.CONSTANT;
            }

            public String getSymbol()
            {
                return constant;
            }

        }

        private class OperatorToken : SpecialToken<Operator>
        {
            private Operator op;
            public OperatorToken(Operator op)
            {
                this.op = op;
            }
            public TokenType getTypeToken()
            {
                return TokenType.OPERATOR;
            }

            public String getSymbol()
            {
                return op.Symbol;
            }

            public Operator getObjectToken()
            {
                return op;
            }
        }

    }
}
