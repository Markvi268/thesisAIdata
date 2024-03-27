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

// Kysytty 26.3.2024 uusi chat

using System;

class Program
{
    static void Main()
    {
        // Luo taulukko lottonumeroille ja aseta kaikki arvot nollaksi aluksi
        int[] lottoNumerot = new int[8];

        Random rnd = new Random();

        // Generoi varsinaiset lottonumerot
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = rnd.Next(1, 41); // Arvotaan numero väliltä 1-40
            } while (Array.Exists(lottoNumerot, element => element == arvottuNumero)); // Tarkistetaan, ettei numero ole jo lottonumerona

            lottoNumerot[i] = arvottuNumero;
        }

        // Lajittele varsinaiset lottonumerot
        Array.Sort(lottoNumerot, 0, 7);

        // Generoi lisänumero
        lottoNumerot[7] = rnd.Next(1, 41);

        // Tulosta lottorivi
        for (int i = 0; i < 8; i++)
        {
            if (i == 7)
            {
                Console.Write("   +   ");
            }
            Console.Write(lottoNumerot[i] + "   ");
        }
    }
}

