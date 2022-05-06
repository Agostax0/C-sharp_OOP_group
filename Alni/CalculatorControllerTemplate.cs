using OOP21_Calculator.Lepore;
using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// Implementation of the generic Controller. It is used with Standard, Scientific, Programmer and Combinatorics models.
    /// </summary>
    public class CalculatorControllerTemplate : ICalculatorController
    {
        private readonly ICalculatorModel _model;
        public IManager Manager { get; set; }
        public CalculatorControllerTemplate(ICalculatorModel model) => _model = model;
        public double ApplyBinaryOperation(string op, double a, double b) => GetBinaryOperators().GetValueOrDefault(op).apply(a, b);

        public double ApplyUnaryOperation(string op, double a) => GetUnaryOperators().GetValueOrDefault(op).apply(a);
        public int GetPrecedence(string op) => !GetBinaryOperators().ContainsKey(op)
                ? GetUnaryOperators().GetValueOrDefault(op).Prec
                : GetBinaryOperators().GetValueOrDefault(op).Prec;
        public CCType GetType(string op) => !IsBinaryOperator(op)
                ? GetUnaryOperators().GetValueOrDefault(op).Op_Type
                : GetBinaryOperators().GetValueOrDefault(op).Op_Type;
        public bool IsBinaryOperator(string op) => GetBinaryOperators().ContainsKey(op);
        public bool IsUnaryOperator(string op) => GetUnaryOperators().ContainsKey(op);
        private Dictionary<string, CCBinaryOperator> GetBinaryOperators() => _model.BinaryOps;
        private Dictionary<string, CCUnaryOperator> GetUnaryOperators() => _model.UnaryOps;
    }
}

