using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*

KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
 */

namespace ConsoleApp1
{
    class Program
    {
        static void ArvoJaTallenna()
        { 
            Random rnd = new Random();
        StreamWriter sw = new StreamWriter("c:\\temp\\datat.txt");

        double num;
        
            for (int i = 0;i <= 40;i++)
            {
                num = rnd.Next(14, 59) / 10.0;
                sw.WriteLine(num);
            }
            sw.Close();
        }
        static void LueTiedostosta(double[] taulu )
        {
            double num;
            StreamReader sr = new StreamReader("c:\\temp\\datat.txt");
            for (int i = 0; i < taulu.Length; i++)
            {
                num = Convert.ToDouble(sr.ReadLine());
                taulu[i] = num;
               
            }
            sr.Close();
        }
        static void TulostaTiedot(double[] taulu)
        {
            double summa = 0;
            for (int i = 0; i < taulu.Length; i++ )
            {
                summa = summa + taulu[i];
            }
            Array.Sort(taulu);
            Console.WriteLine("Lukujen suma on {0}, keskiarvo: {1:F2}, minimiarvo {2} ja maksimiarvo {3}", summa, (summa / 40), taulu[0], taulu[39]);
        }
        static void Main()
        {
            
            ArvoJaTallenna();
            double[] taulu = new double[40];
            LueTiedostosta(taulu);
            TulostaTiedot(taulu);
           
           


        }
    }
}
