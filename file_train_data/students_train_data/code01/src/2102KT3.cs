using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

/*KT3
Luo C# ohjelma joka tekee seuraavaa:

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. 
Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
*/
namespace ConsoleApp1
{
    class Program
    {
        public static void ArvoJaTallennaTiedostoon()
        {
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("d:\\Koulu\\datat.txt");
            for (int i = 0; i < 40; i++)
            {
                sw.WriteLine(rnd.NextDouble() * 4.4 + 1.4);
            }
            sw.Close();
        }
        public static void LueTiedostosta(double[] t)
        {
            StreamReader sr = new StreamReader("d:\\Koulu\\datat.txt");
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
        }
        public static void TulostaTiedot(double[] t)
        {

            Console.WriteLine("summa : {0}",t.Sum());
            Console.WriteLine("keskiarvo : {0}", t.Average());
            Console.WriteLine("minimi : {0}", t.Min());
            Console.WriteLine("maksimi : {0}", t.Max());

        }
        public static void Main()
        {
            double[] taulu = new double[40];
            ArvoJaTallennaTiedostoon();
            LueTiedostosta(taulu);
            TulostaTiedot(taulu);
        }
    }
}