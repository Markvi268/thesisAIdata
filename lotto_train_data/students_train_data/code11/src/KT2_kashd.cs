using System;
using System.Linq;

namespace lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lotto = new int[8];
            Random random = new Random();
      
            for (int i = 0; i < lotto.Length; i++) {

                int numero = random.Next(1, 41);

                while (lotto.Contains(numero)) {

                    numero = random.Next(1, 41);

                }

                lotto[i] = numero;

            }


            Array.Sort(lotto, 0, 6);

            for (int i = 0; i < lotto.Length; i++) {

                if (i < lotto.Length - 1)
                {

                    Console.Write(lotto[i] + " ");

                }
                else {

                    Console.Write("+ " + lotto[i]);

                }

            }


        }
    }
}
