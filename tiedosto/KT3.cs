using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

/*
Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. 
Älä käytä taulukkoa tässä vaiheessa. 

Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:
ArvoJaTallennaTiedostoon
LueTiedostosta
TulostaTiedot
 */

namespace ETA18KP

{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rnd = new Random();
            StreamWriter kirjoittaja = new StreamWriter("C:\\Users\\Sanna\\koodit.txt");

            for (int i = 0; i < 40; i++)
            {

                double arvoLuku = rnd.NextDouble() * 4.4 + 1.4;
                kirjoittaja.WriteLine(arvoLuku);

            }
            kirjoittaja.Close();

        }

        static void LueTiedostosta(out double[] luvut)
        {

            luvut = new double[40];
            StreamReader lukija = new StreamReader("C:\\Users\\Sanna\\koodit.txt");
            for (int i = 0; i < luvut.Length; i++)
            {

                luvut[i] = double.Parse(lukija.ReadLine());

            }
            lukija.Close();

        }

        static void TulostaTiedot(double[] taulu)
        {
            double summa = 0;
            double keskiarvo, minimi, maksimi;
            Array.Sort(taulu);

            minimi = taulu[0];
            maksimi = taulu[taulu.Length - 1];

            for (int i = 0; i < taulu.Length; i++)
            {

                summa += taulu[i];

            }

            keskiarvo = summa / taulu.Length;

            Console.WriteLine("Minimi: {0}, Maksimi: {1} Keskiarvo: {2} Summa: {3}", minimi, maksimi, keskiarvo, summa);

        }

        static void Main(string[] args)
        {

            ArvoJaTallennaTiedostoon();
            double[] luvut;
            LueTiedostosta(out luvut);
            TulostaTiedot(luvut);

        }
    }
}

