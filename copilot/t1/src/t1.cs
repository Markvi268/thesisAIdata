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
// HUOM! Luovempi kysely

using System;

class Lotto
{
    static void Main()
    {
        int[] lottoNumbers = new int[8];
        Random rand = new Random();

        for (int i = 0; i < lottoNumbers.Length - 1; i++)
        {
            int number;
            do
            {
                number = rand.Next(1, 41);
            } while (Array.IndexOf(lottoNumbers, number) != -1);

            lottoNumbers[i] = number;
        }

        // Lajittele ensimmäiset seitsemän numeroa
        Array.Sort(lottoNumbers, 0, 7);

        // Arvo lisänumero, joka ei ole vielä lottorivissä
        int extraNumber;
        do
        {
            extraNumber = rand.Next(1, 41);
        } while (Array.IndexOf(lottoNumbers, extraNumber) != -1);

        lottoNumbers[7] = extraNumber;

        // Tulosta lottorivi
        for (int i = 0; i < lottoNumbers.Length - 1; i++)
        {
            Console.Write(lottoNumbers[i] + "   ");
        }
        Console.Write("+   " + lottoNumbers[7]);
    }
}
