using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int i, j;
            Random rdm = new Random();
            int[] taulu = new int[8];

            for (i = 0; i < taulu.Length; i++)
            {
                if (i == 0)
                {
                    taulu[i] = rdm.Next(1, 41);
                }
                else
                {
                    taulu[i] = rdm.Next(1, 41);
                    for (j = i - 1; j >= 0; j--)
                    {
                        if (taulu[i] == taulu[j])
                        {
                            i--;
                        }
                    }
                }
            }
            //Console.WriteLine("a");   //TESTASIN TÄLLÄ TOIMIVUUDEN
            Array.Sort(taulu, 0, 7);
            /*foreach (int x in taulu)  //TESTASIN TÄLLÄ TOIMIVUUDEN
            {
                Console.WriteLine(x);   //TESTASIN TÄLLÄ TOIMIVUUDEN
            } */
            for (i = 0; i < taulu.Length; i++)
            {
                if (taulu[i] == taulu[7])
                {
                    Console.WriteLine("+ {0}", taulu[i]);
                }
                else
                {
                    Console.Write("{0} ", taulu[i]);
                }
            }
        }
    }
}

