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

// Kysytty 27.3.2024 uusi 'tarkempi' kysely

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] lottoNumbers = new int[8];
        Random rand = new Random();

        for (int i = 0; i < 7; i++)
        {
            int num;

            do
            {
                num = rand.Next(1, 41);
            }
            while (lottoNumbers.Contains(num));

            lottoNumbers[i] = num;
        }

        // Lajitellaan ensimmäiset 7 numeroa
        Array.Sort(lottoNumbers, 0, 7);

        // Arvotaan lisänumero
        int extraNum;

        do
        {
            extraNum = rand.Next(1, 41);
        }
        while (lottoNumbers.Contains(extraNum));

        lottoNumbers[7] = extraNum;

        // Tulostetaan lottorivi
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoNumbers[i] + "   ");
        }

        Console.Write("+   " + lottoNumbers[7]);
    }
}
