using System;
/*
Luo c# ohjelma: Lotossa arvotaan seitsemän (7) varsinaista numeroa ja yksi (1) lisänumero. Numerot ovat väliltä 1-40.

Esittele kahdeksan (8) alkioinen lotto-taulukko ja arvo siihen lottonumerot (7 ensimmäistä
on siis varsinaisia lottonumeroita ja viimeinen on lisänumero). Muista, että samaa numeroa
ei saa tulla lottoriviin eli mieti miten voisit tarkistaa onko arvottu numero jo lottorivissä entuudestaan ja silloin sen tilalle pitää arpoa uusi numero.

Tulosta lopuksi lottorivi seuraavasti:

1   4   12   16   19   25   31   +   13

HUOM!! seitsemän varsinaista numeroa on lajiteltu suuruusjärjestykseen! Mutta
lisänumeroa ei tietenkään saa ottaa lajitteluun mukaan! Löytysköhän Array.Sort:sta sellainen
ominaisuus, jolla tämän saisi ratkaistua? Voisi esimerkiksi kertoa, että mistä indeksistä eteenpäin lajittellaan niin ja niin monta alkiota...

*/
class Program
{
    static void Main()
    {
        // Alusta lottorivi taulukko
        int[] lottorivi = new int[8];

        // Alusta Random-luokka satunnaislukujen arpomiseen
        Random rnd = new Random();

        // Arvo varsinaiset lottonumerot (1-40)
        for (int i = 0; i < 7; i++)
        {
            int numero;
            // Arvo uusi numero, kunnes se ei ole jo lottorivissä
            do
            {
                numero = rnd.Next(1, 41);
            } while (Array.IndexOf(lottorivi, numero) != -1);

            lottorivi[i] = numero;
        }

        // Lajittele varsinaiset lottonumerot suuruusjärjestykseen
        Array.Sort(lottorivi, 0, 7);

        // Arvo lisänumero (1-40, ei saa olla sama kuin varsinaiset numerot)
        int lisänumero;
        do
        {
            lisänumero = rnd.Next(1, 41);
        } while (Array.IndexOf(lottorivi, lisänumero) != -1);

        // Aseta lisänumero lottoriviin
        lottorivi[7] = lisänumero;

        // Tulosta lottorivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottorivi[i]);
            if (i < 7)
                Console.Write("   ");
            else
                Console.Write("   +   ");
        }
        Console.WriteLine();
    }
}
