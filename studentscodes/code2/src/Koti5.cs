using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
KT2
Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. 
Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo 
lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä 
indeksistä eteenpäin lajittellaan niin ja niin monta alkiota...
*/
namespace ETA18KP
{
    class Program
    {
        static void Main()
        {
            int[] lottotaulu = new int[8];
            int i, numero;
            Random rnd = new Random();
 

            for (i = 0; i < lottotaulu.Length; i++)
            {
                numero = rnd.Next(1, 41);

                while (lottotaulu.Contains(numero) == true)
                {
                    numero = rnd.Next(1, 41);
                }
                lottotaulu[i] = numero;
            }

            foreach (int luku in lottotaulu)
            {
                Array.Sort(lottotaulu); // ää en osaa äiti auta...
                Console.Write("{0}  ", luku);
            }

        }
    }
}

