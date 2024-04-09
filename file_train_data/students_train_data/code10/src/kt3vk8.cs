using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon.
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot */

namespace ekaprojekti18kp
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            StreamWriter SW = new StreamWriter("C:\\temp\\data.txt");
            Random rnd = new Random();
            double luku;
            for(int i = 0; i < 40; i++)
            {
                luku = rnd.NextDouble() * (5.8 - 1.4) + 1.4;
                SW.WriteLine(luku);
            }
            SW.Close();
        }
        static void LueTiedostosta(ref double[] taulu)
        {

            int i = 0;
            StreamReader SR = new StreamReader("C:\\temp\\data.txt");
            do
            {
                taulu[i] = double.Parse(SR.ReadLine());
                i++;
            }
            while (SR.EndOfStream == false);
            SR.Close();
        }
        static void TulostaTiedot(double[] taulu)
        {
            double summa, ka, min, max;
            min = taulu.Min();
            max = taulu.Max();
            summa = taulu.Sum();
            ka = summa / taulu.Length;

            Console.WriteLine("Taulukon maksimiarvo on: {0:f1}", max);
            Console.WriteLine("Taulukon minimiarvo on: {0:f1}", min);
            Console.WriteLine("Taulukon lukujen summa on: {0:f1}", summa);
            Console.WriteLine("Taulukon lukujen keskiarvo on: {0:f1}", ka);
        }
        static void Main(string[] args)
        {
            ArvoJaTallennaTiedostoon();
            double[] taulu = new double[40];
            LueTiedostosta(ref taulu);
            TulostaTiedot(taulu);

        }
    }
}
 