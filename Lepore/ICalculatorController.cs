namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Interface used to simulate the interaction with a calculator controller.
    /// This class wasn't implemented by me in the original project.
    /// </summary>
    public interface ICalculatorController
    {
        double ApplyBinaryOperator(string op, double a, double b);

        double ApplyUnaryOperator(string op, double a);

        bool IsUnaryOperator(string op);

        bool IsBinaryOperator(string op);

        int GetPrecedence(string op);

        CCType GetType(string op);
    }
    
}
