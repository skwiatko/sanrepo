using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class ZajezdniaAutobusowa : Zajezdnia
    {
        private List<Autobus> Lista_autobusow = new List<Autobus>();

        public ZajezdniaAutobusowa(String nazwa, String typ)
        {
            NazwaZaj = nazwa;
            TYP = typ;
        }

        public List<Autobus> AUTOBUSY
        {
            get { return Lista_autobusow; }
            set { Lista_autobusow = value; }
        }

        public void WypiszAutobusy()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------LISTA AUTOBUSÓW----------");
            foreach (Autobus aut in Lista_autobusow)
            {
                Console.WriteLine("----------------------------------");
                //Console.WriteLine("Numer autobusu: \t\t{0} \nPrędkość maksymalna:\t\t{1}\nZużycie paliwa: \t\t{2}", aut.Numer, aut.VMAX, aut.Zuzycie);
                aut.WypiszOpis();
            }
            Console.WriteLine("----------------------------------");
        }

        public void SumaZuzycia()
        {
            int suma = 0;
            foreach (Autobus aut in Lista_autobusow)
            {
                suma += aut.Zuzycie;
            }
            Console.WriteLine("Sumaryczne zużycie paliwa przez wszystkie autobusy: " + suma);
        }

        public override void WypiszOpis()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-------" + NazwaZaj + "-------");
            Console.WriteLine("-------Typ: " + TYP + "-------");
            WypiszAutobusy();
            SumaZuzycia();
        }
    }
}
