using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
 @author: Sylwester Kwiatkowski
 @university: Społeczna Akademia Nauk

 */
 
namespace POLab2_v2
{
    static class Obliczenia
    {
        public static double Dodaj(double a, double b)
        {
            return a + b;
        }

        public static double Odejmij(double a, double b)
        {
            return a - b;
        }

        public static double Pomnoz(double a, double b)
        {
            return a * b;
        }

        public static void Podziel(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Nie dzielimy przez zero!");
            }
            else
            {
                Console.WriteLine("Iloraz: " + a / b);
            }
        }

        public static void Potega(long a, long b)
        {
            if (b == 0)
            {
                Console.WriteLine("Potęga a do b: 1");
            }
            else
            {
                long wynik;
                wynik = a;
                for (int i = 1; i < b; i++)
                {
                    wynik = wynik * a;
                }
                Console.WriteLine("Potęga a do b: " + wynik);
            }
        }

        public static double Pierwiastek(double a, double b)
        {
            return Math.Pow(a, 1/b);
        }
    }

    class Zadanie1
    {
        public void Zad1()
        {
            try
            {
                double a, b;
                Console.Write("Podaj liczbe a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Podaj liczbe b: ");
                b = Convert.ToDouble(Console.ReadLine());

                long c = Convert.ToInt64(a);
                long d = Convert.ToInt64(b);


                Console.WriteLine("\nSuma: {0}", Obliczenia.Dodaj(a, b));
                Console.WriteLine("Różnica: {0}", Obliczenia.Odejmij(a, b));
                Console.WriteLine("Iloczyn: {0}", Obliczenia.Pomnoz(a, b));
                Obliczenia.Podziel(a, b);
                Obliczenia.Potega(c, d);
                Console.WriteLine("Pierwiastek: {0}", Obliczenia.Pierwiastek(a, b));


                Console.ReadLine();
            }
            catch (FormatException fEx) //wyjątek gdy wpisane będą litery
            {
                Console.WriteLine(fEx.Message);
            }
            catch (OverflowException OverEx) //gdy wartość podana w konsoli będzie poza zakresem liczbowym wartości typu int
            {
                Console.WriteLine(OverEx.Message);
            }
            catch (ArithmeticException ArgEx) //wyjątek przy dzieleniu przez 0
            {
                Console.WriteLine(ArgEx.Message);
            }
            catch (Exception Ex) //inne wyjątki
            {
                Console.WriteLine("Coś poszło nie tak");
            }
        }
    }
}
