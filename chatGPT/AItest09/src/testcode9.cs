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
        // Luodaan taulukko lottonumeroille
        int[] lottoRivi = new int[8];

        // Arvotaan varsinaiset lottonumerot
        Random random = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
            } while (Array.IndexOf(lottoRivi, arvottuNumero) != -1); // Tarkistetaan, ettei numeroa ole jo arvottu

            lottoRivi[i] = arvottuNumero; // Lisätään numero lottoriville
        }

        // Arvotaan lisänumero
        int lisänumero;
        do
        {
            lisänumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
        } while (Array.IndexOf(lottoRivi, lisänumero) != -1); // Tarkistetaan, ettei numeroa ole jo arvottu

        lottoRivi[7] = lisänumero; // Lisätään lisänumero lottoriville

        // Lajitellaan varsinaiset lottonumerot
        Array.Sort(lottoRivi, 0, 7);

        // Tulostetaan lottorivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottoRivi[i]);
            if (i == 6)
                Console.Write("   +   "); // Erotin varsinaisten numeroiden ja lisänumeron välillä
            else if (i < 7)
                Console.Write("   ");
        }
    }
}
