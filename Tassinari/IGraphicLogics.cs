using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Tassinari
{
    interface IGraphicLogics
    {
        ///<summary> This method takes a String function f(x) and calculates it in a certain amount of points.</summary>
        void Calculate(String eq);
        ///<summary> This method returns a List<Double> containing the points found from the last given function.</summary>
        List<Double> Results { get; }
    }
}
