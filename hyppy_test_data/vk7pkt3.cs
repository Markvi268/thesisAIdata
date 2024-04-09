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

pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin
tyylipisteet + 60.

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
namespace vk7pkt3.cs
{
    class MainClass
    {
        const int KP = 90;

        static void KysyHypynPituus(out double a)
        {
            bool x;
            do
            {
                Console.Write("Anna hypyn pituus 0,5m tarkkuudella: ");
                x = double.TryParse(Console.ReadLine(), out a);
            } while (x == false);
        }

        static void KysyTuomareidenPisteet(double[] t)
        {
            bool x;
            for (int i = 0; i < t.Length; i++)
            {
                do
                {
                    Console.WriteLine("Tuomarin {0} pisteet (0-20) : ", i + 1);
                    x = double.TryParse(Console.ReadLine(),out t[i]);
                } while (x == false);
                        Array.Sort(t);

            }

        }

        static void LaskeHypynPisteet(out double pisteet, double pituus, double []t)
           {
            pisteet = (pituus + KP) * 1.8 + t[1] + t[2] + t[3] + 60;
           }
                                   
        static void Tulosta(double pituus, double pisteet)
        {
                            Console.WriteLine("Hypyn pituus {0} metriä", pituus);
                            Console.WriteLine("Hypyn pisteet {0} ", pisteet);
        }


        public static void Main(string[] args)
        {
            double pituus, pisteet;
            double[] taulu = new double[5];
            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(taulu);
            LaskeHypynPisteet(out pisteet, pituus, taulu);
            Tulosta(pituus, pisteet);
        }
    }
}
