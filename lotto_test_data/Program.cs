namespace LottoAppi
{
    class Program
    {
        static void Main()
        {   
            Random rnd = new Random();
            int[] lottoNumerot = new int[8];
            int arvottuNumero;

            for (int i = 0; i < lottoNumerot.Length; i++)
            {
                arvottuNumero = rnd.Next(1, 41);

                if (!lottoNumerot.Contains(arvottuNumero))
                {
                    lottoNumerot[i] = arvottuNumero;
                }
                else
                    i--;
            }
            Array.Sort(lottoNumerot, 0, 7);
            Console.Write("Arvotut lottonumerot ovat: ");
            foreach (var item in lottoNumerot)
            {
                Console.Write("{0} ", item);
                if(item == lottoNumerot[6])
                {
                    Console.Write("+ {0}", lottoNumerot[7]);
                    break;
                }
            }            
            Console.WriteLine();
        }
    }

}

