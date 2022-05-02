using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    class Logger
    {
        private static readonly bool on = true;

        public static void log(IList<string> list)
        {
            if (!on) return;
            Console.WriteLine(string.Join(" ", list) + "\n");
        }
        public static void log(string title, IList<string> list)
        {
            if (!on) return;
            Console.WriteLine("[ " + title + " ]");
            Console.WriteLine(string.Join(" ", list) + "\n");
        }

        public static void log(string title, string s)
        {
            if (!on) return;
            Console.WriteLine("[ " + title + " ]");
            Console.WriteLine(s + "\n");
        }
    }
}
