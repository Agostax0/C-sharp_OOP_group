using System;
using System.Collections.Generic;
using System.Text;

namespace OOP21_Calculator.Tassinari
{
    class GraphicLogicsImpl : IGraphicLogics
    {
        private readonly List<Double> results;
        public List<double> Results { get => this.results; }

        public void Calculate(string eq)
        {
            throw new NotImplementedException();
        }
    }
}
