using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden arvostelutuomarin tyylipisteet (0-20 välillä 0.5 välein eli
esim. 16.5 tai 17.0 tai 18.5)

Hyppääjän pisteet muodostuvat kaavasta.

pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60.

Tyylipisteissä siis parhain ja huonoin pistemäärä tipahtaa pois.

Ohjelman hyppyrimäen kriittinen piste on 90 metrin kohdalla. Laita kriittinen piste 
vakioon.

Tulosta lopuksi hypyn pituus ja hypyn pisteet

Käytä ohjelmassa funktioita (funktiot eivät saa palauttaa mitään):


KysyHypynPituus
KysyTuomareidenPisteet
LaskeHypynPisteet
Tulosta
*/

namespace ETA18KP
{
    class Program
    {
        const int piste = 90;
        static void KysyHypynPituus(out double x)
        {
            Console.Write("Hypyn pituus : ");
            x = double.Parse(Console.ReadLine());
            x = Math.Round(x * 2) / 2; // Tässä lasketaan pyöristetty arvo.
            //Console.WriteLine(x);// Testasin tässä pyöristyksen.
        }
        static void KysyTuomareidenPisteet(double[] taulu)
        {
            int i;
            for (i = 0; i < taulu.Length; i++)
            {
                Console.Write("{0} Tuomarin pisteet : ", i + 1);
                taulu[i] = double.Parse(Console.ReadLine());
                taulu[i] = Math.Round(taulu[i] * 2) / 2; // Tässä lasketaan pyöristetty arvo.
                if (taulu[i]<0 || taulu[i]>20) // Tässä tarkistetaan oikein syöttö
                {
                    i--;
                }
            }
        }
        static void LaskeHypynPisteet(double pituus, int piste, double[] taulu, out double pisteet)
        {
            int i;
            double y = 0;
            Array.Sort(taulu, 0, 5);
            for (i = 1; i < taulu.Length - 1; i++) // Lasketaan Tuomareiden pisteet yhteen. Jätetään huomioimatta isoin ja pienin.
            {
                y = taulu[i] + y;
            }
            pisteet = (pituus - piste) * 1.8 + y + 60;
            //pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60.
        }
        static void Tulosta(double pituus, double pisteet)
        {
            Console.WriteLine("Hypyn pituus : {0}\nHypyn pisteet : {1}", pituus, pisteet);
        }
        static void Main()
        {
            double pituus, pisteet;
            double[] taulu = new double[5];
            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(taulu);
            LaskeHypynPisteet(pituus, piste, taulu, out pisteet);
            Tulosta(pituus, pisteet);
        }
    }
}