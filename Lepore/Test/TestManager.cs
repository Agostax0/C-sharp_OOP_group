using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine(mng.Memory.State);
            Assert.AreEqual("3", ListToString(mng.Memory.State));
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
            Assert.AreEqual("3.2", ListToString(mng.Memory.State));
            mng.Memory.Clear();

            mng.Memory.ReadAll(new List<string>() { "1", ".", "2", "+", "2", ".", "3" });
            mng.Engine.Calculate();
            Assert.AreEqual("3.5", ListToString(mng.Memory.State));
            mng.Memory.Clear();

        }


        [Test]
        public void TestExpression()
        {
            string input = "((1 / 3) + (1 / 5)) + ((1 / 6) + (2 / 5) - (3 / 7)) * 7";

            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.Read("sqrt");
            mng.Memory.ReadAll(ToList(input));
            mng.Engine.Calculate();
            Assert.AreEqual("1.6969634100068882", ListToString(mng.Memory.State));
            mng.Memory.Clear();   
        }

        [Test]
        public void TestPrecedence()
        { 
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            // precedence from right to left
            string input = "2^2^3";
            mng.Memory.ReadAll(ToList(input));
            mng.Engine.Calculate();
            Assert.AreEqual("256", ListToString(mng.Memory.State));
            mng.Memory.Clear();

            //first multiplications, then subtraction
            input = "3*4-5*3";
            mng.Memory.ReadAll(ToList(input));
            mng.Engine.Calculate();
            Assert.AreEqual("-3", ListToString(mng.Memory.State));
            mng.Memory.Clear();
        }

        [Test]
        public void TestScientific()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = SCIENTIFIC;

            string input1 = "(3/5)+";
            string input2 = "(0.5)";

            mng.Memory.Read("sin");
            mng.Memory.ReadAll(ToList(input1));
            mng.Memory.Read("cos");
            mng.Memory.ReadAll(ToList(input2));

            mng.Engine.Calculate();
            Assert.AreEqual("1.442225035285408", ListToString(mng.Memory.State));
            mng.Memory.Clear();
        }

        [Test]
        public void TestHistory()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.ReadAll(ToList("1+2"));
            mng.Engine.Calculate();
            mng.Memory.AddResult("1 + 2 = " + ListToString(mng.Memory.State));
            mng.Memory.Clear();
            mng.Memory.ReadAll(ToList("6*2"));
            mng.Engine.Calculate();
            mng.Memory.AddResult("6 * 2 = " + ListToString(mng.Memory.State));
            mng.Memory.Clear();

            var exp = new List<string>() { "1 + 2 = 3", "6 * 2 = 12" };
            Assert.AreEqual(exp, mng.Memory.History);
        }

        [Test]
        public void TestException()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            // Too many operands
            mng.Memory.ReadAll(ToList("1+2+"));
            Assert.DoesNotThrow(() => mng.Engine.Calculate());
            Assert.AreEqual("Syntax error", mng.Memory.State[0]);
            mng.Memory.Clear();

            // Too many dots in a number
            mng.Memory.ReadAll(ToList("1+2.3.4"));
            Assert.DoesNotThrow(() => mng.Engine.Calculate());
            Assert.AreEqual("Syntax error", mng.Memory.State[0]);
            mng.Memory.Clear();

            //Parentheses mismatch
            mng.Memory.ReadAll(ToList("1+(2"));
            Assert.DoesNotThrow(() => mng.Engine.Calculate());
            Assert.AreEqual("Parenthesis mismatch", mng.Memory.State[0]);
            mng.Memory.Clear();
        }

        [Test]
        public void TestDelete()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = STANDARD;

            mng.Memory.ReadAll(ToList("123"));
            Assert.AreEqual("123", ListToString(mng.Memory.State));
            mng.Memory.DeleteLast();
            Assert.AreEqual("12", ListToString(mng.Memory.State));

            mng.Memory.State.RemoveAt(mng.Memory.State.Count - 1);
            Assert.AreEqual("12", ListToString(mng.Memory.State));
        }


        private List<string> ToList(string s) => s.Select(c => c.ToString()).ToList();
        
        private string ListToString(IList<string> list) => string.Join("", list); 
        

    }
}
