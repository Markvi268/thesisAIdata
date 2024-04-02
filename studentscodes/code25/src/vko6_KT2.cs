using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*otossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:
1   4   12   16   19   25   31   +   13
*/
namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] taulu = new int[8];
            int i;
            Random rnd = new Random();

            for (i = 0; i < taulu.Length; i++)
            {
                taulu[i] = rnd.Next(1, 41);

                if (taulu[i] == 0)
                {
                    i++;
                }
            }
            for (i = 0; i < taulu.Length; i++)
            {
                Array.Sort(taulu);
                Console.Write(taulu[i]);


            }
























        }
    }
}


    

























