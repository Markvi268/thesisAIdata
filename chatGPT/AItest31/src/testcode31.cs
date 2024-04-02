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

// Kysytty 1.4.2024 uusi kysely

using System;

class Program
{
    static void Main(string[] args)
    {
        // Define the lotto table with 8 elements
        int[] lottoNumbers = new int[8];

        // Random number generator
        Random random = new Random();

        // Fill the lotto table with unique random numbers for main numbers (1-40)
        for (int i = 0; i < 7; i++)
        {
            int newNumber;
            // Keep generating new numbers until a unique one is found
            do
            {
                newNumber = random.Next(1, 41);
            } while (Array.IndexOf(lottoNumbers, newNumber, 0, i) != -1);

            lottoNumbers[i] = newNumber;
        }

        // Fill the last element of the array with the additional number
        lottoNumbers[7] = random.Next(1, 41);

        // Sort the main numbers in ascending order using Array.Sort
        Array.Sort(lottoNumbers, 0, 7);

        // Print the lotto row
        for (int i = 0; i < 8; i++)
        {
            // Print the main numbers with spaces
            if (i < 7)
            {
                Console.Write(lottoNumbers[i] + "   ");
            }
            // Print the additional number with a '+' sign
            else
            {
                Console.Write("+   " + lottoNumbers[i]);
            }
        }

        // Output a newline for better formatting
        Console.WriteLine();
    }
}
