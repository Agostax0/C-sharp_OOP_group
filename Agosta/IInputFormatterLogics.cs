
namespace OOP21_Calculator.Agosta
{
    internal interface IInputFormatterLogics
    {
        ///<summary> This method reads its input value to the engine's memory.</summary>
        void Read(string input);
        ///<summary> This method deletes the engine's memory last input value.</summary>
        void DeleteLast();
        ///<summary> This method calculates the current state of its engine's memory</summary>
        void Calculate();
    }
}
