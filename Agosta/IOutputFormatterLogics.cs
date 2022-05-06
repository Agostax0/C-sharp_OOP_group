
namespace OOP21_Calculator.Agosta
{
    internal interface IOutputFormatterLogics
    {
        ///<summary> This method handles the display's updatings. </summary>
        void UpdateDisplay();
        ///<summary> This method handles the display uppertext's updatings. </summary>
        void UpdateDisplayUpperText();
        ///<summary> This method return a general purpose string of the current buffer. </summary>
        string Format();
        ///<summary> This method return a bool whether it's input contains an error value. </summary>
        virtual bool CheckForError(string input)
        {
            return  "Syntax error".Equals(input) ||
                    "Parenthesis mismatch".Equals(input);
        }
         ///<summary> This method add to the History the last valid executed operation. </summary>
        void AddResult(string input);
    }
}
