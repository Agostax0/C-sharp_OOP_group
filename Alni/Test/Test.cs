using NUnit.Framework;
using System.Collections.Generic;

namespace OOP21_Calculator.Alni.Test
{
    public class Test
    {
        [Test]
        public void FibonacciTest()
        {
            CCUnaryOperator op = CombinatoricsCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("fibonacci");
            Assert.AreEqual(5.0, op.apply(5.0), 0);
            Assert.AreEqual(10946.0, op.apply(21.0), 0);
            Assert.AreEqual(1.0, op.apply(2.0), 0);
            Assert.AreEqual(0.0, op.apply(0.0), 0);
            Assert.AreEqual(75_025.0, op.apply(25.0), 0);
            Assert.AreEqual(354_224_848_179_261_915_075.0, op.apply(100.0), 0);
        }
        [Test]
        public void FallingFactorialTest()
        {
            CCBinaryOperator op = CombinatoricsCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("factorial");
            Assert.AreEqual(336.0, op.apply(8, 3), 0);
            Assert.AreEqual(0, op.apply(2, 4), 0);
            Assert.AreEqual(2432902008176640000.0, op.apply(20, 20), 0);
            Assert.AreEqual(1, op.apply(0, 0), 0);
        }
        [Test]
        public void BinomialCoefficientTest()
        {
            CCBinaryOperator op = CombinatoricsCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("binomialCoefficient");
            Assert.AreEqual(56.0, op.apply(8, 3), 0);
            Assert.AreEqual(200.0, op.apply(200, 199), 0);
            Assert.AreEqual(1, op.apply(6000, 6000), 0);
            Assert.AreEqual(0, op.apply(5, 7), 0);
        }
        [Test]
        public void DerangementsTest()
        {
            CCUnaryOperator op = CombinatoricsCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("derangement");
            Assert.AreEqual(44.0, op.apply(5), 0);
            Assert.AreEqual(0.0, op.apply(1), 0);
            Assert.AreEqual(4.810_665_157_34E11, op.apply(15), 0);
        }
        [Test]
        public void BellNumberTest()
        {
            CCUnaryOperator op = CombinatoricsCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("bellNumber");
            Assert.AreEqual(52.0, op.apply(5), 0);
            Assert.AreEqual(877, op.apply(7), 0);
            Assert.AreEqual(1.382_958_545E9, op.apply(15), 0);
        }
        [Test]
        public void StirtlingNumberTest()
        {
            CCBinaryOperator op = CombinatoricsCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("stirlingNumber");
            Assert.AreEqual(1.0, op.apply(5, 5), 0);
            Assert.AreEqual(301.0, op.apply(7, 3), 0);
            Assert.AreEqual(1, op.apply(300, 1), 0);
            Assert.AreEqual(7_770, op.apply(9, 4), 0);
        }
    }
}