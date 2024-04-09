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
            Random rnd = new Random();
            int i, j, arvottu;

            for (i = 0; i < lotto.Length; i++)
            {
                arvottu = rnd.Next(1, 41);
                if (lotto.Contains(arvottu)==true)
                {
                    i--;
                }
                else
                {
                    lotto[i] = arvottu;
                }

                

                Array.Sort(lotto, 0, 7);

                for(i=0; i< lotto.Length; i++)
                {
                    Console.Write("{0} ", lotto[i]);

                    if (i==6)
                    {
                        Console.Write(" + ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
