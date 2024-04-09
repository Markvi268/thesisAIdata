using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
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
        static void ArvoJaTallennaTiedostoon()
        {
            int i;
            double arvottu;
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("C:\\projekti\\data.txt");
            for(i = 0; i < 40; i++)
            {
                arvottu = rnd.Next(14, 59);
                arvottu = arvottu / 10;
                sw.WriteLine(arvottu);
            }            
         
            sw.Close();
        }
        static void LueTiedostot(double[] t) 
        {
            int i;
            
            StreamReader sr = new StreamReader("C:\\projekti\\data.txt");
            for(i = 0; i < t.Length; i++)
            {
                t[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
            
        }
        static void TulostaTiedot(double[] t)
        {
            Console.WriteLine(t.Sum());
            Console.WriteLine(t.Average());
            Console.WriteLine(t.Min());
            Console.WriteLine(t.Max());

        }
            
    

        static void Main()
        {           
            double[] taulu = new double[40];
            ArvoJaTallennaTiedostoon();
            LueTiedostot(taulu);
            TulostaTiedot(taulu);











        }

    }
}


    

























