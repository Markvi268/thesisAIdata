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

// Kysytty 9.4.2024 korjaus AItest01 'funktiot ei saa palauttaa mitään'

using System;

class Program
{
    static double kriittinenPiste = 90.0;

    static void Main(string[] args)
    {
        double hypynPituus = KysyHypynPituus();
        double[] tuomariPisteet = KysyTuomareidenPisteet();
        LaskeHypynPisteet(hypynPituus, tuomariPisteet);
    }

    static void KysyHypynPituus()
    {
        Console.WriteLine("Syötä hypyn pituus (metreinä, 0.5 metrin välein): ");
        double hypynPituus = double.Parse(Console.ReadLine());
        KysyTuomareidenPisteet(hypynPituus);
    }

    static void KysyTuomareidenPisteet(double hypynPituus)
    {
        double[] tuomariPisteet = new double[5];

        Console.WriteLine("Syötä viiden tuomarin antamat pisteet (0-20, 0.5 välein): ");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Tuomari {i + 1}: ");
            tuomariPisteet[i] = double.Parse(Console.ReadLine());
        }

        Array.Sort(tuomariPisteet);
        LaskeHypynPisteet(hypynPituus, tuomariPisteet);
    }

    static void LaskeHypynPisteet(double hypynPituus, double[] tuomariPisteet)
    {
        double sum = 0;
        for (int i = 1; i < 4; i++) // Otetaan kolmen keskimmäisen tuomarin pisteet
        {
            sum += tuomariPisteet[i];
        }

        double pisteet = (hypynPituus - kriittinenPiste) * 1.8 + sum + 60;
        Tulosta(hypynPituus, pisteet);
    }

    static void Tulosta(double hypynPituus, double hypynPisteet)
    {
        Console.WriteLine($"Hypyn pituus: {hypynPituus} m");
        Console.WriteLine($"Hypyn pisteet: {hypynPisteet:F1}");
    }
}

