using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.
Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.
Tulosta lopuksi lottorivi seuraavasti:
1   4   12   16   19   25   31   +   13
HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin 
lajittellaan niin ja niin monta alkiota...
*/

namespace Eta18KP

{
    class Program
    {
        static void Main()
        {
            {

                int[] taulu = new int[8];
                int i;
                Random rnd = new Random();

                for (i = 0; i < taulu.Length; i++)
                {
                    taulu[i] = rnd.Next(1, 41);                   
                }
                Array.Sort(taulu, 0, 7);
                Console.WriteLine("Oikeat numerot:{0} {1} {2} {3} {4} {5} {6} + {7}", taulu[0], taulu[1], taulu[2], taulu[3], taulu[4], taulu[5], taulu[6], taulu[7]);
            }
        }
    }
}