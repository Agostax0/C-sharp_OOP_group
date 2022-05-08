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
            if (this.CheckForError(input))
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
            
        }

        public void UpdateDisplayUpperText()
        {
            
        }
        private void SetAppearanceMap()
        {
            ScientificCalculatorModelFactory.Create().UnaryOp.forEach((str, op) => {
                switch (str)
                {
                    case "x²":
                        appearanceMap.put(str, "²");
                        break;
                    case "1/x":
                        appearanceMap.put(str, "1/");
                        break;
                    case "factorial":
                        appearanceMap.put(str, "!");
                        break;
                    case "log":
                        appearanceMap.put(str, "log₁₀");
                        break;
                    default:
                        appearanceMap.put(str, str);
                        break;
                }
            });
            ScientificCalculatorModelFactory.Create().BinaryOps.forEach((str, op) => {
                switch (str)
                {
                    case "root":
                        appearanceMap.put(str, "√");
                        break;
                    default:
                        appearanceMap.put(str, str);
                        break;
                }
            });
        }
        private List<String> ReplaceOp()
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            return state.stream().map((str) => {
                if (this.controller.isBinaryOperator(str) || this.controller.isUnaryOperator(str))
                {
                    return appearanceMap.get(str);
                }
                return str;
            }).collect(Collectors toList());
        }
        private String getStringOf(List<String> input)
        {
            return input.stream().reduce("", (a, b) => a + b);
        }
    }
}
