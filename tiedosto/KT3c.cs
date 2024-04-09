using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* KT3 */

namespace ETA18KP
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            double i;

            Random rnd = new Random();

            StreamWriter sw = new StreamWriter("c:\\temp\\data.txt");

            for (i = 1; i <= 40; i++)
            {
                i = rnd.Next(14, 59) / 10.0;
                sw.WriteLine(i);
            }
            sw.Close();
        }
        static void LueTiedostosta(ref double[] t)
        {
            double i;
            double[] taulukko = new double[40];

            StreamReader sr = new StreamReader("c:\\temp\\data.txt");
            double LuettuLuku = 0;

            for (i = 0; i < taulukko.Length; i++)
            {
                LuettuLuku = double.Parse(sr.ReadLine());
                
            }
            sr.Close();
            Console.WriteLine(LuettuLuku);

        
        }
        static void TulostaTiedot(double[] t)
        {
            double summa, ka, min, max;

            summa = t.Sum();
            ka = t.Average();
            max = t.Max();
            min = t.Min();

            Console.WriteLine("Summa : {0:f1}", summa);
            Console.WriteLine("Keskiarvo : {0:f1}", ka);
            Console.WriteLine("Maksimiarvo : {0:f1}", max);
            Console.WriteLine("Minimiarvo : {0:f1}", min);
        }

        
       


        static void Main(string[] args)
        {
            double[] taulukko = new double[40];
            ArvoJaTallennaTiedostoon();
            LueTiedostosta(ref taulukko);
            TulostaTiedot(taulukko);
            
            
            

        }
    }
}
