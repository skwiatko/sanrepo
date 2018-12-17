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
    enum Woj
    {
        Mazowieckie,
        Podkarpackie,
        Małopolskie,
        Opolskie,
    }
    class Panstwo
    {
        public Woj Wojewodztwa;

        public Panstwo()
        { }

    }

    class Zadanie3
    {
        public void Zad3()
        {
            Panstwo p = new Panstwo();
            Woj obecne = Woj.Mazowieckie;
            p.Wojewodztwa = Woj.Małopolskie;

            Console.WriteLine(obecne);
            Console.WriteLine(p.Wojewodztwa);

            Console.ReadLine();
        }
    }
}