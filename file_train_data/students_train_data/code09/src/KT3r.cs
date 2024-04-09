using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
KT3
Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. 
Älä käytä taulukkoa tässä vaiheessa.
Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
 */
namespace KT1_2_25
{
    class KT1
    {
        static void ArvoJaTallenna(out double luku)
        {
            int i;
            luku = 0;
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("c:/temp/datat.txt");
            for (i = 0; i < 40; i++)
            {
                luku = rnd.NextDouble() * 4.4 + 1.4;
                sw.WriteLine(luku);
            }
            sw.Close();
        }
        static void LueTiedostosta(double[] t)
        {
            int i;
            StreamReader sr = new StreamReader("c:/temp/datat.txt");
            for (i = 0; i < 40; i++)
            {
                t[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
        }
        static void TulostaTiedot(double[] t)
        {
            Console.WriteLine("summa: {0:f2}", t.Sum());
            Console.WriteLine("keskiarvo: {0:f2}", t.Average());
            Console.WriteLine("MIN: {0:f2}", t.Min());
            Console.WriteLine("MAX: {0:f2}", t.Max());
        }
        
        static void Main(string[] args)
        {
            double luku;
            double[] t = new double[40];

            ArvoJaTallenna(out luku);
            LueTiedostosta(t);
            TulostaTiedot(t);

            


           

            
        }
    }
}
