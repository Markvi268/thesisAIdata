using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
/*
KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot 
*/
namespace KT_3
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            float x;
            Random randomi = new Random();

            StreamWriter sw = new StreamWriter("c:\\datat.txt");

            for (int i = 0; i < 40; i++)
            {
                x = randomi.Next(14, 59) / 10;
                sw.WriteLine(x);
            }
            sw.Close();
        }
        static void LueTiedostosta(ref double summa, out double pienin, out double suurin)
        {
            double[] taulu = new double[40];
            StreamReader sr = new StreamReader("c:\\datat.txt");

            for (int i = 0; i < taulu.Length; i++)
            {
                taulu[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();

            for (int i = 0; i < taulu.Length; i++)
            {
                summa = summa + taulu[i];
            }
            Array.Sort(taulu);
            pienin = taulu[0];
            suurin = taulu[39];
        }
        static void TulostaTiedot(double summa, double pienin, double suurin)
        {

            Console.WriteLine("Lukujen summa : {0}", summa);

            Console.WriteLine("Lukujen keskiarvo : {0}", summa / 40);

            Console.WriteLine("Pienin luku : {0}", pienin);

            Console.WriteLine("Suurin luku : {0}", suurin);
        }
        static void Main()
        {
            double summa = 0, pienin, suurin;

            ArvoJaTallennaTiedostoon();

            LueTiedostosta(ref summa, out pienin, out suurin);

            TulostaTiedot(summa, pienin, suurin);
        }
    }
}
