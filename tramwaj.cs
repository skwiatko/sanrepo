using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class Tramwaj : Pojazd
    {
        public ZajezdniaTramwajowa zaj;
        private int wagony;

        public int Wagony { get { return wagony; } set { wagony = value; } }

        public Tramwaj() { }
        public Tramwaj(int v, int num, int wag, ZajezdniaTramwajowa zajezd) : base(v, num)
        {
            wagony = wag;
            VMAX = v;
            Numer = num;
            zaj = zajezd;
        }

        public void WypiszOpis()
        {
            base.WypiszOpis(Numer, VMAX);
            Console.WriteLine("| Liczba wagonów: **{0}** | Zajezdnia: **{1}**", wagony, zaj.NazwaZaj);
        }

    }
}
