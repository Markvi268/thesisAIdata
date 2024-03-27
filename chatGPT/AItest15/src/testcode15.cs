/*
Luo c# ohjelma: Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan niin ja niin monta alkiota...

*/

// Kysytty 27.3.2024 korjaus AItest14, pyydetty 'tulostus on vääränlainen'

using System;

class Program
{
    static void Main()
    {
        // Alusta lotto-taulukko
        int[] lottoTaulukko = new int[8];

        // Arvo varsinaiset lottonumerot
        Random rnd = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = rnd.Next(1, 41);
            } while (Array.IndexOf(lottoTaulukko, arvottuNumero, 0, i) != -1); // Tarkista, onko numero jo lottorivissä
            lottoTaulukko[i] = arvottuNumero;
        }

        // Lajittele varsinaiset numerot
        Array.Sort(lottoTaulukko, 0, 7);

        // Arvo lisänumero
        int lisäNumero;
        do
        {
            lisäNumero = rnd.Next(1, 41);
        } while (Array.IndexOf(lottoTaulukko, lisäNumero) != -1); // Tarkista, ettei lisänumero ole jo lottorivissä
        lottoTaulukko[7] = lisäNumero;

        // Tulosta lottorivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottoTaulukko[i]);
            if (i < 7)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write("   +   ");
            }
        }
        Console.WriteLine();
    }
}
