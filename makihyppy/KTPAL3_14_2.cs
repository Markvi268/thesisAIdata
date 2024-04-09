using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
namespace ConsoleApp1
{
    class Program
    {
        
        public static void KysyHypynPituus(out double pituus)
        {
            
            Console.Write("Syötä hypyn pituus 0.5metrin tarkkuudella: ");
            pituus = double.Parse(Console.ReadLine());
            

        }
        public static void KysyTuomarienPisteet( double[] pojot)
        {
            
            for (int i = 0; i < pojot.Length; i++)
            {
                
                Console.Write("Anna {0} tuomarin pisteet 0.5 välein, väliltä 0-20:", i + 1);
                pojot[i] = double.Parse(Console.ReadLine());
                
            }

        }
        public static void LaskeHypynPisteet(double[] pojot, double pit,out double pis)
        {
            const double kriit = 90;
            double[] pisteet = new double[3];
            Array.Sort(pojot);
            for (int i = 0; i < pisteet.Length; i++)
            {
                pisteet[i] = pojot[i + 1];
            }
            pis = (((pit - kriit) * 1.8 + (pisteet[0] + pisteet[1] + pisteet[2])+60));
            
        }
        public static void Tulosta(double pis)
            {
            Console.WriteLine("Pisteet : {0} ", pis);
            }

    public static void Main()
        {
            
            double pis;
            double[] pojot = new double[5];

            double pituus;
            KysyHypynPituus(out pituus);
            KysyTuomarienPisteet(pojot);
            

            
            LaskeHypynPisteet( pojot, pituus,out pis);
            
            Tulosta(pis);
        }
    }
}
        
    

    

