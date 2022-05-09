using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OOP21_Calculator.Tassinari.Test
{
    public class Test
    {
        [Test]
        public void UnaryScientificCalculatorTest()
        {
            var log = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("log");
            Assert.AreEqual(1, log.apply(10));
            Assert.AreEqual(2, log.apply(100));

            var ln = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("ln");
            Assert.AreEqual(1, ln.apply(Math.E));

            var abs = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("abs");
            Assert.AreEqual(1, abs.apply(-1));
            Assert.AreEqual(-10, -abs.apply(10));
            Assert.AreEqual(0, abs.apply(0));

            var fact = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("factorial");
            Assert.AreEqual(120, fact.apply(5));
            Assert.AreEqual(1, fact.apply(0));

            var sin = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("sin");
            Assert.AreEqual(Math.Sin(5), sin.apply(5));

            var cos = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("cos");
            Assert.AreEqual(Math.Cos(1), cos.apply(1));

            var tan = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("tan");
            Assert.AreEqual(Math.Tan(1), tan.apply(1));

            var sec = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("sec");
            Assert.AreEqual(1 / Math.Cos(1), sec.apply(1));

            var csc = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("csc");
            Assert.AreEqual(1 / Math.Sin(1), csc.apply(1));

            var cot = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("cot");
            Assert.AreEqual(Math.Cos(1) / Math.Sin(1), cot.apply(1));

        }
        [Test]
        public void BinaryScientificCalculatorTest()
        {
            var root = ScientificCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("root");
            Assert.AreEqual(2, root.apply(4, 2));
            Assert.AreEqual(10, root.apply(100, 2));

            var pot = ScientificCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("^");
            Assert.AreEqual(100, pot.apply(10, 2));
            Assert.AreEqual(25, pot.apply(5, 2));
        }
        [Test]
        public void GraphicCalculatorLogicsTest()
        {
            IGraphicLogics logics = new GraphicLogicsImpl();
            List<double> result = new List<double>();
            for (int i = -3; i <= 3; i++)
            {
                result.Add(i);
            }
            logics.Calculate("x");
            Assert.AreEqual(result, logics.Results);
        }
    }
}
