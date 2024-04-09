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

Älä käytä näitä nimiä: lottoTaulukko, lottoRivi, lottoNumbers, lotteryNumbers, lottorivi, lottoNumerot

*/

// Kysytty 31.3.2024 uusi kysely

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[8];
        Random rand = new Random();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int num;
            do
            {
                num = rand.Next(1, 41);
            } while (Array.IndexOf(numbers, num, 0, i) != -1);

            numbers[i] = num;
        }

        // Lisänumero
        numbers[7] = rand.Next(1, 41);

        // Lajitellaan varsinaiset numerot
        Array.Sort(numbers, 0, 7);

        // Tulostetaan lottorivi
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == 7)
                Console.Write("   +   ");
            Console.Write(numbers[i] + "   ");
        }
    }
}

