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

// Kysytty 31.3.2024 uusi kysely

using System;

class Program
{
    static void Main()
    {
        // Alusta lotto-taulukko
        int[] lottoRivi = new int[8];

        // Arvo varsinaiset lottonumerot
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero = ArvoNumero(lottoRivi);
            lottoRivi[i] = arvottuNumero;
        }

        // Arvo lisänumero
        lottoRivi[7] = ArvoNumero(lottoRivi);

        // Lajittele varsinaiset lottonumerot
        Array.Sort(lottoRivi, 0, 7);

        // Tulosta lottorivi
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoRivi[i] + "   ");
        }

        Console.Write("+   " + lottoRivi[7]);
    }

    // Metodi arpoa uusi numero, joka ei ole vielä lotto-taulukossa
    static int ArvoNumero(int[] lottoRivi)
    {
        Random rnd = new Random();
        int arvottuNumero;

        do
        {
            arvottuNumero = rnd.Next(1, 41);
        } while (Array.IndexOf(lottoRivi, arvottuNumero) != -1);

        return arvottuNumero;
    }
}

