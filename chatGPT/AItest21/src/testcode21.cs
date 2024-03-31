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

// Kysytty 28.3.2024 uusi kysely

using System;

class Program
{
    static void Main()
    {
        // Luodaan taulukko, johon tallennetaan lottonumerot
        int[] lottoRivi = new int[8];

        // Arvotaan seitsemän varsinaista numeroa ja yksi lisänumero
        Random random = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40

                // Tarkistetaan, ettei arvottu numero ole jo lottonumeroina
            } while (Array.IndexOf(lottoRivi, arvottuNumero) != -1);

            lottoRivi[i] = arvottuNumero;
        }

        // Arvotaan lisänumero
        lottoRivi[7] = random.Next(1, 41);

        // Järjestetään varsinaiset lottonumerot
        Array.Sort(lottoRivi, 0, 7);

        // Tulostetaan lottonumerot
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoRivi[i] + "   ");
        }

        // Tulostetaan lisänumero
        Console.Write("+   " + lottoRivi[7]);

        // Lopeta ohjelma
        Console.ReadLine();
    }
}
