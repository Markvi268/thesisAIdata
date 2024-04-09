using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
Kukkonen Tero
viikko 8
kotitehtävä 3
KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.

Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
*/
namespace Projekti1
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            double a;
            StreamWriter sw = new StreamWriter("c:\\temp\\datat.txt");
            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                a = rnd.NextDouble() * 4.4 + 1.4;
                sw.WriteLine(a);
            }
            sw.Close();
        }
        static void LueTiedostosta(double[] t)
        {
            StreamReader sr = new StreamReader("c:\\temp\\datat.txt");
            int i = 0;
            while (sr.EndOfStream == false)
            {
                t[i] = double.Parse(sr.ReadLine());
                i++;
            }
            sr.Close();
        }
        static void TulostaTiedot(double[] t)
        {
            Console.Write("Summa: ");
            Console.WriteLine(t.Sum());
            Console.Write("Keskiarvo: ");
            Console.WriteLine(t.Average());
            Console.Write("Minimiarvo: ");
            Console.WriteLine(t.Min());
            Console.Write("Maksimiarvo: ");
            Console.WriteLine(t.Max());
        }
        static void Main()
        {
            ArvoJaTallennaTiedostoon();
            double[] taulu = new double[40];
            LueTiedostosta(taulu);
            TulostaTiedot(taulu);
        }
    }
}
