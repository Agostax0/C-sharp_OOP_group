using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP21_Calculator.Lepore.CCEngineManager;

namespace OOP21_Calculator.Lepore
{

    class Program
    {
       /* private static void Main(string[] args)
        {
            Console.WriteLine("[ Start ]\n");
            IManager manager = new CCManager();

            manager.Engine.Mounted = Calculator.STANDARD;

            while (true)
            {
                Console.WriteLine("Insert Expression: ");
                string inputLine = Console.ReadLine();
                if (inputLine == "q" || inputLine == "") break;

                foreach (char s in inputLine)
                {
                    manager.Memory.Read(s.ToString());
                }

                manager.Engine.Calculate();
                Console.WriteLine("RESULT: " + manager.Memory.State[0]);

                manager.Memory.Clear();
            }
        }*/
    }
}
