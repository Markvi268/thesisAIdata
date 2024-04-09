using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
*/
namespace Tehtava3
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("c:\\Windows\\Temp\\datat.txt"); //tämä polku toimii minun koneessa

            for (int i = 0; i <= 40; i++)
            {
                double d = rnd.NextDouble() * 4.4 + 1.4;
                sw.WriteLine(d);
            }
            sw.Close();
        }
        static void LueTiedostosta(ref double[]taulu)
        {
            StreamReader sr = new StreamReader("c:\\Windows\\Temp\\datat.txt");

            while (sr.EndOfStream == false)
            {
                for (int i = 0; i < taulu.Length; i++) //tässä tapahtuu jotain jännää tuon lukemisen lopussa?
                {
                    double arvo = double.Parse(sr.ReadLine());
                    taulu[i] = arvo;
                }
                
            }
            sr.Close();
        }
        static void TulostaTiedot(double [] taulu)
        {
            Console.WriteLine("SUMMA: {0}, KESKIARVO: {1}, MINIMI: {2}, MAKSIMI: {3}", 
                               taulu.Sum(), taulu.Average(), taulu.Min(), taulu.Max());
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
