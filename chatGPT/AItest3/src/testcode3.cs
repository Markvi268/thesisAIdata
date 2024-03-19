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

// Kysytty 19.3.2024 ja korjaus pyyntö 'ei toimi'. AItest2:seen uusinta korjauspyyntö 'tulostus ei vastaa tehtävänantoa'

using System;

class Program
{
    static void Main()
    {
        // Luodaan uusi satunnaislukugeneraattori
        Random rand = new Random();

        // Luodaan taulukko, johon tallennetaan lottorivit
        int[,] lottoTaulukko = new int[8, 8];

        // Generoidaan lottorivit
        for (int i = 0; i < 8; i++)
        {
            // Ensimmäiset 7 numeroa ovat varsinaisia lottorivejä
            for (int j = 0; j < 7; j++)
            {
                int arvottuNumero;
                do
                {
                    arvottuNumero = rand.Next(1, 41); // Arvotaan numero väliltä 1-40

                } while (OnkoNumeroJoLottorivissa(lottoTaulukko, i, arvottuNumero));

                lottoTaulukko[i, j] = arvottuNumero;
            }

            // Lajitellaan ensimmäiset 7 numeroa suuruusjärjestykseen
            Array.Sort(lottoTaulukko, i * 8, 7);

            // Viimeinen numero on lisänumero
            lottoTaulukko[i, 7] = rand.Next(1, 41); // Arvotaan lisänumero väliltä 1-40

            // Tulostetaan lottorivi
            for (int j = 0; j < 8; j++)
            {
                Console.Write(lottoTaulukko[i, j]);
                if (j < 7)
                {
                    Console.Write("   "); // Lisätään välilyönti varsinaisten numeroiden välille
                }
                else
                {
                    Console.Write("   +   "); // Lisätään +-merkki varsinaisten numeroiden ja lisänumeron välille
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

