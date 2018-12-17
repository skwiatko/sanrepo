using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_Zadania3
{
    class zadanie1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polecenie:");
            Console.WriteLine("Napisać program obliczający sumę kwadratów kolejnych liczb naturalnych parzystych nie większych niż podane n.\n");
            int n;
            Console.WriteLine("Podaj liczbę n: ");
            n = Convert.ToInt32(Console.ReadLine());

            SumaKwadratow obj = new SumaKwadratow(n);

            Console.WriteLine("Podana liczba to: {0}", obj.N);
            Console.WriteLine("Suma kwadratow wynosi: {0}", obj.Parzysta(n));

            Console.ReadKey();
        }
    }

    class SumaKwadratow
    {
        private int n;

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

        public SumaKwadratow(int a)
        {
            n = a;
        }

        public int Parzysta(int a)
        {
            int i = 0;
            int suma = 0;

            while (a >= i)
            {
                if (i % 2 == 0)
                {
                    suma = suma + (i * i);
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return suma;

        }
    }
}
