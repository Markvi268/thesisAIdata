/*Luo C# ohjelma: Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan niin 
ja niin monta alkiota...
*/

// HUOM! Uusi kysely
using System;

class Program
{
    static void Main()
    {
        // Luodaan lottorivi
        int[] lottoRivi = ArvoLottoRivi();

        // Tulostetaan lottorivi
        TulostaLottoRivi(lottoRivi);
    }

    static int[] ArvoLottoRivi()
    {
        Random rand = new Random();
        int[] lottoRivi = new int[8];

        // Arvotaan varsinaiset lottorivin numerot
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = rand.Next(1, 41);
            } while (Array.Exists(lottoRivi, element => element == arvottuNumero)); // Tarkistetaan, ettei numeroa ole jo lottorivissä
            lottoRivi[i] = arvottuNumero;
        }

        // Lajitellaan varsinaiset numerot suuruusjärjestykseen
        Array.Sort(lottoRivi, 0, 7);

        // Arvotaan lisänumero
        lottoRivi[7] = rand.Next(1, 41);

        return lottoRivi;
    }

    static void TulostaLottoRivi(int[] lottoRivi)
    {
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoRivi[i] + "   ");
        }

        Console.Write("+   ");

        Console.WriteLine(lottoRivi[7]);
    }
}
