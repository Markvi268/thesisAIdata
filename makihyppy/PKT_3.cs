using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
KT3
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden arvostelutuomarin 
tyylipisteet (0-20 välillä 0.5 välein eli esim. 16.5 tai 17.0 tai 18.5)

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
namespace Palautettava_3
{
    class Program
    {
        static void KysyHypynPituus(out float pituus)
        {
            float hyppy;
            do
            {
                Console.Write("Anna hypyn pituus (0,5 m välein) : ");
                hyppy = float.Parse(Console.ReadLine());
            } while (hyppy < 0 || hyppy > 250);

            hyppy = (int)(hyppy * 2);
            pituus = hyppy / 2;
        }
        static void KysyTuomareidenPisteet(float[] taulu)
        {
            float luku, luku2;
            int i;
            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("Anna {0}. tuomarin pisteet (0-20, 0,5 pisteen välein) : ", i + 1);
                luku2 = float.Parse(Console.ReadLine());
                luku2 = (int)(luku2 * 2);
                luku = luku2 / 2;
                if (luku < 0 || luku > 20)
                {
                    i--;
                }
                else
                    taulu[i] = luku;
            }

            Array.Sort(taulu);
            
        }
        static void LaskeHypynPisteet(float[] taulu, int KRIITTINEN_PISTE, float pituus, out float pisteet)
        {
            float lasku1, kertolasku, TuomarienPisteet;
            //(hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60.
            lasku1 = pituus - KRIITTINEN_PISTE;
            kertolasku = lasku1 * 1.8f;
            TuomarienPisteet = taulu[1] + taulu[2] + taulu[3];
            pisteet = kertolasku + TuomarienPisteet + 60;
        }
        static void Tulosta(float pituus, float pisteet, float[] taulu)
        {
            Console.WriteLine("Hypyn pituus oli : {0}", pituus);
            Console.WriteLine("Hypyn pisteet : {0}", pisteet);
        }
        static void Main(string[] args)
        {
            float[] taulu = new float[5];
            float pituus, pisteet;
            const int KRIITTINEN_PISTE = 90;
            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(taulu);
            LaskeHypynPisteet(taulu, KRIITTINEN_PISTE, pituus, out pisteet);
            Tulosta(pituus, pisteet, taulu);
        }
    }
}
