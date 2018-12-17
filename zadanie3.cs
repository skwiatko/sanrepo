using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_3
{
    class Program_3
    {
        static void Main(string[] args)
        {
            double l, n, silnia;
            Console.Write("Podaj liczbę n, dla której zostanie policzona silnia: ");
            n = Convert.ToDouble(Console.ReadLine());
            l = n;
            silnia = n;

            do
            {
                n--;
                l = l * n;
            }
            while (n > 1);

            Console.WriteLine("Silnia liczby " + silnia + " wynosi " + l + ".");

            Console.ReadLine();
        }
    }
}
