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
        // Arvo ja tallenna tiedostoon
        ArvoJaTallennaTiedostoon();

        // Luo taulukko ja lue arvot tiedostosta
        double[] luvut = LueTiedostosta();

        // Tulosta tiedot
        TulostaTiedot(luvut);
    }

    static void ArvoJaTallennaTiedostoon()
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double luku = 1.4 + (rnd.NextDouble() * (5.8 - 1.4));
                sw.WriteLine(luku);
            }
        }
    }

    static double[] LueTiedostosta()
    {
        double[] luvut = new double[40];
        using (StreamReader sr = new StreamReader("datat.txt"))
        {
            string line;
            int i = 0;
            while ((line = sr.ReadLine()) != null && i < 40)
            {
                luvut[i] = double.Parse(line);
                i++;
            }
        }
        return luvut;
    }

    static void TulostaTiedot(double[] luvut)
    {
        double summa = 0;
        double min = double.MaxValue;
        double max = double.MinValue;

        foreach (double luku in luvut)
        {
            summa += luku;
            if (luku < min)
                min = luku;
            if (luku > max)
                max = luku;
        }

        double keskiarvo = summa / luvut.Length;

        Console.WriteLine("Summa: " + summa);
        Console.WriteLine("Keskiarvo: " + keskiarvo);
        Console.WriteLine("Minimiarvo: " + min);
        Console.WriteLine("Maksimiarvo: " + max);
    }
}

