using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
KT3
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet. 

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein)
sekä viiden arvostelutuomarin tyylipisteet (0-20 välillä 0.5 välein eli esim. 16.5 tai 17.0 tai 18.5)

Hyppääjän pisteet muodostuvat kaavasta.

pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60. 

Tyylipisteissä siis parhain ja huonoin pistemäärä tipahtaa pois.

Ohjelman hyppyrimäen kriittinen piste on 90 metrin kohdalla.
Laita kriittinen piste vakioon.

Tulosta lopuksi hypyn pituus ja hypyn pisteet

Käytä ohjelmassa funktioita (funktiot eivät saa palauttaa mitään):


KysyHypynPituus
KysyTuomareidenPisteet
LaskeHypynPisteet
Tulosta
*/

namespace Projekti1
{
    class Program
    {
        const double KRIITTINEN = 90;

        static void KysyHypynPituus(out double hypynpituus)
        {
            Console.Write("Syötä hypyn pituus 0,5 metrin tarkkuudella: ");
            hypynpituus = double.Parse(Console.ReadLine());
        }

        static void KysyTuomareidenPisteet(out double tuomaripisteet)
        {
            double[] taulukko = new double[5];
            int i;
            for (i = 0; i <= 4; i++)
            {
                Console.Write("Syötä {0}. tuomarin antamat pisteet (0-20) puolikkaan pisteen tarkkuudella: ", i + 1);
                taulukko[i] = double.Parse(Console.ReadLine());
            }

            tuomaripisteet = taulukko.Sum() - taulukko.Min() - taulukko.Max();

        }

        static void LaskeHypynPisteet(out double hypynpisteet, double hypynpituus, double tuomaripisteet)
        {
           hypynpisteet = (hypynpituus - KRIITTINEN)* 1.8 + tuomaripisteet + 60;
        }

        static void Tulosta(double hypynpituus, double hypynpisteet)
        {
            Console.WriteLine("Hyppy oli {0}m pitkä ja sen pisteet olivat {1}", hypynpituus, hypynpisteet);
        }


        static void Main()
        {
            double hypynpituus, tuomaripisteet, hypynpisteet;
            KysyHypynPituus(out hypynpituus);
            KysyTuomareidenPisteet(out tuomaripisteet);
            LaskeHypynPisteet(out hypynpisteet, hypynpituus, tuomaripisteet);
            Tulosta(hypynpituus, hypynpisteet);
        }
    }
}

