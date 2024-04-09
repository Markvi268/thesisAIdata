using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kt3._8.cs
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon(out double x)
        {
            
            int i = 0;
            x = 0;

            Random rnd = new Random();

            StreamWriter sw = new StreamWriter("C:\\Ohjelmointi\\tiedot.txt");

            while (i < 40)
            {
                i++;
                x = rnd.Next(14, 59)/10.0;
                sw.WriteLine(x);
            }
            
            sw.Close();
            
        }
        static void LueTiedostosta(double x, double[] t)
        {
           
            int i;
           
            StreamReader sr = new StreamReader("C:\\Ohjelmointi\\tiedot.txt");
            
                for (i = 0; i < t.Length; i++)
                {
                    t[i] = double.Parse(sr.ReadLine());
                   
                }

            sr.Close();
            
            
             
        }
        static void TulostaTiedot(double[] t)
        {
            Console.WriteLine("Summa : {0}", t.Sum());

            Console.WriteLine("Keskiarvo : {0}", t.Average());

            Console.WriteLine("Minimi : {0}", t.Min());

            Console.WriteLine("Maksimi : {0}", t.Max());
            
        }
        static void Main()
        {
            double arvotut;
            double[] taulu = new double[40];

            ArvoJaTallennaTiedostoon(out arvotut);
            LueTiedostosta(arvotut, taulu);
            TulostaTiedot(taulu);
        }
    }
}
