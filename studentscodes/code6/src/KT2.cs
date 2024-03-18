using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 
*/
namespace KT11_2
{
    class KT1
    {
        static void Main(string[] args)
        {
            int i;
            int[] taulu = new int[8];
            Random rndm = new Random();

            for (i = 0; i < 8; i++)
            {
                taulu[i] = rndm.Next(1, 41);
                if(taulu.Contains(taulu[i]))
                {
                    taulu[i] = rndm.Next(1, 41);
                }
            }

            for (i = 0; i < 8; i++)
            {
                Array.Sort(taulu, 0, 7);
                Console.Write("{0}\t", taulu[i]);
            }
           


        }
    }
}
