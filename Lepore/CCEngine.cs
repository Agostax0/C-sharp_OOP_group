using System;
using System.Collections.Generic;
using static OOP21_Calculator.Lepore.CCEngineManager;
using static OOP21_Calculator.Lepore.Type;


namespace OOP21_Calculator.Lepore
{
    class CCEngine : IEngine
    {
        private readonly Calculator calc;
        public CCEngine(Calculator c)
        {
            calc = c;
        }

        public double Calculate(IList<string> input)
        {
            IList<string> rpnInput = ParseToRPN(UnifyTerms(input));
            Logger.log("RPN", rpnInput);
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
                        throw new Exception("Parsing");

                    if (stack.Count > 0 && IsUnaryOperator(stack.Peek()))
                        output.Add(stack.Pop());
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                    throw new Exception("Parsing");
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
                    Double.TryParse(token, out result);
                    stack.Push(result);
                }
                else if (IsBinaryOperator(token))
                {
                    if (stack.Count < 2) throw new Exception("Evaluation");
                    double secondOperand = stack.Pop();
                    double firstOperand = stack.Pop();
                    stack.Push(ApplyBinaryOperator(token, firstOperand, secondOperand));
                }
                else if (IsUnaryOperator(token))
                {
                    if (stack.Count == 0) throw new Exception("Evaluation");
                    double operand = stack.Pop();
                    stack.Push(ApplyUnaryOperator(token, operand));
                }
            }

            if (stack.Count != 1) throw new Exception("Evaluation");
            return stack.Pop();
        }

        private IList<string> UnifyTerms(IList<string> input)
        {
            Logger.log("Unify", input);
            IList<string> unified = new List<string>();
            IList<string> currentNumber = new List<string>();

            foreach(string s in input)
            {
                if (IsNumber(s) || s == ",")
                    currentNumber.Add(s);
                else
                {
                    if (currentNumber.Count > 0)
                    {
                        double actual = Convert(currentNumber);
                        currentNumber.Clear();
                        unified.Add(actual.ToString());
                    }
                    unified.Add(s);
                }
            }

            if (currentNumber.Count > 0)
            {
                double actual = Convert(currentNumber);
                currentNumber.Clear();
                unified.Add(actual.ToString());
            }

            Logger.log("Unified", unified);

            return unified;
        }

        private double Convert(IList<string> currentNumber)
        {
            Logger.log("Convert", currentNumber);
            //check number of dots
            string num = "";
            foreach(string s in currentNumber)
            {
                num += s;
            }

            double value;
            double.TryParse(num, out value);
            Logger.log("Converted", value.ToString());
            return value;
        }

        private double ApplyUnaryOperator(string token, double operand)
        {
            switch (token)
            {
                case "sin":
                    {
                        return Math.Sin(operand);
                    }
                case "cos":
                    {
                        return Math.Cos(operand);
                    }
                default: return 0;
            }
        }

        private double ApplyBinaryOperator(string token, double firstOperand, double secondOperand)
        {
            switch(token)
            {
                case "+":
                    {
                        return firstOperand + secondOperand;
                    }
                case "-":
                    {
                        return firstOperand - secondOperand;
                    }
                default: return 0;
            }
        }

        private bool IsNumber(string s)
        {
            double parse;
            return Double.TryParse(s, out parse);
        }
        private bool IsUnaryOperator (string s)
        {
            return new List<string> {
                "sin",
                "cos"
            }.Contains(s);
        }

        private bool IsBinaryOperator(string s)
        {
            return new List<string> {
                "+",
                "-",
                "*",
                "^",
                "/"
            }.Contains(s);
        }

        private Type Type(string s)
        {
            if (s == "^") return RIGHT;
            else return LEFT;
        }

        private int Precedence(string s)
        {
            IDictionary<string, int> prec = new Dictionary<string, int>()
            {
                {"+", 1 },
                {"-", 1 },
                {"*", 2 },
                {"/", 2 },
                {"^", 3 },
                {"sin", 4 },
                {"cos", 4 },
            };

            int result;
            if (prec.TryGetValue(s, out result))
                return result;
            else
                return -1;
        }
    }
}
