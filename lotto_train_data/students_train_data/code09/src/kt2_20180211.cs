using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

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

namespace Tehtavat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taulukko = new int[8];
            Random satunnainen = new Random();
            int pallo, lisapallo;

            for (pallo = 0; pallo < 8; pallo++)
            {
                {
                    taulukko[pallo] = satunnainen.Next(1, 41);
                    Console.Write("{0} ",taulukko[pallo]);
                }
            }
            for (lisapallo = 0; lisapallo < 1; lisapallo++)
            {
                taulukko[lisapallo] = satunnainen.Next(1, 41);
                Console.WriteLine(" + {0}", taulukko[lisapallo]);
            }
        }
    }
}
