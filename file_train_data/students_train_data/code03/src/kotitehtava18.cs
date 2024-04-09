using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.

Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
 */


namespace Projekti
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random _r = new Random();
            StreamWriter sw = new StreamWriter(@"C:\temp\datat.txt");
            for(int i = 0; i < 40; i++)
            {
                sw.WriteLine(_r.NextDouble() * 4.4 + 1.4); 
            }
            sw.Close();
        }
        static void LueTiedostosta(double[] t)
        {
            StreamReader sr = new StreamReader(@"C:\temp\datat.txt");
            for(int i = 0; i < t.Length; i++)
            {
                t[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
        }
        static void TulostaTiedot(double[] t)
        {
            Console.WriteLine(t.Sum());
            Console.WriteLine(t.Average());
            Console.WriteLine(t.Min());
            Console.WriteLine(t.Max());
        }
        static void Main(string[] args)
        {
            double[] t = new double[40];

            ArvoJaTallennaTiedostoon();
            LueTiedostosta(t);
            TulostaTiedot(t);


        }

    }
}
