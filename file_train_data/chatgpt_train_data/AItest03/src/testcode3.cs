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
        // Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja tallenna ne tiedostoon
        ArvoJaTallennaTiedostoon("datat.txt", 40, 1.4, 5.8);

        // Luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon
        double[] data = LueTiedostosta("datat.txt");

        // Tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo
        TulostaTiedot(data);
    }

    static void ArvoJaTallennaTiedostoon(string tiedosto, int lkm, double min, double max)
    {
        Random rand = new Random();
        using (StreamWriter sw = new StreamWriter(tiedosto))
        {
            for (int i = 0; i < lkm; i++)
            {
                double arvo = min + (max - min) * rand.NextDouble();
                sw.WriteLine(arvo.ToString("F2"));
            }
        }
    }

    static double[] LueTiedostosta(string tiedosto)
    {
        double[] data = new double[40];
        using (StreamReader sr = new StreamReader(tiedosto))
        {
            string line;
            int i = 0;
            while ((line = sr.ReadLine()) != null && i < 40)
            {
                if (double.TryParse(line, out double value))
                {
                    data[i] = value;
                    i++;
                }
            }
        }
        return data;
    }

    static void TulostaTiedot(double[] data)
    {
        double summa = 0;
        double minimi = double.MaxValue;
        double maksimi = double.MinValue;

        foreach (double d in data)
        {
            summa += d;
            if (d < minimi)
                minimi = d;
            if (d > maksimi)
                maksimi = d;
        }

        double keskiarvo = summa / data.Length;

        Console.WriteLine($"Summa: {summa:F2}");
        Console.WriteLine($"Keskiarvo: {keskiarvo:F2}");
        Console.WriteLine($"Minimiarvo: {minimi:F2}");
        Console.WriteLine($"Maksimiarvo: {maksimi:F2}");
    }
}
