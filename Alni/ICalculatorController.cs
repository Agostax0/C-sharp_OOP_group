using System;
using OOP21_Calculator.Lepore;

namespace OOP21_Calculator.Alni
{
    public interface ICalculatorController
    {
        IManager Manager { get; set; }
        double ApplyBinaryOperation(string op, double a, double b);
        int GetPrecedence(string op);
        CCType GetType(string op);
        double ApplyUnaryOperation(string op, double a);
        bool IsUnaryOperator(string op);
        bool IsBinaryOperator(string op);
    }
}

