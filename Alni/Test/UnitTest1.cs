using OOP21_Calculator.Alni;
using NUnit.Framework;
using System.Collections.Generic;

namespace OOP21_Calculator.Alni.Test
{
    public class Test
    {
        [Test]
        public void Test1()
        {
            Dictionary<string, CCBinaryOperator> map = Combinatoricsfactory.Create().Get_Binary_Ops();
            Dictionary<string, CCUnaryOperator> map2 = Combinatoricsfactory.Create().Get_Unary_Ops();
            Assert.AreEqual(6, map.GetValueOrDefault("Somma").apply(3, 3));
            Assert.AreEqual(5, map2.GetValueOrDefault("Precedente").apply(6));
        }
    }
}