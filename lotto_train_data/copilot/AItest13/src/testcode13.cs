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

// Kysytty 30.3.2024 korjaus AItest12 kysely korjauspyyntö 'tulostuksessa on ylimääräinen 'Lottorivi:' teksti'

using System;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luo taulukko seitsemälle varsinaiselle numerolle ja yhdelle lisänumerolle
            int[] lottoNumerot = new int[8];

            // Arvo seitsemän varsinaista numeroa
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int arvottuNumero;
                do
                {
                    arvottuNumero = random.Next(1, 41); // Välillä 1-40
                } while (Array.Exists(lottoNumerot, num => num == arvottuNumero)); // Tarkista, ettei numeroa ole jo lottorivissä
                lottoNumerot[i] = arvottuNumero;
            }

            // Arvo yksi lisänumero
            int lisäNumero;
            do
            {
                lisäNumero = random.Next(1, 41);
            } while (Array.Exists(lottoNumerot, num => num == lisäNumero)); // Tarkista, ettei lisänumero ole jo lottorivissä
            lottoNumerot[7] = lisäNumero;

            // Lajittele seitsemän varsinaista numeroa suuruusjärjestykseen
            Array.Sort(lottoNumerot, 0, 7);

            // Tulosta lottorivi
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottoNumerot[i] + "   ");
            }
            Console.Write("+   " + lottoNumerot[7]);
            Console.WriteLine();
        }
    }
}

