using System;
using System.Collections.Generic;
using static OOP21_Calculator.Lepore.CCEngineManager;

namespace Agosta
{
    internal class ProgrammerLogicsImpl : IInputFormatterLogics, IOutputFormatterLogics
    {
        private readonly List<string> _tokens;
        private readonly List<string> buffer;
        private string lastNumBuffer;
        private readonly CalculatorController _controller;
        private readonly CCDisplay _display;
        private int conversionBase = 10;
        public ProgrammerLogicsImpl(CCDisplay display)
        {
            this._display = display;
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
        public void Reset(int convBase)
        {
            this.conversionBase = convBase;
            this.buffer.Clear();
            //this.controller.getManager().memory().clear();
            this.lastNumBuffer = "";
        }


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
        public void Calculate()
        {
            throw new NotImplementedException();
        }

        public void UpdateDisplay()
        {
            //this._display.updateText(this.GetBuffer());
        }

        public void UpdateDisplayUpperText()
        {
            if (this.GetBuffer().Length != 0)
            {
                //_display.updateUpperText(this.GetBuffer() + " =");
            }
        }
        public string Format() => this.GetBuffer();

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
                string text = before + " = " + this.Format();
                //this._controller.getManager().memory().addResult(text);
                
            }
        }
    }
}
