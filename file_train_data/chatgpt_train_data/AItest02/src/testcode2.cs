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
    static void Main()
    {
        ArvoJaTallennaTiedostoon();
        double[] luvut = LueTiedostosta();
        TulostaTiedot(luvut);
    }

    static void ArvoJaTallennaTiedostoon()
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double luku = rnd.NextDouble() * (5.8 - 1.4) + 1.4;
                sw.WriteLine(luku);
            }
        }
    }

    static double[] LueTiedostosta()
    {
        double[] luvut = new double[40];
        using (StreamReader sr = new StreamReader("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                string rivi = sr.ReadLine();
                luvut[i] = double.Parse(rivi);
            }
        }
        return luvut;
    }

    static void TulostaTiedot(double[] luvut)
    {
        double summa = 0;
        double minimi = double.MaxValue;
        double maksimi = double.MinValue;

        foreach (double luku in luvut)
        {
            summa += luku;
            if (luku < minimi)
                minimi = luku;
            if (luku > maksimi)
                maksimi = luku;
        }

        double keskiarvo = summa / luvut.Length;

        Console.WriteLine("Summa: " + summa);
        Console.WriteLine("Keskiarvo: " + keskiarvo);
        Console.WriteLine("Minimi: " + minimi);
        Console.WriteLine("Maksimi: " + maksimi);
    }
}
