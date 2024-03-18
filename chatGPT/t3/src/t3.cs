using System;

// uusi keskustelu tehtävänannolle, mikä löytyy t1.cs tiedostosta
class Program
{
    static void Main(string[] args)
    {
        int[] lottoNumbers = GenerateLottoNumbers();
        Array.Sort(lottoNumbers, 0, 7); // Lajitellaan ensimmäiset seitsemän numeroa

        Console.WriteLine("Lottorivi:");
        for (int i = 0; i < lottoNumbers.Length - 1; i++)
        {
            Console.Write(lottoNumbers[i] + "   ");
        }
        Console.WriteLine("+   " + lottoNumbers[lottoNumbers.Length - 1]);
    }

    static int[] GenerateLottoNumbers()
    {
        Random random = new Random();
        int[] numbers = new int[8];

        for (int i = 0; i < 7; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 41); // Generoidaan uusi numero
            } while (Array.Exists(numbers, element => element == randomNumber)); // Tarkistetaan, onko numero jo lottorivissä
            numbers[i] = randomNumber;
        }

        numbers[7] = random.Next(1, 41); // Lisätään lisänumero

        return numbers;
    }
}
