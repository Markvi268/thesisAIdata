using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

 */
namespace kt1
{
    class kt1
    {
        static void KysyHypynPituus(out double p)
        {
            Console.WriteLine("Anna hypyn pituus: ");
            p = double.Parse(Console.ReadLine());
        }
        static void KysyTuomareidenPisteet(double[]t)
        {
            int i;
            for(i=0; i< t.Length; i++)
            {
                Console.WriteLine("Anna pisteet (0-20): ");
                t[i] = double.Parse(Console.ReadLine());
            }
        }
        static void LaskeHypynPisteet(out double pisteet, double pituus, double[]t)
        {
            pisteet = (pituus - kriittinenPiste) * 1.8 + t.Sum() - t.Min() - t.Max();
        }
        static void Tulosta(double pituus, double pisteet)
        {
           Console.WriteLine("Hypyn pituus: {0:f1} Pisteet: {1:f1}", pituus, pisteet);
        }
        const double kriittinenPiste = 90;

        static void Main(string[] args)
        {
            double pituus, pisteet;
            double[] t = new double[5];

            KysyHypynPituus(out pituus);
            KysyTuomareidenPisteet(t);
            LaskeHypynPisteet(out pisteet, pituus, t);
            Tulosta(pituus, pisteet); 
        }
    }
}
