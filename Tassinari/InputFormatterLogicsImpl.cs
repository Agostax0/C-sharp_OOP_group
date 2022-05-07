using System;
using OOP21_Calculator.Agosta;
using OOP21_Calculator.Alni;
using System.Collections.Generic;

namespace OOP21_Calculator.Tassinari
{
    public class InputFormatterLogicsImpl : IInputFormatterLogics
    {
        private ICalculatorController controller;

        public InputFormatterLogicsImpl(ICalculatorController contr)
        {
            this.controller = contr;
        }
        public void Calculate()
        {
            controller.Manager.Engine.Calculate();
        }
        public void DeleteLast()
        {
            //not implemented
            //controller.Manager.Memory.DeleteLast();
        }
        public void Read(string input)
        {
            if (controller.IsUnaryOperator(input))
            {
                if (this.IsPreviousValueANumber())
                {
                    this.WrapNumberInOperator(input);
                }
                else
                {
                    this.ReadInvalidOperand(input);
                }
            }
            else
            {
                controller.Manager.Memory.Read(input);
            }
            this.checkParenthesis();
        }
        private void checkParenthesis()
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            for (int i = 0; i < state.Count; i++)
            {
                if (i != (state.Count - 1) && ("(".Equals(state[i]) && ")".Equals(state[i + 1])))
                {
                    state.RemoveAt(i);
                    state.RemoveAt(i);
                }
            }
            controller.Manager.Memory.Clear();
            controller.Manager.Memory.ReadAll(state);
        }
        private bool IsPreviousValueANumber()
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            return this.IsNumber(state.Count - 1);
        }
        private void WrapNumberInOperator(String op)
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            int index = state.Count - 1;
            while (index >= 0)
            {
                if (!this.IsNumber(index))
                {
                    index++;
                    break;
                }
                index--;
            }
            index = index == -1 ? 0 : index;
            state.Insert(index, "(");
            if ("x²".Equals(op))
            {
                state.Add(")");
                state.Add(op);
            }
            else
            {
                state.Insert(index, op);
                state.Add(")");
            }
            controller.Manager.Memory.Clear();
            controller.Manager.Memory.ReadAll(state);
        }
        private bool IsNumber(int i)
        {
            List<String> state = new List<String>(controller.Manager.Memory.State);
            if (state.Count == 0)
            { //se lo state è vuoto allora devo ritornare che prima non c'è un numero
                return false;
            }
            if (".".Equals(state[i]) || ")".Equals(state[i]))
            {
                return true;
            }
            Double.Parse(state[i]);
            return true;
        }
        private void ReadInvalidOperand(String op)
        {
            switch (op)
            {
                case "x²":
                    controller.Manager.Memory.Read("(");
                    controller.Manager.Memory.Read("0");
                    controller.Manager.Memory.Read(")");
                    controller.Manager.Memory.Read(op);
                    break;
                case "1/x":
                    controller.Manager.Memory.Read("(");
                    controller.Manager.Memory.Read(op);
                    controller.Manager.Memory.Read("1");
                    controller.Manager.Memory.Read(")");
                    break;
                case "√":
                    controller.Manager.Memory.Read("(");
                    controller.Manager.Memory.Read(op);
                    controller.Manager.Memory.Read("0");
                    controller.Manager.Memory.Read(")");
                    break;
                case "cos":
                case "tan":
                case "abs":
                case "sin":
                    controller.Manager.Memory.Read(op);
                    controller.Manager.Memory.Read("(");
                    controller.Manager.Memory.Read("0");
                    controller.Manager.Memory.Read(")");
                    break;
                case "csc":
                case "sec":
                case "cot":
                case "factorial":
                case "log":
                case "ln":
                    controller.Manager.Memory.Read(op);
                    controller.Manager.Memory.Read("(");
                    controller.Manager.Memory.Read("1");
                    controller.Manager.Memory.Read(")");
                    break;
                default:
                    break;
            }
        }
    }
}


