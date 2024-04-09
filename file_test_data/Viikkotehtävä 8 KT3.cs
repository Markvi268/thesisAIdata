using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Syvennykset: ctrl A, ctrl k, ctrl f
/*      
KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
*/


namespace Ohjelmointi_1_Projekti
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rnd = new Random();
            int i;
            StreamWriter sw = new StreamWriter("C: \\Users\\Anton\\OneDrive\\4 vuosi koulujuttuja\\Ohjelmointi 1\\datat.txt");

            for (i = 0; i < 40; i = i + 1)
            {
                sw.WriteLine(rnd.NextDouble() * (5.8 - 1.4) + 1.4);
            }
            sw.Close();

        }

        static void LueTiedostosta(double[] taulukko)
        {
            StreamReader sr = new StreamReader("C: \\Users\\Anton\\OneDrive\\4 vuosi koulujuttuja\\Ohjelmointi 1\\datat.txt");
            int i;

            for (i = 0; i < 40; i = i + 1)
            {
                taulukko[i] = Convert.ToDouble(sr.ReadLine());
            }
            sr.Close();
        }

        static void TulostaTiedot(double[] taulukko)
        {
            Console.WriteLine("Arvottujen lukujen summa: {0:f3}", taulukko.Sum());
            Console.WriteLine("Arvottujen lukujen keski-arvo: {0:f3}", taulukko.Sum() / 40);
            Console.WriteLine("Arvottujen lukujen pienin-arvo: {0:f3}", taulukko.Min());
            Console.WriteLine("Arvottujen lukujen suurin-arvo: {0:f3}", taulukko.Max());
        }

        static void Main(string[] args)
        {
            //KONSOLIN ASETUKSET
            Console.ForegroundColor = ConsoleColor.Green;
            //KONSOLIN ASETUKSET

            double[] taulukko = new double[40];

            ArvoJaTallennaTiedostoon();
            LueTiedostosta(taulukko);
            TulostaTiedot(taulukko);
        }
    }
}
