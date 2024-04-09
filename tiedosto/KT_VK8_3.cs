using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rojekti
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            double arvottu;
            int i;
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("C:\\kansio\\data.txt");
            
            for(i = 0; i < 40; i++)
            {
                arvottu = rnd.Next(14, 59);
                arvottu = arvottu / 10;
                sw.WriteLine(arvottu);                
            }
            sw.Close();
        }
        static void LueTiedostosta (double[] t)
        {
            
            int i;
            StreamReader sr = new StreamReader("C:\\kansio\\data.txt");
            for(i = 0; i < t.Length; i++)
            {
                t[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
            
        }
        static void TulostaTiedot(double[] taulu)
        {
            Console.WriteLine("{0:f2}", taulu.Sum());
            Console.WriteLine("{0:f2}", taulu.Average());
            Console.WriteLine("{0:f2}", taulu.Min());
            Console.WriteLine("{0:f2}", taulu.Max());
        }


        static void Main()
        {
            double[] taulu = new double[40];
            ArvoJaTallennaTiedostoon();
            LueTiedostosta(taulu);
            TulostaTiedot(taulu);
        }
    }
}
