using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zawartosc_Portfela
{
    class Program
    {
        static void Main(string[] args)
        {
            Portfel.MainTask();
        }
    }
    public class Portfel
    {

        public static double[] Amount(double[] portfel)
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                portfel[i] = rnd.Next(21);
            }
            for (int i = 4; i < portfel.Length; i++)
            {
                portfel[i] = rnd.Next(101); ;
            }
            return portfel;
        }

        public static void MainTask()
        {
            try
            {
                double[] value = new double[] { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };
                double[] portfel = new double[15];
                Console.WriteLine("Program sprawdzający czy z portfela użytkownika (kwota generowana losowo) można wypłacić żądaną przez użytkownika kwotę i w jakich nominałach.");
                double money = 0;
                double withdraw,rest;

                Amount(portfel);

                for (int i = 0; i < portfel.Length; i++)
                {
                    money = money + (portfel[i] * value[i]);
                }

                Console.Write("\nObecna wartość Twojego portfela to: ");
                Console.WriteLine(money + " w podanych nominałach:");
                for(int i=0;i<portfel.Length;i++)
                {
                    Console.WriteLine("- {0} x {1} zł", portfel[i], value[i]);
                }

                Console.WriteLine("Podaj jaką kwotę chcesz wypłacić: ");
                withdraw = Convert.ToDouble(Console.ReadLine());
                if(withdraw<=0 || withdraw>money)
                {
                    Console.WriteLine("Podana kwota jest nieprawidłowa.");
                    ReplyTask();
                }
                else
                {
                    Console.WriteLine("\nPieniądze mogą zostać wypłacone w postaci: ");
                    rest = withdraw;
                    int i = 0;
                    while(rest>0)
                    {
                        if (rest >= value[i] && portfel[i]>0)
                        {
                            int valueCount = (int)(rest / value[i]);
                            if(valueCount<= portfel[i])
                            {
                                rest = Math.Round(rest - (valueCount * value[i]), 2);
                                portfel[i] -= valueCount;
                                Console.WriteLine("- {0} x {1} zł", valueCount, value[i]);
                            }
                            else
                            {
                                rest = Math.Round(rest - (portfel[i] * value[i]), 2);
                                Console.WriteLine("- {0} x {1} zł", portfel[i], value[i]);
                                portfel[i] = 0;
                            }
                        }
                        i++;
                    }
                    Console.WriteLine("Pozostała kwota: {0}", Math.Round(money - withdraw));
                    ReplyTask();
                }

                Console.ReadLine();
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
