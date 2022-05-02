using System;
using OOP21_Calculator.Lepore;

namespace OOP21_Calculator.Alni
{
    public interface  ICalculatorController
    {
        double ApplyBinaryOperation(String op, double a, double b);
        int GetPrecedence(String op);
        CCType GetType(String op);
        double ApplyUnaryOperation(String op, double a);
        bool IsUnaryOperator(String op);
        bool IsBinaryOperator(String op);
        void SetManager(IManager mng);
        IManager GetManager();
    }
}

