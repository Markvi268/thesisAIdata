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

// Kysytty 1.4.2024 uusi 'tasapainoinen' kysely. Itse kommentoitu 'Console.Write("Lottorivi: ");'

using System;

namespace LottoArvonta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luo kahdeksan alkion taulukko
            int[] lottoNumerot = new int[8];

            // Arvo seitsemän varsinaista lottonumeroa (1-40)
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int arvottuNumero;
                do
                {
                    arvottuNumero = random.Next(1, 41); // Arvotaan numero väliltä 1-40
                } while (Array.Exists(lottoNumerot, num => num == arvottuNumero)); // Tarkistetaan, ettei numeroa ole jo taulukossa
                lottoNumerot[i] = arvottuNumero;
            }

            // Arvo lisänumero (1-40, ei saa olla jo taulukossa)
            int lisäNumero;
            do
            {
                lisäNumero = random.Next(1, 41);
            } while (Array.Exists(lottoNumerot, num => num == lisäNumero));
            lottoNumerot[7] = lisäNumero;

            // Lajittele seitsemän varsinaista numeroa suuruusjärjestykseen
            Array.Sort(lottoNumerot, 0, 7);

            // Tulosta lottorivi
            // Console.Write("Lottorivi: ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottoNumerot[i] + "   ");
            }
            Console.Write("+   " + lottoNumerot[7]);
        }
    }
}



