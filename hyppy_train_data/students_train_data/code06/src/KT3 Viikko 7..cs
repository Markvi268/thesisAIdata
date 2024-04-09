using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{/*
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
    class Program
    {
        static void KysyHypynPituus(out double x)
        {
            Console.Write("kuinka pitkä hyppy oli? ");
            x = double.Parse(Console.ReadLine());

        }
        static void KysyTuomareidenPisteet(out double [] t)
        {
            int i;
            t = new double [5];
            
            for (i = 0; i < t.Length; i++)
            {
                Console.Write("Anna {0} tuomarin pisteet :", i +1);
                t[i] = double.Parse(Console.ReadLine());

            }
            Array.Sort(t);
            for (i = 0; i < t.Length; i++)
            {
                if (i == t[0])
                {
                    i++;
                }
                if (i == t[4])
                {
                    i--;
                }
            }
            Console.Write(t);
        }
        
        static void LaskeHypynPisteet(double x, double y, double [] t,  out double a)
        {
            double b, c, d;
            b =t[1];
            c = t[2];
            d = t[3];

            a = (x - y) * 1.8 + 60.0 + b + c + d ;
            
        }
        static void Tulosta(double pituus, double tulos)
        {
            Console.WriteLine("HYPYNPITUUS : {0}", pituus);
            Console.WriteLine("PISTEET : {0}", tulos);
        }

        static void Main(string[] args)
        {
            double kriittinen = 90;
            double hypynpituus;
            double[] tuomaripisteet;
            double pisteet;
            

            KysyHypynPituus(out hypynpituus);

            KysyTuomareidenPisteet(out tuomaripisteet);
            
            LaskeHypynPisteet( hypynpituus,  kriittinen, tuomaripisteet, out pisteet);

            Tulosta(hypynpituus, pisteet);
            


        }


    }
}
