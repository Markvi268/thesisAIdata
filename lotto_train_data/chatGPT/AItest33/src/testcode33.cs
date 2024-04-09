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

// Kysytty 1.4.2024 korjaus kysely AItest32, korjauspyyntö 'plus merkin jälkeen ei tulostu mitään'


using System;

class Program
{
    static void Main()
    {
        // Luo taulukko lottoriville
        int[] lottoRivi = new int[8];

        // Arvo varsinaiset lottorivin numerot
        Random rand = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            // Arvotaan uusi numero, kunnes se ei ole jo lottorivissä
            do
            {
                arvottuNumero = rand.Next(1, 41);
            } while (Array.IndexOf(lottoRivi, arvottuNumero) != -1);
            
            lottoRivi[i] = arvottuNumero;
        }

        // Järjestä varsinaiset numerot suuruusjärjestykseen
        Array.Sort(lottoRivi, 0, 7);

        // Arvo lisänumero
        lottoRivi[7] = rand.Next(1, 41);

        // Tulosta lottorivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottoRivi[i]);
            if (i < 7)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write("   +   ");
                Console.Write(lottoRivi[i]); // Tulostetaan lisänumero
            }
        }
        Console.WriteLine();
    }
}
