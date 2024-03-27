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

// Kysytty 27.3.2024 uusi 'tasapainoinen' kysely

using System;

namespace LottoOhjelma
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luo taulukko, jossa on 8 alkiota
            int[] lottorivi = new int[8];

            // Arvo 7 varsinaista lottonumeroa (1-40)
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int arvottuNumero;
                do
                {
                    arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
                } while (Array.Exists(lottorivi, num => num == arvottuNumero)); // Tarkistetaan, ettei numero ole jo lottorivissä
                lottorivi[i] = arvottuNumero;
            }

            // Arvo lisänumero (1-40)
            int lisanumero;
            do
            {
                lisanumero = random.Next(1, 41);
            } while (Array.Exists(lottorivi, num => num == lisanumero)); // Tarkistetaan, ettei lisänumero ole jo lottorivissä
            lottorivi[7] = lisanumero;

            // Lajittele varsinaiset numerot suuruusjärjestykseen
            Array.Sort(lottorivi, 0, 7);

            // Tulosta lottorivi
            Console.Write("Lottorivi: ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottorivi[i] + "   ");
            }
            Console.Write("+   " + lottorivi[7]);
            Console.WriteLine();
        }
    }
}
