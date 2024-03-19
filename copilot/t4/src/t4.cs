/*Luo C# ohjelma: Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan niin 
ja niin monta alkiota...
*/
// HUOM! Tasapainoinen kysely

using System;
using System.Linq;

namespace LottoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luo tyhjä taulukko lottonumeroille
            int[] lottoNumerot = new int[7];

            // Arvo 7 uniikkia lottonumeroa
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int numero;
                do
                {
                    numero = random.Next(1, 41);
                } while (lottoNumerot.Contains(numero));
                lottoNumerot[i] = numero;
            }

            // Lajittele varsinaiset lottonumerot suuruusjärjestykseen
            Array.Sort(lottoNumerot, 0, 7);

            // Arvo lisänumero
            int lisaNumero;
            do
            {
                lisaNumero = random.Next(1, 41);
            } while (lottoNumerot.Contains(lisaNumero));

            // Tulosta lottorivi
            Console.Write("Lottorivi: ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottoNumerot[i] + " ");
            }
            Console.Write("+ " + lisaNumero);
        }
    }
}
