using System;

// t1.cs korjaus pyynnöllä 'tulostus ei toimi oikein'

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
            } while (Array.IndexOf(lottorivi, numero, 0, i) != -1);

            lottorivi[i] = numero;
        }

        // Lajittele varsinaiset lottonumerot suuruusjärjestykseen
        Array.Sort(lottorivi, 0, 7);

        // Arvo lisänumero (1-40, ei saa olla sama kuin varsinaiset numerot)
        int lisänumero;
        do
        {
            lisänumero = rnd.Next(1, 41);
        } while (Array.IndexOf(lottorivi, lisänumero, 0, 7) != -1);

        // Aseta lisänumero lottoriviin
        lottorivi[7] = lisänumero;

        // Tulosta lottorivi
        for (int i = 0; i < 7; i++)
        {
            Console.Write($"{lottorivi[i],3}");
        }

        Console.Write("   +   ");

        Console.WriteLine($"{lottorivi[7]}");
    }
}
