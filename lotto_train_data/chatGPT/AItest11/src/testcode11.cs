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
        // Alusta taulukko lottoriveille
        int[,] lottoTaulukko = new int[8, 1];

        // Alusta satunnaislukugeneraattori
        Random random = new Random();

        // Käy läpi jokainen lottorivi
        for (int i = 0; i < 8; i++)
        {
            // Lisää 7 varsinaista numeroa lottoriviin
            for (int j = 0; j < 7; j++)
            {
                int arvottuNumero;
                do
                {
                    arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
                } while (OnkoNumeroJoLottorivissa(lottoTaulukko, i, arvottuNumero)); // Tarkista, ettei numero ole jo lottorivissä

                lottoTaulukko[i, j] = arvottuNumero;
            }

            // Lajittele varsinaiset numerot suuruusjärjestykseen
            Array.Sort(lottoTaulukko, i, 7);

            // Lisää lottoriville lisänumero
            int lisänumero = random.Next(1, 41); // Arvotaan lisänumero
            lottoTaulukko[i, 7] = lisänumero;
        }

        // Tulosta lottorivit
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(lottoTaulukko[i, j]);
                if (j < 7)
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

    // Metodi tarkistaa, onko numero jo lottorivissä
    static bool OnkoNumeroJoLottorivissa(int[,] taulukko, int rivi, int numero)
    {
        for (int i = 0; i < 7; i++)
        {
            if (taulukko[rivi, i] == numero)
            {
                return true;
            }
        }
        return false;
    }
}

