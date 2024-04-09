using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        const double KR_PISTE = 90.0;

        static void KysyHypynPituus(out double pit)
        {
            Console.Write("Anna hypyn pituus : ");
            pit = double.Parse(Console.ReadLine());
        }

        static void KysyTuomareidenPisteet(double[] t)
        {
            int i;

            for (i = 0; i < t.Length; i++)
            {
                Console.Write("Anna {0} tuomarin pisteet : ", i + 1);
                t[i] = double.Parse(Console.ReadLine());

                if (t[i] < 0 || t[i] >20 || t[i] % 0.5 != 0)
                {
                    i--;
                }
            }
        }
        
        static void LaskeHypynPisteet(out double kp, double pit, double tp)
        {
            kp = (pit - KR_PISTE) * 1.8 + tp + 60;
        }

        static void Tulosta(double pit, double kp)
        {
            Console.WriteLine("Hypyn pituus : {0:f1} m", pit);
            Console.WriteLine("Pisteet      : {0:f1}", kp);
        }

        static void Main(string[] args)
        {
            double pituus, kokonaisPisteet, tuomareidenPisteet;
            double[] tuomarit = new double[5];

            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(tuomarit);

            tuomareidenPisteet = tuomarit.Sum() - tuomarit.Min() - tuomarit.Max();

            LaskeHypynPisteet(out kokonaisPisteet, pituus, tuomareidenPisteet);
            Tulosta(pituus, kokonaisPisteet);
        }
    }
}
