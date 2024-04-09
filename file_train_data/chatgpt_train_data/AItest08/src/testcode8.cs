/*KT3
Luo C# ohjelma joka tekee seuraavaa:

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain. 
Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.

Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
*/

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ArvoJaTallennaTiedostoon();
        
        double[] numbers = new double[40];
        LueTiedostosta(numbers);

        TulostaTiedot(numbers);
    }

    static void ArvoJaTallennaTiedostoon()
    {
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter("datat.txt"))
        {
            for (int i = 0; i < 40; i++)
            {
                double randomNumber = 1.4 + (random.NextDouble() * (5.8 - 1.4));
                writer.WriteLine(randomNumber);
            }
        }
    }

    static void LueTiedostosta(double[] numbers)
    {
        using (StreamReader reader = new StreamReader("datat.txt"))
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    numbers[i] = double.Parse(line);
                }
            }
        }
    }

    static void TulostaTiedot(double[] numbers)
    {
        double sum = 0;
        double min = double.MaxValue;
        double max = double.MinValue;

        foreach (double number in numbers)
        {
            sum += number;
            if (number < min)
                min = number;
            if (number > max)
                max = number;
        }

        double average = sum / numbers.Length;

        Console.WriteLine("Summa: " + sum);
        Console.WriteLine("Keskiarvo: " + average);
        Console.WriteLine("Minimiarvo: " + min);
        Console.WriteLine("Maksimiarvo: " + max);
    }
}
