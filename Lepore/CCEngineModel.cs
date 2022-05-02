using System;
using System.Collections.Generic;
using System.Text;
using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    public class CCEngineModel : IEngineModel
    {
        private Calculator? mounted;
        public Calculator Mounted { get => mounted.Value; set => mounted = value; }
    }
}
