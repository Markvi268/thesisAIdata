using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* KT2 */

namespace ETA18KP
{
    class Program
    {


        static void Main(string[] args)
        {

            int[] taulu = new int[8];
            int i;
            Random rnd = new Random();
            int numero = 0;

            for (i = 0; i < taulu.Length; i++)
            {
                numero = rnd.Next(1, 41);
                while (taulu.Contains(numero) == true)
                {
                    numero = rnd.Next(1, 41);
                }
                taulu[i] = numero;
            }
            Array.Sort(taulu, 0, 6);

            for (i = 0; i < taulu.Length; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine(" + {0}", taulu[i]);
                }
                else
                {
                    Console.WriteLine(taulu[i]);
                }
               

                    
            }












        }
    }
}
