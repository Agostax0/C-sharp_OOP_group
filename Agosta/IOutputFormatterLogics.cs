
namespace Agosta
{
    internal interface IOutputFormatterLogics
    {
        void UpdateDisplay();

        void UpdateDisplayUpperText();

        string Format();

        bool CheckForError(string input)
        {
            return  "Syntax error".Equals(input) ||
                    "Parenthesis mismatch".Equals(input);
        }
        void AddResult(string input);
    }
}
