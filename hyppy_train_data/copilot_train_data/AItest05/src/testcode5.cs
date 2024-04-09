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
        Console.WriteLine("Anna hypyn pituus (liukuluku 0.5 metrin välein): ");
        hypynPituus = Convert.ToDouble(Console.ReadLine());
    }

    static void KysyTuomareidenPisteet()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Anna tuomarin {i+1} tyylipisteet (0-20 välillä 0.5 välein): ");
            tuomareidenPisteet[i] = Convert.ToDouble(Console.ReadLine());
        }
    }

    static void LaskeHypynPisteet()
    {
        Array.Sort(tuomareidenPisteet);
        double pisteet = (hypynPituus - kriittinenPiste) * 1.8 + tuomareidenPisteet[1] + tuomareidenPisteet[2] + tuomareidenPisteet[3] + 60;
        hypynPituus = pisteet;
    }

    static void Tulosta()
    {
        Console.WriteLine($"Hypyn pituus: {hypynPituus} metriä");
        Console.WriteLine($"Hypyn pisteet: {hypynPituus} pistettä");
    }
}
