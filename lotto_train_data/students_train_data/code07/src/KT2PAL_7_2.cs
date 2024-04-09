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


namespace rojekti1
{
    class Program
    {
        static void Main()
        {
            int[] taulu = new int[8];
            int nro;
               
            Random arvo = new Random();
            int i;
            for (i=0;i < taulu.Length;i++)
            {
                nro = arvo.Next(1, 41);
                while(taulu.Contains(nro) == true )
                {

                }
                taulu[i] = nro;
            }
            Array.Sort(taulu,0,7);
            
            
            for (i = 0;i <= 6;i++)
            { 
            Console.Write("{0} ", taulu[i]);
            }
            
            Console.Write("+ {0} \n", taulu[7]);
            
            
        }
    }
}