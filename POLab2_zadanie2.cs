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
    class Osoba_zad2
    {
        public static int Zwieksz(ref int pr)
        {
            pr++;
            return pr;
        }
    }

    class Zadanie2
    {
        public void Zad2()
        {
            int praca = 5;

            Console.WriteLine("Praca: {0}\nZwiekszona: {1}", praca, Osoba_zad2.Zwieksz(ref praca));
            Console.WriteLine("Praca: {0}", praca);

            Console.ReadLine();
        }
    }
}
