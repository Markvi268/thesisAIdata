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
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double luku = 1.4 + random.NextDouble() * (5.8 - 1.4);
                writer.WriteLine(luku.ToString("0.00"));
            }
        }
    }

    static double[] LueTiedostosta()
    {
        double[] taulukko = new double[40];
        using (StreamReader reader = new StreamReader("datat.txt"))
        {
            string line;
            int i = 0;
            while ((line = reader.ReadLine()) != null && i < 40)
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
        double minimi = taulukko[0];
        double maksimi = taulukko[0];

        foreach (double luku in taulukko)
        {
            summa += luku;
            if (luku < minimi)
                minimi = luku;
            if (luku > maksimi)
                maksimi = luku;
        }

        double keskiarvo = summa / taulukko.Length;

        Console.WriteLine("Summa: " + summa.ToString("0.00"));
        Console.WriteLine("Keskiarvo: " + keskiarvo.ToString("0.00"));
        Console.WriteLine("Minimiarvo: " + minimi.ToString("0.00"));
        Console.WriteLine("Maksimiarvo: " + maksimi.ToString("0.00"));
    }
}
