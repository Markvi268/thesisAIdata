using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekoilua
{
    class Program
    {
        /* VK6KT2 ETA18KP Janne Kankkunen
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



        static void Main(string[] args)
        {
            int i;
            int[] taulu1 = new int[8];
            Random rnd = new Random();

            for (i = 0; i < taulu1.Length; i++)
            {
              taulu1[i] = rnd.Next(1, 41);
                if (taulu1[i] != taulu1[i])
                {
                    i--;
                }
            } 
            Array.Sort(taulu1, 0, 7);
            
            Console.Write("Arvotaan seitsemän numeroa ja yksi lisänumero: {0} {1} {2} {3} {4} {5} {6} + {7} ", taulu1[0], taulu1[1], taulu1[2], taulu1[3], taulu1[4], taulu1[5], taulu1[6], taulu1[7]);
            
        }   //HUOM!!! En osannut tehdä sitä ettei samaa numeroa tule useammin. 
    }

}







        

    

