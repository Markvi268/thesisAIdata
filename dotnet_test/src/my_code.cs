using System;
using System.Globalization;
int[] lottotaulu = new int[8];
            int i, numero;
            Random rnd = new Random();
 

            for (i = 0; i < lottotaulu.Length; i++)
            {
                numero = rnd.Next(1, 41);

                while (lottotaulu.Contains(numero) == true)
                {
                    numero = rnd.Next(1, 41);
                }
                lottotaulu[i] = numero;
            }

            foreach (int luku in lottotaulu)
            {
                Array.Sort(lottotaulu); // ää en osaa äiti auta...
                Console.Write("{0}  ", luku);
            }
