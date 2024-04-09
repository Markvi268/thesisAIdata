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

// Kysytty 30.3.2024 uusi kysely

using System;

class Program
{
    static void Main()
    {
        // Luodaan lotto-taulukko, jossa 7 varsinaista numeroa ja 1 lisänumero
        int[] lottoTaulukko = new int[8];
        
        // Arvotaan varsinaiset lottonumerot
        Random random = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = random.Next(1, 41); // Arvotaan luku väliltä 1-40
            } while (Array.Exists(lottoTaulukko, element => element == arvottuNumero)); // Tarkistetaan, ettei numero ole jo lottonumeroina
            
            lottoTaulukko[i] = arvottuNumero;
        }
        
        // Järjestetään varsinaiset lottonumerot suuruusjärjestykseen
        Array.Sort(lottoTaulukko, 0, 7);
        
        // Arvotaan lisänumero
        int lisänumero;
        do
        {
            lisänumero = random.Next(1, 41); // Arvotaan luku väliltä 1-40
        } while (Array.Exists(lottoTaulukko, 0, 7, element => element == lisänumero)); // Tarkistetaan, ettei lisänumero ole jo varsinaisena lottonumerona
        
        lottoTaulukko[7] = lisänumero; // Asetetaan lisänumero lotto-taulukkoon
        
        // Tulostetaan lottonumerot
        for (int i = 0; i < 7; i++)
        {
            Console.Write(lottoTaulukko[i] + "   ");
        }
        Console.Write("+   " + lottoTaulukko[7]);
    }
}
