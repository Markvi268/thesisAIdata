﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*

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

namespace Kouluprojekti
{
    class Program
    {
        static void ArvoJaTallennaTiedostoon()
        {
            Random rnd = new Random();
            double dluku;
            StreamWriter sw = new StreamWriter("c:\\datat.txt");
            for (int i = 0; i < 40; i++)
            {
                dluku = rnd.NextDouble() * (5.8 - 1.4) + 1.4;
                sw.WriteLine("{0:f2}", dluku);
            }
            sw.Close();
        }
        static void LueTiedostosta(out double[] taulu)
        {
            taulu = new double[40];
            StreamReader sr = new StreamReader("c:\\datat.txt");
            for (int i = 0; i < taulu.Length; i++)
            {
                taulu[i] = double.Parse(sr.ReadLine());
            }
            sr.Close();
        }
        static void TulostaTiedot(ref double[] taulu)
        {
            double summa = taulu.Sum();
            double minimi = taulu.Min();
            double maksimi = taulu.Max();
            double avg = taulu.Average();
            Console.WriteLine("Summa = {0:f2}", summa);
            Console.WriteLine("Keskiarvo = {0:f2}", avg);
            Console.WriteLine("Pienin arvo = {0:f2}", minimi);
            Console.WriteLine("Suurin arvo = {0:f2}", maksimi);

        }
            
        
        static void Main(string[] args)
        {
            ArvoJaTallennaTiedostoon();
            double[] taulu;
            LueTiedostosta(out taulu);
            TulostaTiedot(ref taulu);

        }
    }
}
