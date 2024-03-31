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

// Kysytty 28.3.2024 korjaus AItest18 versiosta pyydetty 'error CS1501: No overload for method 'Exists' takes 4 arguments'

using System;

class Program
{
    static void Main()
    {
        // Luodaan uusi satunnaislukugeneraattori
        Random rnd = new Random();

        // Luodaan taulukko lottoriville (7 varsinaista numeroa ja 1 lisänumero)
        int[] lottoRivi = new int[8];

        // Generoidaan varsinaiset lottonumerot
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                // Arvotaan uusi numero
                arvottuNumero = rnd.Next(1, 41);
            }
            // Tarkistetaan, ettei arvottu numero ole jo lottorivissä
            while (OnkoNumeroJoLottorivissa(lottoRivi, arvottuNumero));

            // Lisätään arvottu numero lottoriviin
            lottoRivi[i] = arvottuNumero;
        }

        // Generoidaan lisänumero
        do
        {
            // Arvotaan uusi numero
            lottoRivi[7] = rnd.Next(1, 41);
        }
        // Tarkistetaan, ettei lisänumero ole sama kuin varsinaiset numerot
        while (OnkoNumeroJoLottorivissa(lottoRivi, lottoRivi[7]));

        // Järjestetään varsinaiset numerot suuruusjärjestykseen
        Array.Sort(lottoRivi, 0, 7);

        // Tulostetaan lottorivi
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoRivi[i] + "   ");
        }
        Console.Write("+   ");
        Console.WriteLine(lottoRivi[7]);
    }

    // Metodi tarkistaa, onko annettu numero jo lottorivissä
    static bool OnkoNumeroJoLottorivissa(int[] lottorivi, int numero)
    {
        foreach (int luku in lottorivi)
        {
            if (luku == numero)
            {
                return true;
            }
        }
        return false;
    }
}
