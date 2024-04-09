using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden arvostelutuomarin tyylipisteet 
(0-20 välillä 0.5 välein eli esim. 16.5 tai 17.0 tai 18.5)

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
Tulosta*/

namespace Kolmas
{   //tässä osittainen ratkaisu tehtävään, ei toimi kaikkien funktioiden osalta
    class Program
    {
        static void KysyHypynPituus(out double hyppy)
        {
            Console.WriteLine("Anna hypyn pituus (0,5 m tarkkuudella): ");
            hyppy = float.Parse(Console.ReadLine());

        }
        static void KysyTuomareidenPisteet(double hyppy, int Kpiste) 
        {
             // ei oteta huomioon 0.5 pisteen asteikkoa
             // arvotaan vain pisteet tuomareille

            int tuomareita = 5;
            double[] pisteet = new double[tuomareita];
            Random rnd = new Random();

            for (int i=0; i< pisteet.Length; i++)
            {
                if(hyppy<= Kpiste)
                {
                    pisteet[i] = rnd.Next(0, 10) + 5; // saa enintään 15 pistettä
                }
                else if (hyppy> Kpiste)
                {
                    pisteet[i] = rnd.Next(7,10) + 10; //saa vähintään 17 pistettä
                }
            }
        }
        static void LaskeHypynPisteet(double [] pisteet, out double summa)
        {
            double max = pisteet.Min();
            double min = pisteet.Max();

            summa= pisteet.Sum()-max-min;
        }
        static void Tulosta(ref double hyppy, ref double summa)
        {
            Console.WriteLine("Hypyn pituus oli: {0}", hyppy);
            Console.WriteLine("Tyylipisteet olivat: {0}", summa);
        }

        static void Main(string[] args)
        {
            double hyppy;
            const int Kpiste = 90;
            double summa = 0;
            double [] pisteet = {};

            KysyHypynPituus(out hyppy);
            KysyTuomareidenPisteet(hyppy, Kpiste);
            LaskeHypynPisteet(pisteet, out summa);
            Tulosta(ref hyppy, ref summa);
        }
    }
}
