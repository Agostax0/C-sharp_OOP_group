using NUnit.Framework;
using OOP21_Calculator.Agosta;
using OOP21_Calculator.Alni;
using System.Collections.Generic;

namespace TestProgrammer
{
    public class Tests
    {
        private CCBinaryOperator nand;
        private CCBinaryOperator nor;
        private CCUnaryOperator not;
        private CCBinaryOperator roR;
        private CCBinaryOperator roL;
        private CCBinaryOperator shiftL;
        private CCBinaryOperator shiftR;
        [SetUp]
        public void Setup()
        {
            nand = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("nand");
            nor = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("nor");
            not = ProgrammerCalculatorModelFactory.Create().UnaryOps.GetValueOrDefault("not");
            roR = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("roR");
            roL = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("roL");
            shiftL = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("shiftL");
            shiftR = ProgrammerCalculatorModelFactory.Create().BinaryOps.GetValueOrDefault("shiftR");
        }

        [Test]
        public void TestNot()
        {

            Assert.AreEqual(255 - 20, not.apply(20));
            Assert.AreEqual(65535 - 4095, not.apply(4095));

            Assert.AreEqual(-(255 - 20), not.apply(-20));
            Assert.AreEqual(-(65535 - 4095), not.apply(-4095));
        }

        [Test]
        public void TestRoR()
        {
            Assert.AreEqual(251, roR.apply(191, 4));
            Assert.AreEqual(251, roR.apply(251, 8));
            Assert.AreEqual(251, roR.apply(191, 12));
        }
        [Test]
        public void TestRoL()
        {
            Assert.AreEqual(191, roL.apply(251, 4));
            Assert.AreEqual(251, roL.apply(251, 8));
            Assert.AreEqual(191, roL.apply(251, 12));
        }
        [Test]
        public void TestShiftR()
        {
            Assert.AreEqual(100 / (2*2), shiftR.apply(100, 2));
            Assert.AreEqual((int)(100 / (2 * 2 * 2)), shiftR.apply(100, 3));

        }
        [Test]
        public void TestShiftL()
        {
            Assert.AreEqual(100 * 2*2, shiftL.apply(100, 2));
            Assert.AreEqual((int)(100 * (2 * 2 * 2)), shiftL.apply(100, 3));
        }

        [Test]
        public void TestNor()
        {
            Assert.AreEqual(128 + 64 + 32, nor.apply(23, 15));
        }
        [Test]
        public void TestNand()
        {
            Assert.AreEqual(255-7, nand.apply(23, 15));
        }


    }
}