using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schemat_Hornera
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program rozwiązujący równania za pomocą schematu Hornera. Maksymalny stopień wielomianu = 10.");
            Wielomiany.MainTask();
            Console.ReadLine();
        }
    }

    public static class Wielomiany
    {
        public static void MainTask()
        {
            try
            {
                //Console.ReadLine();
                int deg, c = 0;
                Console.WriteLine("Podaj stopień wielomianu (do jakiej maksymalnej potęgi jest podniesiony x) [3-10]: ");
                deg = Convert.ToInt32(Console.ReadLine());

                if (deg < 3 || deg >10)
                {
                    if(deg==2) { Console.WriteLine("Wykorzystaj program do rozwiązywania równania kwadratowego."); }
                    else if(deg<2) { Console.WriteLine("To już nie będzie równanie..."); ReplyTask(); }
                    else { Console.WriteLine("Przepraszam, największy wielomian jaki jestem w stanie podzielić jest w 10 potędze."); ReplyTask(); }
                }
                else
                {
                    List<double> nums = new List<double>();
                    List<double> numsResult = new List<double>();
                    List<string> stopienW = new List<string>
                { "", "x", "x^2", "x^3", "x^4", "x^5", "x^6", "x^7", "x^8", "x^9", "x^10" };
                    nums.Clear();
                    numsResult.Clear();

                    Console.WriteLine("Podaj współczynniki wielomianu [każdy w osobnej linii]. ");
                    for (int i = 0; i < deg + 1; i++)
                    {
                        Console.WriteLine("Współczynnik numer {0}", i + 1);
                        double num = Convert.ToDouble(Console.ReadLine());
                        nums.Add(num);
                    }
                    Console.WriteLine("\nPodaj przez jaki duwmian dzielimy wielomian x-[c]: ");
                    c = Convert.ToInt32(Console.ReadLine());

                    HorizontalLine();
                    Console.WriteLine("Podany wielomian to: ");

                    ReturnPolynomial(nums, stopienW, deg);

                    Console.WriteLine("\nWielomian dzielimy przez dwumian x-{0}\n", c);
                    Calculate(nums, numsResult, c);

                    HorizontalLine();
                    Console.WriteLine("Wynikiem działania jest: ");
                    ReturnNewPolynomial(numsResult, stopienW, deg, c);

                    ReplyTask();
                    Console.ReadLine();
                }
            }
            catch (FormatException fEx) //wyjątek gdy wpisane będą litery
            {
                //Console.WriteLine(fEx.Message);
                Console.WriteLine("Podany znak nie jest cyfrą!");
                ReplyTask();
            }
        }
        public static List<double> Calculate(List<double> nums, List<double> numsResult, int c)
        {
            numsResult.Add(nums[0]);
            for (int i = 1; i < nums.Count; i++)
            {
                numsResult.Add(numsResult[i - 1] * c + nums[i]);
            }
            return numsResult;
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
            if(answer=='n' || answer == 'N')
            {
                HorizontalLine();
                Console.WriteLine("Koniec programu. Naciśnij dowolny przycisk..");
                Console.Read();
                Environment.Exit(0);
            }
            else if(answer=='t' || answer =='T')
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

        public static void ReturnPolynomial(List<double> nums, List<string> stopienW, int deg)
        {
            int sto = deg;
            for (int i = 0; i <= deg; i++)
            {
                if (i == 0)
                {
                    Console.Write(nums[i] + "" + stopienW[sto]);
                }
                else
                {
                    if (nums[i] > 0)
                    {
                        if (nums[i] == 1)
                        {
                            Console.Write(" + " + stopienW[sto]);
                        }
                        else
                        {
                            Console.Write(" + " + nums[i] + "" + stopienW[sto]);
                        }
                    }
                    else if (nums[i] < 0)
                    {
                        if (nums[i] == -1)
                        {
                            Console.Write(" - " + stopienW[sto]);
                        }
                        else
                        {
                            Console.Write(" - " + nums[i] * -1 + "" + stopienW[sto]);
                        }
                    }
                }
                sto--;
            }

        }

        public static void ReturnNewPolynomial(List<double> numsResult, List<string> stopienW, int deg, int c)
        {
            int sto = deg - 1;
            Console.Write("(x - {0})", c);
            for (int i = 0; i <= deg; i++)
            {
                if (i == 0)
                {
                    if (numsResult[i] != 0)
                    {
                        Console.Write("(" + numsResult[i] + "" + stopienW[sto]);
                    }
                }
                else if (i <= deg - 1)
                {
                    if (numsResult[i] > 0)
                    {
                        if (numsResult[i] == 1)
                        {
                            Console.Write(" + {0}", stopienW[sto]);
                        }
                        else
                        {
                            Console.Write(" + {0}{1}", numsResult[i], stopienW[sto]);
                        }
                    }
                    else if (numsResult[i] < 0)
                    {
                        if (numsResult[i] == -1)
                        {
                            Console.Write(" - {0}", stopienW[sto]);
                        }
                        else
                        {
                            Console.Write(" - {0}{1}", numsResult[i] * -1, stopienW[sto]);
                        }
                    }
                }
                else
                {
                    if (numsResult[i] > 0)
                    {
                        Console.Write(") + {0} reszty", numsResult[i]);
                    }
                    else if (numsResult[i] < 0)
                    {
                        Console.Write(") - {0} reszty", numsResult[i] * -1);
                    }
                }
                sto--;
            }Console.WriteLine("");
        }
    }
}