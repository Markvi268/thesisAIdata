using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/*Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja 
 * kirjoita ne datat.txt tiedostoon allekkain. 
 * Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue 
arvot tiedostosta taulukkoon. Tämän jälkeen tulosta 
taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot



*/
namespace ConsoleApp2
{
    class VK7T15
    {

        static void ArvoJaTallennaTiedostoon()
        {
            int i;
            double luku;
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("D:\\data.txt");

            for (i = 0; i < 40 ; i++)
            {
                luku = rnd.NextDouble()* (5.8-1.4)+1.4;
                sw.WriteLine("{0:f2}", luku);
            }

            sw.Close();
        }

        static void LueTiedostosta(ref double[] taulu)
        {
            int i = 0;

            StreamReader sr = new StreamReader("D:\\data.txt");


            do
            {
                taulu[i] = double.Parse(sr.ReadLine());
                i++;
            }
            while (sr.EndOfStream == false);

                sr.Close();

        }

        static void TulostaTiedot(double[] taulu)

        {
            double ka, sum, min, max;

            sum = taulu.Sum();
            ka = sum / taulu.Length;

            max = taulu.Max();
            min = taulu.Min();



            Console.WriteLine("Lukuje summa on {0:f2}", sum);
            Console.WriteLine("Lukujen keskiarvo on {0:f2}",ka);
            Console.WriteLine("Suurin luku on {0:f2}", max);
            Console.WriteLine("Pienin luku on {0:f2} ", min);
        }







        static void Main(string[] args)
        {
            double[] taulu = new double[40];

            ArvoJaTallennaTiedostoon();
            LueTiedostosta(ref taulu);
            TulostaTiedot(taulu);



        }
    }
}
