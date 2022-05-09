using OOP21_Calculator.Alni;
using OOP21_Calculator.Lepore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP21_Calculator.Tassinari
{
    class GraphicLogicsImpl : IGraphicLogics
    {
        public static double PRECISION = 1;
        public static double RANGE = 3;

        private readonly List<Double> results = new List<Double>();
        private readonly Alni.ICalculatorController _controller = new CalculatorControllerTemplate(new CalculatorModelTemplate(ScientificCalculatorModelFactory.Create().BinaryOps, ScientificCalculatorModelFactory.Create().UnaryOps));
        public GraphicLogicsImpl() 
        {
            _controller.Manager = new CCManager();
        
        }
        public List<double> Results { get => results; }

        public void Calculate(string eq)
        {
            results.Clear();
            double x = -RANGE;
            while (x <= RANGE)
            {
                List<string> temp = eq.Split(",").ToList();
                int index;
                index = temp.FindIndex(e => e == "x");
                while(index != -1)
                {
                    temp[index] = x.ToString();
                    index = temp.FindIndex(e => e == "x");
                }
                var s = _controller.Manager.Memory.State;
                _controller.Manager.Memory.ReadAll(temp);
                _controller.Manager.Engine.Calculate();
                try
                {
                    results.Add(Double.Parse(_controller.Manager.Memory.State.First()));
                }
                catch (ArgumentException)
                {
                    x = RANGE;
                    results.Clear();
                }
                _controller.Manager.Memory.Clear();
                x += PRECISION;
            }
        }
    }
}
