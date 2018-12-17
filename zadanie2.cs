using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumator obj1 = new Sumator();

            Console.WriteLine("Suma: " + obj1.Suma());
            Console.WriteLine("Podziel3: " + obj1.Podziel3());
            Console.WriteLine("Ile elementow: " + obj1.ileElementow());
            obj1.Wypisz();
            Console.WriteLine("\n");
            obj1.Index(2, 5);

            Console.ReadLine();
        }
    }
    class Sumator
    {
        private int[] Liczby = new int[] { 2, 6, 1, 8, 13, 24, 23, 30 };

        public Sumator()
        {
        }

        public int Suma()
        {
            int wynik = 0;

            for (int i = 0; i < Liczby.Length; i++)
            {
                wynik = wynik + Liczby[i];
            }

            return wynik;
        }

        public int Podziel3()
        {
            int wynik = 0;

            for (int i = 0; i < Liczby.Length; i++)
            {
                if (Liczby[i] % 3 == 0)
                {
                    wynik = wynik + Liczby[i];
                }
            }

            return wynik;
        }

        public int ileElementow()
        {
            int ile = 0;

            for (int i = 0; i < Liczby.Length; i++)
            {
                ile = ile + 1;
            }

            return ile;
        }

        public void Wypisz()
        {
            for (int i = 0; i < Liczby.Length; i++)
            {
                Console.Write(Liczby[i] + ", ");
            }
        }

        public void Index(int lowIndex, int highIndex)
        {
            for (int i = 0; i < Liczby.Length; i++)
            {
                if (i >= lowIndex && i <= highIndex)
                {
                    Console.Write(Liczby[i] + ", ");
                }
            }
        }

    }
}
