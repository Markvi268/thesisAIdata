using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kotihommia
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rng = new Random();
            double luku;
            int i = 1;
            StreamWriter sw1 = new StreamWriter("c:\\temp\\datat.txt");
            
            for (; ; )
            {
                luku = rng.NextDouble() * (5.8 - 1.4) + 1.4;
                sw1.WriteLine(luku);
                i++;
                if (i == 41)
                {
                    break;
                }

            }
            sw1.Close();
        }

        static void LueTiedostosta(ref double[] taulu)
        {
            
            int i = 0;
            StreamReader sr1 = new StreamReader("c:\\temp\\datat.txt");
            do
            {
                taulu[i] = double.Parse(sr1.ReadLine());
                i++;
            }
            while (sr1.EndOfStream == false);
            sr1.Close();
        }

        static void TulostaTiedot(double[] taulu)
        {
            double summa, ka, min, max;
            min = taulu.Min();
            max = taulu.Max();
            summa = taulu.Sum();
            ka = summa/taulu.Length;

            Console.WriteLine("Taulukon maksimiarvo on: {0:f1}", max);
            Console.WriteLine("Taulukon minimiarvo on: {0:f1}", min);
            Console.WriteLine("Taulukon lukujen summa on: {0:f1}", summa);
            Console.WriteLine("Taulukon lukujen keskiarvo on: {0:f1}", ka);
        }
        static void Main(string[] args)
        {
            double[] taulu = new double[40];
            ArvoJaTallennaTiedostoon();
            LueTiedostosta(ref taulu);
            TulostaTiedot(taulu);
        }
    }
}
