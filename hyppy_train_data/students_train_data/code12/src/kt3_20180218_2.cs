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

namespace Tehtavat
{
    class Program
    {
        const int kriittinenPiste = 90;
        static void Main(string[] args)
        {
            kysyPisteet();
        }

        private static void kysyPisteet()
        {
            double[] pstTaulu = new double[5];
            Console.WriteLine("Anna hypyn pituus: ");
            double pituus = double.Parse(Console.ReadLine());

            for (int i = 0; i < pstTaulu.Length; i++)
            {
                Console.WriteLine("Anna hypyn pisteet: ");
                double num = double.Parse(Console.ReadLine());
                pstTaulu[i] = num;
            }

            laskePisteet(pstTaulu, pituus);
        }

        private static void laskePisteet(double[] pstTaulu, double pituus)
        {
            // järjestetään taulukko
            for (int i = 0; i < pstTaulu.Length; i++)
            {
                for (int j = i + 1; j < pstTaulu.Length; j++)
                {
                    if (pstTaulu[i] > pstTaulu[j])
                    {
                        pstTaulu[i] = pstTaulu[i] + pstTaulu[j];
                        pstTaulu[j] = pstTaulu[i] - pstTaulu[j];
                        pstTaulu[i] = pstTaulu[i] - pstTaulu[j];
                    }
                }
            }
            double pisteSumma = 0;
            pisteSumma = pstTaulu[1] + pstTaulu[2] + pstTaulu[3];
            //Lasketaan hypyn pinnat

            double pisteet = (pituus - kriittinenPiste) * 1.8 + pisteSumma + 60;
            Console.WriteLine("Hypyn pituus oli: {0} ja sen pisteet: {1}", pituus, pisteet);
        }

    }
}
// Tehty kaverin kanssa.