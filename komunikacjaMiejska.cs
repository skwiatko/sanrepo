using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class KomunikacjaMiejska
    {
        static void Main(string[] args)
        {
            try
            {
                int odp;
                Zajezdnia Lista = new Zajezdnia();
                ZajezdniaAutobusowa zajStalowa = new ZajezdniaAutobusowa("Zajezdnia Stalowa", "Autobusowa");
                ZajezdniaAutobusowa zajOstrobramska = new ZajezdniaAutobusowa("Zajezdnia Ostrobramska", "Autobusowa");
                ZajezdniaTramwajowa zajWola = new ZajezdniaTramwajowa("Zajezdnia Wola", "Tramwajowa");
                ZajezdniaTramwajowa zajPraga = new ZajezdniaTramwajowa("Zajezdnia Praga", "Tramwajowa");

                //Autobusy w zajezdni Stalowa
                Autobus auto523 = new Autobus(70, 523, 230, zajStalowa);
                Autobus auto123 = new Autobus(70, 123, 170, zajStalowa);
                Autobus auto169 = new Autobus(60, 169, 194, zajStalowa);
                Autobus auto120 = new Autobus(65, 120, 205, zajStalowa);
                Autobus auto112 = new Autobus(90, 112, 352, zajStalowa);
                //Autobusy w zajezdni Ostrobramska
                Autobus auto105 = new Autobus(70, 105, 562, zajOstrobramska);
                Autobus auto227 = new Autobus(60, 227, 343, zajOstrobramska);
                Autobus auto500 = new Autobus(85, 500, 400, zajOstrobramska);
                Autobus auto188 = new Autobus(65, 188, 266, zajOstrobramska);
                Autobus auto512 = new Autobus(90, 512, 438, zajOstrobramska);

                //Tramwaje w zajezdni Praga
                Tramwaj tram24 = new Tramwaj(75, 24, 3, zajPraga);
                Tramwaj tram22 = new Tramwaj(65, 22, 3, zajPraga);
                Tramwaj tram3 = new Tramwaj(50, 3, 1, zajPraga);
                Tramwaj tram6 = new Tramwaj(55, 6, 2, zajPraga);
                Tramwaj tram9 = new Tramwaj(80, 9, 3, zajPraga);
                //Tramwaje w zajezdni Wola
                Tramwaj tram26 = new Tramwaj(80, 26, 2, zajWola);
                Tramwaj tram1 = new Tramwaj(75, 1, 3, zajWola);
                Tramwaj tram15 = new Tramwaj(60, 15, 3, zajWola);
                Tramwaj tram7 = new Tramwaj(55, 7, 2, zajWola);
                Tramwaj tram11 = new Tramwaj(70, 11, 1, zajWola);

                //Przydzielenie zajezdni Stalowa Autobusów
                zajStalowa.AUTOBUSY.Add(auto523);
                zajStalowa.AUTOBUSY.Add(auto123);
                zajStalowa.AUTOBUSY.Add(auto169);
                zajStalowa.AUTOBUSY.Add(auto120);
                zajStalowa.AUTOBUSY.Add(auto112);

                //Przydzielenie zajezdni Ostrobramska Autobusów
                zajOstrobramska.AUTOBUSY.Add(auto105);
                zajOstrobramska.AUTOBUSY.Add(auto227);
                zajOstrobramska.AUTOBUSY.Add(auto500);
                zajOstrobramska.AUTOBUSY.Add(auto188);
                zajOstrobramska.AUTOBUSY.Add(auto512);

                //Przydzielenie zajezdni Praga Tramwajów
                zajPraga.TRAMWAJE.Add(tram24);
                zajPraga.TRAMWAJE.Add(tram22);
                zajPraga.TRAMWAJE.Add(tram3);
                zajPraga.TRAMWAJE.Add(tram6);
                zajPraga.TRAMWAJE.Add(tram9);

                //Przydzielenie zajezdni Wola Tramwajów
                zajWola.TRAMWAJE.Add(tram26);
                zajWola.TRAMWAJE.Add(tram1);
                zajWola.TRAMWAJE.Add(tram15);
                zajWola.TRAMWAJE.Add(tram7);
                zajWola.TRAMWAJE.Add(tram11);

                //Dodanie zajezdni do zajezdni autobusowych
                Lista.zajAutobusowe.Add(zajStalowa); 
                Lista.zajAutobusowe.Add(zajOstrobramska);

                //Dodanie zajezdni do zajezdni tramwajowych
                Lista.zajTramwajowe.Add(zajPraga);
                Lista.zajTramwajowe.Add(zajWola);

                //Lista.WypiszAutobusowe();
                //Console.WriteLine(Lista.WypiszNazweZajAut(1));

                Console.WriteLine("**********************************");
                Console.WriteLine("Wybierz zajezdnię:");
                Console.WriteLine("1. Zajezdnie autobusowe");
                Console.WriteLine("2. Zajezdnie tramwajowe");
                odp = Convert.ToInt32(Console.ReadLine());
                switch (odp)
                {
                    case 1:
                        Console.WriteLine("**********************************");
                        Console.WriteLine("1. Zajezdnia Stalowa");
                        Console.WriteLine("2. Zajezdnia Ostrobramska");
                        odp = Convert.ToInt32(Console.ReadLine());
                        switch (odp)
                        {
                            case 1:
                                Console.WriteLine("**********************************");
                                Console.WriteLine("1. Wypisz opis całej zajezdni");
                                Console.WriteLine("2. Wypisz listę pojazdów");
                                odp = Convert.ToInt32(Console.ReadLine());
                                switch (odp)
                                {
                                    case 1:
                                        Console.WriteLine("##################################");
                                        zajStalowa.WypiszOpis();
                                        Console.WriteLine("##################################");
                                        break;
                                    case 2:
                                        Console.WriteLine("##################################");
                                        zajStalowa.WypiszAutobusy();
                                        Console.WriteLine("##################################");
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("**********************************");
                                Console.WriteLine("1. Wypisz opis całej zajezdni");
                                Console.WriteLine("2. Wypisz listę pojazdów");
                                odp = Convert.ToInt32(Console.ReadLine());
                                switch (odp)
                                {
                                    case 1:
                                        Console.WriteLine("##################################");
                                        zajOstrobramska.WypiszOpis();
                                        Console.WriteLine("##################################");
                                        break;
                                    case 2:
                                        Console.WriteLine("##################################");
                                        zajOstrobramska.WypiszAutobusy();
                                        Console.WriteLine("##################################");
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("**********************************");
                        Console.WriteLine("1. Zajezdnia Wola");
                        Console.WriteLine("2. Zajezdnia Praga");
                        odp = Convert.ToInt32(Console.ReadLine());
                        switch (odp)
                        {
                            case 1:
                                Console.WriteLine("**********************************");
                                Console.WriteLine("1. Wypisz opis całej zajezdni");
                                Console.WriteLine("2. Wypisz listę pojazdów");
                                odp = Convert.ToInt32(Console.ReadLine());
                                switch (odp)
                                {
                                    case 1:
                                        Console.WriteLine("##################################");
                                        zajWola.WypiszOpis();
                                        Console.WriteLine("##################################");
                                        break;
                                    case 2:
                                        Console.WriteLine("##################################");
                                        zajWola.WypiszTramwaje();
                                        Console.WriteLine("##################################");
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("**********************************");
                                Console.WriteLine("1. Wypisz opis całej zajezdni");
                                Console.WriteLine("2. Wypisz listę pojazdów");
                                odp = Convert.ToInt32(Console.ReadLine());
                                switch (odp)
                                {
                                    case 1:
                                        Console.WriteLine("##################################");
                                        zajPraga.WypiszOpis();
                                        Console.WriteLine("##################################");
                                        break;
                                    case 2:
                                        Console.WriteLine("##################################");
                                        zajPraga.WypiszTramwaje();
                                        Console.WriteLine("##################################");
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
        
                Console.WriteLine("**********************************");

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
                Console.WriteLine("Coś poszło nie tak\n"+Ex.Message);
            }
            Console.ReadKey();
        }
    }
}
