using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Java_zadanie_1
{
    class Program_1
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.Write("Podaj wartosc dla a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj wartość dla b: ");
            b = Convert.ToInt32(Console.ReadLine());

            if (b < a)
            {
                Console.WriteLine("Wartość b musi być większa od wartości a");
            }
            else
            {
                Console.WriteLine("Liczby całkowite z zakresu od " + a + " do " + b + " to: ");
                while (a <= b)
                {
                    if (a < b)
                    {
                        Console.Write(+a + ", ");
                        a++;

                    }
                    else if (a == b)
                    {
                        Console.Write(a);
                        a++;
                    }
                    else break;
                }
            }

            Console.ReadLine();
        }
    }
}