using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzeregHarmoniczny
{
    class Program
    {
        static void Main(string[] args)
        {
            Szeregi.MainTask();
            Console.ReadLine();
        }
    }

    public static class Szeregi
    {
        public static void MainTask()
        {
            try
            {
                int n;
                Console.WriteLine("Program obliczający sumę n liczb w szeregu harmonicznym.");
                Console.Write("Podaj liczbę elementów do zsumowania: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Liczba elementów musi być większa od 0!");
                    ReplyTask();
                }
                else
                {
                    Console.WriteLine("Czy chcesz zmienić rząd szeregu? Domyślnie 1. [T/N]");

                    char answer = Convert.ToChar(Console.Read());
                    switch (answer)
                    {
                        case 't':
                        case 'T':
                            Console.Write("Podaj rząd szeregu: ");
                            var test = Console.ReadLine();
                            var rz = Convert.ToDouble(Console.ReadLine());
                            double rza = Convert.ToDouble(rz);
                            Console.WriteLine("Sumą podanego szeregu jest: {0}", HarmonicznyRzad(n, rz));
                            ReplyTask();
                            break;
                        case 'n':
                        case 'N':
                            Console.WriteLine("Sumą podanego szeregu jest: {0}", Harmoniczny(n));
                            Console.ReadLine();
                            ReplyTask();
                            break;
                        default:
                            ReplyTask();
                            break;
                    }
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
        public static double Harmoniczny(int n)
        {
            double r = 1;
            for(double i=2;i<n+1;i++)
            {
                r = r + (1 / i);
            }
            return r;
        }

        public static double HarmonicznyRzad(int n, double rz)
        {
            double r = 1;
            for (double i = 2; i < n + 1; i++)
            {
                r = r + (1 / (double)Math.Pow(i,rz));
            }
            return r;
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
            switch (answer)
            {
                case 'n':
                case 'N':
                    HorizontalLine();
                    Console.WriteLine("Koniec programu. Naciśnij dowolny przycisk..");
                    Console.Read();
                    Environment.Exit(0);
                    break;
                case 't':
                case 'T':
                    Console.WriteLine("Poczekaj chwilę..");
                    Console.ReadLine();
                    Console.Clear();
                    MainTask();
                    break;
                default:
                    HorizontalLine();
                    Console.WriteLine("Wprowadzono błędną odpowiedź.");
                    Console.WriteLine("Poczekaj chwilę..");
                    Console.ReadLine();
                    ReplyTask();
                    break;
            }
        }
    }
}
