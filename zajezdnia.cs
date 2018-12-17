using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLab3
{
    class Zajezdnia
    {
        private String nazwa_zajezdni;
        private String typ;
        public List<ZajezdniaAutobusowa> zajAutobusowe = new List<ZajezdniaAutobusowa>();
        public List<ZajezdniaTramwajowa> zajTramwajowe = new List<ZajezdniaTramwajowa>();

        public String NazwaZaj { get { return nazwa_zajezdni; } set { nazwa_zajezdni = value; } }
        public String TYP { get { return typ; } set { typ = value; } }

        public Zajezdnia()  {        }

        public virtual void WypiszOpis()
        {
            Console.WriteLine("Nazwa zajezdni: {0}", nazwa_zajezdni);
        }

        public void WypiszAutobusowe()
        {
            int i=1;
            foreach (ZajezdniaAutobusowa aut in zajAutobusowe)
            {
                int n =1;
                n = n + i;
                Console.WriteLine(i+". "+aut.NazwaZaj);
                i++;
            }
        }

        public String WypiszNazweZajAut(int nr)
        {
            //nr--;
            return zajAutobusowe[nr].NazwaZaj;
        }

        


    }
}
