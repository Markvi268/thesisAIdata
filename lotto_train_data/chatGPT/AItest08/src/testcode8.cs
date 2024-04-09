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
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] lottoNumbers = new int[8];

        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 41);
            } while (Array.IndexOf(lottoNumbers, randomNumber) != -1);

            lottoNumbers[i] = randomNumber;
        }

        Array.Sort(lottoNumbers, 0, 7);

        // Arvotaan lisänumero
        lottoNumbers[7] = random.Next(1, 41);

        // Tulostetaan lottorivi
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoNumbers[i] + "   ");
        }
        Console.Write("+   ");
        Console.WriteLine(lottoNumbers[7]);
    }
}
