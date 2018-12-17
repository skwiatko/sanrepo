using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    class Program
    {
        public static void LiczbaGraczy(ref int liczbaGraczy)
        {
            Console.WriteLine("Podaj liczbę graczy (2-6): ");
            liczbaGraczy = Convert.ToInt32(Console.ReadLine());

            if (liczbaGraczy > 6 || liczbaGraczy < 2)
            {
                Console.WriteLine("Liczba graczy nie jest z zakresu (2-6)!");
            }
        }
        public static void NickGracza(Gracz gracz, ref int nickGracza)
        {
            Console.Write("Podaj nick {0} gracza: ", nickGracza);
            gracz.nick = Console.ReadLine();
            nickGracza++;
        }
        static void Main(string[] args)
        {
            try
            {
            //Definiowanie obiektów
            Stol Stol = new Stol();
            Gracz Gracz1 = new Gracz();
            Gracz Gracz2 = new Gracz();
            Gracz Gracz3 = new Gracz();
            Gracz Gracz4 = new Gracz();
            Gracz Gracz5 = new Gracz();
            Gracz Gracz6 = new Gracz();

            //Lista, dzięki której pętla do while wie kiedy został tylko jeden gracz z kartami.
            Gracz[] GraczeGracze = new Gracz[] { Gracz1, Gracz2, Gracz3, Gracz4, Gracz5, Gracz6 };
            List<Gracz> ListaGraczy = new List<Gracz>();
            ListaGraczy.Add(Gracz1);
            ListaGraczy.Add(Gracz2);
            ListaGraczy.Add(Gracz3);
            ListaGraczy.Add(Gracz4);
            ListaGraczy.Add(Gracz5);
            ListaGraczy.Add(Gracz6);

            //Zmienna zawierająca liczbę graczy
            int liczbaGraczy = 0;
            int nickGracza = 1;

            // zoladz - trefl, dzwonek - karo, wino - pik, czerwien - kier
            //Tworzenie obiektów kart
            int w = 13;
            foreach (String figura in Karta.Figury)
            {
                foreach (String kolor in Karta.Kolory)
                {
                    Stol.Talia_kart.Add(new Karta(kolor, figura, w));
                }
                w--;
            }
            //Zmienne trzymające, najnowszą kartę na stole - porównanie kart dotyczy tych o najwyższych indeksach w liście
            int n = 0;
            int a = 0;
            //Liczba tur
            int x = 1;

            Console.WriteLine("Witaj w grze w wojnę. Autor: Sylwester Kwiatkowski, SAN Informatyka");
            do
            {
                LiczbaGraczy(ref liczbaGraczy);
            } while (liczbaGraczy > 6 || liczbaGraczy < 2);

            for (int i = 1; i <= liczbaGraczy; i++)
            {
                NickGracza(GraczeGracze[i - 1], ref nickGracza);
            }



            //Miejsce na nadanie nicków..

            //
            Console.WriteLine("Losowanie kart dla {0} graczy...", liczbaGraczy);
            //Losowanie kart dla graczy
            Operacje.Losuj(liczbaGraczy, Stol, Gracz1, Gracz2, Gracz3, Gracz4, Gracz5, Gracz6);
            Console.ReadLine();
            Console.WriteLine("Karty zostały rozdane.");
            Console.ReadLine();


            do
            {
                //Jeżeli pozostanie tylko jeden gracz w liście pętla wykona się ostatni raz i poinformuje gracza o wygranej
                if (Gracz1.wRece.Count == 0) ListaGraczy.Remove(Gracz1);
                if (Gracz2.wRece.Count == 0) ListaGraczy.Remove(Gracz2);
                if (Gracz3.wRece.Count == 0) ListaGraczy.Remove(Gracz3);
                if (Gracz4.wRece.Count == 0) ListaGraczy.Remove(Gracz4);
                if (Gracz5.wRece.Count == 0) ListaGraczy.Remove(Gracz5);
                if (Gracz6.wRece.Count == 0) ListaGraczy.Remove(Gracz6);
                //Rozdanie kart na stół przez graczy
                Operacje.Rozdanie(liczbaGraczy, Gracz1, Gracz2, Gracz3, Gracz4, Gracz5, Gracz6, ref n, ref x, ref a);
            } while (ListaGraczy.Count > 1);



            Console.ReadLine();

            //Wyliczenie ilości kart w ręce po zakończeniu gry, zwycięzca posiada 52 karty podczas gdy reszta 0
            Console.WriteLine("Karty {0}: {1}", Gracz1.nick, Gracz1.wRece.Count);
            Console.WriteLine("Karty {0}: {1}", Gracz2.nick, Gracz2.wRece.Count);
            if (liczbaGraczy >= 3) Console.WriteLine("Karty {0}: {1}", Gracz3.nick, Gracz3.wRece.Count);
            if (liczbaGraczy >= 4) Console.WriteLine("Karty {0}: {1}", Gracz4.nick, Gracz4.wRece.Count);
            if (liczbaGraczy >= 5) Console.WriteLine("Karty {0}: {1}", Gracz5.nick, Gracz5.wRece.Count);
            if (liczbaGraczy >= 6) Console.WriteLine("Karty {0}: {1}", Gracz6.nick, Gracz6.wRece.Count);


            Console.ReadLine();
            }
            catch (FormatException fEx) //wyjątek gdy wpisane będą litery
            {
                Console.WriteLine(fEx.Message); Console.ReadLine();
            }
            catch (OverflowException OverEx) //gdy wartość podana w konsoli będzie poza zakresem liczbowym wartości typu int
            {
                Console.WriteLine(OverEx.Message); Console.ReadLine();
            }
            catch (ArithmeticException ArgEx) //wyjątek przy dzieleniu przez 0
            {
                Console.WriteLine(ArgEx.Message); Console.ReadLine();
            }
            catch (Exception Ex) //inne wyjątki
            {
                Console.WriteLine(Ex.Message + " Coś poszło nie tak"); Console.ReadLine();
            }
        }

    }
    
    public class Karta
    {
        private String kolor;
        private String wartosc;
        private int waga;

        public String Kolor { get { return kolor; } set { kolor = value; } }
        public String Wartosc { get { return wartosc; } set { wartosc = value; } }
        public int Waga { get { return waga; } set { waga = value; } }

        public Karta(String kol, String war, int wa)
        {
            kolor = kol;
            wartosc = war;
            waga = wa;
        }

        // zoladz - trefl, dzwonek - karo, wino - pik, czerwien - kier
        public static String[] Kolory = new String[4] //tablica kolorów
        {
                /* trefl */
                "Trefl",
                /* karo */
                "Karo",
                /* pik */
                "Pik",
                /* kier */
                "Kier"
        };
        public static String[] Figury = new String[13] // tablica figur tj. wartosci
        {
                "A", "K", "D", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2"
        };
    }

    public class Gracz
    {
        public String nick;
        public Queue<Karta> wRece = new Queue<Karta>();
        public List<Karta> naStole = new List<Karta>();
    }

    //Klasa stół powstała tylko ze względu na ułatwienie operacji
    public class Stol
    {
        public List<Karta> Talia_kart = new List<Karta>();


    }

    //Klasa operacje zawiera wszystkie metody wykonywane przez grę
    public static class Operacje
    {
        //Metoda losuj - losuje losową kartę z LISTY talii kart po czym przydziela ją kolejnemu graczowi (zależne od ilości graczy)
        public static void Losuj(int liczbaGraczy, Stol table, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6)
        {
            Random rnd = new Random();
            for (int i = 1; i <= liczbaGraczy + 1; i++)
            {
                if (i == 1 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);  //Losowanie karty z talii
                    gracz1.wRece.Enqueue(table.Talia_kart[los]);    //Przydzielenie do KOLEJKI gracza zwanej ręką losowej karty z LISTY kart
                    table.Talia_kart.RemoveAt(los);                 //Usunięcie karty z listy, aby nie wylosować jej ponownie
                }
                else if (i == 2 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);
                    gracz2.wRece.Enqueue(table.Talia_kart[los]);
                    table.Talia_kart.RemoveAt(los);
                }
                else if (i == 3 && liczbaGraczy >= 3 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);
                    gracz3.wRece.Enqueue(table.Talia_kart[los]);
                    table.Talia_kart.RemoveAt(los);
                }
                else if (i == 4 && liczbaGraczy >= 4 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);
                    gracz4.wRece.Enqueue(table.Talia_kart[los]);
                    table.Talia_kart.RemoveAt(los);
                }
                else if (i == 5 && liczbaGraczy >= 5 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);
                    gracz5.wRece.Enqueue(table.Talia_kart[los]);
                    table.Talia_kart.RemoveAt(los);
                }
                else if (i == 6 && liczbaGraczy >= 6 && table.Talia_kart.Count > 0)
                {
                    int los = rnd.Next(0, table.Talia_kart.Count);
                    gracz6.wRece.Enqueue(table.Talia_kart[los]);
                    table.Talia_kart.RemoveAt(los);
                }
                //Jeżeli w Talii nie ma już kart losowanie kończy się
                else if (table.Talia_kart.Count == 0)
                {
                    break;
                }
                //A jeżeli jakieś zostały zaczyna się kolejna tura losowania
                else
                {
                    i = 0;
                }
            }
        }

        //Metoda wybrania pierwszej karty z kolejki do wylozenia na stol
        public static void WezKarte(Gracz gracz)
        {
            if (gracz.wRece.Count > 0)
            {
                gracz.naStole.Add(gracz.wRece.Peek());  //Dodaj do kolejki pierwszą kartę z ręki gracza nie usuwając jej
                gracz.wRece.Dequeue();                  //Usuń kartę z ręki gracza
            }
            else { Console.WriteLine("Gracz nie ma kart!"); }   //Ta część się nie wykonuje, ponieważ sprawdzenie warunku czy gracz ma karty odbywa się w Rozdaniu, jeżeli nie ma, ta metoda jest omijana
        }

        //Metoda rozdająca karty graczy na stół i wyświetlająca kto jaką kartę zagrał, Jeżeli tylko jeden gracz ma karty wyświetla się informaca
        //W ilu turach (zmniejszonych o 1, ponieważ w ostatniej turze tylko jeden gracz wykłada karty, więc wygrał wcześniej) gracz wygrał
        public static void Rozdanie(int liczbaGraczy, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n, ref int x, ref int a)
        {
            List<Gracz> Lista = new List<Gracz>();
            Console.WriteLine("----------Tura: " + x + "-----------");

            if (Lista.Count == 1)
            {
                Koniec(Lista[0]);
            }
            else
            {
                if (gracz1.wRece.Count > 0)
                {
                    WezKarte(gracz1);  //Wez z reki gracza karte
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[n].Wartosc, gracz1.naStole[n].Kolor); //Wyswietl jaka to karta
                    Lista.Add(gracz1); //Dodaj gracza do listy graczy (zawsze będzie minimum 1)
                }
                else { Lista.Remove(gracz1); } // Jeżeli gracz nie ma kart to usuń go z listy (ale i tak go tam nie powinno być, bo nie został dodany
                if (gracz2.wRece.Count > 0)
                {
                    WezKarte(gracz2);
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[n].Wartosc, gracz2.naStole[n].Kolor);
                    Lista.Add(gracz2);
                }
                else { Lista.Remove(gracz2); }
                if (liczbaGraczy >= 3 && gracz3.wRece.Count > 0)
                {
                    WezKarte(gracz3);
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz3.nick, gracz3.naStole[n].Wartosc, gracz3.naStole[n].Kolor);
                    Lista.Add(gracz3);
                }
                else { Lista.Remove(gracz3); }
                if (liczbaGraczy >= 4 && gracz4.wRece.Count > 0)
                {
                    WezKarte(gracz4);
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz4.nick, gracz4.naStole[n].Wartosc, gracz4.naStole[n].Kolor);
                    Lista.Add(gracz4);
                }
                else { Lista.Remove(gracz4); }
                if (liczbaGraczy >= 5 && gracz5.wRece.Count > 0)
                {
                    WezKarte(gracz5);
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz5.nick, gracz5.naStole[n].Wartosc, gracz5.naStole[n].Kolor);
                    Lista.Add(gracz5);
                }
                else { Lista.Remove(gracz5); }
                if (liczbaGraczy >= 6 && gracz6.wRece.Count > 0)
                {
                    WezKarte(gracz6);
                    Console.WriteLine("{0} zagrał: {1} {2}", gracz6.nick, gracz6.naStole[n].Wartosc, gracz6.naStole[n].Kolor);
                    Lista.Add(gracz6);
                }
                else { Lista.Remove(gracz6); }

                //W przypadku gdy tylko jeden gracz ma karty informacja o wygranej
                if (Lista.Count == 1)
                {
                    Koniec(Lista[0]);
                    Console.WriteLine("");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("");
                    Console.WriteLine("Inni gracze nie mają kart. Wygrał gracz o nicku {0}! Wygrał w {1} turach!", Lista[0].nick, x - 1);
                    Console.WriteLine("");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("");
                }
                else
                {
                    //Jeżeli więcej niż jeden gracz ma karty to je porównujemy
                    Operacje.Porownanie(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n, ref a);
                }
            }
            //Zwiększamy liczbę tur
            x++;

        }

        //Metoda karty do wojny to metoda, która pobiera kolejne karty od maksymalnie 4 graczy (tylu może być w wojnie)
        //Działanie bardzo podobne jak w przypadku WezKarte
        //Metoda nie jest wykorzystywana!!!
        public static void KartyDoWojny(Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, int y)
        {

            if (gracz1.wRece.Count > 1)
            {
                y++;
                WezKarte(gracz1);
                Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                y++;
                WezKarte(gracz1);
                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                y = y - 2;//dopisane
            }
            else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
            {
                y++;
                WezKarte(gracz1);
                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                y = y - 1;//dopisane
            }
        }

        //Metoda działająca jak rozdanie - z tą różnicą, że pobiera karty od maksymalnie 4 graczy, które póżniej dzięki indeksowi y są porównywane
        //Powinna być tu wykorzystana metoda KartyDoWojny, jednak implementacja mnie przerosła ;)
        public static void Wojna(int liczbaGraczy, int ileWWojnie, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n, ref int a)
        {
            int y = 0;
            List<Gracz> wWojnie = new List<Gracz>();
            switch (ileWWojnie)
            {
                case 2:
                    if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0)
                    {
                        Console.WriteLine("Gracze nie mają kart !");
                        Console.WriteLine("REMIS!!! Karty wracają do właścicieli!");
                        Koniec(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6);
                        break;
                    }
                    else
                    {
                        if (gracz1.wRece.Count > 0 && gracz2.wRece.Count > 0)
                        {
                            Console.WriteLine("----------Wojna!-----------");
                            //System.Threading.Thread.Sleep(1000);
                            if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                y++;

                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz2);
                            }
                            else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz1);
                            }
                            else { wWojnie.Remove(gracz1); wWojnie.Remove(gracz2); }


                            if (wWojnie.Count == 1)
                            {
                                if (wWojnie[0] == gracz1)
                                { Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n); }
                                else if(wWojnie[0] == gracz2)
                                { Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n); }
                                ElseIf(wWojnie[0]);//Metoda elseif to tylko wyświetlenie informacji kto wygrał jeżeli przeciwnik nie ma kart do wojny
                            }
                            //System.Threading.Thread.Sleep(2000);
                            //Nie korzystamy już ze zmiennej y tylko z a.
                            a = a + y;
                            PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                        }

                        else if (gracz1.wRece.Count > 0 && gracz2.wRece.Count == 0)
                        {
                            ElseIf(gracz1); //Metoda elseif to tylko wyświetlenie informacji kto wygrał jeżeli przeciwnik nie ma kart do wojny
                            Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count > 0)
                        {
                            ElseIf(gracz2);
                            Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                    }
                    break;
                case 3:
                    if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count == 0)
                    {
                        Console.WriteLine("Gracze nie mają kart !");
                        Console.WriteLine("REMIS!!! Karty wracają do właścicieli!");
                        Koniec(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6);
                        break;
                    }
                    else
                    {
                        if (gracz1.wRece.Count > 0 && gracz2.wRece.Count > 0 && gracz3.wRece.Count > 0)
                        {
                            Console.WriteLine("----------Wojna!-----------");
                            //System.Threading.Thread.Sleep(1000);
                            if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1 && gracz3.wRece.Count > 1)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                y++;

                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz3);
                            }
                            else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz3);
                            }
                            else { wWojnie.Remove(gracz1); wWojnie.Remove(gracz2); wWojnie.Remove(gracz2); }
                            //System.Threading.Thread.Sleep(2000);

                            if (wWojnie.Count == 1)
                            {
                                if (wWojnie[0] == gracz1)
                                { Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n); }
                                else if (wWojnie[0] == gracz2)
                                { Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n); }
                                else if (wWojnie[0] == gracz3)
                                { Win(liczbaGraczy, gracz3, gracz2, gracz1, gracz4, gracz5, gracz6, ref n); }
                                ElseIf(wWojnie[0]);//Metoda elseif to tylko wyświetlenie informacji kto wygrał jeżeli przeciwnik nie ma kart do wojny
                            }

                            a = a + y;
                            PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                        }

                        else if (gracz1.wRece.Count > 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count == 0)
                        {
                            ElseIf(gracz1);
                            Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count > 0 && gracz3.wRece.Count == 0)
                        {
                            ElseIf(gracz2);
                            Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count > 0)
                        {
                            ElseIf(gracz3);
                            Win(liczbaGraczy, gracz3, gracz2, gracz1, gracz4, gracz5, gracz6, ref n);
                        }
                    }
                    break;
                case 4:
                    if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1 && gracz3.wRece.Count > 1 && gracz4.wRece.Count > 1)
                    {
                        if (gracz1.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz1);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz1);
                        }
                        else { wWojnie.Remove(gracz1); }
                        //n = n - 2;
                        if (gracz2.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz2);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz2);
                        }
                        else { wWojnie.Remove(gracz2); }
                        if (gracz3.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz3);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz3);
                        }
                        else { wWojnie.Remove(gracz3); }
                        if (gracz4.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            //y--; //dopisane
                            wWojnie.Add(gracz4);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2 || gracz4.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            wWojnie.Add(gracz1);
                        }
                        else { wWojnie.Remove(gracz4); }
                        a = a + y;
                        PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void WojnaWojny(int liczbaGraczy, int ileWWojnie, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n, ref int a, ref int y)
        {
            List<Gracz> wWojnie = new List<Gracz>();
            switch (ileWWojnie)
            {
                case 2:
                    if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0)
                    {
                        Console.WriteLine("Gracze nie mają kart !");
                        Console.WriteLine("REMIS!!! Karty wracają do właścicieli!");
                        Koniec(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6);
                        break;
                    }
                    else
                    {
                        if (gracz1.wRece.Count > 0 && gracz2.wRece.Count > 0)
                        {
                            Console.WriteLine("----------Wojna!-----------");
                            //System.Threading.Thread.Sleep(1000);
                            if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                y++;

                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz2);
                            }
                            else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz1);

                            }
                            else { wWojnie.Remove(gracz1); wWojnie.Remove(gracz2); }


                            if (wWojnie.Count == 1)
                            {
                                ElseIf(wWojnie[0]);//Metoda elseif to tylko wyświetlenie informacji kto wygrał jeżeli przeciwnik nie ma kart do wojny
                            }
                            //System.Threading.Thread.Sleep(2000);
                            //Nie korzystamy już ze zmiennej y tylko z a.
                            PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                        }

                        else if (gracz1.wRece.Count > 0 && gracz2.wRece.Count == 0)
                        {
                            ElseIf(gracz1); //Metoda elseif to tylko wyświetlenie informacji kto wygrał jeżeli przeciwnik nie ma kart do wojny
                            Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count > 0)
                        {
                            ElseIf(gracz2);
                            Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                    }
                    break;
                case 3:
                    if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count == 0)
                    {
                        Console.WriteLine("Gracze nie mają kart !");
                        Console.WriteLine("REMIS!!! Karty wracają do właścicieli!");
                        Koniec(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6);
                        break;
                    }
                    else
                    {
                        if (gracz1.wRece.Count > 0 && gracz2.wRece.Count > 0 && gracz3.wRece.Count > 0)
                        {
                            Console.WriteLine("----------Wojna!-----------");
                            //System.Threading.Thread.Sleep(1000);
                            if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1 && gracz3.wRece.Count > 1)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                y++;

                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz3);
                                a = a + 1;
                            }
                            else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2)
                            {
                                y++;
                                WezKarte(gracz1);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                                WezKarte(gracz2);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                                WezKarte(gracz3);
                                Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                                wWojnie.Add(gracz2);
                                wWojnie.Add(gracz1);
                                wWojnie.Add(gracz3);
                            }
                            else { wWojnie.Remove(gracz1); wWojnie.Remove(gracz2); wWojnie.Remove(gracz2); }
                            //System.Threading.Thread.Sleep(2000);
                            PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                        }

                        else if (gracz1.wRece.Count > 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count == 0)
                        {
                            ElseIf(gracz1);
                            Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count > 0 && gracz3.wRece.Count == 0)
                        {
                            ElseIf(gracz2);
                            Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n);
                        }
                        else if (gracz1.wRece.Count == 0 && gracz2.wRece.Count == 0 && gracz3.wRece.Count > 0)
                        {
                            ElseIf(gracz3);
                            Win(liczbaGraczy, gracz3, gracz2, gracz1, gracz4, gracz5, gracz6, ref n);
                        }
                    }
                    break;
                case 4:
                    if (gracz1.wRece.Count > 1 && gracz2.wRece.Count > 1 && gracz3.wRece.Count > 1 && gracz4.wRece.Count > 1)
                    {
                        if (gracz1.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz1);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz1);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz1.nick, gracz1.naStole[y].Wartosc, gracz1.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz1);
                        }
                        else { wWojnie.Remove(gracz1); }
                        //n = n - 2;
                        if (gracz2.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz2);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz2);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz2.nick, gracz2.naStole[y].Wartosc, gracz2.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz2);
                        }
                        else { wWojnie.Remove(gracz2); }
                        if (gracz3.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y = y - 2;//dopisane
                            wWojnie.Add(gracz3);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz3);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz3.nick, gracz3.naStole[y].Wartosc, gracz3.naStole[y].Kolor);
                            y = y - 1;//dopisane
                            wWojnie.Add(gracz3);
                        }
                        else { wWojnie.Remove(gracz3); }
                        if (gracz4.wRece.Count > 1)
                        {
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            //y--; //dopisane
                            wWojnie.Add(gracz4);
                        }
                        else if (gracz1.wRece.Count < 2 || gracz2.wRece.Count < 2 || gracz3.wRece.Count < 2 || gracz4.wRece.Count < 2)
                        {
                            y++;
                            WezKarte(gracz4);
                            Console.WriteLine("{0} zagrał ostatecznie: {1} {2}", gracz4.nick, gracz4.naStole[y].Wartosc, gracz4.naStole[y].Kolor);
                            wWojnie.Add(gracz1);
                        }
                        else { wWojnie.Remove(gracz4); }
                        a = a + y;
                        PorownanieWojna(liczbaGraczy, ileWWojnie, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref y, ref n, ref a);
                    }
                    break;
                default:
                    break;
            }
        }

        //Zamiennik powielania kodu
        public static void ElseIf(Gracz gracz1)
        {
            Console.WriteLine("");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("");
            Console.WriteLine("Przeciwnik gracza {0} nie ma kart do wojny. Wojnę wygrał gracz o nicku {0}!", gracz1.nick);
            Console.WriteLine("");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("");
        }

        //Metoda porównania kart na stole zależna od ilości graczy. Sprawdza kto ma najwyższą kartę i informuje o jego wygranej.
        //W przypadku wojny ustawia graczy z najwyższymi kartami na początku, aby ułatwić porównanie w wojnie
        public static void Porownanie(int liczbaGraczy, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n, ref int a)
        {
            //Tablice wykorzystywane do porównań
            int[] waga = new int[6] { 0, 0, 0, 0, 0, 0 };
            int[] wojna = new int[] { 0, 0, 0, 0, 0, 0 };
            //Lista graczy wykorzystana w porównaniu
            Gracz[] listGracze = new Gracz[] { gracz1, gracz2, gracz3, gracz4, gracz5, gracz6 };
            int max = 0;
            int ilewygranych = 0;
            Gracz[] doWojny = new Gracz[6] { null, null, null, null, null, null };
            int z = 0;
            int y = 2;

            //Przypisanie wagi karty do tablicy Waga, każdy ma swój indeks
            if (gracz1.naStole.Count > 0) { waga[0] = listGracze[0].naStole[n].Waga; }
            if (gracz2.naStole.Count > 0) { waga[1] = listGracze[1].naStole[n].Waga; }
            if (liczbaGraczy >= 3 && gracz3.naStole.Count > 0) { waga[2] = listGracze[2].naStole[n].Waga; }
            if (liczbaGraczy >= 4 && gracz4.naStole.Count > 0) { waga[3] = listGracze[3].naStole[n].Waga; }
            if (liczbaGraczy >= 5 && gracz5.naStole.Count > 0) { waga[4] = listGracze[4].naStole[n].Waga; }
            if (liczbaGraczy >= 6 && gracz6.naStole.Count > 0) { waga[5] = listGracze[5].naStole[n].Waga; }

            //Porównanie w tablicy zmiennej waga, jeżeli jest najwyższa zapisuje się jako max
            for (int i = 0; i < liczbaGraczy; i++)
            {
                if (waga[i] > max)
                {
                    max = waga[i];
                }
            }

            //Sprawdzenie ilu graczy ma maxa
            for (int i = 0; i < liczbaGraczy; i++)
            {
                if (waga[i] == max)
                {
                    wojna[i] = 1;
                    ilewygranych++;
                }
                else { wojna[i] = 0; }
            }

            //Jeżeli tylko jeden gracz ma maxa - wygrał
            if (ilewygranych == 1)
            {
                if (wojna[0] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz1.nick, gracz1.naStole[n].Wartosc, gracz1.naStole[n].Kolor); Win(liczbaGraczy, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n); }
                if (wojna[1] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz2.nick, gracz2.naStole[n].Wartosc, gracz2.naStole[n].Kolor); Win(liczbaGraczy, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n); }
                if (wojna[2] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz3.nick, gracz3.naStole[n].Wartosc, gracz3.naStole[n].Kolor); Win(liczbaGraczy, gracz3, gracz2, gracz1, gracz4, gracz5, gracz6, ref n); }
                if (wojna[3] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz4.nick, gracz4.naStole[n].Wartosc, gracz4.naStole[n].Kolor); Win(liczbaGraczy, gracz4, gracz2, gracz3, gracz1, gracz5, gracz6, ref n); }
                if (wojna[4] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz5.nick, gracz5.naStole[n].Wartosc, gracz5.naStole[n].Kolor); Win(liczbaGraczy, gracz5, gracz2, gracz3, gracz4, gracz1, gracz6, ref n); }
                if (wojna[5] == 1) { Console.WriteLine("$$$$ {0} wygrał to rozdanie kartą {1} {2}! $$$$", gracz6.nick, gracz6.naStole[n].Wartosc, gracz6.naStole[n].Kolor); Win(liczbaGraczy, gracz6, gracz2, gracz3, gracz4, gracz5, gracz1, ref n); }
            }
            //Jeżeli 2 i więcej graczy ma maxa wyszukiwani są gracze z maxem i ustawiani w tablicy. Indeks z to najniższe indeksy, więc Ci gracze będą wprowadzani do
            //metody jako pierwsi, y to kolejne indeksy, bez znaczenia w przypadku wojny
            else if (ilewygranych == 2)
            {
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[y] = listGracze[i];
                        y++;
                    }
                }
                Wojna(liczbaGraczy, ilewygranych, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a);
            }
            else if (ilewygranych == 3)
            {
                y++;
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[y] = listGracze[i];
                        y++;
                    }
                }
                Wojna(liczbaGraczy, ilewygranych, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a);
            }
            else if (ilewygranych == 4)
            {
                y = y + 2;
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[y] = listGracze[i];
                        y++;
                    }
                }
                Wojna(liczbaGraczy, ilewygranych, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a);
            }
            else { }
        }

        //Porównanie w przypadku wojny, wprowadzone na potrzeby programu, Działanie zbliżone do Porownanie
        public static void PorownanieWojna(int liczbaGraczy, int ilewygranych, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int y, ref int n, ref int a) //Metoda porównuje karty w przypadku 'wojny po wojnie'
        {
            int[] waga = new int[6] { 0, 0, 0, 0, 0, 0 };
            int[] wojna = new int[] { 0, 0, 0, 0, 0, 0 };
            Gracz[] listGracze = new Gracz[] { gracz1, gracz2, gracz3, gracz4, gracz5, gracz6 };
            int max = 0;
            int ilewygranych2 = 0;
            int z = 0;
            int rest;
            Gracz[] doWojny = new Gracz[6] { null, null, null, null, null, null };

            if (gracz1.naStole.Count > 0) { waga[0] = listGracze[0].naStole[a].Waga; }
            if (gracz2.naStole.Count > 0) { waga[1] = listGracze[1].naStole[a].Waga; }
            if (ilewygranych >= 3 && gracz3.naStole.Count > 0) { waga[2] = listGracze[2].naStole[a].Waga; }
            if (ilewygranych >= 4 && gracz4.naStole.Count > 0) { waga[3] = listGracze[3].naStole[a].Waga; }

            for (int i = 0; i < ilewygranych; i++)
            {
                if (waga[i] > max)
                {
                    max = waga[i];
                }
            }

            for (int i = 0; i < ilewygranych; i++)
            {
                if (waga[i] == max)
                {
                    wojna[i] = 1;
                    ilewygranych2++;
                }
                else { wojna[i] = 0; }
            }
            if (ilewygranych2 == 1)
            {
                if (wojna[0] == 1) { Console.WriteLine("$$$$ {0} wygrał wojnę kartą {1} {2}! $$$$", gracz1.nick, gracz1.naStole[a].Wartosc, gracz1.naStole[a].Kolor); WinWojna(liczbaGraczy, ilewygranych, gracz1, gracz2, gracz3, gracz4, gracz5, gracz6, ref n, ref y, ref a); /*System.Threading.Thread.Sleep(2000);*/ }
                if (wojna[1] == 1) { Console.WriteLine("$$$$ {0} wygrał wojnę kartą {1} {2}! $$$$", gracz2.nick, gracz2.naStole[a].Wartosc, gracz2.naStole[a].Kolor); WinWojna(liczbaGraczy, ilewygranych, gracz2, gracz1, gracz3, gracz4, gracz5, gracz6, ref n, ref y, ref a); /*System.Threading.Thread.Sleep(2000);*/ }
                if (wojna[2] == 1) { Console.WriteLine("$$$$ {0} wygrał wojnę kartą {1} {2}! $$$$", gracz3.nick, gracz3.naStole[a].Wartosc, gracz3.naStole[a].Kolor); WinWojna(liczbaGraczy, ilewygranych, gracz3, gracz2, gracz1, gracz4, gracz5, gracz6, ref n, ref y, ref a); /*System.Threading.Thread.Sleep(2000);*/ }
                if (wojna[3] == 1) { Console.WriteLine("$$$$ {0} wygrał wojnę kartą {1} {2}! $$$$", gracz4.nick, gracz4.naStole[a].Wartosc, gracz4.naStole[a].Kolor); WinWojna(liczbaGraczy, ilewygranych, gracz4, gracz2, gracz3, gracz1, gracz5, gracz6, ref n, ref y, ref a); /*System.Threading.Thread.Sleep(2000);*/ }
            }
            else if (ilewygranych2 == 2)
            {
                rest = 2;
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[rest] = listGracze[i];
                        rest++;
                    }
                }
                WojnaWojny(liczbaGraczy, ilewygranych2, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a, ref a);
            }
            else if (ilewygranych2 == 3)
            {
                rest = 3;
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[rest] = listGracze[i];
                        rest++;
                    }
                }
                WojnaWojny(liczbaGraczy, ilewygranych2, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a, ref a);
            }
            else if (ilewygranych2 == 4)
            {
                rest = 4;
                for (int i = 0; i < liczbaGraczy; i++)
                {
                    if (wojna[i] == 1)
                    {
                        doWojny[z] = listGracze[i];
                        z++;
                    }
                    else
                    {
                        doWojny[rest] = listGracze[i];
                        rest++;
                    }
                }
                WojnaWojny(liczbaGraczy, ilewygranych2, doWojny[0], doWojny[1], doWojny[2], doWojny[3], doWojny[4], doWojny[5], ref n, ref a, ref a);
            }
        }

        //Metoda przydziela karty wygranemu graczowi. Jak prawie wszystkie zależna od ilości graczy
        public static void Win(int liczbaGraczy, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n)
        {
            int i = 0;
            for (i = n; i > -1; i--)
            {
                switch (liczbaGraczy)
                {
                    case 2:
                        WinifMniej(gracz1, gracz1, ref i);
                        WinifMniej(gracz1, gracz2, ref i);
                        break;
                    case 3:
                        //WinifMniej to sposób na skrócenie kodu, który powtarza się
                        WinifMniej(gracz1, gracz1, ref i);
                        WinifMniej(gracz1, gracz2, ref i);
                        WinifMniej(gracz1, gracz3, ref i);
                        break;
                    case 4:
                        WinifMniej(gracz1, gracz1, ref i);
                        WinifMniej(gracz1, gracz2, ref i);
                        WinifMniej(gracz1, gracz3, ref i);
                        WinifMniej(gracz1, gracz4, ref i);
                        break;
                    case 5:
                        WinifMniej(gracz1, gracz1, ref i);
                        WinifMniej(gracz1, gracz2, ref i);
                        WinifMniej(gracz1, gracz3, ref i);
                        WinifMniej(gracz1, gracz4, ref i);
                        WinifMniej(gracz1, gracz5, ref i);
                        break;
                    case 6:
                        WinifMniej(gracz1, gracz1, ref i);
                        WinifMniej(gracz1, gracz2, ref i);
                        WinifMniej(gracz1, gracz3, ref i);
                        WinifMniej(gracz1, gracz4, ref i);
                        WinifMniej(gracz1, gracz5, ref i);
                        WinifMniej(gracz1, gracz6, ref i);
                        break;
                    default:
                        break;
                }

            }
            n = 0;
        }

        //Skrócenie kodu
        public static void WinifMniej(Gracz gracz1, Gracz gracz2, ref int i)
        {
            if (gracz2.naStole.Count > 1)
            { gracz1.wRece.Enqueue(gracz2.naStole[i]); gracz2.naStole.RemoveAt(i); }
            else if (gracz2.naStole.Count == 1)
            { gracz1.wRece.Enqueue(gracz2.naStole[0]); gracz2.naStole.RemoveAt(0); }
            else { }
        }

        //Również skrócenie kodu
        public static void WinIfMniejWojna(Gracz gracz1, Gracz gracz2)
        {
            if (gracz2.naStole.Count > 0)
            {
                gracz1.wRece.Enqueue(gracz2.naStole[0]);
                gracz2.naStole.RemoveAt(0);
            }
            else { }
        }

        //Przydzielenie kart graczowi po wygranej wojnie. Zwraca uwagę na to, że gracze biorący udział w wojnie mają więcej kart na stole
        public static void WinWojna(int liczbaGraczy, int ilewygranych, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6, ref int n, ref int y, ref int a) //Metoda przydziela karty wygranemu graczowi
        {
            switch (liczbaGraczy)
            {
                case 2:
                    for (int i = a; i >= 0; i--)
                    {
                        gracz1.wRece.Enqueue(gracz1.naStole[0]);
                        gracz1.wRece.Enqueue(gracz2.naStole[0]);
                        gracz1.naStole.RemoveAt(0);
                        gracz2.naStole.RemoveAt(0);
                    }
                    n = 0;
                    y = 0;
                    a = 0;
                    break;
                case 3:
                    for (int i = a; i >= 0; i--)
                    {
                        gracz1.wRece.Enqueue(gracz1.naStole[0]);
                        gracz1.wRece.Enqueue(gracz2.naStole[0]);
                        gracz1.naStole.RemoveAt(0);
                        gracz2.naStole.RemoveAt(0);
                    }
                    WinIfMniejWojna(gracz1, gracz3);
                    n = 0;
                    y = 0;
                    a = 0;
                    break;
                case 4:
                    for (int i = a; i >= 0; i--)
                    {
                        gracz1.wRece.Enqueue(gracz1.naStole[0]);
                        gracz1.wRece.Enqueue(gracz2.naStole[0]);
                        gracz1.naStole.RemoveAt(0);
                        gracz2.naStole.RemoveAt(0);
                    }
                    WinIfMniejWojna(gracz1, gracz3);
                    WinIfMniejWojna(gracz1, gracz4);
                    n = 0;
                    y = 0;
                    a = 0;
                    break;
                case 5:
                    for (int i = a; i >= 0; i--)
                    {
                        gracz1.wRece.Enqueue(gracz1.naStole[0]);
                        gracz1.wRece.Enqueue(gracz2.naStole[0]);
                        gracz1.naStole.RemoveAt(0);
                        gracz2.naStole.RemoveAt(0);
                    }
                    WinIfMniejWojna(gracz1, gracz3);
                    WinIfMniejWojna(gracz1, gracz4);
                    WinIfMniejWojna(gracz1, gracz5);
                    n = 0;
                    y = 0;
                    a = 0;
                    break;
                case 6:
                    for (int i = a; i >= 0; i--)
                    {
                        gracz1.wRece.Enqueue(gracz1.naStole[0]);
                        gracz1.wRece.Enqueue(gracz2.naStole[0]);
                        gracz1.naStole.RemoveAt(0);
                        gracz2.naStole.RemoveAt(0);

                    }
                    WinIfMniejWojna(gracz1, gracz3);
                    WinIfMniejWojna(gracz1, gracz4);
                    WinIfMniejWojna(gracz1, gracz5);
                    WinIfMniejWojna(gracz1, gracz6);
                    n = 0;
                    y = 0;
                    a = 0;
                    break;
            }
        }

        //Powrót kart do ręki gracz w przypadku remisu
        public static void Koniec(Gracz gracz)
        {
            gracz.wRece.Enqueue(gracz.naStole[0]);
            gracz.naStole.RemoveAt(0);
        }

        //Powrót kart do rąk graczy ---- || ------
        public static void Koniec(int liczbaGraczy, Gracz gracz1, Gracz gracz2, Gracz gracz3, Gracz gracz4, Gracz gracz5, Gracz gracz6)
        {
            if (gracz1.naStole.Count > 0)
            {
                gracz1.wRece.Enqueue(gracz1.naStole[0]);
                gracz1.naStole.RemoveAt(0);
            }
            if (gracz2.naStole.Count > 0)
            {
                gracz2.wRece.Enqueue(gracz2.naStole[0]);
                gracz2.naStole.RemoveAt(0);
            }
            if (gracz3.naStole.Count > 0 && liczbaGraczy > 2)
            {
                gracz3.wRece.Enqueue(gracz3.naStole[0]);
                gracz3.naStole.RemoveAt(0);
            }
            if (gracz4.naStole.Count > 0 && liczbaGraczy > 3)
            {
                gracz4.wRece.Enqueue(gracz4.naStole[0]);
                gracz4.naStole.RemoveAt(0);
            }
            else { }
            if (gracz5.naStole.Count > 0 && liczbaGraczy > 4)
            {
                gracz5.wRece.Enqueue(gracz5.naStole[0]);
                gracz5.naStole.RemoveAt(0);
            }
            else { }
            if (gracz6.naStole.Count > 0 && liczbaGraczy > 5)
            {
                gracz6.wRece.Enqueue(gracz6.naStole[0]);
                gracz6.naStole.RemoveAt(0);
            }
        }
    }
}