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
    // Globaali muuttuja kriittiselle pisteelle
    const double kriittinenPiste = 90.0;

    public static void Main (string[] args) {
        double hypynPituus = KysyHypynPituus();
        double[] tuomariPisteet = KysyTuomareidenPisteet();
        double hypynPisteet = LaskeHypynPisteet(hypynPituus, tuomariPisteet);
        Tulosta(hypynPituus, hypynPisteet);
    }

    // Funktio kysyy hypyn pituuden käyttäjältä ja palauttaa sen
    static double KysyHypynPituus() {
        Console.WriteLine("Syötä hypyn pituus (metreinä, 0.5 metrin välein): ");
        double pituus = Convert.ToDouble(Console.ReadLine());
        return pituus;
    }

    // Funktio kysyy tuomareiden pisteet käyttäjältä ja palauttaa ne taulukkona
    static double[] KysyTuomareidenPisteet() {
        double[] pisteet = new double[5];
        for (int i = 0; i < 5; i++) {
            Console.WriteLine($"Syötä tuomari {i + 1} pistemäärä (0-20 välillä, 0.5 välein): ");
            pisteet[i] = Convert.ToDouble(Console.ReadLine());
        }
        return pisteet;
    }

    // Funktio laskee hypyn pisteet annetuilla parametreilla ja palauttaa ne
    static double LaskeHypynPisteet(double pituus, double[] tuomariPisteet) {
        Array.Sort(tuomariPisteet);
        double summa = 0;
        for (int i = 1; i < 4; i++) {
            summa += tuomariPisteet[i];
        }
        double keskiarvo = summa / 3;
        double pisteet = (pituus - kriittinenPiste) * 1.8 + keskiarvo + 60;
        return pisteet;
    }

    // Funktio tulostaa hypyn pituuden ja pisteet
    static void Tulosta(double pituus, double pisteet) {
        Console.WriteLine($"Hypyn pituus: {pituus} metriä");
        Console.WriteLine($"Hypyn pisteet: {pisteet}");
    }
}
