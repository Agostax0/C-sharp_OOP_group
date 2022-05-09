using System;
using System.Collections.Generic;
using System.Text;

namespace OOP21_Calculator.Tassinari
{
    interface IGraphicLogics
    {
        ///<summary> This method takes a String function f(x) and calculates a certain amount of points.</summary>
        void Calculate(String eq);
        ///<summary> This method returns a List<Double> containing the points of the last given function.</summary>
        List<Double> Results { get; }
    }
}
