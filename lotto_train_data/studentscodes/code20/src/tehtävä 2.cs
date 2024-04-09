using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
   /* KT2
   Lotossa arvotaan seitsemän(7) varsinaista numeroa ja yksi(1) lisänumero.Numerot ovat väliltä 1-40.

Esittele kahdeksan(8) alkioinen lotto-taulukko ja arvo siihen lottonumerot(7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja 
silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13


HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan 
niin ja niin monta alkiota...*/
    class Program
    {
        static void Main(string[] args)
        {
            int[] lotto = new int[8];
            Random rand = new Random();
            int i;
            int num;
            for (i=0; i<lotto.Length; i++)
            {
                num = rand.Next(1, 41);
                while(lotto.Contains(num)==true)
                {
                   num=rand.Next(1, 41);
                }
                lotto[i] = num;
            }
            
            Array.Sort(lotto,0,7);
            foreach (int luku in lotto)
            {
                Console.WriteLine(luku);
            }
            

        }
    }
}
