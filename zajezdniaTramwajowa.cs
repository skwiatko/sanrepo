using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class ZajezdniaTramwajowa : Zajezdnia
    {
        public List<Tramwaj> Lista_tramwajow = new List<Tramwaj>();

        public ZajezdniaTramwajowa(String nazwa, String typ)
        {
            NazwaZaj = nazwa;
            TYP = typ;
        }

        public List<Tramwaj> TRAMWAJE
        {
            get { return Lista_tramwajow; }
            set { Lista_tramwajow = value; }
        }

        public void WypiszTramwaje()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------LISTA TRAMWAJÓW----------");
            foreach (Tramwaj tram in Lista_tramwajow)
            {
                Console.WriteLine("----------------------------------");
                //Console.WriteLine("Numer tramwaju: \t\t{0} \nPrędkość maksymalna:\t\t{1}\nLiczba wagonów: \t\t{2}", tram.Numer, tram.VMAX, tram.Wagony);
                tram.WypiszOpis();
            }
            Console.WriteLine("----------------------------------");
        }

        public void SumaWagonow()
        {
            int suma = 0;
            foreach (Tramwaj tram in Lista_tramwajow)
            {
                suma += tram.Wagony;
            }
            Console.WriteLine("Sumaryczne liczba wagonów wszystkich tramwajów: " + suma);
        }

        public override void WypiszOpis()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-------" + NazwaZaj + "-------");
            Console.WriteLine("-------Typ: " + TYP + "-------");
            WypiszTramwaje();
            SumaWagonow();
        }
    }
}
