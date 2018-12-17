using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_2
{
    class Program_2
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Podaj wartosc dla a: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj wartosc dla b: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj wartosc dla c: ");
            c = Convert.ToInt32(Console.ReadLine());


            if (a < b)
            {
                Console.WriteLine("Liczby całkowite z zakresu od " + a + " do " + b + " podzielne przez " + c + " to: ");
                do
                {
                    if (a < b)
                    {
                        if (a % c == 0)
                        {
                            Console.Write(+a + ", ");
                            a += c;
                        }
                        else
                        {
                            a++;
                        }
                    }
                }
                while (a < b);
            }
            else if (b < a)
            {
                Console.WriteLine("Liczby całkowite z zakresu od " + b + " do " + a + " podzielne przez " + c + " to: ");
                while (b < a)
                {
                    if (b % c == 0)
                    {
                        Console.Write(+b + ", ");
                        b += c;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wartości a oraz b są równe!");
            }

            Console.ReadLine();
       
        }
    }
}
