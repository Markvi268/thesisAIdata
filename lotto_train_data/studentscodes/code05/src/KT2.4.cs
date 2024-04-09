using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT2._4.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taulu = new int[8];
            Random rdn = new Random();
            int i;
            for (i = 0; i < taulu.Length; i++)

            {
                taulu[i] = rdn.Next(1, 41);

                if (taulu[i]++ == taulu[i])
                    continue;
            }

            Array.Sort(taulu, 0, 7);
            

            for (i = 0; i < 7; i++)
            {
                Console.Write("{0} ", taulu[i]);
            }
            Console.WriteLine("+ {0}", taulu[7]);








        }
    }
}
