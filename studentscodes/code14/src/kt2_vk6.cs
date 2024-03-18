using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] lotto = new int[8];
            Random rng = new Random();
            int pallo;

            for (int i = 0; i < 8; i++)
            {
                pallo = rng.Next(1, 41);
                while (lotto.Contains(pallo) == true)
                {
                    pallo = rng.Next(1, 41);
                }
                lotto[i] = pallo;
            }

            Array.Sort(lotto, 0, 7);

            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0} ", lotto[i]);
            }

            Console.WriteLine("+ {0}",lotto[7]);
            



        }
    }
}
