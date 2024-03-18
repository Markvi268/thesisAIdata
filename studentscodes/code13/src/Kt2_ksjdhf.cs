using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        static void Main()
        {
            double[,] taulu = new double[5, 4];
            int i, j;

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Console.Write("Anna arvo [{0}, {1}] kohtaan : ", i, j);
                    taulu[i, j] = double.Parse(Console.ReadLine());
                }
                
                }
            }
        }
    }



           
            







        
    

            
                
       
            
        
            
            








        
    
