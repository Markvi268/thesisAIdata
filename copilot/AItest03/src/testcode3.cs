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
// Kysytty 26.3.2024 uusi 'luovempi' kysely

using System;

namespace LottoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luo taulukko seitsemälle varsinaiselle numerolle ja yhdelle lisänumerolle
            int[] lottoNumbers = new int[8];

            // Arvo seitsemän uniikkia varsinaista numeroa
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 41);
                } while (Array.Exists(lottoNumbers, n => n == number));
                lottoNumbers[i] = number;
            }

            // Lajittele varsinaiset numerot suuruusjärjestykseen
            Array.Sort(lottoNumbers, 0, 7);

            // Arvo yksi uniikki lisänumero
            int additionalNumber;
            do
            {
                additionalNumber = random.Next(1, 41);
            } while (Array.Exists(lottoNumbers, n => n == additionalNumber));
            lottoNumbers[7] = additionalNumber;

            // Tulosta lottorivi
            Console.Write("Lottorivi: ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(lottoNumbers[i] + "   ");
            }
            Console.Write("+   " + lottoNumbers[7]);
        }
    }
}
