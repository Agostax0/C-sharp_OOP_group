using System;
using System.Collections.Generic;
using static OOP21_Calculator.Lepore.CCEngineManager;

namespace OOP21_Calculator.Agosta
{
    ///<summary>Class<c>ProgrammerLogicsImpl</c> mediates between CalculatorController and ProgrammerPanel.</summary>
    internal class ProgrammerLogicsImpl : IInputFormatterLogics, IOutputFormatterLogics
    {
        private readonly List<string> _tokens;
        private readonly List<string> buffer;
        private string lastNumBuffer;
        //private readonly CalculatorController _controller;
        //private readonly CCDisplay _display;
        private int conversionBase = 10;
        public ProgrammerLogicsImpl(/*CCDisplay display*/)
        {
            //this._display = display;
            this._tokens = new List<string>();
            this.buffer = new List<string>();
            //_controller = Calculator.PROGRAMMER.getController();
            this.AddTokens();
        }

        private void AddTokens()
        {
            this._tokens.Add("(");
            this._tokens.Add(")");

            foreach (var token in ProgrammerCalculatorModelFactory.Create().UnaryOps)
            {
                this._tokens.Add(token.Key);
            }
            foreach (var token in ProgrammerCalculatorModelFactory.Create().BinaryOps)
            {
                this._tokens.Add(token.Key);
            }
        }
        ///<summary> This method reads a string value to be added to the current buffer.
        ///<example> For example:
        ///<paramref name="input">the value to be read.</paramref>
        ///<code>
        ///     new ProgrammerLogicsImpl().Read("F");
        ///</code>
        /// the buffer will contain a single string "F".
        ///</example>
        ///</summary>
        public void Read(string input)
        {
            if ("not".Equals(input))
            {
                this.handleNot();
            }
            else
            {
                if( !this._tokens.Contains(input))
                {
                    this.lastNumBuffer += input;
                }
                else
                {
                    this.lastNumBuffer = "";
                }
                this.buffer.Add(input);
            }
            this.RemoveError();
        }

        private void RemoveError()
        {
            this.buffer.Remove("Syntax error");
            this.buffer.Remove("Parenthesis mismatch");
        }

        private void handleNot()
        {
            this.buffer.Insert(0, "(");
            this.buffer.Insert(0, "not");
            this.buffer.Insert(0, ")");
            this.RemoveError();
            string before = this.GetBuffer();
            this.UpdateDisplayUpperText();
            this.Calculate();
            this.UpdateDisplay();
            this.AddResult(before);
        }

        private string GetBuffer()
        {
            string ret = "";
            this.buffer.ForEach(elem =>
            {
                ret += elem;
            });
            return ret;
        }
        ///<summary> This method changes the current conversion base
        ///     and clears the buffers.
        ///<example> For example:
        ///<code>
        ///     new FormatterLogicsImpl().Reset(a);
        ///</code>
        /// where <c>a</c> can assume the following values: 2, 8, 10, 16;
        ///</example>
        ///</summary>
        public void Reset(int convBase)
        {
            this.conversionBase = convBase;
            this.buffer.Clear();
            //this.controller.getManager().memory().clear();
            this.lastNumBuffer = "";
        }

        ///<summary> This method deletes the last input recieved.
        ///<example> For example:
        ///<code>
        ///    var x = new FormatterLogicsImpl();
        ///    x.Read("1");x.Read("0");
        ///    x.DeleteLast();
        ///</code>
        ///    doing so will leave in the buffer only the value "1";
        ///</example>
        ///</summary>
        public void DeleteLast()
        {
            if("Syntax error".Equals(this.lastNumBuffer))
            {
                this.Reset(conversionBase);
            }
            if(this.lastNumBuffer.Length > 0)
            {
                this.buffer.RemoveAt(this.buffer.Count - 1);
                this.lastNumBuffer = "";
                this.buffer.ForEach(str =>
                {
                    lastNumBuffer += str;
                });
            }
        }
        ///<summary> This method calculates the current buffer's contents 
        ///     using the engine's calculate.
        ///<example> For example:
        ///<code>
        ///     var x = new FormatterLogicsImpl();
        ///     x.read("1");x.read("+");x.read("1");
        ///     x.calculate();
        ///</code>
        /// doing this will leave in the buffer only the result of "1+1".
        ///</example>
        ///</summary>
        public void Calculate()
        {
            if (!this.buffer.Count != 0)
            {
                this.RemoveError();
                var temp = this.FormatToDecimal(); 
                this.controller.getManager().memory.readAll(temp);
                this.controller.getManager().engine().calculate();
                this.buffer.Clear();
                if(this.controller.getManager().memory().getCurrentState().Exists((str) => str.Contains("-")){
                    var res = this.buffer[0];//this.controller.getManager().memory().getCurrentState[0];
                    for(int i = 0; i < res.Length; i++)
                    {
                        this.buffer.Add(res[i]);
                    }
                }
                else
                {
                    //this.buffer.AddRange(this.controller.memory().getManager().getCurrentState());
                }
                this.InverseFormat();
                this.lastNumBuffer = this.buffer.ToString();
                this.controller.getManager().memory().clear();
            }
        }
        private List<string> FormatToDecimal()
        {
            throw new NotImplementedException();
        }
        private List<string> InverseFormat()
        {
            throw new NotImplementedException();
        }

        ///<summary> This method will update the display to show the current buffer </summary>
        public void UpdateDisplay()
        {
            //this._display.updateText(this.GetBuffer());
        }
        ///<summary> This method will update the upper display to show the last operation executed </summary>
        public void UpdateDisplayUpperText()
        {
            if (this.GetBuffer().Length != 0)
            {
                //_display.updateUpperText(this.GetBuffer() + " =");
            }
        }
        ///<summary>
        ///<returns> the current buffer converted to string.</returns>
        ///</summary>
        public string Format() => this.GetBuffer();
        ///<summary> This methods add to the History the
        /// last valid executed operation, if already added.
        ///</summary>
        public void AddResult(string before)
        {
            IOutputFormatterLogics outputFormatterLogics = this;
            if (outputFormatterLogics.CheckForError(before))
            {
                var BaseMap = new Dictionary<int, string>();
                BaseMap.Add(2, "₂");
                BaseMap.Add(8, "₈");
                BaseMap.Add(10, "₁₀");
                BaseMap.Add(16, "₁₆");
                string text = before + " = " + this.Format() + BaseMap.GetValueOrDefault(this.conversionBase);
                //this._controller.getManager().memory().addResult(text);
                
            }
        }
    }
}
