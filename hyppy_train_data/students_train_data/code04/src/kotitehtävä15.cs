using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden arvostelutuomarin tyylipisteet (0-20 välillä 0.5 välein eli esim. 16.5 tai 17.0 tai 18.5)

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


namespace Projekti
{
    class Program
    {
        const int KRIITTINENPISTE = 90;


        static void KysyHypynPituus(out double HypynPituus)
        {
            Console.WriteLine("Kuinka pitkälle hyppääjä hyppäsi?");
            HypynPituus = Double.Parse(Console.ReadLine());
            HypynPituus = Math.Round(HypynPituus * 2) / 2;
        }
        static void KysyTuomareidenPisteet(double[] TuoPisteet, ref double Min, ref double Max, out double TuomarienPisteet)
        {
            for(int i = 0;i < TuoPisteet.Length; i++)
            {
                Console.WriteLine("Paljon {0}. tuomari antoi pisteitä? (0-20)",i + 1);
                TuoPisteet[i] = double.Parse(Console.ReadLine());
                TuoPisteet[i] = Math.Round(TuoPisteet[i] * 2) / 2;
                if(TuoPisteet[i] < 0 || TuoPisteet[i] > 20)
                {
                    Console.WriteLine("Luku ei täyttänyt kriteerejä.");
                    i--;
                }
            }

            for(int i = 0; i < TuoPisteet.Length; i++)
            {
                if(Max < TuoPisteet[i])
                {
                    Max = TuoPisteet[i];
                }
                else if (Min > TuoPisteet[i])
                {
                    Min = TuoPisteet[i];
                }
            }
            Array.Sort(TuoPisteet);
            TuoPisteet[0] = 0;
            TuoPisteet[TuoPisteet.Length - 1] = 0;
            TuomarienPisteet = TuoPisteet.Sum();
        }
        static void LaskeHypynPisteet(double HypynPituus, double TuomarienPisteet, out double Pisteet, double Min, double Max)
        {
            Pisteet = (HypynPituus - KRIITTINENPISTE)*1.8 + TuomarienPisteet + 60;
        }
        static void Tulosta(double HypynPituus, double Pisteet)
        {
            Console.WriteLine("Mäkihyppääjä hyppäsi {0}m.", HypynPituus);
            Console.WriteLine("Mäkihyppääjä sai {0} pistettä.", Pisteet);
        }
        static void Main()
        {
            double HypynPituus,Pisteet,Max = -200,Min = 200,TuomarienPisteet;
            double[] TuoPisteet = new double[5];


            KysyHypynPituus(out HypynPituus);
            KysyTuomareidenPisteet(TuoPisteet, ref Min, ref Max,out TuomarienPisteet);
            LaskeHypynPisteet(HypynPituus, TuomarienPisteet, out Pisteet, Min, Max);
            Tulosta(HypynPituus, Pisteet);
        }

    }
}
