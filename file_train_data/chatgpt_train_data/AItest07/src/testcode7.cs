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
                double luku = 1.4 + (rand.NextDouble() * (5.8 - 1.4));
                sw.WriteLine(luku);
            }
        }
    }

    static double[] LueTiedostosta()
    {
        double[] taulukko = new double[40];
        using (StreamReader sr = new StreamReader("datat.txt"))
        {
            string line;
            int i = 0;
            while ((line = sr.ReadLine()) != null && i < 40)
            {
                if (double.TryParse(line, out double luku))
                {
                    taulukko[i] = luku;
                    i++;
                }
            }
        }
        return taulukko;
    }

    static void TulostaTiedot(double[] taulukko)
    {
        double summa = 0;
        double minimi = double.MaxValue;
        double maksimi = double.MinValue;

        foreach (double luku in taulukko)
        {
            summa += luku;
            if (luku < minimi)
                minimi = luku;
            if (luku > maksimi)
                maksimi = luku;
        }

        double keskiarvo = summa / taulukko.Length;

        Console.WriteLine("Taulukon lukujen summa: " + summa);
        Console.WriteLine("Taulukon lukujen keskiarvo: " + keskiarvo);
        Console.WriteLine("Taulukon minimiarvo: " + minimi);
        Console.WriteLine("Taulukon maksimiarvo: " + maksimi);
    }
}
