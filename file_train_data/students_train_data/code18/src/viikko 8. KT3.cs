﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{/*
 KT3

Arvo 40 kpl liukulukuja väliltä 1.4 – 5.8 ja kirjoita ne datat.txt tiedostoon allekkain.
Älä käytä taulukkoa tässä vaiheessa.


Sen jälkeen luo 40 alkioinen double-taulukko ja lue arvot tiedostosta taulukkoon. 
Tämän jälkeen tulosta taulukon lukujen summa, keskiarvo, minimiarvo ja maksimiarvo.


Käytä funktioita:

ArvoJaTallennaTiedostoon

LueTiedostosta

TulostaTiedot
 */
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rand = new Random();
            StreamWriter sw = new StreamWriter("D:\\txt.txt");
            ;
            double i, arvot;
            for (i = 0; i <= 39; i++)
            {
                arvot = rand.NextDouble() * 1.4 + 4.4;
                sw.WriteLine(arvot);
            }
            sw.Close();
        }

        static void LueTiedostosta(out double[] taulu)
        {
            taulu = new double[40];
            StreamReader sr = new StreamReader("D:\\txt.txt");

            double luku;
            
            int i;
            for (i=0; i<taulu.Length; i++)
            {
                luku = double.Parse(sr.ReadLine());
                taulu[i] = luku;
            }
            sr.Close();
        }
        
        static void TulostaTiedot (double [] t)
        {
            double keskiarvo, min, max;
             int i, j;

            Array.Sort(t);
            max = t.Max();
            min = t.Min();

            double summa = 0;
            
            for(i = 0; i <39; i++)
            {
                summa = summa + t[i];
            }
            keskiarvo = summa / 40;
            
            
            Console.WriteLine("SUMMA {0:f2}",summa);
            Console.WriteLine("MINIMI {0:f2}",min);
            Console.WriteLine("MAXIMI{0:f2}",max);
            Console.WriteLine("KA {0:f2}", keskiarvo);

        }
        static void Main(string[] args)
        {

            ArvoJaTallennaTiedostoon();

            LueTiedostosta(out double [] taulu);

            TulostaTiedot(taulu);

        }

    }
}