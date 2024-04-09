using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Markku_Teema4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. 
              Numerot ovat väliltä 1-40. Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot 
             (7 ensimmäistä on siis varsinaisia lottonumeroita ja viimeinen on lisänumero).
             Muista, että samaa numeroa ei saa tulla lottoriviin eli mieti miten voisit tarkistaa
             onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

            Tulosta lopuksi lottorivi seuraavasti:

            1  4  12  16  19  25  31  +  13

            HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! 
            Mutta lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! 
            Löytysköhän Array.Sort:sta sellainen ominaisuus, jolla tämän saisi ratkaistua?*/
            Random rnd = new Random();
            int[] iLottotaulukko = new int[8];
            int iLottonumero;
            for (int i = 0; i < iLottotaulukko.Length; i++)
            {
                iLottonumero = rnd.Next(1, 41);

                if (!iLottotaulukko.Contains(iLottonumero))
                    iLottotaulukko[i] = iLottonumero;

                else
                    i--;
                
            }
            Array.Sort(iLottotaulukko,0,7);
            for (int i = 0; i < 7; i++)
            {
                Console.Write(iLottotaulukko[i] + " ");
            }
            Console.Write("+ {0}",iLottotaulukko[7]);
            Console.WriteLine();
        } 
    }
}
