using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static OOP21_Calculator.Lepore.CCType;

namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Class that implements methods to parse and execute mathematical expressions.
    /// </summary>
    public class CCEngine : IEngine
    {
        private readonly ICalculatorController _calc;
        private readonly IFormatProvider fp = CultureInfo.CreateSpecificCulture("en-GB");

        public CCEngine(ICalculatorController c)
        {
            _calc = c;
        }

        public double Calculate(IList<string> input)
        {
            IList<string> rpnInput = ParseToRPN(UnifyTerms(input));
            return EvaluateRPN(rpnInput);
        }

        public IList<string> ParseToRPN(IList<string> infix)
        {
            IList<string> output = new List<string>();
            Stack<string> stack = new Stack<string>();

            foreach(string token in infix)
            {
                if (IsNumber(token))
                    output.Add(token);
                else if (IsUnaryOperator(token))
                    stack.Push(token);
                else if (IsBinaryOperator(token))
                {
                    if (stack.Count > 0)
                    {
                        string o2 = stack.Peek();
                        while (o2 != "(" && (Precedence(o2) > Precedence(token) || Precedence(o2) == Precedence(token) && Type(token) == LEFT))
                        {
                            output.Add(stack.Pop());
                            if (stack.Count == 0) break;
                            o2 = stack.Peek();
                        }
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                    stack.Push(token);
                else if (token == ")")
                {
                    while(stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                    }
                    if (stack.Count > 0 && stack.Peek() == "(")
                        stack.Pop();
                    else
                        throw new Exception("Parenthesis mismatch");

                    if (stack.Count > 0 && IsUnaryOperator(stack.Peek()))
                        output.Add(stack.Pop());
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                    throw new Exception("Parenthesis mismatch");
                output.Add(stack.Pop());
            }

            return output;
        }

        private double EvaluateRPN(IList<String> input)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in input)
            {
                if (IsNumber(token))
                {
                    double result;
                    Double.TryParse(token, NumberStyles.Any, fp, out result);
                    stack.Push(result);
                }
                else if (IsBinaryOperator(token))
                {
                    if (stack.Count < 2) throw new Exception("Syntax error");
                    double secondOperand = stack.Pop();
                    double firstOperand = stack.Pop();
                    stack.Push(ApplyBinaryOperator(token, firstOperand, secondOperand));
                }
                else if (IsUnaryOperator(token))
                {
                    if (stack.Count == 0) throw new Exception("Syntax error");
                    double operand = stack.Pop();
                    stack.Push(ApplyUnaryOperator(token, operand));
                }
            }

            if (stack.Count != 1) throw new Exception("Syntax error");
            return stack.Pop();
        }

        private IList<string> UnifyTerms(IList<string> input)
        {
            IList<string> unified = new List<string>();
            IList<string> currentNumber = new List<string>();

            foreach(string s in input)
            {
                if (IsNumber(s) || s == ".")
                    currentNumber.Add(s);
                else
                {
                    if (currentNumber.Count > 0)
                    {
                        double actual = Convert(currentNumber);
                        currentNumber.Clear();
                        unified.Add(actual.ToString(fp));
                    }
                    unified.Add(s);
                }
            }

            if (currentNumber.Count > 0)
            {
                double actual = Convert(currentNumber);
                currentNumber.Clear();
                unified.Add(actual.ToString(fp));
            }

            return unified;
        }

        private double Convert(IList<string> currentNumber)
        {
            // Check number of dots
            if (currentNumber.Where((s) => s == ".").Count() > 1)
                throw new Exception("Syntax error");

            string num = "";
            foreach(string s in currentNumber)
            {
                num += s;
            }

            double.TryParse(num, NumberStyles.Any, fp, out double value);
            return value;
        }

        private double ApplyUnaryOperator(string token, double operand) => _calc.ApplyUnaryOperator(token, operand);

        private double ApplyBinaryOperator(string token, double firstOperand, double secondOperand) => _calc.ApplyBinaryOperator(token, firstOperand, secondOperand);

        private bool IsNumber(string s) => double.TryParse(s, out double parse);
        private bool IsUnaryOperator(string s) => _calc.IsUnaryOperator(s);

        private bool IsBinaryOperator(string s) => _calc.IsBinaryOperator(s);

        private CCType Type(string s) => _calc.GetType(s);

        private int Precedence(string s) => _calc.GetPrecedence(s);


    }
}
