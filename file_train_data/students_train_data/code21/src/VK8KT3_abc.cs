using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        /*
            KT3
            Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. 
            Älä käytä taulukkoa tässä vaiheessa.
            Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
            Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.
            Käytä funktioita:
            ArvoJaTallennaTiedostoon
            LueTiedostosta
            TulostaTiedot

        */
        static void ArvoJaTallennaTiedostoon()
        {
            int i;
            StreamWriter sw = new StreamWriter("c:\\datat.txt");
            double luku;
            Random satun = new Random();

            for (i = 0; i < 40; i++)
            {
                luku = satun.NextDouble() * 1.4 + 4.4;
                
                sw.WriteLine(luku);

                sw.Close();
            }
            
        }

        static void LueTiedostosta()
        {

        }

        static void TulostaTiedot()
        {

        }

        static void Main(string[] args)
        {
            ArvoJaTallennaTiedostoon();
        }
    }
}
