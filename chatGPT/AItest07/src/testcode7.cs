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

// Kysytty 20.3.2024 uusi chat

using System;

class Program
{
    static void Main()
    {
        // Create an array to hold the lottery numbers
        int[] lotteryNumbers = new int[8];

        // Generate the lottery numbers
        Random random = new Random();
        for (int i = 0; i < 7; i++)
        {
            int newNumber;
            do
            {
                newNumber = random.Next(1, 41); // Generate a random number between 1 and 40
            } while (Array.Exists(lotteryNumbers, element => element == newNumber)); // Check if the number already exists
            lotteryNumbers[i] = newNumber;
        }

        // Sort the first 7 elements (main numbers) in ascending order
        Array.Sort(lotteryNumbers, 0, 7);

        // Generate the additional number
        lotteryNumbers[7] = random.Next(1, 41);

        // Print the lottery line
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lotteryNumbers[i] + "   ");
        }
        Console.Write("+   " + lotteryNumbers[7]);
    }
}
