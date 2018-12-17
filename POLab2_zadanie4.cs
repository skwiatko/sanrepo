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
    class Ocena
    {
        private String nazwaPrzedmiotu;
        private String data;
        private double wartosc;

        public String nazwaP { get { return nazwaPrzedmiotu; } set { nazwaPrzedmiotu = value; } }
        public String DATA { get { return data; } set { data = value; } }
        public double WAR { get { return wartosc; } set { wartosc = value; } }

        public Ocena(String k_naz, String k_dat, double k_war)
        {
            nazwaPrzedmiotu = k_naz;
            data = k_dat;
            wartosc = k_war;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Ocena: {0} \t\t{1} \t{2}", nazwaPrzedmiotu, data, wartosc);
        }
    }

    class Student
    {
        private int rok;
        private int grupa;
        private int nrIndeksu;
        private String imie;
        private String nazwisko;
        private String DataUrodzenia;
        private List<Ocena> oceny = new List<Ocena>();

        public int R { get { return rok; } set { rok = value; } }
        public int G { get { return grupa; } set { grupa = value; } }
        public int NR { get { return nrIndeksu; } set { nrIndeksu = value; } }
        public String Imie { get { return imie; } set { imie = value; } }
        public String Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public String Data { get { return DataUrodzenia; } set { DataUrodzenia = value; } }

        public Student(String Im, String naz, String data, int k_rok, int k_grupa, int k_nr)
        {
            rok = k_rok;
            grupa = k_grupa;
            nrIndeksu = k_nr;
            imie = Im;
            nazwisko = naz;
            DataUrodzenia = data;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Imie: \t\t\t\t{0}", imie);
            Console.WriteLine("Nazwisko: \t\t\t{0}", nazwisko);
            Console.WriteLine("Data urodzenia: \t\t{0}", DataUrodzenia);
            Console.WriteLine("Rok: \t\t\t\t{0}\nGrupa: \t\t\t\t{1}\nNr Indeksu: \t\t\t{2}", rok, grupa, nrIndeksu);
            WypiszOceny();
        }

        public void DodajOcene(String nazwaPrzedmiotu, String data, double wartosc)
        {
            oceny.Add(new Ocena(nazwaPrzedmiotu, data, wartosc));

            //Ocena o = new Ocena(nazwaPrzedmiotu, data, wartosc);
            //oceny.Add(o);
        }

        public void WypiszOceny()
        {
            //Console.WriteLine(oceny);
            foreach (var ocena in oceny)
            {
                //Console.WriteLine("Ocena: {0} \t{1} \t{2}", ocena.nazwaP, ocena.DATA, ocena.WAR);
                ocena.WypiszInfo();
            }
        }

        public void WypiszOceny(String nazwaPrzedmiotu)
        {
            foreach (var przedmiot in oceny)
            {
                if (przedmiot.nazwaP == nazwaPrzedmiotu)
                {
                    Console.WriteLine("Ocena z przedmiotu {0}: {1}", przedmiot.nazwaP, przedmiot.WAR);
                }
            }
        }

        public void UsunOcene(String nazwaPrzedmiotu, String data, double wartosc)
        {
            //oceny.Remove(new Ocena(nazwaPrzedmiotu, data, wartosc));
            /*foreach (var przedmiot in oceny)
            {
                if (nazwaPrzedmiotu == przedmiot.nazwaP && data == przedmiot.DATA && wartosc == przedmiot.WAR)
                {
                    oceny.Remove(przedmiot);
                }
            }*/
            for (int i = 0; i < oceny.Count; i++)
            {
                if (nazwaPrzedmiotu == oceny[i].nazwaP && data == oceny[i].DATA && wartosc == oceny[i].WAR)
                {
                    oceny.RemoveAt(i);
                }
            }
        }

        public void UsunOceny()
        {
            oceny.Clear();
        }

        public void UsunOcene(String nazwaPrzedmiotu)
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                if (nazwaPrzedmiotu == oceny[i].nazwaP)
                {
                    oceny.RemoveAt(i);
                }
            }
        }
    }

    class Zadanie4_v1
    {
        public void Zad4_v1()
        {
            Student o1 = new Student("Panda", "Trzy", "01.01.2000", 3, 3, 33333);
            Student o2 = new Student("Beata", "Wiśniewska", "02.05.1997", 2, 1, 12345);

            Console.WriteLine("\n\nStudent 1:\n");

            o1.WypiszInfo();

            Console.WriteLine("\n\nStudent 2:\n");

            o2.WypiszInfo();

            Student o3 = new Student("Sylwester", "Kwiatkowski", "15.11.1992", 1, 2,
            432785);

            Console.WriteLine("\n\nStudent 3:\n");
            o3.WypiszInfo();

            ///zad 2
            o2.DodajOcene("Dyskretna", "20.02.2011", 5.0);
            o2.DodajOcene("Bazy Danych", "13.02.2011", 4.0);

            Console.WriteLine("\n\nStudent po dodaniu Dyskretnej i Baz:\n ");
            o2.WypiszInfo();

            o3.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            o3.DodajOcene("Programowanie", "11.05.2011", 5.0);
            o3.DodajOcene("Programowanie", "02.04.2011", 4.5);

            Console.WriteLine("\n\nStudent po dodaniu bazy, programowanie x2:\n ");
            o3.WypiszInfo();

            o3.UsunOcene("Programowanie", "02.04.2011", 4.5);

            Console.WriteLine("\n\nStudent po usunieciu Programowanie 02.04.2011 4.5 : \n");
            o3.WypiszInfo();

            o3.DodajOcene("Programowanie", "11.04.2011", 3);

            Console.WriteLine("\n\nStudent po wypisaniu wszystkich Programowanie (Dodano ponownie)\n");
            o3.WypiszOceny("Programowanie");

            Console.WriteLine("\n\nStudent caly\n");
            o3.WypiszInfo();

            o3.DodajOcene("Programowanie", "02.05.2011", 4);

            Console.WriteLine("\n\nStudent po dodaniu Programowanie (po raz 3)\n");
            o3.WypiszOceny();

            Console.WriteLine("\n\nStudent caly\n");
            o3.WypiszInfo();

            Console.ReadKey();
        }
    }
}