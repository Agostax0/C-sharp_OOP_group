using OOP21_Calculator.Lepore;
using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public class CalculatorControllerTemplate : ICalculatorController
    {
        private ICalculatorModel _model;
        private IManager _manager;
        public CalculatorControllerTemplate(ICalculatorModel model) => _model = model;
        public double ApplyBinaryOperation(string op, double a, double b) => GetBinaryOperators().GetValueOrDefault(op).apply(a, b);

        public double ApplyUnaryOperation(string op, double a) => GetUnaryOperators().GetValueOrDefault(op).apply(a);
        public IManager GetManager() => _manager;

        public int GetPrecedence(string op) => !GetBinaryOperators().ContainsKey(op)
                ? GetUnaryOperators().GetValueOrDefault(op).Prec
                : GetBinaryOperators().GetValueOrDefault(op).Prec;

        public CCType GetType(string op) => !IsBinaryOperator(op)
                ? GetUnaryOperators().GetValueOrDefault(op).Op_Type
                : GetBinaryOperators().GetValueOrDefault(op).Op_Type;

        public bool IsBinaryOperator(string op) => GetBinaryOperators().ContainsKey(op);

        public bool IsUnaryOperator(string op) => GetUnaryOperators().ContainsKey(op);
        public void SetManager(IManager mng) => _manager = mng;
        private Dictionary<String, CCBinaryOperator> GetBinaryOperators() => _model.BinaryOps;
        private Dictionary<String, CCUnaryOperator> GetUnaryOperators() => _model.UnaryOps;
    }
}

