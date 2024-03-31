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

Älä käytä näitä nimiä: lottoTaulukko, lottoRivi, lottoNumbers, lotteryNumbers, lottorivi, lottoNumerot

*/

// Kysytty 30.3.2024 chatGPT

using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int[] lotto = new int[8];

        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = rnd.Next(1, 41);
            } while (Array.IndexOf(lotto, randomNumber) != -1);
            lotto[i] = randomNumber;
        }

        lotto[7] = rnd.Next(1, 41);

        Array.Sort(lotto, 0, 7);

        foreach (int number in lotto)
        {
            Console.Write(number + "   ");
        }
        Console.Write("+   ");
        Console.WriteLine(lotto[7]);
    }
}
