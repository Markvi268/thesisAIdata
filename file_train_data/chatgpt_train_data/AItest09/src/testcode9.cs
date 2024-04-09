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
        // Arvo ja tallenna tiedostoon
        ArvoJaTallennaTiedostoon("datat.txt", 40, 1.4, 5.8);

        // Luo taulukko ja lue arvot tiedostosta
        double[] taulukko = LueTiedostosta("datat.txt");

        // Tulosta taulukon tiedot
        TulostaTiedot(taulukko);
    }

    static void ArvoJaTallennaTiedostoon(string tiedosto, int lukumaara, double alaraja, double ylaraja)
    {
        Random random = new Random();
        using (StreamWriter sw = new StreamWriter(tiedosto))
        {
            for (int i = 0; i < lukumaara; i++)
            {
                double luku = alaraja + (ylaraja - alaraja) * random.NextDouble();
                sw.WriteLine(luku);
            }
        }
    }

    static double[] LueTiedostosta(string tiedosto)
    {
        string[] rivit = File.ReadAllLines(tiedosto);
        double[] taulukko = new double[rivit.Length];
        for (int i = 0; i < rivit.Length; i++)
        {
            taulukko[i] = double.Parse(rivit[i]);
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

        Console.WriteLine($"Summa: {summa}");
        Console.WriteLine($"Keskiarvo: {keskiarvo}");
        Console.WriteLine($"Minimi: {minimi}");
        Console.WriteLine($"Maksimi: {maksimi}");
    }
}
