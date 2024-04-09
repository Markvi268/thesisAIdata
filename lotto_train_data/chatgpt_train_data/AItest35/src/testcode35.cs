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
    static void Main()
    {
        // Initialize array for storing lottery numbers
        int[] lottoNumbers = new int[8];
        
        // Random object for generating random numbers
        Random random = new Random();
        
        // Loop through each index of the array to generate unique lottery numbers
        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            // Generate a random number and check if it's already in the array
            do
            {
                randomNumber = random.Next(1, 41); // Generate a random number between 1 and 40
            } while (Array.IndexOf(lottoNumbers, randomNumber) != -1); // Check if the number already exists in the array
            
            lottoNumbers[i] = randomNumber; // Assign the unique random number to the array
        }
        
        // Generate the additional number
        lottoNumbers[7] = random.Next(1, 41); // Additional number can be any number between 1 and 40
        
        // Sort the first 7 numbers in ascending order
        Array.Sort(lottoNumbers, 0, 7);
        
        // Print the lottery ticket
        for (int i = 0; i < 8; i++)
        {
            if (i == 7)
            {
                Console.Write(" + "); // Print '+' before the additional number
            }
            Console.Write($"{lottoNumbers[i],3}"); // Print each number with padding of 3 spaces
        }
        
        Console.WriteLine(); // Move to the next line after printing the ticket
    }
}

