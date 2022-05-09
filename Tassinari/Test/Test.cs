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
            Assert.AreEqual(0.0871557427, sin.apply(5));

            var cos = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("cos");
            Assert.AreEqual(0.999847695, cos.apply(1));

            var tan = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("tan");
            Assert.AreEqual(0.0174550649, tan.apply(1));

            var sec = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("sec");
            Assert.AreEqual(1.000152328, sec.apply(1));

            var csc = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("csc");
            Assert.AreEqual(57.29868849, csc.apply(1));

            var cot = ScientificCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("cot");
            Assert.AreEqual(57.8996163, cot.apply(1));

        }
        public void BinaryScientificCalculatorTest()
        {
            var root = ScientificCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("root");
            Assert.AreEqual(2, root.apply(2, 4));
            Assert.AreEqual(10, root.apply(2, 100));

            var pot = ScientificCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("^");
            Assert.AreEqual(100, pot.apply(10, 2));
            Assert.AreEqual(25, pot.apply(5, 2));
        }
        public void GraphicCalculatorLogicsTest()
        {
            var logics = new GraphicLogicsImpl();
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
