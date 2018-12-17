using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    abstract class Pojazd
    {
        private int vmax;
        private int numer;
        //pojazdem moze byc rowniez samochod, wiec zajezdnia przydzielana jest dopiero dla poszczegolnych pojazdow

        public int VMAX { get { return vmax; } set { vmax = value; } }
        public int Numer { get { return numer; } set { numer = value; } }

        public Pojazd() { }

        public Pojazd(int v, int num)
        {
            vmax = v;
            numer = num;
        }

        public void WypiszOpis(int numer, int vmax)
        {
            Console.Write("Numer pojazdu: **{0}** | Prędkość maksymalna: **{1}**", numer, vmax);
        }
    }
}
