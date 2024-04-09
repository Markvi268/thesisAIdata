using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    /*Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa. 
     * Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon.
     * Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.
     * Käytä funktioita:
        ArvoJaTallennaTiedostoon
        LueTiedostosta
        TulostaTiedot     
     */
    class Program
    {
        static void ArvoJaTallennaTiedostoon(double x)
        {
            Random rng = new Random();
            StreamWriter sw = new StreamWriter("c:\\ohjelmointi\\datat.txt");

            for (int i = 0; i < 40; i++)
            {
                x = rng.Next(14, 59) / 10.0;
                sw.WriteLine(x);
            }
            sw.Close();
        }
        static void LueTiedostosta(double[] x)
        {
            StreamReader sr = new StreamReader("c:\\ohjelmointi\\datat.txt");

            for (int i = 0; i < 40; i++)
            {
                x[i] = double.Parse(sr.ReadLine());
            }
        }

        static void TulostaTiedot(double[] x)
        {
            Console.WriteLine("Taulukon summa: {0}",x.Sum());
            Console.WriteLine("Taulukon keskiarvo: {0}", x.Sum() / x.Length);
            Console.WriteLine("Taulukon minimiarvo: {0}", x.Min());
            Console.WriteLine("Taulukon maksimiarvo: {0}", x.Max());
        }
        static void Main()
        {
            double luku = 0;
            double[] ar = new double[40];

            ArvoJaTallennaTiedostoon(luku);
            LueTiedostosta(ar);
            TulostaTiedot(ar);
           

        }

    }
}
