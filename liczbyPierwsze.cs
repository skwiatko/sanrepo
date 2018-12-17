using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_Zadanie3
{
    class zadanie3
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Polecenie:");
            Console.WriteLine("Napisz program wypisujący liczby pierwsze nie większe niż podane n.\n");
            Console.WriteLine("Podaj liczbę naturalną: ");
            a = Convert.ToInt32(Console.ReadLine());
            Pierwsze liczba = new Pierwsze(a);
            liczba.wypiszPierwsze(a);

            Console.ReadKey();
        }
    }

    class Pierwsze
    {
        private int n;

        public Pierwsze(int a)
        {
            n = a;
        }

        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }

        static Boolean pierw(long a)
        { 
            for (long j = 2; j <= (a / 2); j++)
                if (a % j == 0)
                    return false;
            return true;
        }

        public void wypiszPierwsze(int x)
        {
            for (long i = 1; i <= x; i++)
            {
                if (pierw(i))
                {
                        Console.Write("{0}, ", i);
                        //Console.WriteLine("Liczba pierwsza - \t" + i);
                }
            }
        }
    }
}
