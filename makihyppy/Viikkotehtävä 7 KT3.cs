using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Syvennykset: ctrl A, ctrl k, ctrl f
/*      
KT3
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



namespace Ohjelmointi_1_Projekti
{
    class Program
    {
        static void KysyHypynPituus( double[,] taulukko)
        {
            int i;
            double hypyn_pituus;
            bool tosi = false;

            //Kysytään hypyn pituus ja jankataan kunnes oikea double
            do
            {
                Console.Write("syötä Hypyn pituus 0.5m tarkkuudella (esim: 160.5m tai 170.0m) : ");
                tosi = double.TryParse(Console.ReadLine(), out hypyn_pituus);
            }
            while (tosi == false);

            //Pyöristetään vastaus kohti x.0 tai x.5 jos käyttäjä ei syötäkkään ohjeiden mukaisesti
            hypyn_pituus = hypyn_pituus * 2;
            hypyn_pituus = Math.Round(hypyn_pituus, MidpointRounding.AwayFromZero);
            hypyn_pituus = hypyn_pituus / 2;

            //Syötetään hypyn pituus jokaiseen sarakkeeseen taulukon ekalle riville:
            for ( i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
                taulukko[0, i] = hypyn_pituus;
            }


        }
        static void KysyTuomareidenPisteet(double [,] taulukko)
        {
            int i;

            bool tosi = false;

            //Täytetään arrayta
            for (i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
                //Tarkastetaan että vastaus on 0-20
                do
                {
                    //Estetään kaatuminen jos syöttää jotain muuta kuin luvun
                    do
                    {
                        Console.Write("Syötä {0}:en tuomarin pisteet 0-20 : ", i + 1);
                        tosi = double.TryParse(Console.ReadLine(), out taulukko[1,i]);
                    }
                    while (tosi == false);
                } while (taulukko[1,i] < 0 || taulukko[1,i] > 20);
            }
        }
        static void LaskeHypynPisteet(double [,] taulukko)
        {

            const double KRIITTINEN_PISTE = 90;
            int i;
            double pisteet, kolmen_keskimmaisen_tuomarin_pisteet = 0, max, min;

            //Selvitetään maksimi ja minimi
            max = taulukko[1, 0];
            min = taulukko[1, 0];

            for (i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
              if ( taulukko[1,i] > max )
                {
                    max = taulukko[1, i];
                }
              else if ( taulukko[1,i] < min)
                {
                    min = taulukko[1, i];
                }
            }

            //Muutetaan makimiin ja minimiin 0
            for (i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
                if (taulukko[1, i] == max || taulukko[1, i] == min)
                {
                    taulukko[1, i] = 0;
                }
            }

            //Lasketaan "Jäljellä olevien" tuomareiden pisteet yhteen
            for (i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
                kolmen_keskimmaisen_tuomarin_pisteet = kolmen_keskimmaisen_tuomarin_pisteet + taulukko[1, i];
            }

            //Lasketaan pisteet kaavalla   !!pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60. !!
            pisteet = (taulukko[0,1] - KRIITTINEN_PISTE)*1.8 + kolmen_keskimmaisen_tuomarin_pisteet + 60;

            //Syötetään pisteet kolmannelle riville
            for (i = 0; i < taulukko.GetLength(1); i = i + 1)
            {
                taulukko[2, i] = pisteet;
            }


        }

        static void Tulosta(double[,] taulukko)
        {
            //Siistitään konsoli

            Console.Clear();
            //Tulostetaan hyppy
            Console.WriteLine("Hypyn pituus : {0}", taulukko[0, 0]);

            //Tulostetaan pisteet
            Console.WriteLine("Pisteet : {0}", taulukko[2, 0]);
        }

        static void Main(string[] args)
        {
            //KONSOLIN ASETUKSET
            Console.ForegroundColor = ConsoleColor.Green;
            //KONSOLIN ASETUKSET

            double[,] taulukko = new double[3,5];


            KysyHypynPituus(taulukko);
            KysyTuomareidenPisteet(taulukko);
            LaskeHypynPisteet(taulukko);
            Tulosta(taulukko);


            
        }
    }
}
