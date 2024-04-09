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

// Kysytty 27.3.2024 uusi kysely

using System;

class Program
{
    static void Main()
    {
        // Luodaan lotto-taulukko kahdeksalla alkiolla
        int[] lottoRivi = new int[8];

        // Arvotaan varsinaiset lottonumerot
        Random rnd = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = rnd.Next(1, 41); // Arvotaan numero väliltä 1-40
            } while (Array.Exists(lottoRivi, element => element == arvottuNumero)); // Tarkistetaan, onko numero jo lottoRivissä
            lottoRivi[i] = arvottuNumero; // Lisätään numero lottoRiviin
        }

        // Arvotaan lisänumero
        int lisänumero;
        do
        {
            lisänumero = rnd.Next(1, 41);
        } while (Array.Exists(lottoRivi, 0, 7, element => element == lisänumero)); // Tarkistetaan, ettei lisänumero ole mukana varsinaisissa numeroissa
        lottoRivi[7] = lisänumero; // Lisätään lisänumero lottoRiviin

        // Järjestetään varsinaiset numerot suuruusjärjestykseen
        Array.Sort(lottoRivi, 0, 7);

        // Tulostetaan lottonumerot
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoRivi[i] + "   ");
        }
        Console.Write("+   ");
        Console.WriteLine(lottoRivi[7]);
    }
}
