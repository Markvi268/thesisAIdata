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

// Kysytty 31.3.2024 uusi 'tarkempi' kysely

using System;

class Program
{
    static void Main()
    {
        int[] numerot = new int[8];
        Random rand = new Random();
        int i = 0;

        while (i < 8)
        {
            int arvottuNumero = rand.Next(1, 41);

            if (Array.IndexOf(numerot, arvottuNumero) == -1)
            {
                numerot[i] = arvottuNumero;
                i++;
            }
        }

        Array.Sort(numerot, 0, 7);

        for (int j = 0; j < 7; j++)
        {
            Console.Write(numerot[j] + "   ");
        }

        Console.Write("+   " + numerot[7]);
    }
}
