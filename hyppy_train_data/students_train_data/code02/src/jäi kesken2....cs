using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
KT3
Tee ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.
Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden 
arvostelutuomarin tyylipisteet (0-20 välillä 0.5 välein eli esim. 16.5 tai 17.0 tai 18.5)
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

namespace ETA18KP
{
    class Program
    {
        const int KRIITINENPISTE = 90;
        static void KysyHypynPituus(out double hyppy)
        {
            Console.Write("Hypyn pituus? : ");
            hyppy = double.Parse(Console.ReadLine());
            hyppy = Math.Round(0.5);
        }
        static void KysyTuomareidenPisteet(out double pisteet)
        {
            int i;

            for (i = 0; i < 6; i++)
            {
                Console.WriteLine("Tuomarin {0} pisteet: ", i++);
                pisteet = double.Parse(Console.ReadLine());
            }
            
            
        }
        static void LaskeHypynPisteet(out int kokpisteet, double hyppy, int pisteet)
        {
            kokpisteet = (hyppy - KRIITINENPISTE) * 1.8 + kolmen keskimmäisen tuomarin
            tyylipisteet + 60;
        }
        static void Tulosta()
        {

        }
        static void Main()
        {
            double hyppy, pisteet;

            KysyHypynPituus(out hyppy);
            KysyTuomareidenPisteet(out pisteet);

        }
    }
}

