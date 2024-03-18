using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Syvennykset: ctrl A, ctrl k, ctrl f
/*      
KT2
Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan niin ja niin monta alkiota...
*/


namespace Ohjelmointi_1_Projekti
{
    class Program
    {
        static void Main(string[] args)
        {
            //KONSOLIN ASETUKSET
            Console.ForegroundColor = ConsoleColor.Red;
            //KONSOLIN ASETUKSET

            int i, arpa_numero;
            int[] numerot = new int[8];
            Random rnd = new Random();

            //Arvonta
            for (i = 0; i < numerot.Length; i = i + 1)
            {   //Pakotetaan uudelleen arvonta jos arpa_numero esiintyy jo aikasemmin lottorivillä
                arpa_numero = rnd.Next(1, 41);
                while (numerot.Contains(arpa_numero))
                {
                    arpa_numero = rnd.Next(1, 41);
                }
                //Lukitaan saatu uniikki arpa_numero lottoriviin
                numerot[i] = arpa_numero;
            }

            //Järjestellään lottorivi järjestykseen kaikki paitsi lisänumero (viimeinen arvo)
            Array.Sort(numerot, 0, 7);

            //Tulostus
            for (i = 0; i < numerot.Length; i = i + 1)
            {
                //Lisänumero 8
                if (i == 7)
                {
                    Console.Write("+  {0}\n\nOnnea kaikille voittajille!\n\n", numerot[i]);
                }
                //numerot 1-7
                else
                {
                    Console.Write("{0}  ", numerot[i]);
                }              
            }
        }
    }
}
