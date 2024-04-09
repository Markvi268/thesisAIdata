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

// Kysytty 30.3.2024 korjaus AItest15 'luovempi' kysely, korjauspyyntö 'tulostuksessa on ylimääräinen 'Lottorivi:' teksti'

using System;

namespace LottoArvonta
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
                int numero;
                do
                {
                    numero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
                } while (Array.Exists(lottorivi, n => n == numero)); // Tarkistetaan, ettei numeroa ole jo lottorivissä
                lottorivi[i] = numero;
            }

            // Arvo lisänumero (1-40)
            int lisaNumero;
            do
            {
                lisaNumero = random.Next(1, 41);
            } while (Array.Exists(lottorivi, n => n == lisaNumero)); // Tarkistetaan, ettei lisänumeroa ole jo lottorivissä
            lottorivi[7] = lisaNumero;

            // Lajittele varsinaiset numerot suuruusjärjestykseen
            Array.Sort(lottorivi, 0, 7);

            // Tulosta lottorivi
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottorivi[i] + "   ");
            }
            Console.Write("+   " + lottorivi[7]);
            Console.WriteLine();
        }
    }
}

