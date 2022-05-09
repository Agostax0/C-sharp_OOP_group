using System;
using System.Collections.Generic;
using System.Linq;
using OOP21_Calculator.Agosta;
using OOP21_Calculator.Alni;

namespace OOP21_Calculator.Tassinari
{
    class OutputFormatterLogicsImpl : IOutputFormatterLogics
    {
        private Dictionary<String, String> appearanceMap = new Dictionary<String, String>();
        private readonly ICalculatorController controller;
        public OutputFormatterLogicsImpl(ICalculatorController controller)
        {
            this.SetAppearanceMap();
            this.controller = controller;
        }
        public void AddResult(string input)
        {
            IOutputFormatterLogics temp = this;
            if (temp.CheckForError(input))
            {
                this.controller.Manager.Memory.AddResult((string)input.Concat(" = ").Concat(this.Format()));
            }
        }

        public string Format()
        {
            List<String> output = this.ReplaceOp();
            return this.getStringOf(output);
        }

        public void UpdateDisplay()
        {
            throw new NotImplementedException();
        }

        public void UpdateDisplayUpperText()
        {
            throw new NotImplementedException();
        }
        private void SetAppearanceMap()
        {
            foreach((string str, var op) in ScientificCalculatorModelFactory.Create().UnaryOps)
            {
                switch (str)
                {
                    case "x²":
                        appearanceMap.Add(str, "²");
                        break;
                    case "1/x":
                        appearanceMap.Add(str, "1/");
                        break;
                    case "factorial":
                        appearanceMap.Add(str, "!");
                        break;
                    case "log":
                        appearanceMap.Add(str, "log₁₀");
                        break;
                    default:
                        appearanceMap.Add(str, str);
                        break;
                }
            }
            foreach ((string str, var op) in ScientificCalculatorModelFactory.Create().BinaryOps)
            {
                switch (str)
                {
                    case "root":
                        appearanceMap.Add(str, "√");
                        break;
                    default:
                        appearanceMap.Add(str, str);
                        break;
                }
            }
        }
        private List<String> ReplaceOp()
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            return state.Select(String (str) => {
                if (this.controller.IsBinaryOperator(str) || this.controller.IsUnaryOperator(str))
                {
                    appearanceMap.TryGetValue(str, out string value);
                    return value;
                }
                return str;
            }).ToList();
        }
        private String getStringOf(List<String> input)
        {
            return String.Join("", input);
        }
    }
}
