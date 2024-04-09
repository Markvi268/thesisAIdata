using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT3
{
    class Program
    {
        /*
         * KT3
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

        static void KysyHypynPituus(out double hypynpituus) {

            bool onnistui;
            double syote, varmistus;
            do
            {
              
                Console.WriteLine("Anna hypyn pituus: (0,5 tarkkuudella) ");
                onnistui = double.TryParse(Console.ReadLine(), out syote);
                varmistus = Math.Round(syote * 2) / 2;

                if (!onnistui) Console.WriteLine("Älä syötä puppua!");
                if (syote != varmistus) Console.WriteLine("Syötä 0,5 välein"); 


            } while (!(onnistui && syote == varmistus));

            hypynpituus = syote;

        }

        static void KysyTuomarienPisteet(out double[] tuomarienPisteet) {


            tuomarienPisteet = new double[5];

            for (int i = 0; i < tuomarienPisteet.Length; i++) {

                bool onnistui;
                double syote, varmistus;

                do
                {
                    Console.WriteLine("Anna {0} tuomarien pisteet", i + 1);
                    onnistui = double.TryParse(Console.ReadLine(), out syote);
                    varmistus = Math.Round(syote * 2) / 2;

                    if (!onnistui)
                        Console.WriteLine("Älä syötä kukkua!");
                    if (syote != varmistus) Console.WriteLine("Syötä 0,5 tarkkuudella");
                    if (syote < 0 || syote > 20) Console.WriteLine("Syötä 0-20 välillä");

                } while (!(onnistui && syote >= 0 && syote <= 20 && varmistus == syote));

                tuomarienPisteet[i] = Math.Round(syote * 2) / 2;

            }

        }

        static void LaskeHypynPisteet(double hypynPituus, double[] tuomarienpisteet, out double hypynPisteet, double kriittinenPiste) {

            Array.Sort(tuomarienpisteet);

            //pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60.
            hypynPisteet = (hypynPituus - kriittinenPiste) * 1.8 + tuomarienpisteet[1] + tuomarienpisteet[2] + tuomarienpisteet[3] + 60; 


        }

        static void Tulosta(double hypynPituus, double hypynPisteet) {

            Console.WriteLine("Hypyn pituus: {0}", hypynPituus);
            Console.WriteLine("Hypyn pisteet: {0}", hypynPisteet);

        } 

        const double KRIITTINENPISTE = 90;

        static void Main(string[] args)
        {
            
            double hypynPituus;
            double hypynPisteet;
            double[] tuomarienPisteet;
            KysyHypynPituus(out hypynPituus);
            KysyTuomarienPisteet(out tuomarienPisteet);
            LaskeHypynPisteet(hypynPituus, tuomarienPisteet, out hypynPisteet, KRIITTINENPISTE);
            Console.Clear();
            Tulosta(hypynPituus, hypynPisteet);
            
            

        }
}
}
