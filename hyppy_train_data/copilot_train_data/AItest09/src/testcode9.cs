/*
Luo C# ohjelma, joka laskee mäkihyppääjän yhden kierroksen suorituspisteet.

Ohjelma kysyy hypyn pituuden (liukuluku 0.5 metrin välein) sekä viiden arvostelutuomarin tyylipisteet (0-20 välillä 0.5 välein eli
esim. 16.5 tai 17.0 tai 18.5)

Hyppääjän pisteet muodostuvat kaavasta.

pisteet = (hypyn pituus - kriittinen piste)*1,8 + kolmen keskimmäisen tuomarin tyylipisteet + 60.

Tyylipisteissä siis parhain ja huonoin pistemäärä tipahtaa pois.

Ohjelman hyppyrimäen kriittinen piste on 90 metrin kohdalla. Laita kriittinen piste 
vakioon.

Tulosta lopuksi hypyn pituus ja hypyn pisteet

Käytä ohjelmassa funktioita (funktiot ei saa palauttaa mitään):


KysyHypynPituus
KysyTuomareidenPisteet
LaskeHypynPisteet
Tulosta
*/

// Kysytty 9.4.2024 'tarkempi' kysely

using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        double hypynPituus = KysyHypynPituus();
        double[] tuomareidenPisteet = KysyTuomareidenPisteet();
        double pisteet = LaskeHypynPisteet(hypynPituus, tuomareidenPisteet);
        Tulosta(hypynPituus, pisteet);
    }

    static double KysyHypynPituus()
    {
        Console.Write("Anna hypyn pituus: ");
        return double.Parse(Console.ReadLine());
    }

    static double[] KysyTuomareidenPisteet()
    {
        double[] pisteet = new double[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Anna tuomarin {i+1} pisteet: ");
            pisteet[i] = double.Parse(Console.ReadLine());
        }
        return pisteet;
    }

    static double LaskeHypynPisteet(double hypynPituus, double[] tuomareidenPisteet)
    {
        const double kriittinenPiste = 90;
        Array.Sort(tuomareidenPisteet);
        double keskiarvo = (tuomareidenPisteet[1] + tuomareidenPisteet[2] + tuomareidenPisteet[3]) / 3;
        return (hypynPituus - kriittinenPiste) * 1.8 + keskiarvo + 60;
    }

    static void Tulosta(double hypynPituus, double pisteet)
    {
        Console.WriteLine($"Hypyn pituus: {hypynPituus} metriä");
        Console.WriteLine($"Hypyn pisteet: {pisteet}");
    }
}
