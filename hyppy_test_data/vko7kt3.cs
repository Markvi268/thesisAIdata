using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 KT3
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein)
sekä viiden arvostelutuomarin tyylipisteet
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
Tulosta
*/

namespace Kouluprojekti
{
    class Program
    {
        const int KPISTE = 90;
        static void KysyHypynPituus(out double pituus)
        {
            Console.Write("Anna hypyn pituus: ");
            pituus = double.Parse(Console.ReadLine());
            pituus = (pituus % 0.5 == 0 ? pituus : Math.Round(pituus));

        }
        static void KysyTuomareidenPisteet(out double[] taulu)
        {
            taulu = new double[5];
            int i;
            for (i = 0; i < taulu.Length; i++)
            {
                Console.Write("{0} tuomarin pisteet: ", i + 1);
                taulu[i] = double.Parse(Console.ReadLine());
                if (taulu[i] > 20)
                {
                    taulu[i] = 20;
                }
                taulu[i] = (taulu[i] % 0.5 == 0 ? taulu[i] : Math.Round(taulu[i]));
            }
            


        }
        static void LaskeHypynPisteet(ref double pituus, ref double[] taulu, out double pisteet)
        {
            Array.Sort(taulu);
            pisteet = ((pituus - KPISTE) * 1.8) + (taulu[1] + taulu[2] + taulu[3] + 60);


        }
        static void Tulosta(ref double pisteet)
        {
            Console.WriteLine("Hypyn pisteet: {0:f1}", pisteet);

        }
        static void Main(string[] args)
        {
            double pituus;
            double[] taulu;
            double pisteet;
            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(out taulu);
            LaskeHypynPisteet(ref pituus, ref taulu, out pisteet);
            Tulosta(ref pisteet);
            
        }
    }
}
