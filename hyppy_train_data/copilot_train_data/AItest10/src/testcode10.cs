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
    static double hypynPituus;
    static double[] tuomareidenPisteet = new double[5];
    const double kriittinenPiste = 90;

    static void Main(string[] args)
    {
        KysyHypynPituus();
        KysyTuomareidenPisteet();
        LaskeHypynPisteet();
        Tulosta();
    }

    static void KysyHypynPituus()
    {
        Console.Write("Anna hypyn pituus: ");
        hypynPituus = double.Parse(Console.ReadLine());
    }

    static void KysyTuomareidenPisteet()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Anna tuomarin {i + 1} pisteet: ");
            tuomareidenPisteet[i] = double.Parse(Console.ReadLine());
        }
    }

    static void LaskeHypynPisteet()
    {
        Array.Sort(tuomareidenPisteet);
        double tyylipisteet = tuomareidenPisteet[1] + tuomareidenPisteet[2] + tuomareidenPisteet[3];
        hypynPituus = (hypynPituus - kriittinenPiste) * 1.8 + tyylipisteet + 60;
    }

    static void Tulosta()
    {
        Console.WriteLine($"Hypyn pituus: {hypynPituus}");
        Console.WriteLine($"Hypyn pisteet: {hypynPituus}");
    }
}
