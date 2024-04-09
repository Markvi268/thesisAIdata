using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Viikkotehtävät_Vko4
{
    class Program
    {
        static void Main(string[] args)
        {
            //KT4
            //Lotossa arvotaan seitsemän(7) varsinaista numeroa ja yksi(1) lisänumero.Numerot ovat väliltä 1 - 40.
            //Esittele kahdeksan(8) alkioinen lotto-taulukko ja arvo siihen lottonumerot(7 ensimmäistä on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). 
            //Muista, että samaa numeroa ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan 
            //ja silloin sen tilalle pitää arpoa uusi numero.

            Random rnd = new Random();
            int[] iTaulu = new int[8];
            int Lottonumero;

            for (int i = 0; i < iTaulu.Length; i++)
            {
                Lottonumero = rnd.Next(1, 41);

                if (!iTaulu.Contains(Lottonumero))
                {
                    iTaulu[i] = Lottonumero;
                }
                else
                    i--;
            }
            Array.Sort(iTaulu, 0, 7);
            for (int i = 0; i < 7; i++)
            {
                Console.Write(iTaulu[i] + " ");
            }
            Console.Write("+{0}", iTaulu[7]);
            Console.WriteLine();




        }
    }

}

