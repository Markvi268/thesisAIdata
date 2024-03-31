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

// Kysytty 30.3.2024 uusi kysely


using System;

class Program
{
    static void Main()
    {
        // Luodaan uusi lotto-taulukko
        int[] lottoTaulukko = new int[8];

        // Arvotaan varsinaiset lottonumerot
        Random random = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40

            } while (Array.IndexOf(lottoTaulukko, arvottuNumero, 0, 7) != -1); // Tarkistetaan, että numero ei ole jo lotonumerona

            lottoTaulukko[i] = arvottuNumero;
        }

        // Arvotaan lisänumero
        int lisänumero;
        do
        {
            lisänumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40

        } while (Array.IndexOf(lottoTaulukko, lisänumero, 0, 7) != -1); // Tarkistetaan, että lisänumero ei ole jo varsinaisena lottonumerona

        lottoTaulukko[7] = lisänumero;

        // Järjestetään varsinaiset lottonumerot suuruusjärjestykseen
        Array.Sort(lottoTaulukko, 0, 7);

        // Tulostetaan lottonumerot
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoTaulukko[i] + "   ");
        }
        Console.Write("+   " + lottoTaulukko[7]); // Tulostetaan lisänumero
    }
}
