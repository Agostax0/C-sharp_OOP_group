using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore.Test
{
    public class TestManager
    {
        [Test]
        public void TestSimple()
        {
            IManager mng = new CCManager();
            mng.Engine.Mounted = CCEngineManager.Calculator.STANDARD;

            mng.Memory.ReadAll(new List<string>() { "1", "+", "2" });
            mng.Engine.Calculate();
            Assert.AreEqual("3", "3");

        }
    }
}
