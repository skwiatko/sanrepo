using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a,b;
            Console.WriteLine("Podaj liczbe do dodania: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj liczbe do odjecia: ");
            b = Convert.ToInt32(Console.ReadLine());

            liczenie obj1 = new liczenie();
            liczenie obj2 = new liczenie();
            liczenie obj3 = new liczenie(9);
            obj1.W = 5;
            obj2.W = 2;

            Console.WriteLine("OBIEKT1\nWartosc: " + obj1.W + "\nSuma: " + obj1.Dodaj(a) + "\nRóżnica: " + obj1.Odejmij(b));
            Console.WriteLine("\nOBIEKT2\nWartosc: " + obj2.W + "\nSuma: " + obj2.Dodaj(a) + "\nRóżnica: " + obj2.Odejmij(b));
            Console.WriteLine("\nOBIEKT3\nWartosc: " + obj3.W + "\nSuma: " + obj3.Dodaj(a) + "\nRóżnica: " + obj3.Odejmij(b));

            Console.ReadLine();
        }
    }
    class liczenie
    {
        private int wartosc;

        public liczenie()
        {
        }

        public liczenie(int a)
        {
            wartosc = a;
        }

        public int W
        {
            get
            {
                return wartosc;
            }
            set
            {
                wartosc = value;
            }
        }


        public int Dodaj(int a)
        {
            wartosc += a;
            return wartosc;
        }

        public int Odejmij(int a)
        {
            wartosc -= a;
            return wartosc;
        }

    }
}

