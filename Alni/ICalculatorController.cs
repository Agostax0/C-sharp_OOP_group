using System;
using OOP21_Calculator.Lepore;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// Generic Controller that communicates with Manager.
    /// Given the operation name the controller can give every information about it and solve it
    /// </summary>
    public interface ICalculatorController
    {
        IManager Manager { get; set; }

        ///<summary>
        /// (<paramref name="op"/>, <paramref name="a"/>)
        ///</summary>
        ///<param name="op">string representing the operation</param>
        ///<param name="a">the operand</param>
        ///<returns>the result of the given unary operation</returns>
        double ApplyUnaryOperation(string op, double a);

        ///<summary>
        /// (<paramref name="op"/>,<paramref name="a"/>, <paramref name="b"/>)
        ///</summary>
        /// <param name="op">string representing the operation</param>
        /// <param name="a">first operand</param>
        /// <param name="b">second operand</param>
        /// <returns>the result of the given binary operation</returns>
        double ApplyBinaryOperation(string op, double a, double b);

        ///<summary>
        /// (<paramref name="op"/>)
        ///</summary>
        ///<param name="op">string representing the operation</param>
        ///<returns>a integer representing the precedence of the operation</returns>
        int GetPrecedence(string op);

        ///<summary>
        /// (<paramref name="op"/>)
        ///</summary>
        ///<param name="op">string representing the operation</param>
        ///<returns>the type of association of the operation(LEFT or RIGHT)</returns>
        CCType GetType(string op);

        ///<summary>
        /// (<paramref name="op"/>)
        ///</summary>
        ///<param name="op">string representing the operation</param>
        ///<returns>whether the given operation is unary</returns>
        bool IsUnaryOperator(string op);

        ///<summary>
        /// (<paramref name="op"/>)
        ///</summary>
        ///<param name="op">string representing the operation</param>
        ///<returns>return whether the given operation is binary</returns>
        bool IsBinaryOperator(string op);
    }
}

