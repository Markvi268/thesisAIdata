using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* KT3 */

namespace ETA18KP
{
    class Program
    {
        static void KysyHypynPituus(out double x)
        {
            Console.Write("Hypyn pituus :  ");
            x = double.Parse(Console.ReadLine());

        }
        static void KysyTuomareidenPisteet(out double[] t)
        {
            int i;
            t = new double[5];

            for (i = 0; i < t.Length; i++)
            {
                Console.Write("{0} tuomarin pisteet :", i + 1);
                t[i] = double.Parse(Console.ReadLine());

            }
            Array.Sort(t);
            for (i = 0; i < t.Length; i++)
            {
                if (i == t[0])
                {
                    i++;
                }
                if (i == t[4])
                {
                    i--;
                }
            }
            Console.Write(t);
        }

        static void LaskeHypynPisteet(double x, double y, double[] t, out double a)
        {
            double b, c, d;
            b = t[1];
            c = t[2];
            d = t[3];

            a = (x - y) * 1.8 + 60.0 + b + c + d;

        }
        static void Tulosta(double pituus, double tulos)
        {
            Console.WriteLine("HYPYNPITUUS : {0}", pituus);
            Console.WriteLine("PISTEET : {0}", tulos);
        }




        static void Main(string[] args)
        {

            double kriittinen = 90;
            double hypynpituus;
            double[] tuomaripisteet;
            double pisteet;


            KysyHypynPituus(out hypynpituus);

            KysyTuomareidenPisteet(out tuomaripisteet);

            LaskeHypynPisteet(hypynpituus, kriittinen, tuomaripisteet, out pisteet);

            Tulosta(hypynpituus, pisteet);



        }
    }
}
