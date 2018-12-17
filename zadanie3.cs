using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program3
    {
        static void Main(string[] args)
        {
            Statyczna obj1 = new Statyczna(4);

            Console.WriteLine(obj1.I);
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Statyczna obj2 = new Statyczna(625);
            Console.WriteLine(obj2.I);
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Statyczna.Zwieksz();
            Console.WriteLine(Statyczna.Liczba);

            Console.ReadLine();
        }
    }
    class Statyczna
    {
        private int i;
        public static int Liczba;

        public Statyczna(int a)
        {
            i = a;
            Statyczna.Zwieksz();
        }

        public int I
        {
            get
            {
                return i;
            }
            set
            {
                i = value;
            }
        }

        public static void Zwieksz ()
        {
            Liczba++;
        }


    }
}
