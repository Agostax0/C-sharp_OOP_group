﻿using System;
using System.Collections.Generic;
using System.Globalization;
using static OOP21_Calculator.Lepore.CCType;
using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    public class CCEngine : IEngine
    {
        private readonly ICalculatorController calc;
        private readonly IFormatProvider fp = CultureInfo.CreateSpecificCulture("en-GB");
        public CCEngine(ICalculatorController c)
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
                    Double.TryParse(token, NumberStyles.Any, fp, out result);
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
            double.TryParse(num, NumberStyles.Any, fp, out value);
            Logger.log("Converted", value.ToString(fp));
            return value;
        }

        private double ApplyUnaryOperator(string token, double operand)
        {
            return calc.ApplyUnaryOperator(token, operand);
        }

        private double ApplyBinaryOperator(string token, double firstOperand, double secondOperand)
        {
            return calc.ApplyBinaryOperator(token, firstOperand, secondOperand);
        }

        private bool IsNumber(string s)
        {
            double parse;
            return Double.TryParse(s, out parse);
        }
        private bool IsUnaryOperator (string s)
        {
            return calc.IsUnaryOperator(s);
        }

        private bool IsBinaryOperator(string s)
        {

            return calc.IsBinaryOperator(s);
        }

        private CCType Type(string s)
        {
            return calc.GetType(s);
        }

        private int Precedence(string s)
        {
            return calc.GetPrecedence(s);
        }
    

    }
}