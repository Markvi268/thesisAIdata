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
        // Luodaan lotto-taulukko
        int[] lottoRivi = new int[8];
        
        // Arvotaan varsinaiset lottonumerot
        Random rnd = new Random();
        for (int i = 0; i < 7; i++)
        {
            int arvottuNumero;
            do
            {
                arvottuNumero = rnd.Next(1, 41); // Arvotaan numero väliltä 1-40
                
            } while (Array.Exists(lottoRivi, element => element == arvottuNumero)); // Tarkistetaan, ettei arvottu numero ole jo lotto-rivissä
            
            lottoRivi[i] = arvottuNumero;
        }
        
        // Arvotaan lisänumero
        int lisäNumero;
        do
        {
            lisäNumero = rnd.Next(1, 41);
        } while (Array.Exists(lottoRivi, element => element == lisäNumero)); // Tarkistetaan, ettei lisänumero ole jo lotto-rivissä
        lottoRivi[7] = lisäNumero;
        
        // Järjestetään varsinaiset numerot suuruusjärjestykseen
        Array.Sort(lottoRivi, 0, 7);
        
        // Tulostetaan lotto-rivi
        for (int i = 0; i < 8; i++)
        {
            Console.Write(lottoRivi[i]);
            if (i == 6)
            {
                Console.Write("   +   "); // Erotellaan lisänumero varsinaisista numeroista
            }
            else if (i < 7)
            {
                Console.Write("   "); // Lisätään välilyönti numeroiden väliin
            }
        }
        
        Console.WriteLine(); // Rivinvaihto
    }
}
