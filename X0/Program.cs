using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X0G
{
    class Program
    {

        static void Main(string[] args)
        {
            X0Game a = new X0Game();
            a.Draw();
            a.Menu();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var tmp = Console.ReadKey().Key;
                    if (tmp == ConsoleKey.Spacebar)
                    {
                        a.SetXO();
                    }
                    a.Draw();
                    a.Menu(tmp);
                    a.Move(tmp);
                }
            }

        }
    }
}
