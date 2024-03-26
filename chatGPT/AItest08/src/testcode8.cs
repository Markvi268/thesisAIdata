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
        // Initialize array for Lotto numbers
        int[] lottoNumbers = new int[8];

        // Random object for generating random numbers
        Random random = new Random();

        // Generate Lotto numbers
        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            do
            {
                // Generate a random number between 1 and 40
                randomNumber = random.Next(1, 41);
                // Check if the generated number already exists in the lottoNumbers array
            } while (Array.Exists(lottoNumbers, element => element == randomNumber));
            // If the number is unique, add it to the array
            lottoNumbers[i] = randomNumber;
        }

        // Sort the first 7 elements of the array in ascending order
        Array.Sort(lottoNumbers, 0, 7);

        // Generate the additional Lotto number
        lottoNumbers[7] = random.Next(1, 41);

        // Output the Lotto row
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottoNumbers[i]);
            // Add spaces between numbers and after the 7th number (before the additional number)
            if (i < 7)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write("   +   ");
            }
        }

        // Output the additional Lotto number
        Console.WriteLine(lottoNumbers[7]);
    }
}
