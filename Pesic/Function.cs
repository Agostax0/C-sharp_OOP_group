using System;
using System.Collections.Generic;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// It contains references to all the functions implemented.
    /// </summary>
    class Function
    {
        private string name;
        private int numArgs;

        public static Dictionary<string, Function> DICFUNCTIONS = new Dictionary<string, Function>()
        {
            { "abs",new Function("abs") },
            { "acos",new Function("acos") },
            { "asin",new Function("asin") },
            { "atan",new Function("atan") },
            { "cos",new Function("cos") },
            { "exp",new Function("exp") },
            { "log",new Function("log") },
            { "negate",new Function("negate") },
            { "pow",new Function("pow", 2) },
            { "sin",new Function("sin") },
            { "sqrt",new Function("sqrt") },
            { "tan",new Function("tan") },
            { "csc",new Function("csc") },
            { "cot",new Function("cot") },
            { "sec",new Function("sec") },
            { "root",new Function("root") },
            { "√", new Function("√")}
        };

        public static ISet<string> getFunctions()
        {
            var set = new HashSet<string>();
            set.UnionWith(new HashSet<string> {"abs", "acos", "asin", "atan", "cos",
                       "exp", "log", "negate", "pow", "sin", "√", "sqrt", "tan", "csc", "cot", "sec", "root", "√"});
            return set;
        }

        public Function(string name, int numArgs) 
        {
            if (name.Length == 0 || numArgs < 0 || !getFunctions().Contains(name)) 
            {
                throw new ArgumentException();
            }
            this.name = name;
            this.numArgs = numArgs;
        }

        public Function(string name)
        {
            this.name = name;
            this.numArgs = 1;
        }

        public String Name => name;

        public int NumArgs => numArgs;

        public static bool isFunction(String name)
        {
            return getFunctions().Contains(name);
        }
    }
}
