using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class Autobus : Pojazd
    {
        public ZajezdniaAutobusowa zaj;
        private int zuzyciePaliwa;

        public int Zuzycie { get { return zuzyciePaliwa; } set { zuzyciePaliwa = value; } }

        public Autobus() { }
        public Autobus(int v, int num, int zuz, ZajezdniaAutobusowa zajezd) : base(v, num)
        {
            VMAX = v;
            Numer = num;
            zuzyciePaliwa = zuz;
            zaj = zajezd;
        }

        public void WypiszOpis()
        {
            base.WypiszOpis(Numer, VMAX);
            Console.WriteLine("| Zużycie paliwa: **{0}** | Zajezdnia: **{1}**", Zuzycie, zaj.NazwaZaj);
        }
    }
}