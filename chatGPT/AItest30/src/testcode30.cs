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

// Kysytty 31.3.2024 uusi kysely

using System;

class Program
{
    static void Main()
    {
        int[] lottery = new int[8];
        Random random = new Random();

        // Arvotaan varsinaiset lottonumerot
        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 41);
            } while (Array.IndexOf(lottery, randomNumber, 0, 7) != -1); // Tarkistetaan, ettei numero ole jo listassa
            lottery[i] = randomNumber;
        }

        // Arvotaan lisänumero
        int additionalNumber;
        do
        {
            additionalNumber = random.Next(1, 41);
        } while (Array.IndexOf(lottery, additionalNumber, 0, 7) != -1); // Tarkistetaan, ettei numero ole jo listassa
        lottery[7] = additionalNumber;

        // Lajitellaan varsinaiset lottonumerot
        Array.Sort(lottery, 0, 7);

        // Tulostetaan lottorivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"{lottery[i]}");
            if (i == 6)
            {
                Console.Write("   +   ");
            }
            else if (i < 7)
            {
                Console.Write("   ");
            }
        }
    }
}
