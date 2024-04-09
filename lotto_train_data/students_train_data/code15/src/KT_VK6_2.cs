using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rojekti
{
    class Program
    {        
        static void Main(string[] args)
        {
            int[] lotto = new int[8];
            int i;
            Random rnd = new Random();
           

            for(i = 0; i < lotto.Length; i++)
            {
                lotto[i] = rnd.Next(1, 41);

                if (lotto[i] == lotto[i]) //huomasin debuggerissa, että lotto[0] saa aina vain uuden arvon enkä tiedä miten tätä pitäisi muuttaa.
                {
                    i--;
                }
            }
            
            Console.Write( "{0} {1} {2} {3} {4} {5} {6} + {7}", lotto[0], lotto[1], lotto[2], lotto[3], lotto[4], lotto[5], lotto[6], lotto[7]);
           
        }
    }
}
