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

// Kysytty 9.4.2024 

using System;

class MainClass {
    static double kriittinenPiste = 90.0;

    public static void Main (string[] args) {
        double hypynPituus = KysyHypynPituus();
        double[] tuomariPisteet = KysyTuomareidenPisteet();
        double hypynPisteet = LaskeHypynPisteet(hypynPituus, tuomariPisteet);
        Tulosta(hypynPituus, hypynPisteet);
    }

    static double KysyHypynPituus() {
        Console.WriteLine("Anna hypyn pituus (metreinä, 0.5 metrin välein): ");
        double pituus = double.Parse(Console.ReadLine());
        return pituus;
    }

    static double[] KysyTuomareidenPisteet() {
        double[] pisteet = new double[5];
        Console.WriteLine("Anna viiden tuomarin tyylipisteet (0-20 välillä 0.5 välein): ");
        for (int i = 0; i < 5; i++) {
            Console.Write($"Tuomari {i+1}: ");
            pisteet[i] = double.Parse(Console.ReadLine());
        }
        Array.Sort(pisteet);
        return pisteet;
    }

    static double LaskeHypynPisteet(double hypynPituus, double[] tuomariPisteet) {
        double summa = 0.0;
        for (int i = 1; i < 4; i++) {
            summa += tuomariPisteet[i];
        }
        double pisteet = (hypynPituus - kriittinenPiste) * 1.8 + summa + 60;
        return pisteet;
    }

    static void Tulosta(double hypynPituus, double hypynPisteet) {
        Console.WriteLine($"Hypyn pituus: {hypynPituus} m");
        Console.WriteLine($"Hypyn pisteet: {hypynPisteet}");
    }
}

