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
        double jumpLength = KysyHypynPituus();
        double[] judgeScores = KysyTuomareidenPisteet();
        double points = LaskeHypynPisteet(jumpLength, judgeScores);
        Tulosta(jumpLength, points);
    }

    static double KysyHypynPituus()
    {
        Console.Write("Anna hypyn pituus: ");
        return double.Parse(Console.ReadLine());
    }

    static double[] KysyTuomareidenPisteet()
    {
        double[] scores = new double[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Anna tuomarin {i + 1} pisteet: ");
            scores[i] = double.Parse(Console.ReadLine());
        }
        return scores;
    }

    static double LaskeHypynPisteet(double jumpLength, double[] judgeScores)
    {
        const double criticalPoint = 90;
        Array.Sort(judgeScores);
        double stylePoints = judgeScores[1] + judgeScores[2] + judgeScores[3];
        return (jumpLength - criticalPoint) * 1.8 + stylePoints + 60;
    }

    static void Tulosta(double jumpLength, double points)
    {
        Console.WriteLine($"Hypyn pituus: {jumpLength} metriä");
        Console.WriteLine($"Hypyn pisteet: {points}");
    }
}
