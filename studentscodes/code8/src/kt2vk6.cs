using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kotihommia
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] taulu = new int[8];
            Random rng = new Random();
            int luku, i;
            

            for (i = 0; i < 8; i++)
            {           
                luku = rng.Next(1, 41);
                if (taulu.Contains(luku))
                {
                    i--;
                    continue;
                }
                taulu[i] = luku;            
            }
            Array.Sort(taulu, 0, 7);      
            for (i = 0; i<taulu.Length; i++)
            {
                Console.Write(taulu[i] + " ");
                if(i == 6)
                {
                    Console.Write("+ ");
                }
                
            }


           


        }
    }
}
