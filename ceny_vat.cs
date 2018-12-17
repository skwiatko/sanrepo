using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceny_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Podatki.MainTask();

            Console.ReadLine();
        }
    }

    public static class Podatki
    {
        public static void MainTask()
        {
            try
            {
                double n = 0;
                Console.WriteLine("Program obliczający wartość VAT oraz cenę brutto.");
                Console.Write("Podaj kwotę netto [n>0]: ");
                n = Convert.ToDouble(Console.ReadLine());
                if (n > 0)
                {
                    int p = 0;
                    SetVAT(ref p, n);

                }
                else
                {
                    Console.WriteLine("Podana kwota jest nieprawidłowa.");
                    ReplyTask();
                }
            }
            catch (FormatException fEx) //wyjątek gdy wpisane będą litery
            {
                //Console.WriteLine(fEx.Message);
                Console.WriteLine("Podany znak nie jest cyfrą!");
                Console.ReadLine();
                ReplyTask();
            }
            catch (OverflowException OverEx) //gdy wartość podana w konsoli będzie poza zakresem liczbowym wartości typu int
            {
                //Console.WriteLine(OverEx.Message);
                Console.WriteLine("Podana liczba jest z poza zakresu!");
                Console.ReadLine();
                ReplyTask();
            }
            catch (ArithmeticException ArgEx) //wyjątek przy dzieleniu przez 0
            {
                //Console.WriteLine(ArgEx.Message);
                Console.WriteLine("Nie dzielimy przez 0!");
                Console.ReadLine();
                ReplyTask();
            }
            catch (Exception Ex) //inne wyjątki
            {
                Console.WriteLine("Coś poszło nie tak");
                Console.ReadLine();
                ReplyTask();
            }
        }
        public static double StawkaVAT(int p,double n)
        {
            switch (p)
            {
                case 1: return n + n * 0.04;
                case 2: return n + n * 0.05;
                case 3: return n + n * 0.07;
                case 4: return n + n * 0.08;
                case 5: return n + n * 0.23;
                default: return n;
            }
        }
        public static string VAT(int p)
        {
            switch(p)
            {
                case 1: return "4%";
                case 2: return "5%";
                case 3: return "7%";
                case 4: return "8%";
                case 5: return "23%";
                default: return "0%";
            }
        }
        public static void HorizontalLine()
        {
            Console.WriteLine("————————————————————————————————————————————");
        }
        public static void ReplyTask()
        {
            char answer = 'x';
            HorizontalLine();
            Console.WriteLine("\n\nCzy chcesz powótrzyć wykonywanie zadania? [T/N]");
            answer = Convert.ToChar(Console.Read());
            if (answer == 'n' || answer == 'N')
            {
                HorizontalLine();
                Console.WriteLine("Koniec programu. Naciśnij dowolny przycisk..");
                Console.Read();
                Environment.Exit(0);
            }
            else if (answer == 't' || answer == 'T')
            {
                Console.WriteLine("Poczekaj chwilę..");
                Console.ReadLine();
                Console.Clear();
                MainTask();
            }
            else
            {
                HorizontalLine();
                Console.WriteLine("Wprowadzono błędną odpowiedź.");
                Console.WriteLine("Poczekaj chwilę..");
                Console.ReadLine();
                ReplyTask();
            }
        }

        public static void SetVAT(ref int p, double n)
        {
            Console.WriteLine("Wybierz stawkę VAT [1-5]: ");
            Console.WriteLine("\t1. 4%\n\t2. 5%\n\t3. 7%\n\t4. 8%\n\t5. 23%");
            p = Convert.ToInt32(Console.ReadLine());
            if (p > 0 && p < 6)
            {
                Result(p, n);
                Console.ReadLine();
                ReplyTask();
            }
            else
            {
                Console.WriteLine("Podano liczbę spoza zakresu [1-5].");
                SetVAT(ref p, n);
            }
        }

        public static void Result(int p, double n)
        {
            Console.WriteLine("Rezultat: ");
            Console.WriteLine("Netto: \t{0} zł", n);
            Console.WriteLine("VAT: \t{0}", VAT(p));
            Console.WriteLine("Brutto:  {0} zł", StawkaVAT(p, n));
        }
    }
}
