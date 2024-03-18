using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lottonumerot = new int[7];
            Random rand = new Random();
            int temp = 0;
            int count = 0;

            for (int i = 0; i < lottonumerot.Length; i++)
            {
                temp = rand.Next(1, 40);
                while (lottonumerot.Contains(temp)== false)
                {
                    lottonumerot[count] = temp;
                    count++;
                
                }


            }
            
             foreach (int i in lottonumerot)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();






















        }
    }
}
