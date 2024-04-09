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

// Kysytty 1.4.2024 uusi 'Luovempi' kysely. Itse kommmentoitu 'Console.Write("Lottorivi: ");'


using System;
using System.Linq;

namespace Lotto
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
                    arvottuNumero = random.Next(1, 41);
                } while (lottorivi.Contains(arvottuNumero)); // Tarkista, ettei numeroa ole jo lottorivissä
                lottorivi[i] = arvottuNumero;
            }

            // Arvo lisänumero (1-40)
            int lisanumero;
            do
            {
                lisanumero = random.Next(1, 41);
            } while (lottorivi.Contains(lisanumero)); // Tarkista, ettei lisänumero ole jo lottorivissä
            lottorivi[7] = lisanumero;

            // Lajittele varsinaiset numerot suuruusjärjestykseen
            Array.Sort(lottorivi, 0, 7);

            // Tulosta lottorivi
            //Console.Write("Lottorivi: ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottorivi[i] + "   ");
            }
            Console.Write("+   " + lottorivi[7]);
        }
    }
}
