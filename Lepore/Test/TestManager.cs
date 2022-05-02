using NUnit.Framework;
using System;
using System.Collections.Generic;
using static OOP21_Calculator.Lepore.IEngineModel.Calculator;

namespace OOP21_Calculator.Lepore.Test
{
    public class TestManager
    {
        [Test]
        public void TestSimple()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.ReadAll(new List<string>() { "1", "+", "2" });
            mng.Engine.Calculate();
            Assert.AreEqual("3", mng.Memory.State[0]);
            mng.Memory.Clear();
            Assert.AreEqual(0, mng.Memory.State.Count);
        }

        [Test]
        public void TestDecimal()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.ReadAll(new List<string>() { "1.1", "+", "2.1" });
            mng.Engine.Calculate();
            Assert.AreEqual("3.2", mng.Memory.State[0]);
            mng.Memory.Clear();

            mng.Memory.ReadAll(new List<string>() { "1", ".", "2", "+", "2", ".", "3" });
            mng.Engine.Calculate();
            Assert.AreEqual("3.5", mng.Memory.State[0]);
            mng.Memory.Clear();

        }

        [Test]
        public void TestExpression()
        {
            string input = "((1 / 3) + (1 / 5)) + ((1 / 6) + (2 / 5) - (3 / 7)) * 7";

            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.Read("sqrt");
            foreach(char c in input)
            {
                mng.Memory.Read(c.ToString());
            }

            mng.Engine.Calculate();
            Assert.AreEqual("1.6969634100068882", mng.Memory.State[0]);
            mng.Memory.Clear();   
        }

        [Test]
        public void TestPrecedence()
        {
            string input = "2^2^3";

            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            foreach (char c in input)
            {
                mng.Memory.Read(c.ToString());
            }

            mng.Engine.Calculate();
            Assert.AreEqual("256", mng.Memory.State[0]);
            mng.Memory.Clear();

            input = "3*4 - 5*3";
            foreach (char c in input)
            {
                mng.Memory.Read(c.ToString());
            }

            mng.Engine.Calculate();
            Assert.AreEqual("-3", mng.Memory.State[0]);
            mng.Memory.Clear();
        }

        [Test]
        public void TestScientific()
        {
            IList<string> input = new List<string>()
            {
                "sin",
                "(",
                "3",
                "/",
                "5",
                ")",
                "+",
                "cos",
                "(",
                "0",
                ".",
                "5",
                ")"
            };

            IManager mng = new CCManager();
            mng.Engine.Mounted = SCIENTIFIC;

            mng.Memory.ReadAll(input);
            mng.Engine.Calculate();
            Assert.AreEqual("1.442225035285408", mng.Memory.State[0]);
            mng.Memory.Clear();

        }

    }
}
