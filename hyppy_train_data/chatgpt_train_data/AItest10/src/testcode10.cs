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

Käytä ohjelmassa funktioita (funktiot eivät saa palauttaa mitään):


KysyHypynPituus
KysyTuomareidenPisteet
LaskeHypynPisteet
Tulosta
*/

// Kysytty 9.4.2024 korjaus AItest09 'funktiot ei saa palauttaa mitään'

using System;

class Program
{
    static double criticalPoint = 90.0;
    static double pituus;
    static double[] tuomariPisteet = new double[5];
    static double pisteet;

    static void KysyHypynPituus()
    {
        Console.WriteLine("Anna hypyn pituus (metreinä, 0.5 metrin välein): ");
        pituus = double.Parse(Console.ReadLine());
    }

    static void KysyTuomareidenPisteet()
    {
        Console.WriteLine("Anna viiden tuomarin tyylipisteet (0-20 välillä 0.5 välein): ");

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Tuomari {i + 1}: ");
            tuomariPisteet[i] = double.Parse(Console.ReadLine());
        }
    }

    static void LaskeHypynPisteet()
    {
        Array.Sort(tuomariPisteet);
        double sum = 0;

        for (int i = 1; i < 4; i++)
        {
            sum += tuomariPisteet[i];
        }

        pisteet = (pituus - criticalPoint) * 1.8 + sum + 60;
    }

    static void Tulosta()
    {
        Console.WriteLine($"Hypyn pituus: {pituus} m");
        Console.WriteLine($"Hypyn pisteet: {pisteet}");
    }

    static void Main(string[] args)
    {
        KysyHypynPituus();
        KysyTuomareidenPisteet();
        LaskeHypynPisteet();
        Tulosta();
    }
}
