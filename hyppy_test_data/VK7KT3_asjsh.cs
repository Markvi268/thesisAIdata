using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekoilua
{
    class Program
    {
        /* 
          VK7KT2 ETA18KP Janne Kankkunen
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
        const double KPiste = 90;

        static void KysyHypynPituus()
        {
            double pituus;
            Console.Write("Hypyn pituus: ");
            pituus = double.Parse(Console.ReadLine());

        }

        static void KysyTuomareidenPisteet()
        {
            int i;
            double[] TPisteet = new double[5];
            for (i = 0; i < 5; i++)
            {
                Console.Write("{0}.n tuomarin pisteet: ", i+1);
                TPisteet[i] = double.Parse(Console.ReadLine());
                
            }
            Array.Sort(TPisteet);
            

        }

        static void LaskeHypynPisteet()
        {
            double HPisteet;
            HPisteet = pituus - KPiste + KysyTuomareidenPisteet[1] + KysyTuomareidenPisteet[2] + KysyTuomareidenPisteet[3] + 60;
            
        }

        static void Tulosta()
        {
            Console.WriteLine("Hypyn pisteet on {0}", HPisteet);

        }

        static void Main(string[] args)
        {
            KysyHypynPituus();
            KysyTuomareidenPisteet();
            LaskeHypynPisteet();
            Tulosta();
        }   
    }

}







        

    

