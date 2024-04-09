using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt3._5.cs
{
    class Program
    { const int KRIITTINENPISTE = 90;
        static void KysyHypynPisteet(out double x)
        {
            Console.WriteLine("Anna hypyn pituus (0,5m välein) : ");
            x = double.Parse(Console.ReadLine());
        }
        static void KysyTuomareidenPisteet(out double y)
        {
            int i;
            double luku = 0, min = 0, max = 0, summa = 0;
            y = 0;

            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("Anna tuomarin {0} pisteet(väliltä 0-20, 0,5 pisteen välein) : ", i + 1);
                luku = double.Parse(Console.ReadLine());

                if (i == 0)
                {
                    min = max = luku;
                }

                else
                {
                    if (luku > max)
                    {
                        max = luku; 
                    }
                    else if (luku < min)
                    {
                        min = luku;
                    }

                }

                summa = summa + luku;

                y = summa - min - max;

            }
           

        }
        static void LaskeHypynPisteet(out double z, double x, double y)
        {
            z = (x - KRIITTINENPISTE) * 1.8 + y + 60;
        }
        static void Tulosta(double x, double z)
        {
            Console.Clear();
            Console.WriteLine("Hypyn pituus oli {0:f2}m ja pisteet {1:f2}.", x, z);
        }
        static void Main()
        {
            double pituus, tyylipisteet, pisteet;

            KysyHypynPisteet(out pituus);
            KysyTuomareidenPisteet(out tyylipisteet);
            LaskeHypynPisteet(out pisteet, pituus, tyylipisteet);
            Tulosta(pituus, pisteet);
        }
    }
}
