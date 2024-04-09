using System;
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
class Program
{
    static void Main()
    {
        // Arvo ja tallenna tiedostoon
        ArvoJaTallennaTiedostoon();

        // Luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon
        double[] data = new double[40];
        LueTiedostosta(data);

        // Tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo
        TulostaTiedot(data);
    }

    static void ArvoJaTallennaTiedostoon()
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double luku = rnd.NextDouble() * (5.8 - 1.4) + 1.4;
                sw.WriteLine(luku.ToString());
            }
        }
    }

    static void LueTiedostosta(double[] data)
    {
        using (StreamReader sr = new StreamReader("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                string rivi = sr.ReadLine();
                data[i] = double.Parse(rivi);
            }
        }
    }

    static void TulostaTiedot(double[] data)
    {
        double summa = 0;
        double minimi = double.MaxValue;
        double maksimi = double.MinValue;

        foreach (double luku in data)
        {
            summa += luku;
            minimi = Math.Min(minimi, luku);
            maksimi = Math.Max(maksimi, luku);
        }

        double keskiarvo = summa / data.Length;

        Console.WriteLine($"Summa: {summa}");
        Console.WriteLine($"Keskiarvo: {keskiarvo}");
        Console.WriteLine($"Minimi: {minimi}");
        Console.WriteLine($"Maksimi: {maksimi}");
    }
}
