using OOP21_Calculator.Alni;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP21_Calculator.Tassinari
{
    class GraphicLogicsImpl : IGraphicLogics
    {
        public static double PRECISION = 1;
        public static double RANGE = 3;

        private readonly List<Double> results;
        private readonly ICalculatorController controller;
        public GraphicLogicsImpl()
        {
            this.results = new List<Double>();
            this.controller = new CalculatorControllerTemplate(new CalculatorModelTemplate(ScientificCalculatorModelFactory.Create().BinaryOps, ScientificCalculatorModelFactory.Create().UnaryOps));
        }
        public List<double> Results { get => this.results; }

        public void Calculate(string eq)
        {
            string temp = eq;
            this.results.Clear();
            double x = -RANGE;
            while (x <= RANGE)
            {
                temp.Replace('x', (char) x);
                this.controller.Manager.Memory.Read(temp);
                this.controller.Manager.Engine.Calculate();
                try
                {
                    this.results.Add(Double.Parse(this.controller.Manager.Memory.State.First()));
                }
                catch (ArgumentException e)
                {
                    x = RANGE;
                    results.Clear();
                }
                this.controller.Manager.Memory.Clear();
                x += GraphicLogicsImpl.PRECISION;
            }
        }
    }
}
