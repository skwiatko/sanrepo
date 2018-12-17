using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_Zadania3
{
    class zadanie2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polecenie:");
            Console.WriteLine("Napisz program obliczający sumę cyfr podanej liczby naturalnej.\n");
            Console.WriteLine("Podaj liczbę naturalną: ");
            int n = Convert.ToInt32(Console.ReadLine());
            sumaCyfr obj = new sumaCyfr(n);

            Console.WriteLine("Suma cyfr podanej liczby to: {0}", obj.dodaj(n));

            Console.ReadKey();
        }
    }

    class sumaCyfr
    {
        private int x;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public sumaCyfr(int a)
        {
            x = a;
        }

        public int dodaj(int a)
        {
            int suma = 0;
            while (a != 0)
            {
                suma += a % 10;
                a /= 10;
            }

            return suma;
        }

    }
}
