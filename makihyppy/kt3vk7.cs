using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kotihommia
{
    class Program
    {

        static void TuomariPisteet(ref double[] tuomari)
        {
            int i = 0, j = 1;
            for(; ;)
            {
                Console.Write("Tuomarin nro {0} pisteet: ", j);
                tuomari[i] = double.Parse(Console.ReadLine());
                if (i == 4)
                {
                    break;
                }
                i++;
                j++;
                
            }
            Array.Sort(tuomari);
        }

        static void HyppyKysy(out double pituus)
        {
            Console.Write("Kerro kuinka pitkälle mäkihyppääjä hyppäsi(ilmoita tulos 0.5metrin tarkkuudella): ");
            pituus = double.Parse(Console.ReadLine());
        }

        static void Hyppy_Pisteet(double[] tuomarit, out double tulos, double hyppyPituus)
        {
            
            tulos = ((hyppyPituus - KRIITTINENPISTE) * 1.8 + (tuomarit[1] + tuomarit[2] + tuomarit[3]) + 60);
        }

        static void Tulosta(double tulos, double hyppyPituus)
        {
            Console.WriteLine("Mäkihyppääjä hyppäsi {0} metriä. \nHypyn kokonaispisteet: {1}", hyppyPituus, tulos);
        }


        const int KRIITTINENPISTE = 90;
        static void Main(string[] args)
        {
            
            double hyppy_pituus, tulos;           
            double[] tuomarit = new double [5];

            HyppyKysy(out hyppy_pituus);
            TuomariPisteet(ref tuomarit);
            Hyppy_Pisteet(tuomarit, out tulos, hyppy_pituus);
            Tulosta(tulos, hyppy_pituus);



        }
    }
}
