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

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ArvoJaTallennaTiedostoon();
        double[] taulukko = LueTiedostosta();
        TulostaTiedot(taulukko);
    }

    static void ArvoJaTallennaTiedostoon()
    {
        Random rand = new Random();
        using (StreamWriter sw = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double luku = 1.4 + rand.NextDouble() * (5.8 - 1.4);
                sw.WriteLine(luku);
            }
        }
    }

    static double[] LueTiedostosta()
    {
        return File.ReadAllLines("datat.txt").Select(line => double.Parse(line)).ToArray();
    }

    static void TulostaTiedot(double[] taulukko)
    {
        double summa = taulukko.Sum();
        double keskiarvo = summa / taulukko.Length;
        double min = taulukko.Min();
        double max = taulukko.Max();

        Console.WriteLine($"Summa: {summa}");
        Console.WriteLine($"Keskiarvo: {keskiarvo}");
        Console.WriteLine($"Minimiarvo: {min}");
        Console.WriteLine($"Maksimiarvo: {max}");
    }
}
